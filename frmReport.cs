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
        private clCalendar pCalendar;                   //класс производственный календаоь
        private DataTable dtSpecialMarks;               //специальные отметки

        private DateTime firstDayRange;                 //первый день диапазона  
        private DateTime lastDayRange;                  //последний день диапазона
        private int lengthRangeDays;                    //длина диапазона дат 
        bool updateCalendar = false;                    //отключение события календаря

        private Excel.Application excelApp;
        private Excel.Workbook workBook;
        private Excel.Worksheet workSheet;
        private Excel.Range workRange;
        object mis = Type.Missing;

        private string[,] captionData;                  //массив данных заголовка Excel
        private string[,] tableData;                    //массив данных таблицы Excel

        public frmReport()
        {
            //подписка события внешних форм 
            CallBack_FrmMain_outEvent.callbackEventHandler = new CallBack_FrmMain_outEvent.callbackEvent(this.CallbackReload);    //subscribe (listen) to the general notification
            InitializeComponent();
            pCalendar = new clCalendar();                                   //создать экземпляр класса Производственный календарь
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
                uploadTableExcel(cs);

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
                    lengthRangeDays = 5;// 7;// 5;
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
                        captionData[0, i + j] = tDate.ToString("dd MM yyyy г.\r\ndddd");
                        captionData[1, i + j] = pCalendar.getDateDescription(tDate);
                        j += 1;
                    }
                    break;
                case "FormTimeCheck":
                    captionData = new string[5, lengthDays * 2 + 2];  //Создаём новый двумерный массив
                    captionData[0, 0] = "№";
                    captionData[0, 1] = "Фамилия Имя Отчество";
                    for (int i = 0; i < lengthDays; i++)           //циклом перебираем даты в созданный двумерный массив
                    {
                        tDate = mcReport.SelectionStart.AddDays(i);
                        captionData[0, i + j] = tDate.ToString("dd MM yyyy г.\r\ndddd");
                        captionData[1, i + j] = pCalendar.getDateDescription(tDate);
                        captionData[2, i] = "Пришел";
                        captionData[2, i+1] = "Ушел";
                        captionData[1, i + j] = "Специальные отметки";
                        j += 1;
                    }
                    break;
                case "ReportTotal":
                    break;
            }
            return captionData.GetUpperBound(1);
        }

        //Загрузить массив данных для таблицы Excel (с учетом объединенных ячеек - спользуем первое значение)
        private int uploadTableExcel(string cs)
        {
            DataTable dtable = clMsSqlDatabase.TableRequest(cs, "select * from twt_GetUserInfo('') where access=1 order by fio");
            switch (this.AccessibleName)
            {
                case "FormHeatCheck":
                    tableData = new string[dtable.Rows.Count, 2];   //Создаём новый двумерный массив
                    for (int i = 0; i < dtable.Rows.Count; i++)     // Display items in the ListView control
                    {
                        DataRow drow = dtable.Rows[i];
                        if (drow.RowState != DataRowState.Deleted)  // Only row that have not been deleted
                        {
                            tableData[i, 0] = (i + 1).ToString();
                            tableData[i, 1] = drow["fio"].ToString();
                        }
                    }
                    break;
                case "FormTimeCheck":
                    break;
                case "ReportTotal":
                    break;
            }
            return dtable.Rows.Count;
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
            MessageBox.Show(
                "Журнал учета средней температуры по компании создан" + "\r\n" +
                " (см. новый файл Excel)" + "\r\n" + "\r\n" +
                "перейдите на него для печати документа" + "\r\n" +
                "после чего закройте БЕЗ сохранения",
                "Подготовка документов",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
                );
            toolStripStatusLabelInfo.Text = "Выберите диапазон";
        }
        private bool FormHeatPrint()
        {
            Cursor.Current = Cursors.WaitCursor;
            bool ret = false;
            int arrCount = uploadCaptionExcel((int)(mcReport.SelectionRange.End - mcReport.SelectionRange.Start).TotalDays + 1);

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
            workSheet.PageSetup.FirstPageNumber = (int)Excel.Constants.xlAutomatic; //номер первой страници
            workSheet.PageSetup.CenterFooter = "&B Страница &P";

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

            toolStripStatusLabelInfo.Text = "Формирование заголовка";
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
                workRange.Cells[1, 1] = "Журнал учета средней температуры сотрудников Русской Промышленной Компании";
                workRange.Cells[2, 1] = "Период: " + mcReport.SelectionStart.ToString("dd.MM.yyyy") + " - " + mcReport.SelectionEnd.ToString("dd.MM.yyyy");

            toolStripStatusLabelInfo.Text = "Форматирование заголовка и строки данных";
            //диапазон для шапки таблицы и первой строки данных
            workRange = workSheet.Range[workSheet.Cells[8, 2], workSheet.Cells[10, 1 + captionData.GetUpperBound(1)+1]];    //+1 на строку данных
//                ((Excel.Range)workRange.Rows).AutoFit();                                                    //автоувеличение строк в заголовке
                workRange.Font.Name = "Times New Roman";
                workRange.Font.Size = 11;
                workRange.Interior.TintAndShade = 0;// '0.2
                workRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                workRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                workRange.WrapText = true;
                workRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;                               //нарисуем все рамки
                ((Excel.Range)workSheet.Range[workRange.Cells[1, 1], workRange.Cells[1,2]]).Interior.Color = ColorTranslator.ToOle(Color.LightGray);   //заливка первой строки цветом
                ((Excel.Range)workSheet.Range[workRange.Cells[1, 3], workRange.Cells[1, workRange.Columns.Count]]).Interior.Color = ColorTranslator.ToOle(Color.LightGreen);
            //уточнение       
                ((Excel.Range)workRange.Rows[1]).Font.Bold = true;                                          //первая строка шапки
                ((Excel.Range)workRange.Rows[2]).Font.Size = 9;                                             //вторая строка шапки
//Свойства в диапазоне через workSheet        
            ((Excel.Range)workSheet.Range[workRange.Cells[2, 3], workRange.Cells[2, workRange.Columns.Count]]).VerticalAlignment = Excel.XlVAlign.xlVAlignTop;

                ((Excel.Range)workRange.Rows[3]).Font.Size = 11;                                            //третья строка шапки (строка данных)
                ((Excel.Range)workRange.Range[workSheet.Cells[2 , 1], workSheet.Cells[3, 2]]).Font.Bold = true;
                ((Excel.Range)workRange.Cells[3, 2]).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
//Свойства в диапазоне через workSheet 
                ((Excel.Range)workSheet.Range[workRange.Cells[3, 3], workRange.Cells[3, workRange.Columns.Count]]).Font.Color = ColorTranslator.ToOle(Color.LightGray);
                ((Excel.Range)workSheet.Range[workRange.Cells[3, 3], workRange.Cells[3, workRange.Columns.Count]]).Font.Size=16;
                //строка данных значения по умолчанию
                workRange.Rows[3]= "36,3\u00B0";

                toolStripStatusLabelInfo.Text = "Формирование условного форматирования заголовка";
                //условное форматирование диапазона 
                Excel.FormatConditions fcs = ((Excel.Range)workRange.Rows[1]).EntireRow.FormatConditions;
                Excel.FormatCondition fc = (Excel.FormatCondition)fcs.Add(
                    Type:Excel.XlFormatConditionType.xlExpression,
                    mis, //Excel.XlFormatConditionOperator.xlEqual,
                    Formula1: "=ЕЧИСЛО(НАЙТИ(\"Рабочий\";A9))",
                    mis, mis, mis, mis, mis);

                fc.Interior.PatternColorIndex = Excel.Constants.xlAutomatic;
                fc.Interior.ThemeColor = Excel.XlThemeColor.xlThemeColorAccent3;
//              fc.Interior.Color = ColorTranslator.ToWin32(Color.White);
                fc.Interior.TintAndShade = 0.599963377788629;
                fc.StopIfTrue = false;

                toolStripStatusLabelInfo.Text = "Нстройка ширины колонок и объединения ячеек";
                //настройка ширины колонок и объединение ячеек диапазона
                ((Excel.Range)workRange.Columns[1]).ColumnWidth = 3.5;          //ширина колонки с номером
                ((Excel.Range)workRange.Columns[2]).ColumnWidth = 38.5;         //ширина колонки ФИО 
                ((Excel.Range)workRange.Rows[1]).RowHeight = 28.5;              //высота первой строки 
                //объединение столбцов
                workSheet.Range[workRange.Cells[1, 1], workRange.Cells[2, 1]].Merge(mis);
                workSheet.Range[workRange.Cells[1, 2], workRange.Cells[2, 2]].Merge(mis);
                int j = 2;
                for (int i = 1; i <= captionData.GetUpperBound(1)/2; i++)
                {
                //Свойства в диапазоне через workSheet 
                workSheet.Range[workRange.Cells[1, i + j], workRange.Cells[1, i + j + 1]].ColumnWidth = 11.56;// 8;
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
            tableResize(
                workSheet, 
                workRange.Row + workRange.Rows.Count-1, 
                workRange.Column, 
                workRange.Column + workRange.Columns.Count-1, 
                tableData.GetUpperBound(0) + 1
                );
            //диапазон для таблицы
            workRange = workSheet.Range[
                workSheet.Cells[workRange.Row + workRange.Rows.Count - 1, workRange.Column], 
                workSheet.Cells[workRange.Row + workRange.Rows.Count - 1+captionData.GetUpperBound(0), workRange.Column + workRange.Columns.Count - 1]
                ];
            //вставим данные в таблицу одним куском
                workRange.Resize[
                    tableData.GetUpperBound(0) + 1, 
                    tableData.GetUpperBound(1) + 1
                    ].Value = tableData;

            toolStripStatusLabelInfo.Text = "Файл подготовлен";
            //Настройки Application вернуть обратно
            excelApp.DisplayAlerts = true;                                 //Разрешить отображение окон с сообщениями
            excelApp.ScreenUpdating = true;                                //Зазрешить перерисовку экрана    
            excelApp.Visible = true;
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
            MessageBox.Show(
                "Журнал учета рабочего времени создан" + "\r\n" +
                " (см. новый файл Excel)" + "\r\n" + "\r\n" +
                "перейдите на него для печати документа" + "\r\n" +
                "после чего закройте БЕЗ сохранения",
                "Подготовка документов",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
                );
            toolStripStatusLabelInfo.Text = "Выберите диапазон";
        }
        private bool FormTimePrint()
        {
            Cursor.Current = Cursors.WaitCursor;
            bool ret = false;
            int arrCount = uploadCaptionExcel((int)(mcReport.SelectionRange.End - mcReport.SelectionRange.Start).TotalDays + 1);

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
            workSheet.PageSetup.BottomMargin = interval;
            workSheet.PageSetup.HeaderMargin = 0;// excelApp.InchesToPoints(0);
            workSheet.PageSetup.FooterMargin = interval;
            workSheet.PageSetup.FirstPageNumber = (int)Excel.Constants.xlAutomatic; //номер первой страници
            workSheet.PageSetup.CenterFooter = "&B Страница &P";

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

            toolStripStatusLabelInfo.Text = "Формирование заголовка";
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
            workRange.Cells[1, 1] = "Журнал учета рабочего времени сотрудников Русской Промышленной Компании";
            workRange.Cells[2, 1] = "Период: " + mcReport.SelectionStart.ToString("dd.MM.yyyy") + " - " + mcReport.SelectionEnd.ToString("dd.MM.yyyy");

            toolStripStatusLabelInfo.Text = "Форматирование заголовка и строки данных";
            //диапазон для шапки таблицы и первой строки данных
            workRange = workSheet.Range[workSheet.Cells[8, 2], workSheet.Cells[14, 1 + captionData.GetUpperBound(1) + 1]];    //+1 на строку данных
                                                                                                                              //                ((Excel.Range)workRange.Rows).AutoFit();                                                    //автоувеличение строк в заголовке
            workRange.Font.Name = "Times New Roman";
            workRange.Font.Size = 11;
            workRange.Interior.TintAndShade = 0;// '0.2
            workRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            workRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            workRange.WrapText = true;
            workRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;                               //нарисуем все рамки
            ((Excel.Range)workSheet.Range[workRange.Cells[1, 1], workRange.Cells[1, 2]]).Interior.Color = ColorTranslator.ToOle(Color.LightGray);   //заливка первой строки цветом
            ((Excel.Range)workSheet.Range[workRange.Cells[1, 3], workRange.Cells[1, workRange.Columns.Count]]).Interior.Color = ColorTranslator.ToOle(Color.LightGreen);
            //уточнение       
            ((Excel.Range)workRange.Rows[1]).Font.Bold = true;                                          //первая строка шапки
            ((Excel.Range)workRange.Rows[2]).Font.Size = 9;                                             //вторая строка шапки
                                                                                                        //Свойства в диапазоне через workSheet        
            ((Excel.Range)workSheet.Range[workRange.Cells[2, 3], workRange.Cells[2, workRange.Columns.Count]]).VerticalAlignment = Excel.XlVAlign.xlVAlignTop;

            ((Excel.Range)workRange.Rows[3]).Font.Size = 11;                                            //третья строка шапки (строка данных)
            ((Excel.Range)workRange.Range[workSheet.Cells[2, 1], workSheet.Cells[3, 2]]).Font.Bold = true;
            ((Excel.Range)workRange.Cells[3, 2]).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
            //Свойства в диапазоне через workSheet 
            ((Excel.Range)workSheet.Range[workRange.Cells[5, 3], workRange.Cells[5, workRange.Columns.Count]]).Font.Color = ColorTranslator.ToOle(Color.LightGray);
            ((Excel.Range)workSheet.Range[workRange.Cells[5, 3], workRange.Cells[5, workRange.Columns.Count]]).Font.Size = 16;
            //строка данных значения по умолчанию
            workRange.Rows[3] = "00:00";

            toolStripStatusLabelInfo.Text = "Формирование условного форматирования заголовка";
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

            toolStripStatusLabelInfo.Text = "Нстройка ширины колонок и объединения ячеек";
            //настройка ширины колонок и объединение ячеек диапазона
            ((Excel.Range)workRange.Columns[1]).ColumnWidth = 3.5;          //ширина колонки с номером
            ((Excel.Range)workRange.Columns[2]).ColumnWidth = 38.5;         //ширина колонки ФИО 
            ((Excel.Range)workRange.Rows[1]).RowHeight = 28.5;              //высота первой строки
            ((Excel.Range)workRange.Rows[5]).RowHeight = 20;                //высота строки данных
            ((Excel.Range)workRange.Rows[6]).RowHeight = 20;                //объединение столбцов
            workSheet.Range[workRange.Cells[1, 1], workRange.Cells[4, 1]].Merge(mis);
            workSheet.Range[workRange.Cells[5, 1], workRange.Cells[6, 1]].Merge(mis);
            workSheet.Range[workRange.Cells[1, 2], workRange.Cells[4, 2]].Merge(mis);
            int j = 2;
            for (int i = 1; i <= captionData.GetUpperBound(1) / 2; i++)
            {
                //Свойства в диапазоне через workSheet 
                workSheet.Range[workRange.Cells[1, i + j], workRange.Cells[1, i + j + 1]].ColumnWidth = 11.56;// 8;
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
            tableResize(
                workSheet,
                workRange.Row + workRange.Rows.Count - 1,
                workRange.Column,
                workRange.Column + workRange.Columns.Count - 1,
                tableData.GetUpperBound(0) + 1
                );
            //диапазон для таблицы
            workRange = workSheet.Range[
                workSheet.Cells[workRange.Row + workRange.Rows.Count - 1, workRange.Column],
                workSheet.Cells[workRange.Row + workRange.Rows.Count - 1 + captionData.GetUpperBound(0), workRange.Column + workRange.Columns.Count - 1]
                ];
            //вставим данные в таблицу одним куском
            workRange.Resize[
                tableData.GetUpperBound(0) + 1,
                tableData.GetUpperBound(1) + 1
                ].Value = tableData;

            toolStripStatusLabelInfo.Text = "Файл подготовлен";
            //Настройки Application вернуть обратно
            excelApp.DisplayAlerts = true;                                 //Разрешить отображение окон с сообщениями
            excelApp.ScreenUpdating = true;                                //Зазрешить перерисовку экрана    
            excelApp.Visible = true;
            //            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

            Cursor.Current = Cursors.Default;
            ret = true;

            return ret;
        }

        //напечатать итоговый отчет
        private void btReportTotalPrint_Click(object sender, EventArgs e)
        {

        }
        /*--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        ' функция расширения таблицы EXCELL с сохранением форматирования
        ' //  xlsDoc - документ Excel   (обязательно передавать документ, листа недостаточно)
        ' //  shName - имя лист рабочей книги Excel
        '   wShhet - лист книги
        '   spRow - номер строки (расширяемая строка таблицы)
        '   spColFirst - номер колонки (первая колонка таблицы)
        '   spColLast - номер колонки (последняя колонка таблицы)
        '   spCount - количество строк на которое будем расширяться
        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
        private void tableResize(Excel.Worksheet wSheet, int spRow, int spColFirst, int spColLast, int spCount)
        {
            if (spCount > 1) 
            {
                ((Excel.Range)wSheet.Cells[spRow + 1, spColFirst]).Resize[spCount - 1].EntireRow.Insert(Excel.XlDirection.xlDown);
                ((Excel.Range)wSheet.Range[wSheet.Cells[spRow, spColFirst], wSheet.Cells[spRow, spColLast]]).Copy(((Excel.Range)wSheet.Range[wSheet.Cells[spRow + 1, spColFirst], wSheet.Cells[spRow + 1 + spCount - 2, spColLast]]));

                /*
                Excel.Range rng4 = (Excel.Range)wSheet.Cells[spRow + 1, spColFirst];
                rng4.Resize[spCount - 1].EntireRow.Insert(Excel.XlDirection.xlDown);

                Excel.Range from = wSheet.Range[wSheet.Cells[spRow, spColFirst], wSheet.Cells[spRow, spColLast]];
                Excel.Range to = wSheet.Range[wSheet.Cells[spRow + 1, spColFirst], wSheet.Cells[spRow + 1 + spCount - 2, spColLast]];
                from.Copy(to);
                */
            }
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
