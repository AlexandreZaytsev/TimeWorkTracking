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
    public partial class frmDataBasePACS : Form
    {
        public frmDataBasePACS()
        {
            //подписка события внешних форм 
            CallBack_FrmMain_outEvent.callbackEventHandler = new CallBack_FrmMain_outEvent.callbackEvent(this.CallbackReload);    //subscribe (listen) to the general notification
            InitializeComponent();
        }

        //test Connrection СКУД (web сервис PACS)
        private void btTestConnectionPacs_Click(object sender, EventArgs e)
        {
            if (!clSystemSet.CheckPing(tbHostNamePACS.Text))
                MessageBox.Show("Cетевое имя сервера PACS\r\n  " +
                                tbHostNamePACS.Text +
                                "- недоступно\r\n",
                                "Проверка соединения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                TestFormConnectionPACS();        //проверить соединение по настройкам формы
        }
        //полчить строку соединения по настройкам формы
        private string GetFormConnectionString()
        {
            string connectionString = tbHostNamePACS.Text.Trim();
            return connectionString;
        }

        //проверить соединение по настройкам формы
        private Boolean TestFormConnectionPACS()
        {
            bool ret = false;
            string connectionString = GetFormConnectionString();        //полчить строку соединения по настройкам формы
            StringBuilder Messages = new StringBuilder();
            string statusDB = clWebServiceDataBase.pacsConnectBase(connectionString);
            /*
                        switch (statusDB)
                        {
                            case "-1":      //бд не существует
                                statusDB = "";
                                picStatusTWT.Image = global::TimeWorkTracking.Properties.Resources.no;
                                btCreateDBTwt.Visible = true;
                                btTestConnectionTwt.Visible = false;
                                Messages.Append("База данных с именем:" + "\n" +
                                                            "'" + tbDatabaseTWT.Text + "'" + "\n" +
                                                            "не существует на сервере");
                                break;
                            case "-9":      //соединение установить не удалось
                                statusDB = "";
                                picStatusTWT.Image = global::TimeWorkTracking.Properties.Resources.no;
                                btCreateDBTwt.Visible = false;
                                btTestConnectionTwt.Visible = true;
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
                                btTestConnectionTwt.Visible = true;
                                Messages.Append("Соединение установлено");
                                ret = true;
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
            */

            CallBack_FrmDataBasePACS_outEvent.callbackEventHandler("", "", null);  //send a general notification



            //PACS DataBase
            Properties.Settings.Default.pacsHost = tbHostNamePACS.Text;
            Properties.Settings.Default.pascLogin = tbUserNamePACS.Text;
            Properties.Settings.Default.pacsPassword = tbPasswordPASC.Text;

            //            pacsConnectionString

            Properties.Settings.Default.Save();

            CallBack_FrmDataBaseSQL_outEvent.callbackEventHandler("", "", null);  //send a general notification
            return ret;
        }

        private void frmDataBasePACS_Load(object sender, EventArgs e)
        {
            //PACS DataBase
            tbHostNamePACS.Text = Properties.Settings.Default.pacsHost;
            tbUserNamePACS.Text = Properties.Settings.Default.pascLogin;
            tbPasswordPASC.Text = Properties.Settings.Default.pacsPassword;
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
    public static class CallBack_FrmDataBasePACS_outEvent
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
