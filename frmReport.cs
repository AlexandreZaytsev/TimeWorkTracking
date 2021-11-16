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
        private int lengthRange;                        //длина диапазона
        bool updateCalendar = false;                    //отключение события календаря

        private Excel.Application excelApp;
        private Excel.Workbook workBook;
        private Excel.Worksheet workSheet;
        private Excel.Range workRange;

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

                pCalendar.uploadCalendar(cs, "Select * From twt_GetDateInfo('', '') order by dWork");   //прочитаем данные производственного календаря
                LoadBoldedDatesCalendar(pCalendar.getListWorkHoliday());                                //Загрузить производственный календарь в массив непериодических выделенных дат


            }
        }

        //изменение даты календаря
        private void mcReport_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (updateCalendar)         //проверка чтобы не срабатывало два раза
            {
                getRangeFromType();     //вычислить границы диапазона в зависимости от типа формы
                updateRange();          //проверка использования диапазона дат по умолчанию
            } 
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
                    lengthRange = 7;// 5;
                    break;
                case "ReportTotal":
                    firstDayRange = dt.FirstDayOfMonth();
                    lastDayRange = dt.LastDayOfMonth();
                    lengthRange = dt.DaysInMonth();
                    break;
            }
        }
        //обновить диапазон в зависимости от текущей даты
        private void updateRange()
        {
            mcReport.MaxSelectionCount = chRange.Checked ? lengthRange : 365;   //!!!Обязательно задать вначале (инача будет резать диапазон)
            updateCalendar = false;
            if (chRange.Checked) 
                mcReport.SetSelectionRange(firstDayRange, lastDayRange);
//            mcReport.Select();
            updateCalendar = true;
        }

        //проверка флага использования диапазона дат по умолчанию
        private void chRange_CheckedChanged(object sender, EventArgs e)
        {
            getRangeFromType();     //вычислить границы диапазона в зависимости от типа формы
            updateRange();          //проверка использования диапазона дат по умолчанию
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
            //Объявляем приложение
            excelApp = new Excel.Application
            {
                Visible = true,                                             //Отобразить Excel
                SheetsInNewWorkbook = 1                                     //Количество листов в рабочей книге    
            };
            workBook = excelApp.Workbooks.Add(Type.Missing);                //Добавить рабочую книгу

            //Настройки Application установить
            excelApp.DisplayAlerts = false;                                 //Запретить отображение окон с сообщениями
//            excelApp.ScreenUpdating = false;                                //Запретить перерисовку экрана    
            excelApp.ActiveWindow.Zoom = 80;                                //Масштаб листа

            //Переименовать лист
            workSheet = (Excel.Worksheet)excelApp.Worksheets.get_Item(1);   //Получаем первый лист документа (счет начинается с 1)
            workSheet.Name = "Journal";                                     //Название листа (вкладки снизу)
            //RebuildSheet(workBook, "Journal", 3);                         // удалить все листы кроме текущего

            //оформление листа и применение стиля
            Excel.Style style = workBook.Styles.Add("reportStyle");
            style.Font.Name = "Times New Roman";
            style.Font.Size = 11;
            ((Excel.Range)workSheet.Cells).Style = "reportStyle";

            //настройки печати
            ((Excel.Range)workSheet.Cells[1, 1]).EntireColumn.ColumnWidth = 2;
            ((Excel.Range)workSheet.Cells[1, 14]).EntireColumn.ColumnWidth = 2;
            workSheet.PageSetup.LeftMargin = excelApp.CentimetersToPoints(0.2);
            workSheet.PageSetup.RightMargin = excelApp.CentimetersToPoints(0.2);
            workSheet.PageSetup.TopMargin = excelApp.CentimetersToPoints(0.2);//.InchesToPoints(0.2);
            workSheet.PageSetup.BottomMargin = excelApp.CentimetersToPoints(0.2);
            workSheet.PageSetup.HeaderMargin = 0;// excelApp.InchesToPoints(0);
            workSheet.PageSetup.FooterMargin = excelApp.CentimetersToPoints(0.2);
            workSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
            workSheet.PageSetup.FirstPageNumber = (int)Excel.Constants.xlAutomatic; //номер первой страници
            workSheet.PageSetup.Zoom = 83;
            workSheet.PageSetup.CenterFooter = "&B Страница &P";

            //поехали
            int rowTable = 8;                                                       //номер строки начала заголовка
            int colTable = 2;                                                       //номер колонки начала зазоловка
            double daysCount= (mcReport.SelectionRange.End- mcReport.SelectionRange.Start).TotalDays+1;

            ((Excel.Range)workSheet.Rows[2]).EntireRow.Hidden = true;               //скрыть строку
            ((Excel.Range)workSheet.Rows[3]).EntireRow.Hidden = true;
            ((Excel.Range)workSheet.Rows[6]).EntireRow.Hidden = true;

            //главная надпись
                workRange = workSheet.Range[workSheet.Cells[4, colTable], workSheet.Cells[5, colTable + daysCount * 2 + 1]];
                ((Excel.Range)workRange.Rows[1]).Merge(Type.Missing);
                ((Excel.Range)workRange.Rows[2]).Merge(Type.Missing);

//            workSheet.Range[workRange.Cells[1, 1], workRange.Cells[1, workRange.Columns.Count]].Merge(Type.Missing);
//                workSheet.Range[workRange.Cells[2, 1], workRange.Cells[2, workRange.Columns.Count]].Merge(Type.Missing);
                workRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                workRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                workRange.Font.Bold = true;
                workRange.Font.Name = "Times New Roman";
                workRange.Font.Size = 14;
                workRange.Cells[1,1] = "Журнал учета средней температуры сотрудников Русской Промышленной Компании";
                workRange.Cells[2,1] = "Период: " + mcReport.SelectionStart.ToString("dd.MM.yyyy") + " - " + mcReport.SelectionEnd.ToString("dd.MM.yyyy");

            //Таблица заголовок и строка данных
            workRange = workSheet.Range[workSheet.Cells[rowTable, colTable], workSheet.Cells[rowTable, colTable + daysCount * 2+1]];
                workRange.Interior.Color = ColorTranslator.ToOle(Color.LightGray);
                workRange.Interior.TintAndShade = 0;// '0.2
                //Переопределим диапазон на строку данных и нарисуем рамки    
                workRange = workSheet.Range[workRange.Offset[0, 0], workRange.Offset[1, 0]];
                //Границы
                workRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                workRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                workRange.WrapText = true;
                workRange.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                workRange.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;
                workRange.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                workRange.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                workRange.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;
                workRange.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlContinuous;
                workRange.Font.Bold = true;

            //Ширина
            ((Excel.Range)workRange.Rows[1]).RowHeight = 40;// 28.5;          //высота строки заголовка          
                ((Excel.Range)workRange.Rows[2]).RowHeight = 25;            //высота строки данных
                ((Excel.Range)workRange.Rows[2]).WrapText = true;

                ((Excel.Range)workRange.Columns[1]).ColumnWidth = 3.5;      //ширина колонки с номером
                ((Excel.Range)workRange.Columns[2]).ColumnWidth = 38.5;     //ширина колонки ФИО 
                for(int i = 3; i <= daysCount*2+2; i++)
                {
                    ((Excel.Range)workRange.Columns[i]).ColumnWidth = 8;// 10;// 11.5; //ширина колонок дней
                    ((Excel.Range)workRange.Columns[i]).Font.Size = 10;     //
                    ((Excel.Range)workRange.Columns[i]).Font.Bold = false;
                    ((Excel.Range)workRange.Columns[i]).VerticalAlignment = Excel.XlVAlign.xlVAlignTop;
            }

            //Заголовок (value2 реальное значение (работает быстрее) value-форматированное)
            workRange.Cells[1, 1] = "№";
                //            workSheet.Range["A1"].Value = "№";
                //            workSheet.get_Range("A1").Value2 = "№";
                workRange.Cells[1, 2] = "Фамилия Имя Отчество";
                ((Excel.Range)workRange.Cells[1, 2]).Font.Bold = true;

                int uCount = 0;
                workRange.Cells[2, 1] = uCount + 1;
                ((Excel.Range)workRange.Cells[2, 2]).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                ((Excel.Range)workRange.Cells[2, 2]).IndentLevel = 1;
                ((Excel.Range)workRange.Cells[2, 2]).Font.Size = 12;
                //           workRange.Value2 = CStr(Arr(uCount))   //ФИО сотрудника


                for (int i = 0; i <= daysCount * 2 - 2; i+=2) 
                {
                    workSheet.Range[workRange.Cells[1, 3+i], workRange.Cells[1, 4+i]].Merge(Type.Missing);
                    DateTime tDate = mcReport.SelectionStart.AddDays(i / 2);
                    workRange.Cells[1, 3 + i] = tDate.ToString("dddd") + "\r\n" + tDate.ToString("dd.MM.yyyy") + "\r\n" + pCalendar.getDateDescription(tDate);
                    workSheet.Range[workRange.Cells[2, 3 + i], workRange.Cells[2, 4 + i]].Merge(Type.Missing);
                }

            Excel.Range rCaption = workSheet.Range[workSheet.Cells[1, 1], workSheet.Cells[3, daysCount * 2+2]];
            Excel.Range rData = workSheet.Range[workSheet.Cells[2, 1], workSheet.Cells[2, daysCount * 2 + 2]];


            tableResize(workBook, workSheet.Name, 9, 2, 17, 5);  //расширим таблицу спецификации строка 6, колонки 2-UBound(xlsArrForList, 2) + 2, количество UBound(xlsArrForList, 1)+1


            //Настройки Application вернуть обратно
            excelApp.DisplayAlerts = true;                                 //Разрешить отображение окон с сообщениями
            excelApp.ScreenUpdating = true;                                //Зазрешить перерисовку экрана    
            //            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
        }

        /*--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        ' функция расширения таблицы EXCELL с сохранением форматирования
        '   xlsDoc - документ Excel   (обязательно передавать документ, листа недостаточно)
        '   shName - имя лист рабочей книги Excel
        '   spRow - номер строки (расширяемая строка таблицы)
        '   spColFirst - номер колонки (первая колонка таблицы)
        '   spColLast - номер колонки (последняя колонка таблицы)
        '   spCount - количество строк на которое будем расширяться
        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
        private void tableResize(Excel.Workbook xlsDoc, string shName, int spRow, int spColFirst, int spColLast, int spCount)
        {
            Excel.Worksheet wSheet = (Excel.Worksheet)xlsDoc.Sheets[shName];
            if (spCount > 1) 
            {
                Excel.Range rng = (Excel.Range)((Excel.Range)((Excel.Range)wSheet.Cells[spRow + 1, spColFirst]).get_Resize(1).EntireRow).Insert(Excel.XlDirection.xlDown);
                //              ((Excel.Range)wSheet.Cells[spRow + 1, spColFirst]).Resize[spCount - 1].EntireRow.Insert;
 //               Excel.Range rng1 = ((Excel.Range)wSheet.Range[wSheet.Cells[spRow, spColFirst], wSheet.Cells[spRow, spColLast]]).Copy(wSheet.Range[wSheet.Cells[spRow + 1, spColFirst], wSheet.Cells[spRow + 1 + spCount - 2, spColLast]]);


                Excel.Range from = wSheet.Range[wSheet.Cells[spRow, spColFirst], wSheet.Cells[spRow, spColLast]];
                Excel.Range to = wSheet.Range[wSheet.Cells[spRow + 1, spColFirst], wSheet.Cells[spRow + 1 + spCount - 2, spColLast]];
                from.Copy(to);

                //    wSheet.Application.CutCopyMode = False
                //     .Cells(spRow + 1, spColFirst).Resize(spCount - 1).EntireRow.Insert
                //     .Range(.Cells(spRow, spColFirst), .Cells(spRow, spColLast)).Copy.Range(.Cells(spRow + 1, spColFirst), .Cells(spRow + 1 + spCount - 2, spColLast))


            } 
        }
            //напечатать бланк проходов
            private void btFormTimePrint_Click(object sender, EventArgs e)
        {

        }
        //напечатать итоговый отчет
        private void btReportTotalPrint_Click(object sender, EventArgs e)
        {

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
