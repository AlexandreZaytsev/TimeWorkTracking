﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
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

        private Excel.Application excelApp;
        private Excel.Workbook workBook;
        private Excel.Worksheet workSheet;
        private Excel.Range workRange;
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

        private void frmReport_Load(object sender, EventArgs e)
        {
            if (!clSystemChecks.checkProvider()) this.Close();
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
                dtSpecialMarks = clMsSqlDatabase.TableRequest(cs, "select * from SpecialMarks where uses=1");
            }
        }

        //изменение даты календаря
        private void mcReport_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (updateCalendar)         //проверка чтобы не срабатывало два раза
            {
                getRangeFromType();     //вычислить границы диапазона в зависимости от типа формы
                updateRange();          //проверка использования диапазона дат по умолчанию
//                uploadCaptionExel((int)(mcReport.SelectionRange.End - mcReport.SelectionRange.Start).TotalDays + 1);
            } 
        }
        //обновить длину диапазона при изменении
        private void mcReport_DateSelected(object sender, DateRangeEventArgs e)
        {
//            uploadCaptionExel((int)(mcReport.SelectionRange.End - mcReport.SelectionRange.Start).TotalDays + 1);
        }

        //вычислить границы диапазона в зависимости от типа формы
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
        //обновить диапазон в зависимости от текущей даты
        private void updateRange()
        {
            mcReport.MaxSelectionCount = chRange.Checked ? lengthRangeDays : 365;   //!!!Обязательно задать вначале (инача будет резать диапазон)
            updateCalendar = false;
            if (chRange.Checked) 
    //            mcReport.SetSelectionRange(firstDayRange, lastDayRange);
                mcReport.SetSelectionRange(firstDayRange, firstDayRange.AddDays(mcReport.MaxSelectionCount-1));
            //            mcReport.Select();
            updateCalendar = true;
        }

        //проверка флага использования диапазона дат по умолчанию
        private void chRange_CheckedChanged(object sender, EventArgs e)
        {
            getRangeFromType();     //вычислить границы диапазона в зависимости от типа формы
            updateRange();          //проверка использования диапазона дат по умолчанию
        }

        //------------------------------------------------------------------------------------------------------

        //Загрузить массив данных для заголовка Excel (с учетом объединенных ячеек - спользуем первое значение)
        private int uploadCaptionExcel(int lengthDays) 
        {
            DateTime tDate;
            captionData = null;
            int j=2;
            switch (this.AccessibleName)
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
                        captionData[2, i + 1+j] = "Ушел";
                        captionData[3, i + j] = "Специальные отметки";
                        j += 1;
                    }
                    break;
                case "ReportTotal":
                    headerIndex = new Dictionary<string, int>();    //подготовим словарь для хранения индексов колонок
                    captionData = new string[2, lengthDays + 2 + 3 + dtSpecialMarks.Rows.Count - 1 + 2 +1];  //Создаём новый двумерный массив
                    captionData[0, 0] = "№";
                    captionData[0, 0 + 1] = "Фамилия Имя Отчество";
                    for (int i = 0; i < lengthDays; i++)            //циклом перебираем даты в созданный двумерный массив
                    {
                        tDate = mcReport.SelectionStart.AddDays(i);
                        captionData[0, i + 2] = 
                            tDate.ToString("dd.MM.yyyy dddd").PadLeft(7) + "\r\n" + 
                            pCalendar.getDateDescription(tDate).PadLeft(7);
                    }
                    captionData[0, lengthDays + 1 + 1] = "недоработка".PadLeft(7);
                    headerIndex.Add("less", lengthDays + 1 + 1);
                    captionData[0, lengthDays + 1 + 2] = "(Я)Итого отработано".PadLeft(7);
                    headerIndex.Add("Я", lengthDays + 1 + 2);                                   //добавить значение словаря заголока      
                    captionData[0, lengthDays + 1 + 3] = "переработка".PadLeft(7);
                    headerIndex.Add("over", lengthDays + 1 + 3);

                    for (int i = 1; i < dtSpecialMarks.Rows.Count; i++)                         //Цикл по массиву спец отметок
                    {
                        DataRow drow = dtSpecialMarks.Rows[i];
                        if (drow.RowState != DataRowState.Deleted)                              //Only row that have not been deleted
                        {
                            headerIndex.Add(drow["letterCode"].ToString(), lengthDays + 4 + i); //добавить значение словаря заголока
                            captionData[0, lengthDays + 4 + i] = 
                                ("(" + drow["letterCode"].ToString() + ") " +
                                drow["name"].ToString()).PadLeft(7);
                        }
                    }
                    captionData[0, lengthDays + 3 + dtSpecialMarks.Rows.Count + 1] = "Итого спец. отметок".PadLeft(7);
                    headerIndex.Add("sum", lengthDays + 3 + dtSpecialMarks.Rows.Count + 1);
                    captionData[0, lengthDays + 3 + dtSpecialMarks.Rows.Count + 2] = "(из них вне графика)".PadLeft(7);
                    headerIndex.Add("in", lengthDays + 3 + dtSpecialMarks.Rows.Count + 2);
                    captionData[0, lengthDays + 3 + dtSpecialMarks.Rows.Count + 3] = "Сумма фактически отработаного РАБОЧЕГО ВРЕМЕНИ + CЛУЖЕБНЫЕ ЗАДАНИЯ задания вне его";
                    headerIndex.Add("out", lengthDays + 3 + dtSpecialMarks.Rows.Count + 3);

                    break;
            }
            return captionData.GetUpperBound(1);
        }

        //Загрузить массив данных для таблицы Excel (с учетом объединенных ячеек - спользуем первое значение)
        private int uploadTableExcel(int lenDays)
        {
            int j;// = 0;
             switch (this.AccessibleName)
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
                    tableData = new string[usersData.Rows.Count*2, lenDays+1];   //Создаём новый двумерный массив
                    j = 0;
                    for (int i = 0; i < usersData.Rows.Count; i++)     // Display items in the ListView control
                    {
                        DataRow drow = usersData.Rows[i];
                        if (drow.RowState != DataRowState.Deleted)  // Only row that have not been deleted
                        {
                            tableData[i + j, 0] = (i + 1).ToString();
                            tableData[i + j, 1] = drow["fio"].ToString();
                            for(int col=0; col < lenDays-1; col+=2) 
                            {
                                tableData[i + j, 2 + col] = Convert.ToDateTime(drow["startTime"]).ToString("HH:mm");
                                tableData[i + j, 3 + col] = Convert.ToDateTime(drow["stopTime"]).ToString("HH:mm");
                            }
                            j += 1;
                        }
                    }
                    break;
                case "ReportTotal":
                    string cs = Properties.Settings.Default.twtConnectionSrting;    //connection string
                    //Загрузить массив сводных данных для тотального
                    totalReportData = clMsSqlDatabase.TableRequest(cs, "EXEC twt_TotalReport '" + mcReport.SelectionStart.ToString("yyyyMMdd") + "','" + mcReport.SelectionEnd.ToString("yyyyMMdd") + "'");
                                        tableData = new string[totalReportData.Rows.Count * 2, 2 + lenDays + 3 + dtSpecialMarks.Rows.Count - 1 + 2 + 1];   //Создаём новый двумерный массив
                    //var tableData = new[,];//[totalReportData.Rows.Count * 2, 2 + lenDays + 3 + dtSpecialMarks.Rows.Count - 1 + 2 + 1];

                    string[] splitValue = new string[5];                            //шесть параметров упакованных в день
                    double timeScheduleWithoutLunch;                                //фактическое время без обеда
                    double timeScheduleLess;                                        //время недоработки    
                    double timeScheduleOver;                                        //время переработки
                    string specmarkShortName;                                       //короткое имя спец отметок
                    double totalHoursInWork;                                        //часов в рамках рабочего дня
                    double totalHoursOutsideWork;                                   //часов за рамками рабочего дня    
                    double specmarkValue;                                           //переменная для хранения текущего значения спец отметки    
                    double specmarkSum;                                             //переменная для подсчета суммы спец отметок
                    string formatName = "N8";// "F8";                               //формат строки для преобразований

                    j = 0;
                    for (int i = 0; i < totalReportData.Rows.Count; i++)            //Цикл по строкам отчета
                    {
                        DataRow drow = totalReportData.Rows[i];
                        if (drow.RowState != DataRowState.Deleted)                  // Only row that have not been deleted
                        {
                            tableData[i + j, 0] = (i + 1).ToString();
                            tableData[i + j, 1] = drow[1].ToString();               //должность (первая строка)
                            tableData[i + j + 1, 1] = drow[0].ToString();           //фио (вторая строка)
                            specmarkValue = 0;
                            specmarkSum = 0;
                            for (int col = 0; col < lenDays - 1; col++)             //Цикл по колонкам календаря отчета
                            {
                                if (drow[4 + col] != System.DBNull.Value)           //Если данные для обработки на дату есть 
                                {
                                    //РАБОТАЕМ СО СТРОКАМИ - ОБЯЗАТЕЛЬНОЕ ФОРМАТИРОВАНИЕ В КУЛЬТУРЕ + 8 ДЕСЯТИЧНЫХ ЗНАКОВ (см. ниже проблемы вставки в EXCEL) 

                                    //распакуем пришедшие данные в массив
                                    splitValue = drow[4 + col].ToString().Substring(1, drow[4 + col].ToString().Length - 2).Split(new[] { "|" }, StringSplitOptions.None);

                                    //Спецотметка (короткое имя) (первая строка)
                                    tableData[i + j, 2 + col] = splitValue[3];                          //в диапазоне дат        
                                    tableData[i + j, headerIndex[splitValue[3]]] = splitValue[3];       //в диапазоне спец отметок

                                    //Текущее значение спецотметки
                                    specmarkValue = (Convert.ToDouble(splitValue[0]) / 60);
                                    //Корректировка значений спец отметок
                                    switch (splitValue[3])
                                    {
                                        case "УД":
                                            specmarkValue = 0;
                                            break;
                                    }

                                    //Корректировка недоработки переработки для спецотметки "Я"
                                    switch (splitValue[3])
                                    {
                                        case "Я":
                                            //вспомогательное время
                                            timeScheduleLess = (Convert.ToDouble(splitValue[1]) / 60);  //недоработка 
                                            timeScheduleOver = (Convert.ToDouble(splitValue[2]) / 60);  //переработка 
                                            //коррекция на +/-
                                            timeScheduleLess = (timeScheduleOver - timeScheduleLess) < 0 ? Math.Abs(specmarkValue) : 0;
                                            timeScheduleOver = (timeScheduleOver - timeScheduleLess) < 0 ? 0 : Math.Abs(specmarkValue);
                                            //недоработка (вторая строка)
                                            tableData[i + j + 1, headerIndex["less"]] = timeScheduleLess.ToString(formatName, CultureInfo.InvariantCulture);
                                            //переработка (вторая строка)
                                            tableData[i + j + 1, headerIndex["over"]] = timeScheduleOver.ToString(formatName, CultureInfo.InvariantCulture);
                                            break;
                                    }

                                    //значение спецотметки в диапазоне дат
                                    tableData[i + j + 1, 2 + col] = specmarkValue.ToString(formatName, CultureInfo.InvariantCulture);
                                    //суммы спецотметок в диапазоне спецотметок
                                    specmarkSum = tableData[i + j + 1, headerIndex[splitValue[3]]] == null ? 0 : Double.Parse(tableData[i + j + 1, headerIndex[splitValue[3]]], CultureInfo.InvariantCulture);
                                    specmarkSum = specmarkSum + specmarkValue;
                                    tableData[i + j + 1, headerIndex[splitValue[3]]] = specmarkSum.ToString(formatName, CultureInfo.InvariantCulture);

                                    //время отработанное в пределах рабочего дня
                                    tableData[i + j + 1, headerIndex["in"]] = (Convert.ToDouble(splitValue[4]) / 60).ToString(formatName, CultureInfo.InvariantCulture);//CurrentCulture);
                                    //время отработанное вне пределов рабочего дня
                                    tableData[i + j + 1, headerIndex["out"]] = (Convert.ToDouble(splitValue[5]) / 60).ToString(formatName, CultureInfo.InvariantCulture);


                                    //Коррекция итогов 
                                    switch (splitValue[3])
                                    {
                                        case "СЗ":                                                      //добавим к итогам время отработанное вне пределов рабочего дня
                                            tableData[i + j + 1, headerIndex[splitValue[3]]] += Double.Parse(tableData[i + j + 1, headerIndex["out"]], CultureInfo.InvariantCulture);
                                            break;
                                    }
                                }
                            }
                            j += 1;
                        }
                    }
                    break;
            }
            return usersData.Rows.Count;
        }

        //Загрузить Производственный календарь Data из DataSet в Calendar
        private void LoadBoldedDatesCalendar(List<DateTime> dList)
        {
            mcReport.RemoveAllBoldedDates();                           //Сбросить все непериодические даты
            foreach (DateTime dt in dList)
            {
                mcReport.AddBoldedDate(dt);
            }
            mcReport.UpdateBoldedDates();
        }

        //проверить соединение с базами
        private bool CheckConnects()
        {
            //проверка соединения с SQL
            string cs = Properties.Settings.Default.twtConnectionSrting;    //connection string
            bool conSQL = clMsSqlDatabase.CheckConnectWithConnectionStr(cs);
            mainPanelReport.Enabled = conSQL;
            return conSQL;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------
        //напечатать бланк температуры
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
        private bool FormHeatPrint()
        {
            Cursor.Current = Cursors.WaitCursor;
            bool ret;// = false;
            int daysCount = (int)(mcReport.SelectionRange.End - mcReport.SelectionRange.Start).TotalDays + 1;
            int arrCount = uploadCaptionExcel(daysCount);
            uploadTableExcel(arrCount);                                     //загрузить массив по данным сотрудников

            toolStripStatusLabelInfo.Text = "Подключение к Excel";
            //Объявляем приложение
            excelApp = new Excel.Application
            {
                Visible = false,                                            //Отобразить Excel
                SheetsInNewWorkbook = 1                                     //Количество листов в рабочей книге    
            };
            workBook = excelApp.Workbooks.Add(mis);                         //Добавить рабочую книгу

            toolStripStatusLabelInfo.Text = "Создание рабочей книги";
            //Настройки Application установить
            excelApp.DisplayAlerts = false;                                 //Запретить отображение окон с сообщениями
            excelApp.ScreenUpdating = false;                                //Запретить перерисовку экрана    
            excelApp.ActiveWindow.Zoom = 80;                                //Масштаб листа
            excelApp.ActiveWindow.View = Excel.XlWindowView.xlPageBreakPreview;

            //Переименовать лист
            workSheet = (Excel.Worksheet)excelApp.Worksheets.get_Item(1);   //Получаем первый лист документа (счет начинается с 1)
            workSheet.Name = "Journal";                                     //Название листа (вкладки снизу)
            //RebuildSheet(workBook, "Journal", 3);                         // удалить все листы кроме текущего
            ((Excel.Range)workSheet.Cells).FormatConditions.Delete();       //удалить все форматы с листа

            //оформление листа и применение стиля
            Excel.Style style = workBook.Styles.Add("reportStyle");
            style.Font.Name = "Times New Roman";
            style.Font.Size = 11;

            toolStripStatusLabelInfo.Text = "Настройка листа";
            //ширина колонок
            ((Excel.Range)workSheet.Cells).Style = "reportStyle";
            ((Excel.Range)workSheet.Columns[1]).ColumnWidth = 2;
            ((Excel.Range)workSheet.Columns[1 +2 + captionData.GetUpperBound(1)]).EntireColumn.ColumnWidth = 2;

            toolStripStatusLabelInfo.Text = "Настройка границ листа";
            //настройки печати
            double interval = excelApp.CentimetersToPoints(0.2);
            workSheet.PageSetup.LeftMargin = interval;
            workSheet.PageSetup.RightMargin = interval;
            workSheet.PageSetup.TopMargin = interval;
            workSheet.PageSetup.BottomMargin = interval;
            workSheet.PageSetup.HeaderMargin = 0;// excelApp.InchesToPoints(0);
            workSheet.PageSetup.FooterMargin = interval;
            workSheet.PageSetup.PrintTitleRows = "$1:$7";                                      //печать заголовков на каждой странице
            workSheet.PageSetup.PrintTitleColumns = "";
            workSheet.PageSetup.FirstPageNumber = (int)Excel.Constants.xlAutomatic; //номер первой страници
//            workSheet.PageSetup.CenterFooter = "&B Страница &P";
            workSheet.PageSetup.LeftFooter = "&B Секретно&B";
            workSheet.PageSetup.CenterFooter = "&D";
            workSheet.PageSetup.RightFooter = "Страница &P из &N";

            toolStripStatusLabelInfo.Text = "Настройка ориентации листа и ограничений";
            workSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
            workSheet.PageSetup.Zoom = 83;// false;                                       // 83; //% от натуральной величины
//            workSheet.PageSetup.FitToPagesWide = 1;                                 //не более чем на количество страниц в ширину           
//            workSheet.PageSetup.FitToPagesTall = 1;                                 //не более чем на количество страниц в высоту    

            //поехали
            toolStripStatusLabelInfo.Text = "Скрыть лишние строки";
            ((Excel.Range)workSheet.Rows[2]).EntireRow.Hidden = true;               //скрыть строку
            ((Excel.Range)workSheet.Rows[3]).EntireRow.Hidden = true;
            ((Excel.Range)workSheet.Rows[6]).EntireRow.Hidden = true;

            toolStripStatusLabelInfo.Text = "Создание заголовка";
            //диапазон для заголовка (главная надпись) (2 строки)
            workRange = workSheet.Range[workSheet.Cells[4, 2-1], workSheet.Cells[5, 2 + captionData.GetUpperBound(1)+1]];
                workRange.Font.Name = "Times New Roman";
                workRange.Font.Size = 11;
                ((Excel.Range)workRange.Rows[1]).Merge(mis);                        //объединить строку диапазона
                ((Excel.Range)workRange.Rows[2]).Merge(mis);                        //объединить строку диапазона
                workRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                workRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                workRange.Font.Bold = true;
                workRange.Font.Name = "Times New Roman";
                workRange.Font.Size = 14;
                workRange.Cells[1, 1] = "Журнал учета средней температуры сотрудников " + Properties.Settings.Default.companyName;   //наименование компании
                workRange.Cells[2, 1] = "Период: " + mcReport.SelectionStart.ToString("dd.MM.yyyy") + " - " + mcReport.SelectionEnd.ToString("dd.MM.yyyy");

            toolStripStatusLabelInfo.Text = "Создание шапки таблицы и строки данных";
            //диапазон для шапки таблицы и первой строки данных (3 строки)
            workRange = workSheet.Range[workSheet.Cells[8, 2], workSheet.Cells[10, 1 + captionData.GetUpperBound(1)+1]];    //+1 на строку данных
//                ((Excel.Range)workRange.Rows).AutoFit();                                                    //автоувеличение строк в заголовке
                workRange.Font.Name = "Times New Roman";
                workRange.Font.Size = 11;
                workRange.Interior.TintAndShade = 0;// '0.2
                workRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                workRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                workRange.WrapText = true;
                workRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;               //нарисуем все рамки

            //настройка ширины колонок и высоты строк диапазона                                                                            
                ((Excel.Range)workRange.Rows[1]).RowHeight = 28.5;                          //высота первой строки 
                ((Excel.Range)workRange.Columns[1]).ColumnWidth = 3.5;                      //ширина колонки с номером
                ((Excel.Range)workRange.Columns[2]).ColumnWidth = 38.5;                     //ширина колонки ФИО 
//                ((Excel.Range)workRange.Rows[3]).RowHeight = 20;                          //высота строки данных
                string colsChar =
                NumberToLetters(((Excel.Range)workRange.Columns[3]).Column) + ":" +
                NumberToLetters(((Excel.Range)workRange.Columns[3+daysCount*2-1]).Column);
                ((Excel.Range)workSheet.Columns[colsChar]).ColumnWidth = 11.56; //ширина колонок с датами 
            //управление шрифтами и выравниванием
                ((Excel.Range)workRange.Rows[1]).Font.Bold = true;                          //первая строка шапки
                ((Excel.Range)workRange.Rows[2]).Font.Size = 9;                             //вторая строка шапки
                ((Excel.Range)workRange.Rows[3]).Font.Size = 11;                            //третья строка шапки (строка данных)
                ((Excel.Range)workSheet.Range[workRange.Cells[3, 3], workRange.Cells[3, workRange.Columns.Count]]).Font.Size = 16;
                ((Excel.Range)workRange.Range[workSheet.Cells[2, 1], workSheet.Cells[3, 2]]).Font.Bold = true;
                ((Excel.Range)workSheet.Range[workRange.Cells[2, 3], workRange.Cells[2, workRange.Columns.Count]]).VerticalAlignment = Excel.XlVAlign.xlVAlignTop;
                ((Excel.Range)workRange.Cells[3, 2]).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                //температуру влево с отступом
                ((Excel.Range)workSheet.Range[workRange.Cells[3, 3], workRange.Cells[3, workRange.Columns.Count]]).HorizontalAlignment= Excel.XlHAlign.xlHAlignLeft;
                ((Excel.Range)workSheet.Range[workRange.Cells[3, 3], workRange.Cells[3, workRange.Columns.Count]]).IndentLevel = 2;

            //заливка цветом
            ((Excel.Range)workSheet.Range[workRange.Cells[1, 1], workRange.Cells[1,2]]).Interior.Color = ColorTranslator.ToOle(Color.LightGray);   //заливка первой строки цветом
                ((Excel.Range)workSheet.Range[workRange.Cells[1, 3], workRange.Cells[1, workRange.Columns.Count]]).Interior.Color = ColorTranslator.ToOle(Color.LightGreen);
            ((Excel.Range)workSheet.Range[workRange.Cells[3, 3], workRange.Cells[3, workRange.Columns.Count]]).Font.Color = ColorTranslator.ToOle(Color.Gainsboro);//.WhiteSmoke);//.LightGray);
                                                                                                                                                                        //строка данных значения по умолчанию
            //workRange.Rows[3]= "36,3\u00B0";
            workRange.Rows[3] = String.Format("{0}°C", 36.3);
            //workRange.Cells[3, 3] = "36,3\u00B0";


            toolStripStatusLabelInfo.Text = "Вставка условного форматирования шапки таблицы";
                //условное форматирование диапазона 
                Excel.FormatConditions fcs = ((Excel.Range)workRange.Rows[1]).EntireRow.FormatConditions;
                Excel.FormatCondition fc = (Excel.FormatCondition)fcs.Add(
                    Type:Excel.XlFormatConditionType.xlExpression,
                    mis, //Excel.XlFormatConditionOperator.xlNotEqual,//.xlEqual,
                    Formula1: "=ЕЧИСЛО(НАЙТИ(\"Рабочий\";A9))",
                    mis, mis, mis, mis, mis);

                fc.Interior.PatternColorIndex = Excel.Constants.xlAutomatic;
                fc.Interior.ThemeColor = Excel.XlThemeColor.xlThemeColorAccent3;
//              fc.Interior.Color = ColorTranslator.ToWin32(Color.White);
                fc.Interior.TintAndShade = 0.599963377788629;
                fc.StopIfTrue = false;

            toolStripStatusLabelInfo.Text = "Настройка объединения ячеек";
            //объединение столбцов
                workSheet.Range[workRange.Cells[1, 1], workRange.Cells[2, 1]].Merge(mis);
                workSheet.Range[workRange.Cells[1, 2], workRange.Cells[2, 2]].Merge(mis);
                int j = 2;
                for (int i = 1; i <= captionData.GetUpperBound(1)/2; i++)
                {
                    workSheet.Range[workRange.Cells[1, i + j], workRange.Cells[1, i + j + 1]].Merge(mis);
                    workSheet.Range[workRange.Cells[2, i + j], workRange.Cells[2, i + j + 1]].Merge(mis);
                    workSheet.Range[workRange.Cells[3, i + j], workRange.Cells[3, i + j + 1]].Merge(mis);
                    j += 1;
                }

            toolStripStatusLabelInfo.Text = "Вставка данных заголовка";
                //вставим данные в заголовок одним куском
                workRange.Resize[
                    captionData.GetUpperBound(0) + 1, 
                    captionData.GetUpperBound(1) + 1
                    ].Value = captionData;

//            string used = workRange.Address[false, false, Excel.XlReferenceStyle.xlA1, mis, mis];

            toolStripStatusLabelInfo.Text = "Вставка данных таблицы";
            //расширим форматированную таблицу данных
            Excel.Range fullTable = tableResize(
                workSheet,
                (Excel.Range)workRange.Rows[3],//(Excel.Range)workSheet.Cells[workRange.Row + workRange.Rows.Count - 1, workRange.Column],
                tableData.GetUpperBound(0) + 1
                );
            //       fullTable.Value = tableData; 
            //подрежем таблицу до двух колонок (т.к. в пришедших данных их только две)
            //вставим данные в таблицу одним куском
            fullTable.Resize[
                    tableData.GetUpperBound(0) + 1,
                    tableData.GetUpperBound(1) + 1
                    ].Value = tableData;

            toolStripStatusLabelInfo.Text = "Дополнительное форматирование";
            fullTable.Rows.RowHeight = 22;  //восстановить высоту строк в диапазоне данных

            toolStripStatusLabelInfo.Text = "Файл подготовлен";
            //Настройки Application вернуть обратно
            excelApp.DisplayAlerts = true;                                  //Разрешить отображение окон с сообщениями
            excelApp.ScreenUpdating = true;                                 //Зазрешить перерисовку экрана    
            excelApp.Visible = true;
//            excelApp.WindowState = Excel.XlWindowState.xlMinimized;         //Свернуть окно   
            //            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

            Cursor.Current = Cursors.Default;
            ret = true;

            return ret;
        }
        //напечатать бланк проходов
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
        private bool FormTimePrint()
        {
            Cursor.Current = Cursors.WaitCursor;
            bool ret;// = false;
            int daysCount = (int)(mcReport.SelectionRange.End - mcReport.SelectionRange.Start).TotalDays + 1;
            int arrCount = uploadCaptionExcel(daysCount);
            uploadTableExcel(arrCount);                                     //загрузить массив по данным сотрудников

            toolStripStatusLabelInfo.Text = "Подключение к Excel";
            //Объявляем приложение
            excelApp = new Excel.Application
            {
                Visible = false,                                            //Отобразить Excel
                SheetsInNewWorkbook = 1                                     //Количество листов в рабочей книге    
            };
            workBook = excelApp.Workbooks.Add(mis);                         //Добавить рабочую книгу

            toolStripStatusLabelInfo.Text = "Создание рабочей книги";
            //Настройки Application установить
            excelApp.DisplayAlerts = false;                                 //Запретить отображение окон с сообщениями
            excelApp.ScreenUpdating = false;                                //Запретить перерисовку экрана    
            excelApp.ActiveWindow.Zoom = 80;                                //Масштаб листа
            excelApp.ActiveWindow.View = Excel.XlWindowView.xlPageBreakPreview;

            //Переименовать лист
            workSheet = (Excel.Worksheet)excelApp.Worksheets.get_Item(1);   //Получаем первый лист документа (счет начинается с 1)
            workSheet.Name = "Journal";                                     //Название листа (вкладки снизу)
            //RebuildSheet(workBook, "Journal", 3);                         // удалить все листы кроме текущего
            ((Excel.Range)workSheet.Cells).FormatConditions.Delete();       //удалить все форматы с листа

            //оформление листа и применение стиля
            Excel.Style style = workBook.Styles.Add("reportStyle");
            style.Font.Name = "Times New Roman";
            style.Font.Size = 11;

            toolStripStatusLabelInfo.Text = "Настройка листа";
            //ширина колонок
            ((Excel.Range)workSheet.Cells).Style = "reportStyle";
            ((Excel.Range)workSheet.Columns[1]).ColumnWidth = 2;
            ((Excel.Range)workSheet.Columns[1 + 2 + captionData.GetUpperBound(1)]).EntireColumn.ColumnWidth = 2;

            toolStripStatusLabelInfo.Text = "Настройка границ листа";
            //настройки печати
            double interval = excelApp.CentimetersToPoints(0.2);
            workSheet.PageSetup.LeftMargin = interval;
            workSheet.PageSetup.RightMargin = interval;
            workSheet.PageSetup.TopMargin = interval;
            workSheet.PageSetup.BottomMargin = excelApp.CentimetersToPoints(1.3); 
            workSheet.PageSetup.HeaderMargin = 0;// excelApp.InchesToPoints(0);
            workSheet.PageSetup.FooterMargin = interval;
            workSheet.PageSetup.PrintTitleRows = "$1:$11";                                      //печать заголовков на каждой странице
            workSheet.PageSetup.PrintTitleColumns = "";
            workSheet.PageSetup.FirstPageNumber = (int)Excel.Constants.xlAutomatic; //номер первой страници
//            workSheet.PageSetup.CenterFooter = "Страница  &P из &N";
            workSheet.PageSetup.LeftFooter = "&B Секретно&B";
            workSheet.PageSetup.CenterFooter = "&D";
            workSheet.PageSetup.RightFooter = "Страница &P из &N";


            toolStripStatusLabelInfo.Text = "Настройка ориентации листа и ограничений";
            workSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
            workSheet.PageSetup.Zoom = 83;// false;                                       // 83; //% от натуральной величины
                                          //            workSheet.PageSetup.FitToPagesWide = 1;                                 //не более чем на количество страниц в ширину           
                                          //            workSheet.PageSetup.FitToPagesTall = 1;                                 //не более чем на количество страниц в высоту    

            //поехали
            toolStripStatusLabelInfo.Text = "Скрыть лишние строки";
            ((Excel.Range)workSheet.Rows[2]).EntireRow.Hidden = true;               //скрыть строку
            ((Excel.Range)workSheet.Rows[3]).EntireRow.Hidden = true;
            ((Excel.Range)workSheet.Rows[6]).EntireRow.Hidden = true;

            toolStripStatusLabelInfo.Text = "Создание заголовка";
            //диапазон для заголовка (главная надпись) (2 строки)
            workRange = workSheet.Range[workSheet.Cells[4, 2 - 1], workSheet.Cells[5, 2 + captionData.GetUpperBound(1) + 1]];
                workRange.Font.Name = "Times New Roman";
                workRange.Font.Size = 11;
                ((Excel.Range)workRange.Rows[1]).Merge(mis);                        //объединить строку диапазона
                ((Excel.Range)workRange.Rows[2]).Merge(mis);                        //объединить строку диапазона
                workRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                workRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                workRange.Font.Bold = true;
                workRange.Font.Name = "Times New Roman";
                workRange.Font.Size = 14;
                workRange.Cells[1, 1] = "Журнал учета рабочего времени сотрудников " + Properties.Settings.Default.companyName;   //наименование компании
                workRange.Cells[2, 1] = "Период: " + mcReport.SelectionStart.ToString("dd.MM.yyyy") + " - " + mcReport.SelectionEnd.ToString("dd.MM.yyyy");

            toolStripStatusLabelInfo.Text = "Создание шапки таблицы и строк данных";
            //диапазон для шапки таблицы и первой строки данных
            workRange = workSheet.Range[workSheet.Cells[8, 2], workSheet.Cells[13, 1 + captionData.GetUpperBound(1) + 1]];    //+1 на строку данных
                                                                                                                             //                ((Excel.Range)workRange.Rows).AutoFit();                                                    //автоувеличение строк в заголовке
                workRange.Font.Name = "Times New Roman";
                workRange.Font.Size = 11;
                workRange.Interior.TintAndShade = 0;// '0.2
                workRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                workRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                workRange.WrapText = true;
                workRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;                               //нарисуем все рамки

            //настройка ширины колонок и высоты строк диапазона 
                ((Excel.Range)workRange.Columns[1]).ColumnWidth = 3.5;          //ширина колонки с номером
                ((Excel.Range)workRange.Columns[2]).ColumnWidth = 38.5;         //ширина колонки ФИО 
                ((Excel.Range)workRange.Rows[1]).RowHeight = 28.5;              //высота первой строки
//                ((Excel.Range)workRange.Rows[5]).RowHeight = 20;                //высота строки данных
//                ((Excel.Range)workRange.Rows[6]).RowHeight = 20;                //высота строки данных
                string colsChar =
                    NumberToLetters(((Excel.Range)workRange.Columns[3]).Column) + ":" +
                    NumberToLetters(((Excel.Range)workRange.Columns[3 + daysCount * 2 - 1]).Column);
                ((Excel.Range)workSheet.Columns[colsChar]).ColumnWidth = 11.56; //ширина колонок с датами 
            //управление шрифтами и выравниванием
                ((Excel.Range)workRange.Rows[1]).Font.Bold = true;              //первая строка шапки
                ((Excel.Range)workRange.Rows[2]).Font.Size = 9;                 //вторая строка шапки
                ((Excel.Range)workRange.Rows["3:4"]).Font.Bold = true;          //первая строка шапки
                ((Excel.Range)workSheet.Range[workRange.Cells[2, 3], workRange.Cells[2, workRange.Columns.Count]]).VerticalAlignment = Excel.XlVAlign.xlVAlignTop;
                ((Excel.Range)workRange.Rows[5]).Font.Size = 11;                                            //пятая строка шапки (строка данных)
                ((Excel.Range)workRange.Range[workSheet.Cells[5, 1], workSheet.Cells[6, 2]]).Font.Bold = true;
                ((Excel.Range)workRange.Cells[5, 2]).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                ((Excel.Range)workSheet.Range[workRange.Cells[5, 3], workRange.Cells[5, workRange.Columns.Count]]).Font.Size = 16;
            //заливка цветом
                ((Excel.Range)workSheet.Range[workRange.Cells[1, 1], workRange.Cells[1, 2]]).Interior.Color = ColorTranslator.ToOle(Color.LightGray);   //заливка первой строки цветом
                ((Excel.Range)workSheet.Range[workRange.Cells[1, 3], workRange.Cells[1, workRange.Columns.Count]]).Interior.Color = ColorTranslator.ToOle(Color.LightGreen);
                ((Excel.Range)workRange.Rows["3:4"]).Interior.Color = ColorTranslator.ToOle(Color.LightGray);
            ((Excel.Range)workSheet.Range[workRange.Cells[5, 3], workRange.Cells[5, workRange.Columns.Count]]).Font.Color = ColorTranslator.ToOle(Color.Gainsboro);//.WhiteSmoke);//.LightGray);
                                                                                                                                                                   //строка данных значения по умолчанию
            workRange.Rows[5] = "00:00";

                toolStripStatusLabelInfo.Text = "Вставка условного форматирования шапки таблицы";
            //условное форматирование диапазона 
                Excel.FormatConditions fcs = ((Excel.Range)workRange.Rows[1]).EntireRow.FormatConditions;
                Excel.FormatCondition fc = (Excel.FormatCondition)fcs.Add(
                    Type: Excel.XlFormatConditionType.xlExpression,
                    mis, //Excel.XlFormatConditionOperator.xlEqual,
                    Formula1: "=ЕЧИСЛО(НАЙТИ(\"Рабочий\";A9))",
                    mis, mis, mis, mis, mis);

                fc.Interior.PatternColorIndex = Excel.Constants.xlAutomatic;
                fc.Interior.ThemeColor = Excel.XlThemeColor.xlThemeColorAccent3;
            //              fc.Interior.Color = ColorTranslator.ToWin32(Color.White);
                fc.Interior.TintAndShade = 0.599963377788629;
                fc.StopIfTrue = false;

                toolStripStatusLabelInfo.Text = "Настройка объединения ячеек";
            //настройка ширины колонок и объединение ячеек диапазона
                workSheet.Range[workRange.Cells[1, 1], workRange.Cells[4, 1]].Merge(mis);
                workSheet.Range[workRange.Cells[1, 2], workRange.Cells[4, 2]].Merge(mis);
                workSheet.Range[workRange.Cells[5, 1], workRange.Cells[6, 1]].Merge(mis);
                workSheet.Range[workRange.Cells[5, 2], workRange.Cells[6, 2]].Merge(mis);

                int j = 2;
                for (int i = 1; i <= captionData.GetUpperBound(1) / 2; i++)
                {
                    workSheet.Range[workRange.Cells[1, i + j], workRange.Cells[1, i + j + 1]].Merge(mis);
                    workSheet.Range[workRange.Cells[2, i + j], workRange.Cells[2, i + j + 1]].Merge(mis);
                    workSheet.Range[workRange.Cells[4, i + j], workRange.Cells[4, i + j + 1]].Merge(mis);
                    workSheet.Range[workRange.Cells[6, i + j], workRange.Cells[6, i + j + 1]].Merge(mis);
                    j += 1;
                }

                toolStripStatusLabelInfo.Text = "Вставка данных заголовка";
            //вставим данные в заголовок одним куском
                workRange.Resize[
                    captionData.GetUpperBound(0) + 1,
                    captionData.GetUpperBound(1) + 1
                    ].Value = captionData;

            //            string used = workRange.Address[false, false, Excel.XlReferenceStyle.xlA1, mis, mis];

            toolStripStatusLabelInfo.Text = "Вставка данных таблицы";
            //расширим форматированную таблицу данных
            Excel.Range fullTable = tableResize(
                workSheet,
                workSheet.Range[
                    workSheet.Cells[workRange.Row + workRange.Rows.Count - 1 - 1, workRange.Column],
                    workSheet.Cells[workRange.Row + workRange.Rows.Count - 1 , workRange.Column + workRange.Columns.Count - 1]],
                tableData.GetUpperBound(0) + 1
                );
            fullTable.Value = tableData;

            toolStripStatusLabelInfo.Text = "Дополнительное форматирование";
            fullTable.Rows.RowHeight = 20;  //восстановить высоту строк в диапазоне данных

            toolStripStatusLabelInfo.Text = "Файл подготовлен";
            //Настройки Application вернуть обратно
            excelApp.DisplayAlerts = true;                                 //Разрешить отображение окон с сообщениями
            excelApp.ScreenUpdating = true;                                //Зазрешить перерисовку экрана    
            excelApp.Visible = true;
            //            excelApp.WindowState = Excel.XlWindowState.xlMinimized;         //Свернуть окно 
            //            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

            Cursor.Current = Cursors.Default;
            ret = true;

            return ret;
        }

        //напечатать итоговый отчет
        private void btReportTotalPrint_Click(object sender, EventArgs e)
        {
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

        private bool ReportTotalPrint() 
        {
            Cursor.Current = Cursors.WaitCursor;
            bool ret;// = false;
            int daysCount = (int)(mcReport.SelectionRange.End - mcReport.SelectionRange.Start).TotalDays + 1;
            int arrCount = uploadCaptionExcel(daysCount);
            uploadTableExcel(daysCount);                                     //загрузить массив по данным сотрудников

            toolStripStatusLabelInfo.Text = "Подключение к Excel";
            //Объявляем приложение
            excelApp = new Excel.Application
            {
                Visible = true,//false,                                            //Отобразить Excel
                SheetsInNewWorkbook = 1                                     //Количество листов в рабочей книге    
            };
            workBook = excelApp.Workbooks.Add(mis);                         //Добавить рабочую книгу

            toolStripStatusLabelInfo.Text = "Создание рабочей книги";
            //Настройки Application установить
            excelApp.DisplayAlerts = false;                                 //Запретить отображение окон с сообщениями
            excelApp.ScreenUpdating = false;                                //Запретить перерисовку экрана    
            excelApp.ActiveWindow.Zoom = 80;                                //Масштаб листа
 //           excelApp.ActiveWindow.View = Excel.XlWindowView.xlPageBreakPreview;

            //Переименовать лист
            workSheet = (Excel.Worksheet)excelApp.Worksheets.get_Item(1);   //Получаем первый лист документа (счет начинается с 1)
            workSheet.Name = "Report";                                      //Название листа (вкладки снизу)
            //RebuildSheet(workBook, "Journal", 3);                         // удалить все листы кроме текущего
            ((Excel.Range)workSheet.Cells).FormatConditions.Delete();       //удалить все форматы с листа
            //((Excel.Range)workSheet.Cells).NumberFormat = "0;[Red]0";

            //оформление листа и применение стиля
            Excel.Style style = workBook.Styles.Add("reportStyle");
            style.Font.Name = "Calibri";//"Times New Roman";
            style.Font.Size = 10;// 11;

            toolStripStatusLabelInfo.Text = "Настройка листа";
            //ширина колонок
            ((Excel.Range)workSheet.Cells).Style = "reportStyle";
            ((Excel.Range)workSheet.Columns[1]).ColumnWidth = 2;
            ((Excel.Range)workSheet.Columns[1 + 2 + captionData.GetUpperBound(1)]).EntireColumn.ColumnWidth = 2;

            toolStripStatusLabelInfo.Text = "Настройка границ листа";
            //настройки печати
            double interval = excelApp.CentimetersToPoints(0.2);
            workSheet.PageSetup.LeftMargin = interval;
            workSheet.PageSetup.RightMargin = interval;
            workSheet.PageSetup.TopMargin = interval;
            workSheet.PageSetup.BottomMargin = excelApp.CentimetersToPoints(1.2); ;
            workSheet.PageSetup.HeaderMargin = 0;// excelApp.InchesToPoints(0);
            workSheet.PageSetup.FooterMargin = interval;
            workSheet.PageSetup.PrintTitleRows = "$1:$11";                                      //печать заголовков на каждой странице
            workSheet.PageSetup.PrintTitleColumns = "";
            workSheet.PageSetup.FirstPageNumber = (int)Excel.Constants.xlAutomatic; //номер первой страници
                                                                                    //            workSheet.PageSetup.CenterFooter = "Страница  &P из &N";
            workSheet.PageSetup.LeftFooter = "&B Секретно&B";
            workSheet.PageSetup.CenterFooter = "&D";
            workSheet.PageSetup.RightFooter = "Страница &P из &N";


            toolStripStatusLabelInfo.Text = "Настройка ориентации листа и ограничений";
            workSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
            workSheet.PageSetup.Zoom = 83;// false;                                       // 83; //% от натуральной величины
                                          //            workSheet.PageSetup.FitToPagesWide = 1;                                 //не более чем на количество страниц в ширину           
                                          //            workSheet.PageSetup.FitToPagesTall = 1;                                 //не более чем на количество страниц в высоту    

            //поехали
            toolStripStatusLabelInfo.Text = "Скрыть лишние строки";
            ((Excel.Range)workSheet.Rows["2:3"]).EntireRow.Hidden = true;               //скрыть строку
            ((Excel.Range)workSheet.Rows[7]).EntireRow.Hidden = true;

            toolStripStatusLabelInfo.Text = "Создание заголовка";
            //диапазон для заголовка (главная надпись) (2 строки)
            workRange = workSheet.Range[workSheet.Cells[4, 2 - 1], workSheet.Cells[5, 2 + captionData.GetUpperBound(1) + 1]];
                workRange.Font.Name = "Times New Roman";
                workRange.Font.Size = 11;
                ((Excel.Range)workRange.Rows[1]).Merge(mis);                        //объединить строку диапазона
                ((Excel.Range)workRange.Rows[2]).Merge(mis);                        //объединить строку диапазона
                workRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                workRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                workRange.Font.Bold = true;
                workRange.Font.Name = "Times New Roman";
                workRange.Font.Size = 14;
                workRange.Cells[1, 1] = "Отчет учета рабочего времени сотрудников " + Properties.Settings.Default.companyName;   //наименование компании
                workRange.Cells[2, 1] = "Период: " + mcReport.SelectionStart.ToString("dd.MM.yyyy") + " - " + mcReport.SelectionEnd.ToString("dd.MM.yyyy");

            toolStripStatusLabelInfo.Text = "Создание шапки таблицы и строки данных";
            //диапазон для шапки таблицы и первой строки данных
            workRange = workSheet.Range[workSheet.Cells[8, 2], workSheet.Cells[8 + captionData.GetUpperBound(0) + 1, 1 + captionData.GetUpperBound(1) + 1]];    //+1 на строку данных
                                                                                                                                                               //                ((Excel.Range)workRange.Rows).AutoFit();                                                    //автоувеличение строк в заголовке
                workRange.Font.Name = "Calibri";// "Times New Roman";
                workRange.Font.Size = 10;// 11;
                workRange.Interior.TintAndShade = 0;// '0.2
                workRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                workRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                workRange.WrapText = true;
//                workRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;   //нарисуем все рамки

            //настройка ширины колонок и высоты строк диапазона  
                ((Excel.Range)workRange.Rows[1]).RowHeight=145;                 //высота строки шапки
                ((Excel.Range)workRange.Columns[1]).ColumnWidth = 3.5;          //ширина колонки с номером
                ((Excel.Range)workRange.Columns[2]).ColumnWidth = 38.5;         //ширина колонки ФИО 
                string colsChar = 
                    NumberToLetters(((Excel.Range)workRange.Columns[3]).Column) + ":" +
                    NumberToLetters(((Excel.Range)workRange.Columns[3+daysCount]).Column);
                ((Excel.Range)workSheet.Columns[colsChar]).ColumnWidth = 4;     //ширина колонок с датами 
                colsChar =
                    NumberToLetters(((Excel.Range)workRange.Columns[3 + daysCount]).Column) + ":" +
                    NumberToLetters(((Excel.Range)workRange.Columns[3 + daysCount + 1 +3 + dtSpecialMarks.Rows.Count]).Column);
                ((Excel.Range)workSheet.Columns[colsChar]).ColumnWidth = 6;                                    //ширина колонок спец отметл + дополнительные 
                ((Excel.Range)workSheet.Columns[1 + 2 + captionData.GetUpperBound(1)-1]).ColumnWidth = 18;     //ширина последнего столбца

            //управление шрифтами и выравниванием
                ((Excel.Range)workRange.Rows[2]).Font.Size = 11;
                ((Excel.Range)workRange.Rows[3]).Font.Size = 11;

                ((Excel.Range)workRange.Rows[1]).Font.Bold = true;              //первая строка шапки
                ((Excel.Range)workRange.Cells[2, 2]).Font.Italic = true;
                ((Excel.Range)workRange.Cells[3, 2]).Font.Bold = true;

                ((Excel.Range)workSheet.Range[workRange.Cells[2, 2], workRange.Cells[3, 2]]).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                ((Excel.Range)workSheet.Range[workRange.Cells[1, 3], workRange.Cells[1, 3 + daysCount-1]]).VerticalAlignment = Excel.XlVAlign.xlVAlignBottom;
                ((Excel.Range)workSheet.Range[workRange.Cells[1, 3], workRange.Cells[1, 3 + daysCount-1]]).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                ((Excel.Range)workSheet.Range[workRange.Cells[1, 3 + daysCount], workRange.Cells[1, 3 + captionData.GetUpperBound(1) - 3]]).VerticalAlignment = Excel.XlVAlign.xlVAlignBottom;
                ((Excel.Range)workSheet.Range[workRange.Cells[1, 3], workRange.Cells[1, 3 + captionData.GetUpperBound(1) - 2]]).Orientation = 90;

            //заливка цветом
                ((Excel.Range)workSheet.Range[workRange.Cells[1, 3], workRange.Cells[1, 3 + daysCount-1]]).Interior.Color = ColorTranslator.ToOle(Color.LightBlue);
                ((Excel.Range)workSheet.Range[workRange.Cells[1, 3 + daysCount + 3], workRange.Cells[1, 3 + captionData.GetUpperBound(1) - 5]]).Interior.Color = ColorTranslator.ToOle(Color.LightBlue);
                ((Excel.Range)workRange.Cells[1, 3 + captionData.GetUpperBound(1) - 2]).Interior.Color = ColorTranslator.ToOle(Color.LightGreen);
                ((Excel.Range)workRange.Cells[2, 1]).Interior.Color = ColorTranslator.ToOle(Color.LightBlue);

            //форматирование диапазона данных 
                Excel.Range rFormat = workSheet.Range[workRange.Cells[3, 3], workRange.Cells[3, workRange.Columns.Count]];
            ((Excel.Range)rFormat).NumberFormat = "##0,0";// "0";// "##0,000";//"0;[Red]0";        //готовим Excel к приему пищи

            toolStripStatusLabelInfo.Text = "Вставка условного форматирования шапки таблицы";
            //условное форматирование диапазона 
               Excel.FormatConditions fcs = ((Excel.Range)workRange.Rows[1]).EntireRow.FormatConditions;
                Excel.FormatCondition fc = (Excel.FormatCondition)fcs.Add(
                    Type: Excel.XlFormatConditionType.xlExpression,
                    mis, //Excel.XlFormatConditionOperator.xlNotEqual,//.xlEqual,
                    Formula1: "=ЕЧИСЛО(НАЙТИ(\"Рабочий\";A8))",
                    mis, mis, mis, mis, mis);

                    fc.Interior.PatternColorIndex = Excel.Constants.xlAutomatic;
                    fc.Interior.ThemeColor = Excel.XlThemeColor.xlThemeColorAccent3;
            //              fc.Interior.Color = ColorTranslator.ToWin32(Color.White);
                    fc.Interior.TintAndShade = 0.599963377788629;
                    fc.StopIfTrue = false;

            toolStripStatusLabelInfo.Text = "Вставка данных заголовка";
            //вставим данные в заголовок одним куском
            workRange.Resize[
                captionData.GetUpperBound(0) + 1,
                captionData.GetUpperBound(1) + 1
                ].Value = captionData;

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

//            excelApp.DecimalSeparator = ".";                                    //сообщаем Excel что к нему придут числа с точкой в виде разделителя
//            excelApp.UseSystemSeparators = false;                               //отключаем Excel использование системного разделителя (запятая по умолчанию)
            //то что выше (две строки) нужно отключить если дальше используем замену точки на запятую - все равно не помогло для Excel 2010

            //расширим форматированную таблицу данных
            Excel.Range fullTable = tableResize(
                workSheet,
                workSheet.Range[
                    workSheet.Cells[workRange.Row + workRange.Rows.Count - 1 - 1, workRange.Column],
                    workSheet.Cells[workRange.Row + workRange.Rows.Count - 1, workRange.Column + workRange.Columns.Count - 1]],
                tableData.GetUpperBound(0) + 1
                );
            fullTable.Formula = tableData;                                      //!!!десятичные числа с точкой (чтобы Excel не ругался на число записанное как строка)
            toolStripStatusLabelInfo.Text = "Форматирование данных из строки в число";
            fullTable.Replace(".", ",");                                        //!!!меняем точку на запятую (чтобы Excel наконец то понял что ему передают число)(жуткий тормоз)
                                                                                // fullTable.Calculate();                                           //перечитать данные листа

//            excelApp.UseSystemSeparators = true;                                //включаем Excel использование системного разделителя (запятая по умолчанию)
            //то что выше (одна строка) нужно отключить если дальше используем замену точки на запятую - все равно не помогло для Excel 2010
            /*
                ---------------------------------------------------------------------------------------------------------------------------------------------------------------
            */

            toolStripStatusLabelInfo.Text = "Дополнительное форматирование";
            fullTable.Rows.RowHeight = 20;  //восстановить высоту строк в диапазоне данных

            toolStripStatusLabelInfo.Text = "Файл подготовлен";
            //Настройки Application вернуть обратно
            excelApp.DisplayAlerts = true;                                 //Разрешить отображение окон с сообщениями
            excelApp.ScreenUpdating = true;                                //Зазрешить перерисовку экрана    

            excelApp.Visible = true;
            //            excelApp.WindowState = Excel.XlWindowState.xlMinimized;         //Свернуть окно 
            //            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

            Cursor.Current = Cursors.Default;
            ret = true;

            return ret;
        }
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
        /*--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        ' функция расширения таблицы EXCELL с сохранением форматирования
        ' //  xlsDoc - документ Excel   (обязательно передавать документ, листа недостаточно)
        ' //  shName - имя лист рабочей книги Excel
        '   wShhet - лист книги
        '   srcRange - диапазон с данными (range) (расширяемая строка таблицы)
        '   spCount - количество строк на которое будем расширяться
        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
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
                    ((Excel.Range)wSheet.Cells[srcRange.Row + srcRange.Rows.Count - 1, srcRange.Column + srcRange.Columns.Count - 1]).Offset[spCount- srcRange.Rows.Count, 0]];

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

    /*--------------------------------------------------------------------------------------------  
    CALLBACK InPut (подписка на внешние сообщения)
    --------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Callbacks the reload.
        /// входящее асинхронное сообщение для подписанных слушателей с передачей текущих параметров
        // </summary>
        /// <param name="controlName">имя CTRL</param>
        /// <param name="controlParentName">имя родителя CNTRL</param>
        /// <param name="param">параметры ключ-значение.</param>
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

    }
    /*----------------------------------------------------------------------------------------------------------
        РАСШИРЕНИЯ
    -----------------------------------------------------------------------------------------------------------*/

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
}
