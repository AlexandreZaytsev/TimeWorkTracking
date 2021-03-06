using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace TimeWorkTracking
{
    public partial class frmReport : Form
    {
        private readonly clCalendar pCalendar;          //класс производственный календаоь

        private DataTable dtSpecialMarks;               //специальные отметки
        private DataTable usersData;                    //информация о пользователях               
        private DataTable totalReportData;              //сводные данные о проходах за период               

        private DateTime firstDayRange;                 //первый день диапазона  
        private DateTime lastDayRange;                  //последний день диапазона
        private int lengthRangeDays;                    //длина диапазона дат 
        bool updateCalendar = false;                    //отключение события календаря

        private Excel.Application xlsApp = null;            //Excel Application
        private Excel.Workbook xlsBook = null;              //Excel WorkBook             
        private Excel.Worksheet xlsSheet = null;            //Excel WorkSheet
        private Excel.Range xlsRange = null;                //Excel Range
        private Excel.Style xlsStyle = null;                //Excel Style
        private Excel.FormatCondition xlsFormatCond = null; //Excel FormatCondition
        private Excel.ListObject xlsSmartTable = null;      //Excel SmartTable
        private Excel.Databar xlsDatabar;                   //Excel Databar итоговые формулы в умной таблице
        private Excel.PivotTable xlsPivotTable = null;      //Excel PivotTable Сводная таблица
        private Excel.PivotFields xlsPivotFields = null;
        private Excel.PivotField xlsPivotField = null;
        private Excel.ColorScale xlsColor = null;           //Excel ColorScale
                                                            //        private Excel.XlBorderWeight brdWeight = null;      //Excel BorderWeight
        private Excel.Chart xlsChart = null;                //Excel Chart Диаграмма

        readonly object mis = Type.Missing;

        private Dictionary<string, int> headerIndex;    //индесы колонок для отчета;
        private string[,] captionData;                  //массив данных заголовка Excel
        private string[,] tableData;                    //массив данных таблицы Excel

        public frmReport()
        {
            //подписка события внешних форм 
            CallBack_FrmMain_outEvent.callbackEventHandler = new CallBack_FrmMain_outEvent.callbackEvent(this.CallbackReload);    //subscribe (listen) to the general notification
            InitializeComponent();
            pCalendar = new clCalendar();               //создать экземпляр класса Производственный календарь
        }

        /// <summary>
        /// загрузка формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmReport_Load(object sender, EventArgs e)
        {
            if (!clSystemSet.checkProvider()) this.Close();
            string cs = Properties.Settings.Default.twtConnectionSrting;    //connection string
            if (CheckConnects())                                            //проверить соединение с базой данных SQL
            {
                getRangeFromType();     //вычислить границы диапазона в зависимости от типа формы
                updateRange();          //проверка использования диапазона дат по умолчанию

                //производственный календарь
                pCalendar.uploadCalendar(cs, "Select * From twt_GetDateInfo('', '') order by dWork");   //прочитаем данные производственного календаря
                LoadBoldedDatesCalendar(pCalendar.getListWorkHoliday());                                //Загрузить производственный календарь в массив непериодических выделенных дат

                //Загрузить массив данных для таблицы Excel
                usersData = clMsSqlDatabase.TableRequest(cs, "select * from twt_GetUserInfo('') where access=1 order by fio");

                //Загрузить массив специальных отметок для таблицы Excel
                //dtSpecialMarks = clMsSqlDatabase.TableRequest(cs, "select * from SpecialMarks where uses=1");
            }
        }

        #region//Работа с Календарем

        /// <summary>
        /// проверить соединение с базами
        /// </summary>
        /// <returns></returns>
        private bool CheckConnects()
        {
            //проверка соединения с SQL
            string cs = Properties.Settings.Default.twtConnectionSrting;    //connection string
            bool conSQL = clMsSqlDatabase.sqlConnectSimple(cs);
            mainPanelReport.Enabled = conSQL;
            return conSQL;
        }

        /// <summary>
        /// Загрузить Производственный календарь Data из DataSet в Calendar (Data из DataSet в ListView)
        /// </summary>
        /// <param name="dList"></param>
        private void LoadBoldedDatesCalendar(List<DateTime> dList)
        {
            mcReport.RemoveAllBoldedDates();                           //Сбросить все непериодические даты
            foreach (DateTime dt in dList)
            {
                mcReport.AddBoldedDate(dt);
            }
            mcReport.UpdateBoldedDates();
        }

        /// <summary>
        /// событие изменение даты календаря
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mcReport_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (updateCalendar)         //проверка чтобы не срабатывало два раза
            {
                getRangeFromType();     //вычислить границы диапазона в зависимости от типа формы
                updateRange();          //проверка использования диапазона дат по умолчанию
                                        //                uploadCaptionExel((int)(mcReport.SelectionRange.End - mcReport.SelectionRange.Start).TotalDays + 1);
            }
        }

        /// <summary>
        /// обновить длину диапазона при изменении
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mcReport_DateSelected(object sender, DateRangeEventArgs e)
        {
            //            uploadCaptionExel((int)(mcReport.SelectionRange.End - mcReport.SelectionRange.Start).TotalDays + 1);
        }

        /// <summary>
        /// вычислить границы диапазона (неделя или месяц) в зависимости от типа формы
        /// </summary>
        private void getRangeFromType()
        {
            DateTime dt = mcReport.SelectionStart;
            switch (this.AccessibleName)
            {
                case "FormHeatCheck":
                case "FormTimeCheck":
                    firstDayRange = dt.FirstDayOfWeek();
                    lastDayRange = firstDayRange.AddDays(6);
                    lengthRangeDays = Properties.Settings.Default.daysInWorkWeek;// 7;// 5;
                    break;
                case "ReportTotal":
                    firstDayRange = dt.FirstDayOfMonth();
                    lastDayRange = dt.LastDayOfMonth();
                    lengthRangeDays = dt.DaysInMonth();
                    break;
            }
        }

        /// <summary>
        /// обновить (перерисовать) диапазон в зависимости от текущей даты
        /// </summary>
        private void updateRange()
        {
            mcReport.MaxSelectionCount = chRange.Checked ? lengthRangeDays : 365;   //!!!Обязательно задать вначале (инача будет резать диапазон)
            updateCalendar = false;
            if (chRange.Checked)
                //            mcReport.SetSelectionRange(firstDayRange, lastDayRange);
                mcReport.SetSelectionRange(firstDayRange, firstDayRange.AddDays(mcReport.MaxSelectionCount - 1));
            //            mcReport.Select();
            updateCalendar = true;
        }

        /// <summary>
        /// проверка флага использования диапазона дат по умолчанию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chRange_CheckedChanged(object sender, EventArgs e)
        {
            getRangeFromType();     //вычислить границы диапазона в зависимости от типа формы
            updateRange();          //проверка использования диапазона дат по умолчанию
        }

        #endregion

        #region//Подготовка данных для отчетов

        /// <summary>
        /// Загрузить массив данных для заголовка Excel (с учетом объединенных ячеек - спользуем первое значение)
        /// </summary>
        /// <param name="lengthDays">длина диапазона дат</param>
        /// <param name="name">наименование области данных</param>
        /// <returns></returns>
        private int uploadCaptionExcel(int lengthDays, string name)
        {
            DateTime tDate;
            captionData = null;
            int j = 2;
            switch (name)// this.AccessibleName)
            {
                case "FormHeatCheck":
                    captionData = new string[2, lengthDays * 2 + 2];  //Создаём новый двумерный массив
                    captionData[0, 0] = "№";
                    captionData[0, 1] = "Фамилия Имя Отчество";
                    for (int i = 0; i < lengthDays; i++)           //циклом перебираем даты в созданный двумерный массив
                    {
                        tDate = mcReport.SelectionStart.AddDays(i);
                        captionData[0, i + j] = tDate.ToString("dddd\r\ndd MMMM yyyy г.");
                        captionData[1, i + j] = pCalendar.getDateDescription(tDate);
                        j += 1;
                    }
                    break;
                case "FormTimeCheck":
                    captionData = new string[4, lengthDays * 2 + 2];  //Создаём новый двумерный массив
                    captionData[0, 0] = "№";
                    captionData[0, 1] = "Фамилия Имя Отчество";
                    for (int i = 0; i < lengthDays; i++)           //циклом перебираем даты в созданный двумерный массив
                    {
                        tDate = mcReport.SelectionStart.AddDays(i);
                        captionData[0, i + j] = tDate.ToString("dddd\r\ndd MMMM yyyy г.");
                        captionData[1, i + j] = pCalendar.getDateDescription(tDate);
                        captionData[2, i + j] = "Пришел";
                        captionData[2, i + 1 + j] = "Ушел";
                        captionData[3, i + j] = "Специальные отметки";
                        j += 1;
                    }
                    break;
                case "ReportTotal_Report":    //"ReportTotal":
                    headerIndex = new Dictionary<string, int>();    //подготовим словарь для хранения индексов колонок
                    captionData = new string[1, lengthDays + 2 + 3 + dtSpecialMarks.Rows.Count - 1 + 2 + 1];  //Создаём новый двумерный массив
                    captionData[0, 0] = "№";
                    captionData[0, 0 + 1] = "Фамилия Имя Отчество";
                    string pad = new String(' ', 7);
                    for (int i = 0; i < lengthDays; i++)            //циклом перебираем даты в созданный двумерный массив
                    {
                        tDate = mcReport.SelectionStart.AddDays(i);
                        captionData[0, i + 2] =
                            pad + tDate.ToString("dd.MM.yyyy dddd") + "\r\n\r\n" +
                            pad + pCalendar.getDateDescription(tDate);
                    }
                    captionData[0, lengthDays + 1 + 1] = pad + "недоработка";
                    headerIndex.Add("less", lengthDays + 1 + 1);
                    captionData[0, lengthDays + 1 + 2] = pad + "+(Я) Итого отработано";
                    headerIndex.Add("Я", lengthDays + 1 + 2);                                   //добавить значение словаря заголока      
                    captionData[0, lengthDays + 1 + 3] = pad + "переработка";
                    headerIndex.Add("over", lengthDays + 1 + 3);
                    int col = 1;
                    for (int i = 0; i < dtSpecialMarks.Rows.Count; i++)                          //Цикл по массиву спец отметок
                    {
                        DataRow drow = dtSpecialMarks.Rows[i];
                        if (drow.RowState != DataRowState.Deleted)                              //Only row that have not been deleted
                        {
                            if (drow["letterCode"].ToString() != "Я")
                            {
                                headerIndex.Add(drow["letterCode"].ToString(), lengthDays + 4 + col); //добавить значение словаря заголока
                                captionData[0, lengthDays + 4 + col] = pad +
                                    "+(" + drow["letterCode"].ToString() + ") " +
                                    drow["name"].ToString().Wrap(20, "\r\n" + pad);             //используем wrap перенос по словам
                                col++;
                            }
                        }
                    }
                    captionData[0, lengthDays + 3 + dtSpecialMarks.Rows.Count + 1] = pad + "Итого спец. отметок";
                    headerIndex.Add("sum", lengthDays + 3 + dtSpecialMarks.Rows.Count + 1);
                    captionData[0, lengthDays + 3 + dtSpecialMarks.Rows.Count + 2] = pad + "(из них вне графика)";
                    headerIndex.Add("ext", lengthDays + 3 + dtSpecialMarks.Rows.Count + 2);
                    captionData[0, lengthDays + 3 + dtSpecialMarks.Rows.Count + 3] = "Сумма фактически отработаного РАБОЧЕГО ВРЕМЕНИ + CЛУЖЕБНЫЕ ЗАДАНИЯ задания вне его";
                    headerIndex.Add("total", lengthDays + 3 + dtSpecialMarks.Rows.Count + 3);
                    break;
                case "ReportTotal_Time":    //"ReportTotal":
                    captionData = new string[3, lengthDays * 2 + 3];  //Создаём новый двумерный массив
                    captionData[0, 0] = "№";
                    captionData[0, 1] = "Фамилия Имя Отчество";
                    captionData[0, 2] = "временной провайдер";
                    j = 3;
                    for (int i = 0; i < lengthDays; i++)           //циклом перебираем даты в созданный двумерный массив
                    {
                        tDate = mcReport.SelectionStart.AddDays(i);
                        captionData[0, i + j] = tDate.ToString("dddd\r\ndd/MM/yyyy г.");
                        captionData[1, i + j] = pCalendar.getDateDescription(tDate);
                        captionData[2, i + j] = "Пришел";
                        captionData[2, i + 1 + j] = "Ушел";
                        j += 1;
                    }
                    break;
            }
            return captionData.GetUpperBound(1);
        }

        /// <summary>
        /// Загрузить массив данных для таблицы Excel (с учетом объединенных ячеек - спользуем первое значение)
        /// </summary>
        /// <param name="lenDays"></param>
        /// <param name="name">наименование области данных</param>
        /// <returns></returns>
        private int uploadTableExcel(int lenDays, string name)
        {
            int j;// = 0;
            switch (name)// this.AccessibleName)
            {
                case "FormHeatCheck":
                    tableData = new string[usersData.Rows.Count, 2];   //Создаём новый двумерный массив
                    for (int i = 0; i < usersData.Rows.Count; i++)     // Display items in the ListView control
                    {
                        DataRow drow = usersData.Rows[i];
                        if (drow.RowState != DataRowState.Deleted)  // Only row that have not been deleted
                        {
                            tableData[i, 0] = (i + 1).ToString();
                            tableData[i, 1] = drow["fio"].ToString();
                        }
                    }
                    break;
                case "FormTimeCheck":
                    tableData = new string[usersData.Rows.Count * 2, lenDays + 1];   //Создаём новый двумерный массив
                    j = 0;
                    for (int i = 0; i < usersData.Rows.Count; i++)     // Display items in the ListView control
                    {
                        DataRow drow = usersData.Rows[i];
                        if (drow.RowState != DataRowState.Deleted)  // Only row that have not been deleted
                        {
                            tableData[i + j, 0] = (i + 1).ToString();
                            tableData[i + j, 1] = drow["fio"].ToString();
                            for (int col = 0; col < lenDays - 1; col += 2)
                            {
                                tableData[i + j, 2 + col] = Convert.ToDateTime(drow["startTime"]).ToString("HH:mm");
                                tableData[i + j, 3 + col] = Convert.ToDateTime(drow["stopTime"]).ToString("HH:mm");
                            }
                            j += 1;
                        }
                    }
                    break;
                case "ReportTotal_Report":    //ReportTotal":
                    string cs = Properties.Settings.Default.twtConnectionSrting;    //connection string
                    //Загрузить массив сводных данных для тотального
                    totalReportData = clMsSqlDatabase.TableRequest(cs, "EXEC twt_TotalReport '" + mcReport.SelectionStart.ToString("yyyyMMdd") + "','" + mcReport.SelectionEnd.ToString("yyyyMMdd") + "', 0");
                    tableData = new string[totalReportData.Rows.Count * 2, 2 + lenDays + 3 + dtSpecialMarks.Rows.Count - 1 + 2 + 1];   //Создаём новый двумерный массив
                    //var tableData = new[,];//[totalReportData.Rows.Count * 2, 2 + lenDays + 3 + dtSpecialMarks.Rows.Count - 1 + 2 + 1];

                    //string[] splitValue = new string[5];                            //шесть параметров упакованных в день
                    double timeScheduleLess;                                        //время недоработки    
                    double timeScheduleOver;                                        //время переработки
                    string specmarkName;                                            //короткое имя спец отметки    
                    double specmarkValue;                                           //переменная для хранения текущего значения спец отметки    
                    double tmpValue;                                                //временная переменная
                    string formatName = "N8";// "F8";                               //формат строки для преобразований
                                             // int stop;
                    j = 0;
                    for (int i = 0; i < totalReportData.Rows.Count; i++)            //Цикл по строкам отчета
                    {
                        DataRow drow = totalReportData.Rows[i];
                        if (drow.RowState != DataRowState.Deleted)                  // Only row that have not been deleted
                        {
                            tableData[i + j, 0] = (i + 1).ToString();
                            tableData[i + j + 1, 0] = (i + 1).ToString();

                            tableData[i + j, 1] = drow[1].ToString();               //должность (первая строка)
                            tableData[i + j + 1, 1] = drow[0].ToString();           //фио (вторая строка)
                            //specmarkValue = 0;
                            //tmpValue = 0;
                            //specmarkName = "";
                            for (int col = 0; col < lenDays - 1; col++)             //Цикл по колонкам календаря отчета
                            {
                                if (drow[4 + col] != System.DBNull.Value)           //Если данные для обработки на дату есть 
                                {
                                    //РАБОТАЕМ СО СТРОКАМИ - ОБЯЗАТЕЛЬНОЕ ФОРМАТИРОВАНИЕ В КУЛЬТУРЕ + 8 ДЕСЯТИЧНЫХ ЗНАКОВ (см. ниже проблемы вставки в EXCEL) 

                                    //распакуем пришедшие данные в массив
                                    string[] splitValue = drow[4 + col].ToString().Substring(1, drow[4 + col].ToString().Length - 2).Split(new[] { "|" }, StringSplitOptions.None);

                                    //ИМЯ И ЗНАЧЕНИЕ СПЕЦОТМЕТКИ В ДАТЕ
                                    //Спецотметка (короткое имя) (первая строка)
                                    specmarkName = splitValue[3];
                                    tableData[i + j, 2 + col] = specmarkName;
                                    //Текущее значение спецотметки
                                    specmarkValue = (Convert.ToDouble(splitValue[0]) / 60);
                                    //Корректировка значений спец отметок
                                    switch (specmarkName)
                                    {
                                        case "УДЛ":
                                            specmarkValue = 0;
                                            break;
                                    }
                                    //Спецотметка (значение) (вторая строка)
                                    tableData[i + j + 1, 2 + col] = specmarkValue.ToString(formatName, CultureInfo.InvariantCulture);

                                    //Корректировка недоработки переработки для спецотметки "Я"
                                    switch (specmarkName)
                                    {
                                        case "Я":
                                            //вспомогательное время
                                            tmpValue = tableData[i + j + 1, headerIndex["less"]] == null ? 0 : Double.Parse(tableData[i + j + 1, headerIndex["less"]], CultureInfo.InvariantCulture);
                                            timeScheduleLess = tmpValue + (Convert.ToDouble(splitValue[1]) / 60);  //недоработка 
                                            tmpValue = tableData[i + j + 1, headerIndex["over"]] == null ? 0 : Double.Parse(tableData[i + j + 1, headerIndex["over"]], CultureInfo.InvariantCulture);
                                            timeScheduleOver = tmpValue + (Convert.ToDouble(splitValue[2]) / 60);  //переработка 

                                            //коррекция на +/-
                                            tmpValue = timeScheduleOver - timeScheduleLess;
                                            timeScheduleLess = tmpValue < 0 ? Math.Abs(tmpValue) : 0;
                                            timeScheduleOver = tmpValue < 0 ? 0 : Math.Abs(tmpValue);
                                            //недоработка (вторая строка)
                                            tableData[i + j + 1, headerIndex["less"]] = timeScheduleLess.ToString(formatName, CultureInfo.InvariantCulture);
                                            //переработка (вторая строка)
                                            tableData[i + j + 1, headerIndex["over"]] = timeScheduleOver.ToString(formatName, CultureInfo.InvariantCulture);
                                            break;
                                    }

                                    //ИМЯ И ЗНАЧЕНИЕ СПЕЦОТМЕТКИ В НАКОПИТЕЛЬНОЙ ЧАСТИ
                                    //Спецотметка (короткое имя) (первая строка)
                                    tableData[i + j, headerIndex[specmarkName]] = specmarkName;
                                    //Спецотметка (значение) (вторая строка)
                                    tmpValue = tableData[i + j + 1, headerIndex[specmarkName]] == null ? 0 : Double.Parse(tableData[i + j + 1, headerIndex[splitValue[3]]], CultureInfo.InvariantCulture);
                                    switch (specmarkName)
                                    {
                                        case "Я":                   //+ значение итого без обеда/60
                                            tmpValue += specmarkValue;
                                            break;
                                        case "УДЛ":
                                            tmpValue = 0;
                                            break;
                                        default:                    //+ значение итого в пределах рабочего дня/60 
                                            tmpValue += (Convert.ToDouble(splitValue[4]) / 60);
                                            break;
                                    }
                                    tableData[i + j + 1, headerIndex[specmarkName]] = tmpValue.ToString(formatName, CultureInfo.InvariantCulture);

                                    //время отработанное в пределах рабочего дня
                                    tmpValue = tableData[i + j + 1, headerIndex["sum"]] == null ? 0 : Double.Parse(tableData[i + j + 1, headerIndex["sum"]], CultureInfo.InvariantCulture);
                                    tmpValue += Convert.ToDouble(splitValue[4]) / 60;
                                    tableData[i + j + 1, headerIndex["sum"]] = tmpValue.ToString(formatName, CultureInfo.InvariantCulture);//CurrentCulture);

                                    //время отработанное вне пределов рабочего дня
                                    tmpValue = tableData[i + j + 1, headerIndex["ext"]] == null ? 0 : Double.Parse(tableData[i + j + 1, headerIndex["ext"]], CultureInfo.InvariantCulture);
                                    tmpValue += Convert.ToDouble(splitValue[5]) / 60;
                                    tableData[i + j + 1, headerIndex["ext"]] = tmpValue.ToString(formatName, CultureInfo.InvariantCulture);


                                    //Коррекция итогов 
                                    tmpValue = tableData[i + j, headerIndex["total"]] == null ? 0 : Double.Parse(tableData[i + j, headerIndex["total"]], CultureInfo.InvariantCulture);
                                    switch (specmarkName)
                                    {
                                        case "Я":       //добавим к итогам итоговое время
                                            tmpValue += specmarkValue;
                                            break;
                                        case "К":// "СЗ":      //добавим к итогам итоговое время + время отработанное вне пределов рабочего дня
                                            tmpValue = tmpValue + specmarkValue + (Convert.ToDouble(splitValue[5]) / 60);
                                            break;
                                    }
                                    if ((int)tmpValue != 0)
                                    {
                                        tableData[i + j, headerIndex["total"]] = tmpValue.ToString(formatName, CultureInfo.InvariantCulture);
                                        tableData[i + j + 1, headerIndex["total"]] = ((int)tmpValue).ToString() + " час " +
                                                                                     (Math.Round((tmpValue - (int)tmpValue) * 60)).ToString() + " мин";
                                    }
                                }
                            }
                            j += 1;
                        }
                    }
                    break;
                case "ReportTotal_Time":    //ReportTotal":
                    cs = Properties.Settings.Default.twtConnectionSrting;    //connection string
                    //Загрузить массив сводных данных для тотального
                    totalReportData = clMsSqlDatabase.TableRequest(cs, "EXEC twt_TotalReport '" + mcReport.SelectionStart.ToString("yyyyMMdd") + "','" + mcReport.SelectionEnd.ToString("yyyyMMdd") + "', 1");
                    tableData = new string[totalReportData.Rows.Count * 3, 3 + lenDays*2];   //Создаём новый двумерный массив

                    j = 0;
                    for (int i = 0; i < totalReportData.Rows.Count; i++)            //Цикл по строкам отчета
                    {
                        DataRow drow = totalReportData.Rows[i];
                        if (drow.RowState != DataRowState.Deleted)                  //Only row that have not been deleted
                        {
                            tableData[i + j, 0] = (i + 1).ToString();               //номер по порядку    
                            tableData[i + j, 1] = drow[0].ToString();               //фио
                            tableData[i + j + 0, 2] = "График";               
                            tableData[i + j + 1, 2] = "Регистратор";               
                            tableData[i + j + 2, 2] = "СКУД";

                            int c = 0;
                            for (int col = 0; col < lenDays ; col++)             //Цикл по колонкам календаря отчета
                            {
                                if (drow[4 + col] != System.DBNull.Value)           //Если данные для обработки на дату есть 
                                {
                                    //распакуем пришедшие данные в массив
                                    string[] splitValue = drow[4 + col].ToString().Substring(1, drow[4 + col].ToString().Length - 2).Split(new[] { "|" }, StringSplitOptions.None);
                                    tableData[i + j + 0, 3 + col + c] = splitValue[0];
                                    tableData[i + j + 0, 3 + col + c + 1] = splitValue[1];
                                    tableData[i + j + 1, 3 + col + c] = splitValue[2];
                                    tableData[i + j + 1, 3 + col + c + 1] = splitValue[3];
                                    tableData[i + j + 2, 3 + col + c] = splitValue[4];
                                    tableData[i + j + 2, 3 + col + c + 1] = splitValue[5];

                                }
                                c += 1;
                            }
                            j += 2;
                        }
                    }
                    break;
                case "ReportTotal_Pass":    //ReportTotal":
                    cs = Properties.Settings.Default.twtConnectionSrting;    //connection string
                    //Загрузить массив данных о проходах за период времени
                    totalReportData = clMsSqlDatabase.TableRequest(cs, 
                        "Select " +
                        "\r\n   passDate дата_прохода " +
                        "\r\n , fio фио " +
//                        "\r\n , userTimeIn время_входа " +
//                        "\r\n , userTimeOut время_выхода " +
                        "\r\n , noLunch без_обеда " +
                        "\r\n , workSchemeId почасовой_поминутный " +
                        "\r\n , specmarkLetter спец_отметка " +
                        "\r\n , timeScheduleFact минут_отработано_всего " +
                        "\r\n , timeScheduleWithoutLunch минут_без_обеда_и_сокращений " +
                        "\r\n , timeScheduleLess минут_недоработка " +
                        "\r\n , timeScheduleOver минут_переработка " +
                        "\r\n , totalHoursInWork минут_в_рабочее_время " +
                        "\r\n , totalHoursOutsideWork минут_вне_рабочего_времени " +
                        "from twt_GetPassFormDate('" + mcReport.SelectionStart.ToString("yyyyMMdd") + "','" + mcReport.SelectionEnd.ToString("yyyyMMdd") + "', '')");
                    break;
            }
            return usersData.Rows.Count;
        }

        #endregion

        #region//Отчеты

        /// <summary>
        /// кнопка напечатать бланк температуры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btFormHeatPrint_Click(object sender, EventArgs e)
        {
            toolStripStatusLabelInfo.Text = "";
            FormHeatPrint();
            /*
                        string msg =
                            "Журнал учета средней температуры по компании создан" + "\r\n" +
                            " (см. новый файл Excel)" + "\r\n" + "\r\n" +
                            "перейдите на него для печати документа" + "\r\n" +
                            "после чего закройте БЕЗ сохранения";
                        MessageBox.Show(msg, "Подготовка документов", MessageBoxButtons.OK, MessageBoxIcon.Information);
            */
            toolStripStatusLabelInfo.Text = "Выберите диапазон";
            System.Threading.Thread.Sleep(1000);    //пауза 1 сек
            this.Close();                           //закрыть форму
        }

        /// <summary>
        /// печать бланка температуры 
        /// </summary>
        /// <returns></returns>
        private bool FormHeatPrint()
        {
            Cursor.Current = Cursors.WaitCursor;
            bool ret;// = false;
            int daysCount = (int)(mcReport.SelectionRange.End - mcReport.SelectionRange.Start).TotalDays + 1;
            int arrCount = uploadCaptionExcel(daysCount, this.AccessibleName);  //FormHeatCheck загрузить данные заголовка      
            uploadTableExcel(arrCount, this.AccessibleName);                    //FormHeatCheck загрузить данные сотрудников из БД

            try
            {
                toolStripStatusLabelInfo.Text = "Подключение к Excel";
                //Объявляем приложение
                xlsApp = new Excel.Application
                {
                    Visible = false,                                            //Отобразить Excel
                    SheetsInNewWorkbook = 1                                     //Количество листов в рабочей книге    
                };
                xlsBook = xlsApp.Workbooks.Add(mis);                         //Добавить рабочую книгу

                toolStripStatusLabelInfo.Text = "Создание рабочей книги";
                //Настройки Application установить
                xlsApp.DisplayAlerts = false;                                 //Запретить отображение окон с сообщениями
                xlsApp.ScreenUpdating = false;                                //Запретить перерисовку экрана    
                xlsApp.ActiveWindow.Zoom = 80;                                //Масштаб листа
                xlsApp.ActiveWindow.View = Excel.XlWindowView.xlPageBreakPreview;

                //Переименовать лист
                xlsSheet = (Excel.Worksheet)xlsApp.Worksheets.get_Item(1);   //Получаем первый лист документа (счет начинается с 1)
                xlsSheet.Name = "Journal";                                     //Название листа (вкладки снизу)
                //RebuildSheet(workBook, "Journal", 3);                         // удалить все листы кроме текущего
                ((Excel.Range)xlsSheet.Cells).FormatConditions.Delete();       //удалить все форматы с листа

                //оформление листа и применение стиля
                xlsStyle = xlsBook.Styles.Add("reportStyle");
                xlsStyle.Font.Name = "Times New Roman";
                xlsStyle.Font.Size = 11;

                toolStripStatusLabelInfo.Text = "Настройка листа";
                //ширина колонок
                ((Excel.Range)xlsSheet.Cells).Style = "reportStyle";
                ((Excel.Range)xlsSheet.Columns[1]).ColumnWidth = 2;
                ((Excel.Range)xlsSheet.Columns[1 + 2 + captionData.GetUpperBound(1)]).EntireColumn.ColumnWidth = 2;

                toolStripStatusLabelInfo.Text = "Настройка границ листа";
                //настройки печати
                double interval = xlsApp.CentimetersToPoints(0.2);
                xlsSheet.PageSetup.LeftMargin = interval;
                xlsSheet.PageSetup.RightMargin = interval;
                xlsSheet.PageSetup.TopMargin = interval;
                xlsSheet.PageSetup.BottomMargin = interval;
                xlsSheet.PageSetup.HeaderMargin = 0;// xlsApp.InchesToPoints(0);
                xlsSheet.PageSetup.FooterMargin = interval;
                xlsSheet.PageSetup.PrintTitleRows = "$1:$7";                                      //печать заголовков на каждой странице
                xlsSheet.PageSetup.PrintTitleColumns = "";
                xlsSheet.PageSetup.FirstPageNumber = (int)Excel.Constants.xlAutomatic; //номер первой страници
                                                                                       //            workSheet.PageSetup.CenterFooter = "&B Страница &P";
                xlsSheet.PageSetup.LeftFooter = "&BДля служебного использования&B";
                xlsSheet.PageSetup.CenterFooter = "&D";
                xlsSheet.PageSetup.RightFooter = "Страница &P из &N";

                toolStripStatusLabelInfo.Text = "Настройка ориентации листа и ограничений";
                xlsSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
                xlsSheet.PageSetup.Zoom = 83;// false;                                       // 83; //% от натуральной величины
                                              //            workSheet.PageSetup.FitToPagesWide = 1;                                 //не более чем на количество страниц в ширину           
                                              //            workSheet.PageSetup.FitToPagesTall = 1;                                 //не более чем на количество страниц в высоту    

                //поехали
                toolStripStatusLabelInfo.Text = "Скрыть лишние строки";
                ((Excel.Range)xlsSheet.Rows[2]).EntireRow.Hidden = true;               //скрыть строку
                ((Excel.Range)xlsSheet.Rows[3]).EntireRow.Hidden = true;
                ((Excel.Range)xlsSheet.Rows[6]).EntireRow.Hidden = true;

                toolStripStatusLabelInfo.Text = "Создание заголовка";
                //диапазон для заголовка (главная надпись) (2 строки)
                xlsRange = xlsSheet.Range[xlsSheet.Cells[4, 2 - 1], xlsSheet.Cells[5, 2 + captionData.GetUpperBound(1) + 1]];
                xlsRange.Font.Name = "Times New Roman";
                xlsRange.Font.Size = 11;
                ((Excel.Range)xlsRange.Rows[1]).Merge(mis);                        //объединить строку диапазона
                ((Excel.Range)xlsRange.Rows[2]).Merge(mis);                        //объединить строку диапазона
                xlsRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                xlsRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                xlsRange.Font.Bold = true;
                xlsRange.Font.Name = "Times New Roman";
                xlsRange.Font.Size = 14;
                xlsRange.Cells[1, 1] = "Журнал учета средней температуры сотрудников " + Properties.Settings.Default.companyName;   //наименование компании
                xlsRange.Cells[2, 1] = "Период: " + mcReport.SelectionStart.ToString("dd.MM.yyyy") + " - " + mcReport.SelectionEnd.ToString("dd.MM.yyyy");

                toolStripStatusLabelInfo.Text = "Создание шапки таблицы и строки данных";
                //диапазон для шапки таблицы и первой строки данных (3 строки)
                xlsRange = xlsSheet.Range[xlsSheet.Cells[8, 2], xlsSheet.Cells[10, 1 + captionData.GetUpperBound(1) + 1]];    //+1 на строку данных
                                                                                                                                  //                ((Excel.Range)xlsRange.Rows).AutoFit();                                                    //автоувеличение строк в заголовке
                xlsRange.Font.Name = "Times New Roman";
                xlsRange.Font.Size = 11;
                xlsRange.Interior.TintAndShade = 0;// '0.2
                xlsRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                xlsRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                xlsRange.WrapText = true;
                xlsRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;               //нарисуем все рамки

                //настройка ширины колонок и высоты строк диапазона                                                                            
                ((Excel.Range)xlsRange.Rows[1]).RowHeight = 28.5;                          //высота первой строки 
                ((Excel.Range)xlsRange.Columns[1]).ColumnWidth = 3.5;                      //ширина колонки с номером
                ((Excel.Range)xlsRange.Columns[2]).ColumnWidth = 38.5;                     //ширина колонки ФИО 
                                                                                            //                ((Excel.Range)xlsRange.Rows[3]).RowHeight = 20;                          //высота строки данных
                string colsChar =
                NumberToLetters(((Excel.Range)xlsRange.Columns[3]).Column) + ":" +
                NumberToLetters(((Excel.Range)xlsRange.Columns[3 + daysCount * 2 - 1]).Column);
                ((Excel.Range)xlsSheet.Columns[colsChar]).ColumnWidth = 11.56; //ширина колонок с датами 
                                                                                //управление шрифтами и выравниванием
                ((Excel.Range)xlsRange.Rows[1]).Font.Bold = true;                          //первая строка шапки
                ((Excel.Range)xlsRange.Rows[2]).Font.Size = 9;                             //вторая строка шапки
                ((Excel.Range)xlsRange.Rows[3]).Font.Size = 11;                            //третья строка шапки (строка данных)
                ((Excel.Range)xlsSheet.Range[xlsRange.Cells[3, 3], xlsRange.Cells[3, xlsRange.Columns.Count]]).Font.Size = 16;
                ((Excel.Range)xlsRange.Range[xlsSheet.Cells[2, 1], xlsSheet.Cells[3, 2]]).Font.Bold = true;
                ((Excel.Range)xlsSheet.Range[xlsRange.Cells[2, 3], xlsRange.Cells[2, xlsRange.Columns.Count]]).VerticalAlignment = Excel.XlVAlign.xlVAlignTop;
                ((Excel.Range)xlsRange.Cells[3, 2]).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                //температуру влево с отступом
                ((Excel.Range)xlsSheet.Range[xlsRange.Cells[3, 3], xlsRange.Cells[3, xlsRange.Columns.Count]]).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                ((Excel.Range)xlsSheet.Range[xlsRange.Cells[3, 3], xlsRange.Cells[3, xlsRange.Columns.Count]]).IndentLevel = 2;

                //заливка цветом
                ((Excel.Range)xlsSheet.Range[xlsRange.Cells[1, 1], xlsRange.Cells[1, 2]]).Interior.Color = ColorTranslator.ToOle(Color.LightGray);   //заливка первой строки цветом
                ((Excel.Range)xlsSheet.Range[xlsRange.Cells[1, 3], xlsRange.Cells[1, xlsRange.Columns.Count]]).Interior.Color = ColorTranslator.ToOle(Color.LightGreen);
                ((Excel.Range)xlsSheet.Range[xlsRange.Cells[3, 3], xlsRange.Cells[3, xlsRange.Columns.Count]]).Font.Color = ColorTranslator.ToOle(Color.Gainsboro);//.WhiteSmoke);//.LightGray);
                                                                                                                                                                       //строка данных значения по умолчанию
                                                                                                                                                                       //xlsRange.Rows[3]= "36,3\u00B0";
                xlsRange.Rows[3] = String.Format("{0}°C", 36.3);
                //xlsRange.Cells[3, 3] = "36,3\u00B0";


                toolStripStatusLabelInfo.Text = "Вставка условного форматирования шапки таблицы";
                //условное форматирование диапазона 
                xlsFormatCond = (Excel.FormatCondition)((Excel.Range)xlsRange.Rows[1]).EntireRow.FormatConditions.
                    Add(Type: Excel.XlFormatConditionType.xlExpression, mis, Formula1: "=ЕЧИСЛО(НАЙТИ(\"Рабочий\";A9))", mis, mis, mis, mis, mis);

                xlsFormatCond.Interior.PatternColorIndex = Excel.Constants.xlAutomatic;
                xlsFormatCond.Interior.ThemeColor = Excel.XlThemeColor.xlThemeColorAccent3;
                //              fc.Interior.Color = ColorTranslator.ToWin32(Color.White);
                xlsFormatCond.Interior.TintAndShade = 0.599963377788629;
                xlsFormatCond.StopIfTrue = false;

                toolStripStatusLabelInfo.Text = "Настройка объединения ячеек";
                //объединение столбцов
                xlsSheet.Range[xlsRange.Cells[1, 1], xlsRange.Cells[2, 1]].Merge(mis);
                xlsSheet.Range[xlsRange.Cells[1, 2], xlsRange.Cells[2, 2]].Merge(mis);
                int j = 2;
                for (int i = 1; i <= captionData.GetUpperBound(1) / 2; i++)
                {
                    xlsSheet.Range[xlsRange.Cells[1, i + j], xlsRange.Cells[1, i + j + 1]].Merge(mis);
                    xlsSheet.Range[xlsRange.Cells[2, i + j], xlsRange.Cells[2, i + j + 1]].Merge(mis);
                    xlsSheet.Range[xlsRange.Cells[3, i + j], xlsRange.Cells[3, i + j + 1]].Merge(mis);
                    j += 1;
                }

                toolStripStatusLabelInfo.Text = "Вставка данных заголовка";
                //вставим данные в заголовок одним куском
                xlsRange.Resize[
                    captionData.GetUpperBound(0) + 1,
                    captionData.GetUpperBound(1) + 1
                    ].Value = captionData;

                //            string used = xlsRange.Address[false, false, Excel.XlReferenceStyle.xlA1, mis, mis];

                toolStripStatusLabelInfo.Text = "Вставка данных таблицы";
                //расширим форматированную таблицу данных
                xlsRange = tableResize(
                    xlsSheet,
                    (Excel.Range)xlsRange.Rows[3],//(Excel.Range)workSheet.Cells[xlsRange.Row + xlsRange.Rows.Count - 1, xlsRange.Column],
                    tableData.GetUpperBound(0) + 1
                    );
                //       fullTable.Value = tableData; 
                //подрежем таблицу до двух колонок (т.к. в пришедших данных их только две)
                //вставим данные в таблицу одним куском
                xlsRange.Resize[
                        tableData.GetUpperBound(0) + 1,
                        tableData.GetUpperBound(1) + 1
                        ].Value = tableData;

                toolStripStatusLabelInfo.Text = "Дополнительное форматирование";
                xlsRange.Rows.RowHeight = 22;  //восстановить высоту строк в диапазоне данных

                toolStripStatusLabelInfo.Text = "Файл подготовлен";
                //Настройки Application вернуть обратно
                xlsApp.DisplayAlerts = true;                                  //Разрешить отображение окон с сообщениями
                xlsApp.ScreenUpdating = true;                                 //Зазрешить перерисовку экрана    
                xlsApp.Visible = true;
                //            xlsApp.WindowState = Excel.XlWindowState.xlMinimized;         //Свернуть окно   
                //            xlsApp.Quit();
            }
            finally
            {
                if (xlsStyle != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsStyle);
                if (xlsFormatCond != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsFormatCond);
                if (xlsRange != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsRange);
                if (xlsSheet != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsSheet);
                if (xlsBook != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsBook);

                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsApp);
            }

            Cursor.Current = Cursors.Default;
            ret = true;

            return ret;
        }

        /// <summary>
        /// кнопка напечатать бланк проходов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btFormTimePrint_Click(object sender, EventArgs e)
        {
            toolStripStatusLabelInfo.Text = "";
            FormTimePrint();
            /*
                        string msg =
                            "Журнал учета рабочего времени создан" + "\r\n" +
                            " (см. новый файл Excel)" + "\r\n" + "\r\n" +
                            "перейдите на него для печати документа" + "\r\n" +
                            "после чего закройте БЕЗ сохранения";
                        MessageBox.Show(msg, "Подготовка документов", MessageBoxButtons.OK, MessageBoxIcon.Information);
            */
            toolStripStatusLabelInfo.Text = "Выберите диапазон";
            System.Threading.Thread.Sleep(1000);    //пауза 1 сек
            this.Close();                           //закрыть форму
        }

        /// <summary>
        /// печать бланка проходов
        /// </summary>
        /// <returns></returns>
        private bool FormTimePrint()
        {
            Cursor.Current = Cursors.WaitCursor;
            bool ret;// = false;
            int daysCount = (int)(mcReport.SelectionRange.End - mcReport.SelectionRange.Start).TotalDays + 1;
            int arrCount = uploadCaptionExcel(daysCount, this.AccessibleName);  //FormTimeCheck загрузить данные заголовка
            uploadTableExcel(arrCount, this.AccessibleName);                    //FormTimeCheck загрузить данные сотрудников из БД

            try
            {
                toolStripStatusLabelInfo.Text = "Подключение к Excel";
                //Объявляем приложение
                xlsApp = new Excel.Application
                {
                    Visible = false,                                            //Отобразить Excel
                    SheetsInNewWorkbook = 1                                     //Количество листов в рабочей книге    
                };
                xlsBook = xlsApp.Workbooks.Add(mis);                         //Добавить рабочую книгу

                toolStripStatusLabelInfo.Text = "Создание рабочей книги";
                //Настройки Application установить
                xlsApp.DisplayAlerts = false;                                 //Запретить отображение окон с сообщениями
                xlsApp.ScreenUpdating = false;                                //Запретить перерисовку экрана    
                xlsApp.ActiveWindow.Zoom = 80;                                //Масштаб листа
                xlsApp.ActiveWindow.View = Excel.XlWindowView.xlPageBreakPreview;

                //Переименовать лист
                xlsSheet = (Excel.Worksheet)xlsApp.Worksheets.get_Item(1);   //Получаем первый лист документа (счет начинается с 1)
                xlsSheet.Name = "Journal";                                     //Название листа (вкладки снизу)
                //RebuildSheet(workBook, "Journal", 3);                         // удалить все листы кроме текущего
                ((Excel.Range)xlsSheet.Cells).FormatConditions.Delete();       //удалить все форматы с листа

                //оформление листа и применение стиля
                xlsStyle = xlsBook.Styles.Add("reportStyle");
                xlsStyle.Font.Name = "Times New Roman";
                xlsStyle.Font.Size = 11;

                toolStripStatusLabelInfo.Text = "Настройка листа";
                //ширина колонок
                ((Excel.Range)xlsSheet.Cells).Style = "reportStyle";
                ((Excel.Range)xlsSheet.Columns[1]).ColumnWidth = 2;
                ((Excel.Range)xlsSheet.Columns[1 + 2 + captionData.GetUpperBound(1)]).EntireColumn.ColumnWidth = 2;

                toolStripStatusLabelInfo.Text = "Настройка границ листа";
                //настройки печати
                double interval = xlsApp.CentimetersToPoints(0.2);
                xlsSheet.PageSetup.LeftMargin = interval;
                xlsSheet.PageSetup.RightMargin = interval;
                xlsSheet.PageSetup.TopMargin = interval;
                xlsSheet.PageSetup.BottomMargin = xlsApp.CentimetersToPoints(1.3);
                xlsSheet.PageSetup.HeaderMargin = 0;// xlsApp.InchesToPoints(0);
                xlsSheet.PageSetup.FooterMargin = interval;
                xlsSheet.PageSetup.PrintTitleRows = "$1:$11";                                      //печать заголовков на каждой странице
                xlsSheet.PageSetup.PrintTitleColumns = "";
                xlsSheet.PageSetup.FirstPageNumber = (int)Excel.Constants.xlAutomatic; //номер первой страници
                                                                                       //            workSheet.PageSetup.CenterFooter = "Страница  &P из &N";
                xlsSheet.PageSetup.LeftFooter = "&BДля служебного использования&B";
                xlsSheet.PageSetup.CenterFooter = "&D";
                xlsSheet.PageSetup.RightFooter = "Страница &P из &N";


                toolStripStatusLabelInfo.Text = "Настройка ориентации листа и ограничений";
                xlsSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
                xlsSheet.PageSetup.Zoom = 83;// false;                                       // 83; //% от натуральной величины
                                              //            workSheet.PageSetup.FitToPagesWide = 1;                                 //не более чем на количество страниц в ширину           
                                              //            workSheet.PageSetup.FitToPagesTall = 1;                                 //не более чем на количество страниц в высоту    

                //поехали
                toolStripStatusLabelInfo.Text = "Скрыть лишние строки";
                ((Excel.Range)xlsSheet.Rows[2]).EntireRow.Hidden = true;               //скрыть строку
                ((Excel.Range)xlsSheet.Rows[3]).EntireRow.Hidden = true;
                ((Excel.Range)xlsSheet.Rows[6]).EntireRow.Hidden = true;

                toolStripStatusLabelInfo.Text = "Создание заголовка";
                //диапазон для заголовка (главная надпись) (2 строки)
                xlsRange = xlsSheet.Range[xlsSheet.Cells[4, 2 - 1], xlsSheet.Cells[5, 2 + captionData.GetUpperBound(1) + 1]];
                xlsRange.Font.Name = "Times New Roman";
                xlsRange.Font.Size = 11;
                ((Excel.Range)xlsRange.Rows[1]).Merge(mis);                        //объединить строку диапазона
                ((Excel.Range)xlsRange.Rows[2]).Merge(mis);                        //объединить строку диапазона
                xlsRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                xlsRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                xlsRange.Font.Bold = true;
                xlsRange.Font.Name = "Times New Roman";
                xlsRange.Font.Size = 14;
                xlsRange.Cells[1, 1] = "Журнал учета рабочего времени сотрудников " + Properties.Settings.Default.companyName;   //наименование компании
                xlsRange.Cells[2, 1] = "Период: " + mcReport.SelectionStart.ToString("dd.MM.yyyy") + " - " + mcReport.SelectionEnd.ToString("dd.MM.yyyy");

                toolStripStatusLabelInfo.Text = "Создание шапки таблицы и строк данных";
                //диапазон для шапки таблицы и первой строки данных
                xlsRange = xlsSheet.Range[xlsSheet.Cells[8, 2], xlsSheet.Cells[13, 1 + captionData.GetUpperBound(1) + 1]];    //+1 на строку данных
                                                                                                                                  //                ((Excel.Range)xlsRange.Rows).AutoFit();                                                    //автоувеличение строк в заголовке
                xlsRange.Font.Name = "Times New Roman";
                xlsRange.Font.Size = 11;
                xlsRange.Interior.TintAndShade = 0;// '0.2
                xlsRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                xlsRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                xlsRange.WrapText = true;
                xlsRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;                               //нарисуем все рамки

                //настройка ширины колонок и высоты строк диапазона 
                ((Excel.Range)xlsRange.Columns[1]).ColumnWidth = 3.5;          //ширина колонки с номером
                ((Excel.Range)xlsRange.Columns[2]).ColumnWidth = 38.5;         //ширина колонки ФИО 
                ((Excel.Range)xlsRange.Rows[1]).RowHeight = 28.5;              //высота первой строки
                                                                                //                ((Excel.Range)xlsRange.Rows[5]).RowHeight = 20;                //высота строки данных
                                                                                //                ((Excel.Range)xlsRange.Rows[6]).RowHeight = 20;                //высота строки данных
                string colsChar =
                    NumberToLetters(((Excel.Range)xlsRange.Columns[3]).Column) + ":" +
                    NumberToLetters(((Excel.Range)xlsRange.Columns[3 + daysCount * 2 - 1]).Column);
                ((Excel.Range)xlsSheet.Columns[colsChar]).ColumnWidth = 11.56; //ширина колонок с датами 
                                                                                //управление шрифтами и выравниванием
                ((Excel.Range)xlsRange.Rows[1]).Font.Bold = true;              //первая строка шапки
                ((Excel.Range)xlsRange.Rows[2]).Font.Size = 9;                 //вторая строка шапки
                ((Excel.Range)xlsRange.Rows["3:4"]).Font.Bold = true;          //первая строка шапки
                ((Excel.Range)xlsSheet.Range[xlsRange.Cells[2, 3], xlsRange.Cells[2, xlsRange.Columns.Count]]).VerticalAlignment = Excel.XlVAlign.xlVAlignTop;
                ((Excel.Range)xlsRange.Rows[5]).Font.Size = 11;                                            //пятая строка шапки (строка данных)
                ((Excel.Range)xlsRange.Range[xlsSheet.Cells[5, 1], xlsSheet.Cells[6, 2]]).Font.Bold = true;
                ((Excel.Range)xlsRange.Cells[5, 2]).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                ((Excel.Range)xlsSheet.Range[xlsRange.Cells[5, 3], xlsRange.Cells[5, xlsRange.Columns.Count]]).Font.Size = 16;
                //заливка цветом
                ((Excel.Range)xlsSheet.Range[xlsRange.Cells[1, 1], xlsRange.Cells[1, 2]]).Interior.Color = ColorTranslator.ToOle(Color.LightGray);   //заливка первой строки цветом
                ((Excel.Range)xlsSheet.Range[xlsRange.Cells[1, 3], xlsRange.Cells[1, xlsRange.Columns.Count]]).Interior.Color = ColorTranslator.ToOle(Color.LightGreen);
                ((Excel.Range)xlsRange.Rows["3:4"]).Interior.Color = ColorTranslator.ToOle(Color.LightGray);
                ((Excel.Range)xlsSheet.Range[xlsRange.Cells[5, 3], xlsRange.Cells[5, xlsRange.Columns.Count]]).Font.Color = ColorTranslator.ToOle(Color.Gainsboro);//.WhiteSmoke);//.LightGray);
                                                                                                                                                                       //строка данных значения по умолчанию
                xlsRange.Rows[5] = "00:00";

                toolStripStatusLabelInfo.Text = "Вставка условного форматирования шапки таблицы";
                //условное форматирование диапазона 
                xlsFormatCond = (Excel.FormatCondition)((Excel.Range)xlsRange.Rows[1]).EntireRow.FormatConditions.
                    Add(Type: Excel.XlFormatConditionType.xlExpression, mis, Formula1: "=ЕЧИСЛО(НАЙТИ(\"Рабочий\";A9))", mis, mis, mis, mis, mis);

                xlsFormatCond.Interior.PatternColorIndex = Excel.Constants.xlAutomatic;
                xlsFormatCond.Interior.ThemeColor = Excel.XlThemeColor.xlThemeColorAccent3;
                //              fc.Interior.Color = ColorTranslator.ToWin32(Color.White);
                xlsFormatCond.Interior.TintAndShade = 0.599963377788629;
                xlsFormatCond.StopIfTrue = false;

                toolStripStatusLabelInfo.Text = "Настройка объединения ячеек";
                //настройка ширины колонок и объединение ячеек диапазона
                xlsSheet.Range[xlsRange.Cells[1, 1], xlsRange.Cells[4, 1]].Merge(mis);
                xlsSheet.Range[xlsRange.Cells[1, 2], xlsRange.Cells[4, 2]].Merge(mis);
                xlsSheet.Range[xlsRange.Cells[5, 1], xlsRange.Cells[6, 1]].Merge(mis);
                xlsSheet.Range[xlsRange.Cells[5, 2], xlsRange.Cells[6, 2]].Merge(mis);

                int j = 2;
                for (int i = 1; i <= captionData.GetUpperBound(1) / 2; i++)
                {
                    xlsSheet.Range[xlsRange.Cells[1, i + j], xlsRange.Cells[1, i + j + 1]].Merge(mis);
                    xlsSheet.Range[xlsRange.Cells[2, i + j], xlsRange.Cells[2, i + j + 1]].Merge(mis);
                    xlsSheet.Range[xlsRange.Cells[4, i + j], xlsRange.Cells[4, i + j + 1]].Merge(mis);
                    xlsSheet.Range[xlsRange.Cells[6, i + j], xlsRange.Cells[6, i + j + 1]].Merge(mis);
                    j += 1;
                }

                toolStripStatusLabelInfo.Text = "Вставка данных заголовка";
                //вставим данные в заголовок одним куском
                xlsRange.Resize[
                    captionData.GetUpperBound(0) + 1,
                    captionData.GetUpperBound(1) + 1
                    ].Value = captionData;

                //            string used = xlsRange.Address[false, false, Excel.XlReferenceStyle.xlA1, mis, mis];

                toolStripStatusLabelInfo.Text = "Вставка данных таблицы";
                //расширим форматированную таблицу данных
                xlsRange = tableResize(
                    xlsSheet,
                    xlsSheet.Range[
                        xlsSheet.Cells[xlsRange.Row + xlsRange.Rows.Count - 1 - 1, xlsRange.Column],
                        xlsSheet.Cells[xlsRange.Row + xlsRange.Rows.Count - 1, xlsRange.Column + xlsRange.Columns.Count - 1]],
                    tableData.GetUpperBound(0) + 1
                    );
                xlsRange.Value = tableData;

                toolStripStatusLabelInfo.Text = "Дополнительное форматирование";
                xlsRange.Rows.RowHeight = 20;  //восстановить высоту строк в диапазоне данных

                toolStripStatusLabelInfo.Text = "Файл подготовлен";
                //Настройки Application вернуть обратно
                xlsApp.DisplayAlerts = true;                                 //Разрешить отображение окон с сообщениями
                xlsApp.ScreenUpdating = true;                                //Зазрешить перерисовку экрана    
                xlsApp.Visible = true;
                    //            xlsApp.WindowState = Excel.XlWindowState.xlMinimized;         //Свернуть окно 
                    //            xlsApp.Quit();
            }
            finally
            {
                if (xlsStyle != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsStyle);
                if (xlsFormatCond != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsFormatCond);
                if (xlsRange != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsRange);
                if (xlsSheet != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsSheet);
                if (xlsBook != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsBook);

                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsApp);
            }

            Cursor.Current = Cursors.Default;
            ret = true;

            return ret;
        }

        /// <summary>
        /// кнопка напечатать итоговый отчет
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btReportTotalPrint_Click(object sender, EventArgs e)
        {
            string cs = Properties.Settings.Default.twtConnectionSrting;    //connection string
                                                                            //Загрузить массив специальных отметок для таблицы Excel
                                                                            //            dtSpecialMarks = clMsSqlDatabase.TableRequest(cs, "select * from SpecialMarks where uses=1");
                                                                            //            dtSpecialMarks = clMsSqlDatabase.TableRequest(cs, EXEC twt_TotalReport '" + mcReport.SelectionStart.ToString("yyyyMMdd") + "','" + mcReport.SelectionEnd.ToString("yyyyMMdd") + "'")
            dtSpecialMarks = clMsSqlDatabase.TableRequest(cs, "Select distinct sm.letterCode, " +
                                                                "sm.name " +
                                                               " From EventsPass ep, SpecialMarks sm " +
                                                               " Where sm.id = ep.specmarkId and passDate between '" + mcReport.SelectionStart.ToString("yyyyMMdd") + "' and '" + mcReport.SelectionEnd.ToString("yyyyMMdd") + "'");

            toolStripStatusLabelInfo.Text = "";

            ReportTotalPrint();
            /*
                        string msg =
                            "Отчет учета рабочего времени создан" + "\r\n" +
                            " (см. новый файл Excel)" + "\r\n" + "\r\n" +
                            "перейдите на него для печати документа" + "\r\n" +
                            "после чего закройте БЕЗ сохранения";
                        MessageBox.Show(msg, "Подготовка документов", MessageBoxButtons.OK, MessageBoxIcon.Information);
            */
            toolStripStatusLabelInfo.Text = "Выберите диапазон";
            System.Threading.Thread.Sleep(1000);    //пауза 1 сек
            this.Close();                           //закрыть форму
        }

        /// <summary>
        /// печать итогового отчета
        /// </summary>
        /// <returns></returns>
        private bool ReportTotalPrint()
        {
            Cursor.Current = Cursors.WaitCursor;
            bool ret;// = false;
            string colsChar;
            int daysCount = (int)(mcReport.SelectionRange.End - mcReport.SelectionRange.Start).TotalDays + 1;

            try
            {
                toolStripStatusLabelInfo.Text = "Подключение к Excel";
                //Объявляем приложение
                xlsApp = new Excel.Application
                {
                    Visible = false,                                            //Отобразить Excel
                    SheetsInNewWorkbook = 4                                     //Количество листов в рабочей книге    
                };

                toolStripStatusLabelInfo.Text = "Создание рабочей книги";
                //Настройки Application установить
                xlsApp.DisplayAlerts = false;                                 //Запретить отображение окон с сообщениями
                xlsApp.ScreenUpdating = false;                                //Запретить перерисовку экрана    

                xlsBook = xlsApp.Workbooks.Add(mis);                         //Добавить рабочую книгу
                                                                                //Переименовать листы
                ((Excel.Worksheet)xlsApp.Worksheets[1]).Name = "Report";
                ((Excel.Worksheet)xlsApp.Worksheets[2]).Name = "Time";
                ((Excel.Worksheet)xlsApp.Worksheets[3]).Name = "Pass";
                ((Excel.Worksheet)xlsApp.Worksheets[4]).Name = "PivotTable";

                #region //работаем с первым листом Данные 

                int arrCount = uploadCaptionExcel(daysCount, this.AccessibleName + "_Report");    //ReportTotal_Data загрузить данные заголовка 
                uploadTableExcel(daysCount, this.AccessibleName + "_Report");                     //ReportTotal_Data загрузить данные проходов из БД


                xlsSheet = (Excel.Worksheet)xlsApp.Worksheets[1];//.get_Item(1);   //Получаем первый лист документа (счет начинается с 1)
                xlsSheet.Activate();
                xlsApp.ActiveWindow.Zoom = 80;                                //Масштаб листа
                                                                                //           xlsApp.ActiveWindow.View = Excel.XlWindowView.xlPageBreakPreview;

                //RebuildSheet(workBook, "Journal", 3);                         // удалить все листы кроме текущего
                ((Excel.Range)xlsSheet.Cells).FormatConditions.Delete();       //удалить все форматы с листа
                                                                               //((Excel.Range)workSheet.Cells).NumberFormat = "0;[Red]0";

                //оформление листа и применение стиля
                xlsStyle = xlsBook.Styles.Add("reportStyle");
                xlsStyle.Font.Name = "Calibri";//"Times New Roman";
                xlsStyle.Font.Size = 10;// 11;

                toolStripStatusLabelInfo.Text = "Настройка листа данных";
                //ширина колонок
                ((Excel.Range)xlsSheet.Cells).Style = "reportStyle";
                ((Excel.Range)xlsSheet.Columns[1]).ColumnWidth = 2;
                ((Excel.Range)xlsSheet.Columns[1 + 2 + captionData.GetUpperBound(1)]).EntireColumn.ColumnWidth = 2;

                toolStripStatusLabelInfo.Text = "Настройка границ листа данных";
                //настройки печати
                double interval = xlsApp.CentimetersToPoints(0.2);
                xlsSheet.PageSetup.LeftMargin = interval;
                xlsSheet.PageSetup.RightMargin = interval;
                xlsSheet.PageSetup.TopMargin = interval;
                xlsSheet.PageSetup.BottomMargin = xlsApp.CentimetersToPoints(1.2); ;
                xlsSheet.PageSetup.HeaderMargin = 0;// xlsApp.InchesToPoints(0);
                xlsSheet.PageSetup.FooterMargin = interval;
                xlsSheet.PageSetup.PrintTitleRows = "$1:$11";                          //печать заголовков на каждой странице
                xlsSheet.PageSetup.PrintTitleColumns = "";
                xlsSheet.PageSetup.FirstPageNumber = (int)Excel.Constants.xlAutomatic; //номер первой страници
                xlsSheet.PageSetup.LeftFooter = "&BДля служебного использования&B";
                xlsSheet.PageSetup.CenterFooter = "&D";
                xlsSheet.PageSetup.RightFooter = "Страница &P из &N";


                toolStripStatusLabelInfo.Text = "Настройка ориентации листа данных и ограничений";
                xlsSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
                xlsSheet.PageSetup.Zoom = 83;// false;                                       // 83; //% от натуральной величины
                                              //            workSheet.PageSetup.FitToPagesWide = 1;                                 //не более чем на количество страниц в ширину           
                                              //            workSheet.PageSetup.FitToPagesTall = 1;                                 //не более чем на количество страниц в высоту    

                //поехали
                toolStripStatusLabelInfo.Text = "Скрыть лишние строки";
                ((Excel.Range)xlsSheet.Rows["2:3"]).EntireRow.Hidden = true;               //скрыть строку
                ((Excel.Range)xlsSheet.Rows[7]).EntireRow.Hidden = true;

                toolStripStatusLabelInfo.Text = "Создание заголовка";
                //диапазон для заголовка (главная надпись) (2 строки)
                xlsRange = xlsSheet.Range[xlsSheet.Cells[4, 2 - 1], xlsSheet.Cells[5, 2 + captionData.GetUpperBound(1) + 1]];
                xlsRange.Font.Name = "Times New Roman";
                xlsRange.Font.Size = 11;
                ((Excel.Range)xlsRange.Rows[1]).Merge(mis);                        //объединить строку диапазона
                ((Excel.Range)xlsRange.Rows[2]).Merge(mis);                        //объединить строку диапазона
                xlsRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                xlsRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                xlsRange.Font.Bold = true;
                xlsRange.Font.Name = "Times New Roman";
                xlsRange.Font.Size = 14;
                xlsRange.Cells[1, 1] = "Отчет учета рабочего времени сотрудников " + Properties.Settings.Default.companyName;   //наименование компании
                xlsRange.Cells[2, 1] = "Период: " + mcReport.SelectionStart.ToString("dd.MM.yyyy") + " - " + mcReport.SelectionEnd.ToString("dd.MM.yyyy");

                toolStripStatusLabelInfo.Text = "Создание smart таблицы";
                //умная таблица
                xlsSmartTable = xlsSheet.ListObjects.AddEx(
                    SourceType: Excel.XlListObjectSourceType.xlSrcRange,
                    Source: xlsSheet.Range[
                                   xlsSheet.Cells[8, 2],
                                   xlsSheet.Cells[8 + tableData.GetUpperBound(0) + 1, 1 + captionData.GetUpperBound(1) + 1]],
                    XlListObjectHasHeaders: Excel.XlYesNoGuess.xlYes);
                xlsSmartTable.Name = "ReportData";
                xlsSmartTable.TableStyle = "TableStyleLight1";//"TableStyleLight2";//"TableStyleMedium20";
                xlsSmartTable.ShowTotals = true;
                xlsSmartTable.ShowTableStyleFirstColumn = true;

                toolStripStatusLabelInfo.Text = "Форматирование заголовка smart таблицы";
                //управление шрифтами и выравниванием
                xlsSmartTable.HeaderRowRange.Font.Size = 10;
                //                tbSmartReport.HeaderRowRange.Font.Name = "Calibri";// "Times New Roman";
                xlsSmartTable.HeaderRowRange.Font.Bold = false;
                xlsSmartTable.HeaderRowRange.Interior.TintAndShade = 0;// '0.2
                xlsSmartTable.HeaderRowRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                xlsSmartTable.HeaderRowRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                xlsSmartTable.HeaderRowRange.WrapText = true;
                //колонки с третьей по предпоследнюю    
                colsChar =
                    NumberToLetters(1 + xlsSmartTable.HeaderRowRange.Column) + ":" +
                    NumberToLetters(1 + xlsSmartTable.HeaderRowRange.Column + daysCount + 3 + dtSpecialMarks.Rows.Count);
                ((Excel.Range)xlsSmartTable.HeaderRowRange.Columns[colsChar]).VerticalAlignment = Excel.XlVAlign.xlVAlignBottom;  //ширина колонок спец отметл + дополнительные
                ((Excel.Range)xlsSmartTable.HeaderRowRange.Columns[colsChar]).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;  //ширина колонок спец отметл + дополнительные
                ((Excel.Range)xlsSmartTable.HeaderRowRange.Columns[colsChar]).Orientation = 90;      //ширина колонок спец отметл + дополнительные
                                                                                                     //заливка цветом
                colsChar =                                                      //колонки с датами
                    NumberToLetters(1 + xlsSmartTable.HeaderRowRange.Column) + ":" +
                    NumberToLetters(1 + xlsSmartTable.HeaderRowRange.Column + daysCount - 1);
                ((Excel.Range)xlsSmartTable.HeaderRowRange.Columns[colsChar]).Interior.Color = ColorTranslator.ToOle(Color.LightBlue);  //ширина колонок спец отметл + дополнительные

                colsChar =                                                      //три итоговые колонки
                    NumberToLetters(1 + xlsSmartTable.HeaderRowRange.Column + daysCount) + ":" +
                    NumberToLetters(1 + xlsSmartTable.HeaderRowRange.Column + daysCount + 2);
                ((Excel.Range)xlsSmartTable.HeaderRowRange.Columns[colsChar]).Interior.Color = ColorTranslator.ToOle(Color.LightGreen);  //ширина колонок спец отметл + дополнительные
                                                                                                                                         //               ((Excel.Range)tbSmartReport.HeaderRowRange.Columns[colsChar]).Interior.ThemeColor = ColorTranslator.ToOle(Color.DarkGray);  //ширина колонок спец отметл + дополнительные
                ((Excel.Range)xlsSmartTable.HeaderRowRange.Columns[xlsSmartTable.ListColumns.Count]).Interior.Color = ColorTranslator.ToOle(Color.LightGreen);
                //               ((Excel.Range)tbSmartReport.HeaderRowRange.Columns[tbSmartReport.ListColumns.Count]).Interior.ThemeColor = ColorTranslator.ToOle(Color.DarkGray);

                //управление размерами
                xlsSmartTable.HeaderRowRange.RowHeight = 154;                   //высота строки шапки
                xlsSmartTable.HeaderRowRange.ColumnWidth = 4;// 3.5;// 4;       //ширина всех колонок
                xlsSmartTable.ListColumns[1].Range.ColumnWidth = 3.5;           //ширина колонки с номером
                xlsSmartTable.ListColumns[2].Range.ColumnWidth = 38.5;          //ширина колонки ФИО 
                colsChar =
                    NumberToLetters(((Excel.Range)xlsSmartTable.HeaderRowRange.Columns[3 + daysCount - 1]).Column) + ":" +
                    NumberToLetters(((Excel.Range)xlsSmartTable.HeaderRowRange.Columns[3 + daysCount + 3 + dtSpecialMarks.Rows.Count]).Column);
                ((Excel.Range)xlsSmartTable.HeaderRowRange.Columns[colsChar]).ColumnWidth = 6;      //ширина колонок спец отметл + дополнительные 
                xlsSmartTable.ListColumns[xlsSmartTable.ListColumns.Count].Range.ColumnWidth = 18;  //ширина последнего столбца

                toolStripStatusLabelInfo.Text = "Форматирование области данных smart таблицы";
                //управление шрифтами и выравниванием
                xlsSmartTable.DataBodyRange.NumberFormat = "##0,0";//"0,0";                         //все цифровые данные с одним разрядом 
                xlsSmartTable.DataBodyRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;    //вся таблица по центру        
                ((Excel.Range)xlsSmartTable.DataBodyRange.Columns[2]).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft; //ширина колонок спец отметл + дополнительные


                toolStripStatusLabelInfo.Text = "Вставка условного форматирования шапки таблицы";

                //условное форматирование диапазона дат
                // colsChar =
                //     NumberToLetters(((Excel.Range)tbSmartReport.HeaderRowRange.Columns[3]).Column) + ":" +
                //     NumberToLetters(((Excel.Range)tbSmartReport.HeaderRowRange.Columns[3 + daysCount - 1]).Column);
                //Excel.FormatConditions fcs = ((Excel.Range)tbSmartReport.HeaderRowRange[tbSmartReport.HeaderRowRange.Cells[0, 3], tbSmartReport.HeaderRowRange.Cells[0, 3 + daysCount - 1]]).FormatConditions;
                xlsFormatCond = (Excel.FormatCondition)((Excel.Range)xlsSmartTable.HeaderRowRange.Columns[colsChar]).EntireRow.FormatConditions.Add(Type: Excel.XlFormatConditionType.xlExpression, mis, Formula1: "=ЕЧИСЛО(НАЙТИ(\"Рабочий\";A8))", mis, mis, mis, mis, mis);
                //xlsRange.Cells[2, 3], xlsRange.Cells[2, xlsRange.Columns.Count]]
                xlsFormatCond.Interior.PatternColorIndex = Excel.Constants.xlAutomatic;
                xlsFormatCond.Interior.ThemeColor = Excel.XlThemeColor.xlThemeColorAccent3;
                //fc.Interior.Color = ColorTranslator.ToWin32(Color.White);
                xlsFormatCond.Interior.TintAndShade = 0.599963377788629;
                xlsFormatCond.StopIfTrue = false;

                //условное форматирование колонок данных
                ;
                //Явка формат цветом
                xlsColor = (Excel.ColorScale)xlsSmartTable.ListColumns[headerIndex["Я"] + 1].DataBodyRange.FormatConditions.AddColorScale(2);
                xlsColor.ColorScaleCriteria[1].Type = Excel.XlConditionValueTypes.xlConditionValueLowestValue;
                xlsColor.ColorScaleCriteria[1].FormatColor.Color = 10285055;// Color.FromArgb(min, 0, 0);
                xlsColor.ColorScaleCriteria[2].Type = Excel.XlConditionValueTypes.xlConditionValueHighestValue;
                xlsColor.ColorScaleCriteria[2].FormatColor.Color = 8109667;// Color.FromArgb(min, 0, 0);

                //Недоработка формат значением
                xlsDatabar = (Excel.Databar)xlsSmartTable.ListColumns[headerIndex["less"] + 1].DataBodyRange.FormatConditions.AddDatabar();
                xlsDatabar.MinPoint.Modify(Excel.XlConditionValueTypes.xlConditionValueAutomaticMin);
                xlsDatabar.MaxPoint.Modify(Excel.XlConditionValueTypes.xlConditionValueAutomaticMax);
                xlsDatabar.BarFillType = Excel.XlDataBarFillType.xlDataBarFillGradient;
                xlsDatabar.Direction = (int)Excel.Constants.xlRTL;
                xlsDatabar.BarBorder.Type = Excel.XlDataBarBorderType.xlDataBarBorderNone;//.xlDataBarBorderSolid;
                ((Excel.FormatColor)xlsDatabar.BarColor).Color = 5920255;

                //Переработка формат значением
                xlsDatabar = (Excel.Databar)xlsSmartTable.ListColumns[headerIndex["over"] + 1].DataBodyRange.FormatConditions.AddDatabar();
                xlsDatabar.MinPoint.Modify(Excel.XlConditionValueTypes.xlConditionValueAutomaticMin);
                xlsDatabar.MaxPoint.Modify(Excel.XlConditionValueTypes.xlConditionValueAutomaticMax);
                xlsDatabar.BarFillType = Excel.XlDataBarFillType.xlDataBarFillGradient;
                xlsDatabar.Direction = (int)Excel.Constants.xlContext;
                xlsDatabar.BarBorder.Type = Excel.XlDataBarBorderType.xlDataBarBorderNone;//.xlDataBarBorderSolid;
                ((Excel.FormatColor)xlsDatabar.BarColor).Color = 15698432;

                //Работа в рабочем графике формат значением
                xlsDatabar = (Excel.Databar)xlsSmartTable.ListColumns[headerIndex["sum"] + 1].DataBodyRange.FormatConditions.AddDatabar();
                xlsDatabar.MinPoint.Modify(Excel.XlConditionValueTypes.xlConditionValueAutomaticMin);
                xlsDatabar.MaxPoint.Modify(Excel.XlConditionValueTypes.xlConditionValueAutomaticMax);
                xlsDatabar.BarFillType = Excel.XlDataBarFillType.xlDataBarFillGradient;
                xlsDatabar.Direction = (int)Excel.Constants.xlContext;
                xlsDatabar.BarBorder.Type = Excel.XlDataBarBorderType.xlDataBarBorderNone;//.xlDataBarBorderSolid;
                ((Excel.FormatColor)xlsDatabar.BarColor).Color = 8700771;

                //Работа вне рабочем графике формат значением
                xlsDatabar = (Excel.Databar)xlsSmartTable.ListColumns[headerIndex["ext"] + 1].DataBodyRange.FormatConditions.AddDatabar();
                xlsDatabar.MinPoint.Modify(Excel.XlConditionValueTypes.xlConditionValueAutomaticMin);
                xlsDatabar.MaxPoint.Modify(Excel.XlConditionValueTypes.xlConditionValueAutomaticMax);
                xlsDatabar.BarFillType = Excel.XlDataBarFillType.xlDataBarFillGradient;
                xlsDatabar.Direction = (int)Excel.Constants.xlContext;
                xlsDatabar.BarBorder.Type = Excel.XlDataBarBorderType.xlDataBarBorderNone;//.xlDataBarBorderSolid;
                ((Excel.FormatColor)xlsDatabar.BarColor).Color = 2668287;

                /*
                    //попытка ускориться - вместо цикла передать диапазон строк
                    colsChar = "";
                    for (int i = 2; i < tbSmartReport.DataBodyRange.Rows.Count; i += 2) 
                    {
                        colsChar = colsChar + $"{i}:{i}, ";
                    }

                    colsChar = colsChar.Remove(colsChar.Length - 1, 1);
                    Excel.Range w = workSheet.Range[colsChar.Remove(colsChar.Length - 1, 1)];
                    ((Excel.Range)workSheet.Range[colsChar.Remove(colsChar.Length - 1, 1)]).Font.Size = 12;
                    ((Excel.Range)tbSmartReport.DataBodyRange.Rows[colsChar.Remove(colsChar.Length - 1, 1)]).Font.Size = 12;
                    ((Excel.Range)tbSmartReport.Range[colsChar.Remove(colsChar.Length - 1, 1)]).Font.Size = 12;
                    ((Excel.Range)tbSmartReport.DataBodyRange.Range[colsChar.Remove(colsChar.Length - 1, 1)]).Font.Bold = true;
                    ((Excel.Range)tbSmartReport.DataBodyRange.Range["1,3,5"]).Font.Size = 12;
                    Range("I:I,F:H,L:T,AD:AE,AH:AM,AN:AS,AT:AW,BF:BI")
                    Range("21:21,25:25,29:29").Font.Bold = True
                 */
                toolStripStatusLabelInfo.Text = "Дополнительное форматирование";
                for (int i = 1; i < xlsSmartTable.DataBodyRange.Rows.Count; i++)
                {
                    ((Excel.Range)xlsSmartTable.DataBodyRange.Cells[i, 2]).Font.Italic = true;
                    ((Excel.Range)xlsSmartTable.DataBodyRange.Rows[i]).Font.Size = 9;
                    i++;
                    ((Excel.Range)xlsSmartTable.DataBodyRange.Rows[i]).Font.Size = 12;
                    //((Excel.Range)tbSmartReport.DataBodyRange.Rows[i]).Font.Bold = true;
                }

                //формулы итогов
                for (int i = 3 + daysCount; i < xlsSmartTable.ListColumns.Count; i++)
                {
                    xlsSmartTable.ListColumns[i].TotalsCalculation = Excel.XlTotalsCalculation.xlTotalsCalculationSum;
                }
                xlsSmartTable.ListColumns[xlsSmartTable.ListColumns.Count].TotalsCalculation = Excel.XlTotalsCalculation.xlTotalsCalculationNone;       //в последней колонке формулу не показывать

                //границы
                Excel.XlBorderWeight brdWeight = Excel.XlBorderWeight.xlThin;//.xlThick;//.xlMedium;
                xlsSmartTable.DataBodyRange.Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = brdWeight;             //сверху
                xlsSmartTable.DataBodyRange.Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = brdWeight;          //снизу
                xlsSmartTable.ListColumns[1].Range.Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = brdWeight;     //слева
                xlsSmartTable.ListColumns[headerIndex["total"] + 1].Range.Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = brdWeight;

                xlsSmartTable.ListColumns[2].Range.Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = brdWeight;     //фио слева    
                xlsSmartTable.ListColumns[2].Range.Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = brdWeight;    //фио справа

                xlsSmartTable.ListColumns[headerIndex["less"] + 1].Range.Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = brdWeight;
                xlsSmartTable.ListColumns[headerIndex["over"] + 1].Range.Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = brdWeight;
                xlsSmartTable.ListColumns[headerIndex["sum"] + 1].Range.Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = brdWeight;
                xlsSmartTable.ListColumns[headerIndex["ext"] + 1].Range.Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = brdWeight;
                xlsSmartTable.ListColumns[headerIndex["total"] + 1].Range.Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = brdWeight;

                toolStripStatusLabelInfo.Text = "Вставка данных заголовка";
                string[] rowCaptionData = new string[captionData.GetUpperBound(1) + 1];
                for (int i = 0; i <= captionData.GetUpperBound(1); i++)
                    rowCaptionData[i] = captionData[0, i];                       //возьмем только первую строку данных
                xlsSmartTable.HeaderRowRange.Value = rowCaptionData;

                toolStripStatusLabelInfo.Text = "Вставка данных таблицы";
                /*
                    ---------------------------------------------------------------------------------------------------------------------------------------------------------------
                    !!!!ВАЖНО
                    1. область данных Excel предварительно отформатирована для приема числовых данных (формат ячейки - "0")
                    2. числа передаем как есть с разделителем c# - точкой. но числа передаем как строки - и дальше боремся с этим
                    3. если число данных целое - обязательно форматируем его на 8 десятичных знаков (чтобы был разделитель)
                    4. если передать строку с разделителем по умолчанию для системы (запятая) - на листе говорит что число записано в виде строки и не воспринимает его как число
                    5. если передать строку с разделителем для c# (точка) - не ругается но все равно не воспринимает его как число
                */

                //            xlsApp.DecimalSeparator = ".";                                    //сообщаем Excel что к нему придут числа с точкой в виде разделителя
                //            xlsApp.UseSystemSeparators = false;                               //отключаем Excel использование системного разделителя (запятая по умолчанию)
                //то что выше (две строки) нужно отключить если дальше используем замену точки на запятую - все равно не помогло для Excel 2010
                xlsSmartTable.DataBodyRange.Value = tableData;

                toolStripStatusLabelInfo.Text = "Форматирование данных из строки в число";
                xlsSmartTable.DataBodyRange.Replace(".", ",");                      //!!!меняем точку на запятую (чтобы Excel наконец то понял что ему передают число)(жуткий тормоз)

                //            xlsApp.UseSystemSeparators = true;                                //включаем Excel использование системного разделителя (запятая по умолчанию)
                //то что выше (одна строка) нужно отключить если дальше используем замену точки на запятую - все равно не помогло для Excel 2010
                /*
                    ---------------------------------------------------------------------------------------------------------------------------------------------------------------
                */

                //примечания
                xlsRange = (Excel.Range)xlsSheet.Cells[xlsSmartTable.DataBodyRange.Row + xlsSmartTable.DataBodyRange.Rows.Count + 2, 2];
                ((Excel.Range)xlsRange).Offset[0, 0].Value = "Примечания";
                ((Excel.Range)xlsRange).Offset[1, 0].Value = "Результаты представлены в двух главных областях: - РАБОЧЕЕЕ ВРЕМЯ (данные на дату) и СПЕЦИАЛЬНЫЕ ОТМЕТКИ (накопительная часть)";
                ((Excel.Range)xlsRange).Offset[2, 0].Value = "  - РАБОЧЕЕ ВРЕМЯ ('Я'): чистое время без обеда, учитывая сокращенные дни, рабочий график, - с разверткой по дням (без накопительной части)";
                ((Excel.Range)xlsRange).Offset[3, 0].Value = "**  наличие сокращенных наименований СПЕЦИАЛЬНЫХ ОТМЕТОК (кроме 'Я') в области РАБОЧЕГО времени говорит ТОЛЬКО о их НАЛИЧИИ в течении дня (к указанному под ними времени они отношения не имеют)";
                ((Excel.Range)xlsRange).Offset[4, 0].Value = "  - СПЕЦИАЛЬНЫЕ ОТМЕТКИ (кроме 'Я') фактическое время как есть (включая обед) с разверткой по типам отметок (с накопительной частью)";

                ((Excel.Range)xlsRange).Offset[6, 0].Value = "ps";
                ((Excel.Range)xlsRange).Offset[7, 0].Value = "ВАЖНО. Итоговые значения получаются ПО ВНУТРЕННИМ ФОРМУЛАМ!!!, не сложением того что вы видите в таблице отчета";
                ((Excel.Range)xlsRange).Offset[8, 0].Value = "Например последняя колонка считается как сумма из области РАБОЧЕГО ВРЕМЕНИ в течении И вне рабочего дня с признаком - СЛУЖЕБНОЕ ЗАДАНИЕ";

                //фиксация заголовка на странице
                xlsSheet.Application.ActiveWindow.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlMaximized;      //окно должно быть активно
                xlsSheet.Application.ActiveWindow.FreezePanes = false;
                xlsSheet.Application.ActiveWindow.SplitRow = xlsSmartTable.HeaderRowRange.Row;
                xlsSheet.Application.ActiveWindow.SplitColumn = 3;
                xlsSheet.Application.ActiveWindow.FreezePanes = true;

                #endregion

                #region //работаем со вторым листом Время

                arrCount = uploadCaptionExcel(daysCount, this.AccessibleName + "_Time");    //ReportTotal_Time загрузить данные заголовка 
                uploadTableExcel(daysCount, this.AccessibleName + "_Time");                 //ReportTotal_Time загрузить данные контроллеров времени из БД

                xlsSheet = (Excel.Worksheet)xlsApp.Worksheets[2];//.get_Item(2);   //Получаем первый лист документа (счет начинается с 1)
                xlsSheet.Activate();
                xlsApp.ActiveWindow.Zoom = 80;                                        //Масштаб листа
                                                                                        //           xlsApp.ActiveWindow.View = Excel.XlWindowView.xlPageBreakPreview;

                ((Excel.Range)xlsSheet.Cells).FormatConditions.Delete();               //удалить все форматы с листа

                toolStripStatusLabelInfo.Text = "Настройка листа";
                //ширина колонок
                ((Excel.Range)xlsSheet.Cells).Style = "reportStyle";
                ((Excel.Range)xlsSheet.Columns[1]).ColumnWidth = 2;                    //первая  и последняя колонка листа
                ((Excel.Range)xlsSheet.Columns[1 + 2 + captionData.GetUpperBound(1)]).EntireColumn.ColumnWidth = 2;

                toolStripStatusLabelInfo.Text = "Настройка границ листа";
                //настройки печати
                interval = xlsApp.CentimetersToPoints(0.2);
                xlsSheet.PageSetup.LeftMargin = interval;
                xlsSheet.PageSetup.RightMargin = interval;
                xlsSheet.PageSetup.TopMargin = interval;
                xlsSheet.PageSetup.BottomMargin = xlsApp.CentimetersToPoints(1.3);
                xlsSheet.PageSetup.HeaderMargin = 0;// xlsApp.InchesToPoints(0);
                xlsSheet.PageSetup.FooterMargin = interval;
                xlsSheet.PageSetup.PrintTitleRows = "$1:$11";                          //печать заголовков на каждой странице
                xlsSheet.PageSetup.PrintTitleColumns = "";
                xlsSheet.PageSetup.FirstPageNumber = (int)Excel.Constants.xlAutomatic; //номер первой страници
                                                                                       //workSheet.PageSetup.CenterFooter = "Страница  &P из &N";
                xlsSheet.PageSetup.LeftFooter = "&BДля служебного использования&B";
                xlsSheet.PageSetup.CenterFooter = "&D";
                xlsSheet.PageSetup.RightFooter = "Страница &P из &N";

                toolStripStatusLabelInfo.Text = "Настройка ориентации листа и ограничений";
                xlsSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
                xlsSheet.PageSetup.Zoom = 83;// false;                                       // 83; //% от натуральной величины
                                              //            workSheet.PageSetup.FitToPagesWide = 1;                                 //не более чем на количество страниц в ширину           
                                              //            workSheet.PageSetup.FitToPagesTall = 1;                                 //не более чем на количество страниц в высоту    

                //поехали
                toolStripStatusLabelInfo.Text = "Скрыть лишние строки";
                ((Excel.Range)xlsSheet.Rows[2]).EntireRow.Hidden = true;               //скрыть строку
                ((Excel.Range)xlsSheet.Rows[3]).EntireRow.Hidden = true;
                ((Excel.Range)xlsSheet.Rows[6]).EntireRow.Hidden = true;

                toolStripStatusLabelInfo.Text = "Создание заголовка";
                //диапазон для заголовка (главная надпись) (2 строки)
                xlsRange = xlsSheet.Range[xlsSheet.Cells[4, 2 - 1], xlsSheet.Cells[5, 2 + captionData.GetUpperBound(1) + 1]];
                xlsRange.Font.Name = "Times New Roman";
                xlsRange.Font.Size = 11;
                ((Excel.Range)xlsRange.Rows[1]).Merge(mis);                        //объединить строку диапазона
                ((Excel.Range)xlsRange.Rows[2]).Merge(mis);                        //объединить строку диапазона
                xlsRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                xlsRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                xlsRange.Font.Bold = true;
                xlsRange.Font.Name = "Times New Roman";
                xlsRange.Font.Size = 14;
                xlsRange.Cells[1, 1] = "Контроль рабочего времени сотрудников " + Properties.Settings.Default.companyName;   //наименование компании
                xlsRange.Cells[2, 1] = "Период: " + mcReport.SelectionStart.ToString("dd.MM.yyyy") + " - " + mcReport.SelectionEnd.ToString("dd.MM.yyyy");

                toolStripStatusLabelInfo.Text = "Создание шапки таблицы и строк данных";
                //диапазон для шапки таблицы 3 строки и 3х первых строк данных
                xlsRange = xlsSheet.Range[xlsSheet.Cells[8, 2], xlsSheet.Cells[13, 1 + captionData.GetUpperBound(1) + 1]];    //+1 на строку данных
                                                                                                                                  //                ((Excel.Range)xlsRange.Rows).AutoFit();                                                    //автоувеличение строк в заголовке
                                                                                                                                  //            xlsRange.Font.Name = "Times New Roman";
                xlsRange.Font.Size = 11;
                xlsRange.Interior.TintAndShade = 0;// '0.2
                xlsRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                xlsRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                xlsRange.WrapText = true;
                ((Excel.Range)xlsRange.Rows["1:6"]).Borders.LineStyle = Excel.XlLineStyle.xlContinuous;                         //нарисуем все рамки на первых трех строчках
                ((Excel.Range)xlsRange.Rows["4:6"]).Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlLineStyleNone;    //уберем горизонтальные линии

                //настройка ширины колонок и высоты строк диапазона 
                ((Excel.Range)xlsRange.Columns[1]).ColumnWidth = 3.5;          //ширина колонки с номером
                ((Excel.Range)xlsRange.Columns[2]).ColumnWidth = 38.5;         //ширина колонки ФИО 
                ((Excel.Range)xlsRange.Columns[3]).ColumnWidth = 12.5;         //ширина колонки контроллер времени 
                ((Excel.Range)xlsRange.Rows[1]).RowHeight = 28.5;              //высота первой строки
                ((Excel.Range)xlsRange.Rows[3]).RowHeight = 12.75;             //высота третьей строки

                colsChar =
                    NumberToLetters(((Excel.Range)xlsRange.Columns[4]).Column) + ":" +
                    NumberToLetters(((Excel.Range)xlsRange.Columns[4 + daysCount * 2 - 1]).Column);
                ((Excel.Range)xlsSheet.Columns[colsChar]).ColumnWidth = 6;     //ширина колонок с датами 

                //управление шрифтами и выравниванием
                ((Excel.Range)xlsRange.Rows["2:4"]).Font.Size = 9;             //вторая и третья строка шапки и первая строка данных
                ((Excel.Range)xlsSheet.Range[xlsRange.Cells[2, 3], xlsRange.Cells[2, xlsRange.Columns.Count]]).VerticalAlignment = Excel.XlVAlign.xlVAlignTop;

                ((Excel.Range)xlsRange.Cells[4, 2]).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                ((Excel.Range)xlsRange.Cells[4, 2]).Font.Size = 12;            //ФИО
                ((Excel.Range)xlsRange.Rows[5]).Font.Size = 12;                //строка регистратора

                //заливка цветом
                ((Excel.Range)xlsSheet.Range[xlsRange.Cells[1, 1], xlsRange.Cells[1, 3]]).Interior.Color = ColorTranslator.ToOle(Color.LightGray);   //заливка первой строки цветом
                ((Excel.Range)xlsSheet.Range[xlsRange.Cells[1, 4], xlsRange.Cells[1, xlsRange.Columns.Count]]).Interior.Color = ColorTranslator.ToOle(Color.LightGreen);
                //            ((Excel.Range)xlsRange.Rows["3:4"]).Interior.Color = ColorTranslator.ToOle(Color.LightGray);
                ((Excel.Range)xlsRange.Rows[3]).Interior.Color = ColorTranslator.ToOle(Color.LightGray);
                ((Excel.Range)xlsRange.Rows[5]).Interior.Color = ColorTranslator.ToOle(Color.LightGray);
                //           ((Excel.Range)workSheet.Range[xlsRange.Cells[5, 3], xlsRange.Cells[5, xlsRange.Columns.Count]]).Font.Color = ColorTranslator.ToOle(Color.Gainsboro);//.WhiteSmoke);//.LightGray);

                //строка данных значения по умолчанию
                ((Excel.Range)xlsRange.Rows["4:6"]).NumberFormat = "@";

                toolStripStatusLabelInfo.Text = "Вставка условного форматирования шапки таблицы";
                //условное форматирование диапазона 
                xlsFormatCond = (Excel.FormatCondition)((Excel.Range)xlsSheet.Range[xlsRange.Cells[1, 4], xlsRange.Cells[1, 4 + daysCount * 2 - 1]]).EntireRow.FormatConditions.
                    Add(Type: Excel.XlFormatConditionType.xlExpression, mis, Formula1: "=ЕЧИСЛО(НАЙТИ(\"Рабочий\";A9))", mis, mis, mis, mis, mis);
                xlsFormatCond.Interior.PatternColorIndex = Excel.Constants.xlAutomatic;
                xlsFormatCond.Interior.ThemeColor = Excel.XlThemeColor.xlThemeColorAccent3;
                //              fc.Interior.Color = ColorTranslator.ToWin32(Color.White);
                xlsFormatCond.Interior.TintAndShade = 0.599963377788629;
                xlsFormatCond.StopIfTrue = false;

                toolStripStatusLabelInfo.Text = "Настройка объединения ячеек";
                //настройка ширины колонок и объединение ячеек диапазона
                xlsSheet.Range[xlsRange.Cells[1, 1], xlsRange.Cells[3, 1]].Merge(mis);
                xlsSheet.Range[xlsRange.Cells[1, 2], xlsRange.Cells[3, 2]].Merge(mis);
                xlsSheet.Range[xlsRange.Cells[1, 3], xlsRange.Cells[3, 3]].Merge(mis);

                xlsSheet.Range[xlsRange.Cells[4, 1], xlsRange.Cells[6, 1]].Merge(mis);
                xlsSheet.Range[xlsRange.Cells[4, 2], xlsRange.Cells[6, 2]].Merge(mis);

                int j = 3;
                for (int i = 1; i <= captionData.GetUpperBound(1) / 2; i++)
                {
                    xlsSheet.Range[xlsRange.Cells[1, i + j], xlsRange.Cells[1, i + j + 1]].Merge(mis);
                    xlsSheet.Range[xlsRange.Cells[2, i + j], xlsRange.Cells[2, i + j + 1]].Merge(mis);

                    xlsSheet.Range[xlsRange.Cells[3, i + j], xlsRange.Cells[6, i + j + 1]].Borders[Excel.XlBordersIndex.xlInsideVertical].Weight = Excel.XlBorderWeight.xlHairline;
                    j += 1;
                }

                toolStripStatusLabelInfo.Text = "Вставка данных заголовка";
                //вставим данные в заголовок одним куском
                xlsRange.Resize[
                    captionData.GetUpperBound(0) + 1,
                    captionData.GetUpperBound(1) + 1
                    ].Value = captionData;

                toolStripStatusLabelInfo.Text = "Вставка данных таблицы";
                //расширим форматированную таблицу данных
                Excel.Range fullTable = tableResize(
                    xlsSheet,
                    xlsSheet.Range[
                        xlsSheet.Cells[xlsRange.Row + xlsRange.Rows.Count - 3, xlsRange.Column],
                        xlsSheet.Cells[xlsRange.Row + xlsRange.Rows.Count - 1, xlsRange.Column + xlsRange.Columns.Count - 1]],
                    tableData.GetUpperBound(0) + 1
                    );
                fullTable.Value = tableData;

                toolStripStatusLabelInfo.Text = "Дополнительное форматирование";
                fullTable.Rows.RowHeight = 15;// .75;// 20;  //восстановить высоту строк в диапазоне данных

                //фиксация заголовка на странице
                xlsSheet.Application.ActiveWindow.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlMaximized;      //окно должно быть активно
                xlsSheet.Application.ActiveWindow.FreezePanes = false;
                xlsSheet.Application.ActiveWindow.SplitRow = fullTable.Row - 1;
                xlsSheet.Application.ActiveWindow.SplitColumn = 4;
                xlsSheet.Application.ActiveWindow.FreezePanes = true;

                #endregion

                #region //работаем с третьим листом Проходы

                uploadTableExcel(daysCount, this.AccessibleName + "_Pass");             //ReportTotal_Time загрузить данные контроллеров времени из БД

                xlsSheet = (Excel.Worksheet)xlsApp.Worksheets[3];//.get_Item(2);     //Получаем первый лист документа (счет начинается с 1)
                xlsSheet.Activate();
                xlsApp.ActiveWindow.Zoom = 80;                                        //Масштаб листа
                                                                                        //           xlsApp.ActiveWindow.View = Excel.XlWindowView.xlPageBreakPreview;
                ((Excel.Range)xlsSheet.Cells).FormatConditions.Delete();               //удалить все форматы с листа

                int ColumnsCount;
                //цикл по всем листам и заполнение их данными из таблиц (имя листа=имятаблицы)
                if (totalReportData == null || (ColumnsCount = totalReportData.Columns.Count) == 0)
                    throw new Exception("ExportToExcel: Null or empty input table!\n");

                object[] Header = new object[ColumnsCount];

                // column headings               
                for (int i = 0; i < ColumnsCount; i++)
                    Header[i] = totalReportData.Columns[i].ColumnName;

                Excel.Range HeaderRange = xlsSheet.get_Range((Excel.Range)(xlsSheet.Cells[1, 1]), (Excel.Range)(xlsSheet.Cells[1, ColumnsCount]));
                HeaderRange.Value = Header;
                HeaderRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                HeaderRange.Font.Bold = true;

                // DataCells
                int RowsCount = totalReportData.Rows.Count;
                object[,] Cells = new object[RowsCount, ColumnsCount];

                for (j = 0; j < RowsCount; j++)
                {
                    for (int i = 0; i < ColumnsCount; i++)
                        Cells[j, i] = totalReportData.Rows[j][i];
                }
                xlsSheet.get_Range((Excel.Range)(xlsSheet.Cells[2, 1]), (Excel.Range)(xlsSheet.Cells[RowsCount + 1, ColumnsCount])).Value = Cells;
                //присвоить диапазону данных с заголовком имя
                xlsRange = xlsSheet.get_Range((Excel.Range)(xlsSheet.Cells[1, 1]), (Excel.Range)(xlsSheet.Cells[RowsCount + 1, ColumnsCount]));
                xlsRange.Name = "PassData";

                toolStripStatusLabelInfo.Text = "Настройка сводной таблицы и диаграммы";
                xlsSheet.Visible = Excel.XlSheetVisibility.xlSheetHidden;              //скрыть лист
                xlsSheet = (Excel.Worksheet)xlsApp.Worksheets[4];//.get_Item(2);     //Получаем первый лист документа (счет начинается с 1)
                xlsSheet.Activate();

                // Create the Pivot Table
                //https://www.add-in-express.com/creating-addins-blog/2011/10/17/excel-pivottables-slicers-programmatically/
                xlsPivotTable = (Excel.PivotTable)xlsBook.PivotCaches().
                        Create(Excel.XlPivotTableSourceType.xlDatabase, "PassData").//, Excel.XlPivotTableVersionList.xlPivotTableVersion12).
                        CreatePivotTable("PivotTable!R1C1", "tablePassData");//, mis, Excel.XlPivotTableVersionList.xlPivotTableVersion12);
                                                                             // Set the Pivot Fields
                xlsPivotFields = (Excel.PivotFields)xlsPivotTable.PivotFields();
                xlsPivotField = (Excel.PivotField)xlsPivotFields.Item("фио");
                xlsPivotField.Orientation = Excel.XlPivotFieldOrientation.xlRowField;
                xlsPivotField = (Excel.PivotField)xlsPivotFields.Item("спец_отметка");
                xlsPivotField.Orientation = Excel.XlPivotFieldOrientation.xlColumnField;
                xlsPivotField = (Excel.PivotField)xlsPivotFields.Item("дата_прохода");
                xlsPivotField.Orientation = Excel.XlPivotFieldOrientation.xlPageField;

                xlsPivotTable.AddDataField((Excel.PivotField)xlsPivotFields.Item("минут_отработано_всего"),
                            "Сумма по полю минут_отработано_всего", Excel.XlConsolidationFunction.xlSum);

                // Create the Chart Diagram from Pivot Table
                //https://www.add-in-express.com/creating-addins-blog/2013/10/22/change-excel-charts-programmatically/
                xlsChart = xlsSheet.Shapes.AddChart(Excel.XlChartType.xlColumnStacked, 100, 5, 800, 700).Chart;
                xlsChart.SetSourceData((Excel.Range)xlsPivotTable.TableRange1, Excel.XlRowCol.xlRows);
                xlsChart.ApplyLayout(5);
                xlsChart.ChartTitle.Text = "Специальные отметки (минуты)";

                #endregion

                ((Excel.Worksheet)xlsApp.Worksheets[1]).Activate();           //уйдем на первый лист

                toolStripStatusLabelInfo.Text = "Файл подготовлен";
                //Настройки Application вернуть обратно
                xlsApp.DisplayAlerts = true;                                  //Разрешить отображение окон с сообщениями
                xlsApp.ScreenUpdating = true;                                 //Зазрешить перерисовку экрана    

                xlsApp.Visible = true;
                //            xlsApp.WindowState = Excel.XlWindowState.xlMinimized;         //Свернуть окно 
                //            xlsApp.Quit();
            }
            finally
            {
                if (xlsChart != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsChart);
                if (xlsPivotField != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsPivotField);
                if (xlsPivotFields != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsPivotFields);
                if (xlsDatabar != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsDatabar);
                if (xlsColor != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsColor);
                if (xlsSmartTable != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsSmartTable);
                if (xlsPivotTable != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsPivotTable);
                if (xlsStyle != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsStyle);
                if (xlsFormatCond != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsFormatCond);
                if (xlsRange != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsRange);
                if (xlsSheet != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsSheet);
                if (xlsBook != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsBook);

                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsApp);
            }

            Cursor.Current = Cursors.Default;
            ret = true;

            return ret;
        }

        #endregion

        #region//Interface

        //преобразовать индекс столбца в букву
        /// <summary>
        /// Возвращает буквенный символ столбца Microsoft Excel, соответствующий заданному порядковому номеру.
        /// </summary>
        /// <param name="number">Порядковый номер столбца.</param>
        /// <returns></returns>
        static string NumberToLetters(int number)
        {
            string result;
            if (number > 0)
            {
                int alphabets = (number - 1) / 26;
                int remainder = (number - 1) % 26;
                result = ((char)('A' + remainder)).ToString();
                if (alphabets > 0)
                    result = NumberToLetters(alphabets) + result;
            }
            else
                result = null;
            return result;
        }

        /// <summary>
        /// функция расширения таблицы EXCELL с сохранением форматирования
        /// </summary>
        /// <param name="wSheet">лист книги</param>
        /// <param name="srcRange">диапазон с данными (range) (расширяемая строка таблицы)</param>
        /// <param name="spCount">количество строк на которое будем расширяться</param>
        /// <returns>Excel.Range</returns>
        private Excel.Range tableResize(Excel.Worksheet wSheet, Excel.Range srcRange, int spCount)
        {
            if (spCount > 1)
            {
                //скопируем, в координатах листа, сохраняя форматирование пришедщий диапазон в новый
                /*
                Excel.Range from = wSheet.Range[
                    wSheet.Cells[srcRange.Row, srcRange.Column], 
                    wSheet.Cells[srcRange.Row + srcRange.Rows.Count - 1, srcRange.Column + srcRange.Columns.Count - 1]];
                */
                Excel.Range to = wSheet.Range[
                    wSheet.Cells[srcRange.Row, srcRange.Column],
                    ((Excel.Range)wSheet.Cells[srcRange.Row + srcRange.Rows.Count - 1, srcRange.Column + srcRange.Columns.Count - 1]).Offset[spCount - srcRange.Rows.Count, 0]];

                //для метода Copy
                // строки каждая по одной без объединения иначе copy не сработает
                //srcRange.Copy(to);  //не работает про объединенных строках, сбрасывает объединения в столбцах

                //для метода AutoFill все ок но теряет высоту строк
                srcRange.AutoFill(Destination: to, Type: Excel.XlAutoFillType.xlFillDefault);

                return to;
            }
            return srcRange;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------

        /*--------------------------------------------------------------------------------------------------------------------------------------------
        'пересоздать листы в книге
        'Book - рабочая книга
        'shName - имя листа
        'Mode   - 0- очистить контент листа shName, 1-пересоздать лист shName, 2-удалить лист shName , 3-удалить листы кроме shName
        */
        //https://www.nookery.ru/c-work-c-excel/
        //https://razilov-code.ru/2017/12/13/microsoft-office-interop-excel/
        /*
        void RebuildSheet(Excel.Workbook Book, string shName, int mode) 
        {
            Excel.Worksheet worksheet;
            switch (mode)
            {
                case 0:                      //очистить контент листа shName
                    worksheet = (Excel.Worksheet)Book.Worksheets[shName];
                    worksheet.Cells.ClearContents();
                    worksheet.Visible = Excel.XlSheetVisibility.xlSheetHidden;  // True 'False ' True 'False
                    break;
                case 1:                      //пересоздать лист shName
                    foreach (Excel.Worksheet sheet in Book.Sheets)
                    {
                        if (shName == sheet.Name)
                        {
                            sheet.Delete();
                            break;
                        }
                    }
                    worksheet = (Excel.Worksheet)Book.Sheets.Add(After: Book.Sheets[Book.Sheets.Count]);
                    worksheet.Name = shName;
                    worksheet.Visible = Excel.XlSheetVisibility.xlSheetHidden;  // True 'False ' True 'False
                    break;
                case 2:                      //удалить лист shName
                    foreach (Excel.Worksheet sheet in Book.Sheets)
                    {
                        if (shName == sheet.Name)
                        {
                            sheet.Delete();
                            break;
                        }
                    }
                    break;
                case 3:                      //удалить листы кроме shName
                    foreach (Excel.Worksheet sheet in Book.Sheets)
                    {
                        if (shName != sheet.Name)
                        {
                            sheet.Delete();
                            break;
                        }
                    }
                    break;
            }   
        }
        */

        #endregion

        #region//CALLBACK InPut (подписка на внешние сообщения)

        /// <summary>
        /// Callbacks the reload.
        /// входящее асинхронное сообщение для подписанных слушателей с передачей текущих параметров
        /// </summary>
        /// <param name="typeForm">просто строка</param>
        /// <param name="nameForm">просто строка</param>
        /// <param name="param">параметры ключ-значение</param>
        private void CallbackReload(string typeForm, string nameForm, Dictionary<String, String> param)
        {
            this.Text = nameForm;
            this.AccessibleName = typeForm;
            switch (typeForm)
            {
                case "FormHeatCheck":
                    btFormTimePrint.Visible = false;
                    btReportTotalPrint.Visible = false;
                    break;
                case "FormTimeCheck":
                    btFormHeatPrint.Visible = false;
                    btReportTotalPrint.Visible = false;
                    break;
                case "ReportTotal":
                    btFormHeatPrint.Visible = false;
                    btFormTimePrint.Visible = false;
                    break;
            }
        }

        #endregion

    }

    #region//РАСШИРЕНИЯ для работы с датами

    public static class DateTimeDayOfMonthExtensions
    {
        //первый день месяца
        public static DateTime FirstDayOfMonth(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, 1);
        }
        //всего дней в месяце
        public static int DaysInMonth(this DateTime value)
        {
            return DateTime.DaysInMonth(value.Year, value.Month);
        }
        //последний день месяца
        public static DateTime LastDayOfMonth(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, value.DaysInMonth());
        }
        //первый день недели
        public static DateTime FirstDayOfWeek(this DateTime value, DayOfWeek firstDayOfWeek = DayOfWeek.Monday)
        {
            int diff = (7 + (value.DayOfWeek - firstDayOfWeek)) % 7;
            DateTime firstDay = value.AddDays(-1 * diff).Date;
            return firstDay;

            //            return value.AddDays((int)CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek -
            //                                            (int)value.DayOfWeek);

        }
    }

    #endregion
}
