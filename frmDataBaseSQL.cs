using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimeWorkTracking
{
    public partial class frmDataBaseSQL : Form
    {
        public frmDataBaseSQL()
        {
            //подписка события внешних форм 
            CallBack_FrmMain_outEvent.callbackEventHandler = new CallBack_FrmMain_outEvent.callbackEvent(this.CallbackReload);    //subscribe (listen) to the general notification
            InitializeComponent();
        }

        private void frmDataBaseSQL_Load(object sender, EventArgs e)
        {
            //Read Setting
            //TimeWorkTracking DataBase
            tbServerTWT.Text = Properties.Settings.Default.twtServerName;
            tbDatabaseTWT.Text = Properties.Settings.Default.twtDatabase;
            if (Properties.Settings.Default.twtAuthenticationDef != "")
                cbAutentificationTWT.SelectedItem = Properties.Settings.Default.twtAuthenticationDef;
            else
                cbAutentificationTWT.SelectedItem = "Windows Autentification";

            tbUserNameTWT.Text = Properties.Settings.Default.twtLogin;
            tbPasswordTWT.Text = Properties.Settings.Default.twtPassword;

            CheckConnects();        //проверить соединение с базами

            btCreateDBTwt.Visible = false;

            // btTestConnectionTwt_Click(null, null);
        }

        private void cbAutentificationTWT_SelectedIndexChanged(object sender, EventArgs e)
        {

            bool auth = cbAutentificationTWT.Text == "SQL Server Autentification";   //если да то true если нет то false
            tbUserNameTWT.Enabled = auth;
            tbPasswordTWT.Enabled = auth;
        }


        //test Connrection TWT (TimeWorkTracking database )
        private void btTestConnectionTwt_Click(object sender, EventArgs e)
        {
            TestFormConnectionTwt();        //проверить соединение по настройкам формы
        }

        //полчить строку соединения по настройкам формы
        private string GetFormConnectionString() 
        {
            string connectionString;
            switch (cbAutentificationTWT.Text)
            {
                case "SQL Server Autentification":
                    connectionString = @"Data Source=" + tbServerTWT.Text + ";Initial Catalog=" + tbDatabaseTWT.Text + ";Persist Security Info=True;User ID=" + tbUserNameTWT.Text + ";Password=" + tbPasswordTWT.Text;
                    break;
                case "Windows Autentification":
                    connectionString = @"Data Source=" + tbServerTWT.Text + "; Initial Catalog=" + tbDatabaseTWT.Text + "; Integrated Security=True";
                    break;
                default:
                    connectionString = "";
                    break;
            }
            return connectionString;
        }

        //проверить соединение по настройкам формы
        private void TestFormConnectionTwt()
        {
            string connectionString = GetFormConnectionString();        //полчить строку соединения по настройкам формы
            StringBuilder Messages = new StringBuilder();
            string statusDB = MsSqlDatabase.GetSqlConnection(connectionString);
            switch (statusDB)
            {
                case "-1":      //бд не существует
                    statusDB = "";
                    picStatusTWT.Image = global::TimeWorkTracking.Properties.Resources.no;
                    btCreateDBTwt.Visible = true;
                    Messages.Append("База данных с именем:" + "\n" +
                                                "'" + tbDatabaseTWT.Text + "'" + "\n" +
                                                "не существует на сервере");
                    break;
                case "-9":      //соединение установить не удалось
                    statusDB = "";
                    picStatusTWT.Image = global::TimeWorkTracking.Properties.Resources.no;
                    btCreateDBTwt.Visible = false;
                    string msg = cbAutentificationTWT.Text == "SQL Server Autentification" ? $"\tИмя пользователя: { tbUserNameTWT.Text}" + "\n" + $"\tПароль: {tbPasswordTWT.Text}" + "\n" : "";
                    Messages.Append("Соединение:" + "\n" +
                                $"\tСервер: {tbServerTWT.Text}" + "\n" +
                                $"\tАутентификация: {cbAutentificationTWT.Text}" + "\n" + msg +
                                $"\tБаза данных: {tbDatabaseTWT.Text}" + "\n" +
                                "установить не удалось");
                    break;
                default:        //все чики-пуки
                    picStatusTWT.Image = global::TimeWorkTracking.Properties.Resources.ok;
                    btCreateDBTwt.Visible = false;
                    Messages.Append("Соединение установлено");
                    break;
            }
            MessageBox.Show(Messages.ToString(),
                            "Подключение к Базе Данных",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Warning);

            Properties.Settings.Default.twtConnectionSrting = statusDB;
            //TimeWorkTracking DataBase
            Properties.Settings.Default.twtServerName = tbServerTWT.Text;
            Properties.Settings.Default.twtDatabase = tbDatabaseTWT.Text;
            Properties.Settings.Default.twtAuthenticationDef = cbAutentificationTWT.Text;
            Properties.Settings.Default.twtLogin = tbUserNameTWT.Text;
            Properties.Settings.Default.twtPassword = tbPasswordTWT.Text;

            Properties.Settings.Default.Save();

            CallBack_FrmDataBaseSQL_outEvent.callbackEventHandler("", "", null);  //send a general notification
        }



        //создать бд
        private void btCreateDBTwt_Click(object sender, EventArgs e)
        {
            string connectionString = GetFormConnectionString();        //полчить строку соединения по настройкам формы
            if (connectionString !="" && tbDatabaseTWT.Text != "")
            {
                MsSqlDatabase.CreateDataBase(connectionString);
                TestFormConnectionTwt();                                //проверить соединение по настройкам формы
            }
        }

        //проверить соединение с базами
        private void CheckConnects()
        {
            if (MsSqlDatabase.CheckConnectWithConnectionStr(Properties.Settings.Default.twtConnectionSrting))
                this.picStatusTWT.Image = Properties.Resources.ok;
            else
                this.picStatusTWT.Image = Properties.Resources.no;
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
    public static class CallBack_FrmDataBaseSQL_outEvent
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
