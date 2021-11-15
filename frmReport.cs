using System;
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

        public frmReport()
        {
            //подписка события внешних форм 
            CallBack_FrmMain_outEvent.callbackEventHandler = new CallBack_FrmMain_outEvent.callbackEvent(this.CallbackReload);    //subscribe (listen) to the general notification
            InitializeComponent();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            if (!clSystemChecks.checkProvider()) this.Close();
            string cs = Properties.Settings.Default.twtConnectionSrting;    //connection string
            if (CheckConnects())                                            //проверить соединение с базой данных SQL
            {
                getRangeFromType();     //вычислить границы диапазона в зависимости от типа формы
                updateRange();          //проверка использования диапазона дат по умолчанию

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
                    lengthRange = 7;
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
            Excel.Application excelApp;
            Excel.Workbook workBook;
            Excel.Worksheet workSheet;
            Excel.Range workRange;
            

            //Объявляем приложение
            excelApp = new Excel.Application
            {
                Visible = true,                                             //Отобразить Excel
                SheetsInNewWorkbook = 1                                     //Количество листов в рабочей книге    
            };
            workBook = excelApp.Workbooks.Add(Type.Missing);                //Добавить рабочую книгу
            excelApp.DisplayAlerts = false;                                 //Отключить отображение окон с сообщениями
            workSheet = (Excel.Worksheet)excelApp.Worksheets.get_Item(1);   //Получаем первый лист документа (счет начинается с 1)
            workSheet.Name = "Journal";                                     //Название листа (вкладки снизу)
            //RebuildSheet(workBook, "Journal", 3);                            // удалить все листы кроме текущего

            Excel.Style style = workBook.Styles.Add("myStyle");
            style.Font.Name = "Times New Roman";
            style.Font.Size = 11;

            workRange = workSheet.Cells;
            workRange.Style = "myStyle";

            ((Excel.Range)workSheet.Cells[1, 1]).EntireColumn.ColumnWidth = 2;
            ((Excel.Range)workSheet.Cells[1, 14]).EntireColumn.ColumnWidth = 2;
            workSheet.PageSetup.LeftMargin = excelApp.InchesToPoints(0.2);
            workSheet.PageSetup.RightMargin = excelApp.InchesToPoints(0.2);
            workSheet.PageSetup.TopMargin = excelApp.InchesToPoints(0.2);
            workSheet.PageSetup.BottomMargin = excelApp.InchesToPoints(0.2);
            workSheet.PageSetup.HeaderMargin = excelApp.InchesToPoints(0);
            workSheet.PageSetup.FooterMargin = excelApp.InchesToPoints(0.2);
            workSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
            workSheet.PageSetup.FirstPageNumber = (int)Excel.Constants.xlAutomatic; //номер первой страници
            workSheet.PageSetup.Zoom = 83;
            workSheet.PageSetup.CenterFooter = "&B Страница &P";



            excelApp.DisplayAlerts = false;
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
                    mcReport.MaxSelectionCount = 7;
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
