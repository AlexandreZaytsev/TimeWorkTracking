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

namespace TimeWorkTracking
{
    public partial class frmReport : Form
    {
        private clCalendar pCalendar;                                       //класс производственный календаоь
        private DataTable dtSpecialMarks;                                   //специальные отметки
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
            if (CheckConnects())                                            //проверить соединение с базами
            {
                mcReport.SelectionStart = DateTime.Now;
            }
        }


        //изменение даты календаря
        private void mcReport_DateChanged(object sender, DateRangeEventArgs e)
        {
            setRangeFromType();
        }
        //выделить диапазон в зависимости от типа формы
        private void setRangeFromType() 
        {
            DateTime dt = mcReport.SelectionStart;
            switch (this.AccessibleName)
            {
                case "FormHeatCheck":
                    mcReport.MaxSelectionCount = 7;
                    //..                    mcReport.SelectionRange.Start=DateTime.Today.ё.Month.
                    break;
                case "FormTimeCheck":
                    mcReport.MaxSelectionCount = 7;
                    mcReport.SelectionEnd = dt.FirstDayOfWeek().AddDays(7);
                    mcReport.SelectionStart = dt.FirstDayOfWeek();
                    mcReport.Select();
                    break;
                case "ReportTotal":
                    mcReport.MaxSelectionCount = dt.DaysInMonth();
                    mcReport.SelectionEnd = dt.LastDayOfMonth();
                    mcReport.SelectionStart = dt.FirstDayOfMonth();
                 //   mcReport.Select(); 
                    break;
            }
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
    //..            mcReport.SelectionRange.Start=DateTime.Today.ё.Month.
                    break;
                case "FormTimeCheck":
                    mcReport.MaxSelectionCount = 7;
                    break;
                case "ReportTotal":
    //                mcReport.SelectionRange.Start = DateTime.Today.FirstDayOfMonth();
    //                mcReport.SelectionRange.Start = DateTime.Today.LastDayOfMonth();
    //                mcReport.MaxSelectionCount = DateTime.Today.DaysInMonth();
                    break;
            }
                /*
                if (param.Count() != 0)
                {
                    Control[] cntrl = this.FilterControls(c => c.Name != null && c.Name.Equals(controlName) && c is DataGridView);
                    ((DataGridView)cntrl[0]).DataSource = param;
                }
                */
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
        public static DateTime FirstDayOfWeek(this DateTime value)
        {
            return value.AddDays((int)CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek -
                                            (int)DateTime.Today.DayOfWeek);
        }
    }
}
