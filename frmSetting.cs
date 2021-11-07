using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace TimeWorkTracking
{
    public partial class frmSetting : Form
    {
        public frmSetting()
        {
            //подписка события внешних форм 
            CallBack_FrmMain_outEvent.callbackEventHandler = new CallBack_FrmMain_outEvent.callbackEvent(this.CallbackReload);    //subscribe (listen) to the general notification
            InitializeComponent();
        }

        private void frmSetting_Load(object sender, EventArgs e)
        {
            string cs = Properties.Settings.Default.twtConnectionSrting;    //connection string
            mainPanelSetting.Enabled = clMsSqlDatabase.CheckConnectWithConnectionStr(cs);
//            int count = Convert.ToInt32(clMsSqlDatabase.RequesScalar(cs, "select count(*) from Users", false));
//            btImportUsers.Enabled = count == 0;
//            count = Convert.ToInt32(clMsSqlDatabase.RequesScalar(cs, "select count(*) from EventsPass", false));
//            btImportPass.Enabled = count == 0;
        }   
        //кнопка импорт пользователей
        private void btImportUsers_Click(object sender, EventArgs e)
        {
            ImportUserDataFromExcel();
            CallBack_FrmSetting_outEvent.callbackEventHandler("", "", null);  //send a general notification
            string cs = Properties.Settings.Default.twtConnectionSrting;    //connection string
            int count = Convert.ToInt32(clMsSqlDatabase.RequesScalar(cs, "select count(*) from Users", false));
            btImportUsers.Enabled = count == 0;

        }

        public static string getPathSourse()
        {
            OpenFileDialog od = new OpenFileDialog
            {
                //                Filter = "Excell|*.xls;*.xlsx;*.xlsm;"
                Filter = "Excel 2010(*.xlsm) | *.xlsm"              //"Excel Worksheets 2003(*.xls)|*.xls|Excel Worksheets 2007(*.xlsx)|*.xlsx|Word Documents(*.doc)|*.doc"
            };
            DialogResult dr = od.ShowDialog();
            if (dr == DialogResult.Abort)
                return "";
            if (dr == DialogResult.Cancel)
                return "" ;
            return od.FileName.ToString();
        }

        public static void ImportUserDataFromExcel()
        {
          //  string excelFilePath = "";
            DialogResult response = MessageBox.Show(
                "Внимание Таблицы Прохода и Сотрудников будут Очищены" + "\r\n" +
                "Продолжить?" + "\r\n",
                "Начальное заполнение данных",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button2,
                MessageBoxOptions.DefaultDesktopOnly
                );
            if (response == DialogResult.Yes) 
            { 
            string excelFilePath = getPathSourse();
                if (excelFilePath != "")
                {
                    Excel.Application excelapp = new Excel.Application();
                    //excelapp.Visible = true;
                    Excel.Workbook workbook = excelapp.Workbooks.Open(
                        excelFilePath,
                        Type.Missing, true, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing);

                    Excel.Worksheet sheet = (Excel.Worksheet)workbook.Sheets["Reference"];
                    Excel.Range range = (Excel.Range)sheet.Range["Users"];// ().Cells[row, col];
                    string n = "'" + range.Parent + "'!" + range.Address;
//                    Set b = Worksheets(2).Range("Users")
//s = "'" & b.Parent.name & "'!" & b.Address(External:= False)
                    foreach (var rangeName in workbook.Names)
                    {
                       // Range c = ws.Cells[row++, 3];
                       // c.Value = rangeName.NameLocal;
                    }
                    //                    string address= workbook.Worksheets[2].R
                    workbook.Close(false, Type.Missing, Type.Missing);  // Закройте книгу без сохранения изменений.
                    excelapp.Quit();                                   // Закройте сервер Excel.


                    //http://www.codedigest.com/Articles/ASPNET/400_ImportUpload_Excel_Sheet_data_to_Sql_Server_in_C__and_AspNet.aspx#google_vignette
                    //https://csharp-tutorials1.blogspot.com/2017/03/import-excel-data-into-sql-table-using.html
                    //https://question-it.com/questions/1788823/kak-zagruzit-fajl-excel-v-tablitsu-bazy-dannyh-sql-s-pomoschju-prilozhenija-s-windows-form
                    //https://www.red-gate.com/simple-talk/databases/sql-server/t-sql-programming-sql-server/questions-about-using-tsql-to-import-excel-data-you-were-too-shy-to-ask/          
                    //https://metanit.com/sharp/tutorial/6.5.php

                    using (var sqlConnection = new SqlConnection(Properties.Settings.Default.twtConnectionSrting))
                    {
                        string myexceldataquery = "Select * from [Reference$B3:J68]";
                        //               string myexceldataquery = "Select * from users";
                        try
                        {
                            string sexcelconnectionstring = @"provider=microsoft.ACE.OLEDB.12.0;data source=" + excelFilePath +
                            ";extended properties=" + "\"Excel 12.0 Macro;hdr=yes;\"";

                            sqlConnection.Open();
                            OleDbConnection oledbconn = new OleDbConnection(sexcelconnectionstring);
                            OleDbCommand oledbcmd = new OleDbCommand(myexceldataquery, oledbconn);
                            oledbconn.Open();
                            OleDbDataReader dr = oledbcmd.ExecuteReader();

                            object[] meta = new object[10];
                            bool read;

                            using (var sqlCommand = sqlConnection.CreateCommand())
                            {
                                sqlCommand.CommandText = "DELETE FROM EventsPass";
                                sqlCommand.ExecuteScalar();

                                sqlCommand.CommandText = "DELETE FROM Users";
                                sqlCommand.ExecuteScalar();
                                if (dr.Read() == true)
                                {
                                    do
                                    {
                                        int NumberOfColums = dr.GetValues(meta);

                                        sqlCommand.CommandText = "SELECT id FROM UserDepartment Where name='" + meta[1].ToString() + "'";
                                        int departmentId = (int)sqlCommand.ExecuteScalar();
                                        sqlCommand.CommandText = "SELECT id FROM UserPost Where name='" + meta[2].ToString() + "'";
                                        int postId = (int)sqlCommand.ExecuteScalar();
                                        sqlCommand.CommandText = "SELECT id FROM UserWorkScheme Where name='" + meta[7].ToString() + "'";
                                        int workSchemeId = (int)sqlCommand.ExecuteScalar();

                                        sqlCommand.CommandText =
                                            "UPDATE Users Set " +
                                              "departmentId = " + departmentId + ", " +
                                              "postId = " + postId + ", " +
                                              "timeStart = " + "'" + ((DateTime)meta[4]).ToShortTimeString() + "', " +
                                              "timeStop = " + "'" + ((DateTime)meta[5]).ToShortTimeString() + "', " +
                                              "noLunch = " + ((Boolean)meta[6] ? 1 : 0) + ", " +
                                              "workSchemeId = " + workSchemeId + ", " +
                                              "uses = " + ((Boolean)meta[8] ? 1 : 0) + " " +
                                            "WHERE extId = '" + meta[0].ToString() + "' and name = '" + meta[3].ToString() + "'; " +
                                            "IF @@ROWCOUNT = 0 " +
                                            "INSERT INTO Users(" +
                                              "extId, " +
                                              "name, " +
                                              "departmentId, " +
                                              "postId, " +
                                              "timeStart, " +
                                              "timeStop, " +
                                              "noLunch, " +
                                              "workSchemeId, " +
                                              "uses) " +
                                            "VALUES (" +
                                              "N'" + meta[0].ToString() + "', " +
                                              "N'" + meta[3].ToString() + "', " +
                                              departmentId + ", " +
                                              postId + ", " +
                                              "'" + ((DateTime)meta[4]).ToShortTimeString() + "', " +
                                              "'" + ((DateTime)meta[5]).ToShortTimeString() + "', " +
                                              ((Boolean)meta[6] ? 1 : 0) + ", " +
                                              workSchemeId + ", " +
                                              ((Boolean)meta[8] ? 1 : 0) +
                                              ")";
                                        sqlCommand.ExecuteNonQuery();
                                        read = dr.Read();
                                    } while (read == true);
                                }
                            }
                            dr.Close();
                            oledbconn.Close();
                            MessageBox.Show("Список сотрудников загружен в БД");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString());
                        }
                    }
                }
            }
        }


        /*--------------------------------------------------------------------------------------------  
        CALLBACK InPut (подписка на внешние сообщения)
        --------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Callbacks the reload.
        /// входящее асинхронное сообщение для подписанных слушателей с передачей текущих параметров
        /// </summary>
        /// <param name="controlName">имя CTRL</param>
        /// <param name="controlParentName">имя родителя CNTRL</param>
        /// <param name="param">параметры ключ-значение.</param>
        private void CallbackReload(string controlName, string controlParentName, Dictionary<String, String> param)
        {
            /*
            if (param.Count() != 0)
            {
                Control[] cntrl = this.FilterControls(c => c.Name != null && c.Name.Equals(controlName) && c is DataGridView);
                ((DataGridView)cntrl[0]).DataSource = param;
            }
            */
        }
    }
    /*--------------------------------------------------------------------------------------------  
    CALLBACK OutPut (собственные сообщения)
    --------------------------------------------------------------------------------------------*/
    //general notification
    /// <summary>
    /// CallBack_GetParam
    /// исходящее асинхронное сообщение для подписанных слушателей с передачей текущих параметров 
    /// </summary>
    public static class CallBack_FrmSetting_outEvent
    {
        /// <summary>
        /// Delegate callbackEvent
        /// </summary>
        /// <param name="controlName">имя CTRL</param>
        /// <param name="controlParentName">имя родителя CNTRL</param>
        /// <param name="parameterPairs">параметры ключ-значение</param>
        public delegate void callbackEvent(string controlName, string controlParentName, Dictionary<String, String> parameterPairs);
        /// <summary>
        /// The callback event handler
        /// </summary>
        public static callbackEvent callbackEventHandler;
    }
}
