using System;
using System.Collections.Generic;
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

        /// <summary>
        /// загрузить данные формы из параметров
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        #region //Подключения и проверки

        /// <summary>
        /// выбор метода аутентификации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbAutentificationTWT_SelectedIndexChanged(object sender, EventArgs e)
        {

            bool auth = cbAutentificationTWT.Text == "SQL Server Autentification";   //если да то true если нет то false
            tbUserNameTWT.Enabled = auth;
            tbPasswordTWT.Enabled = auth;
        }

        /// <summary>
        /// попытка подключения к SQL Базе Данных (TimeWorkTracking)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btTestConnectionTwt_Click(object sender, EventArgs e)
        {
            if (!clSystemSet.CheckPing(tbServerTWT.Text)) 
            {
                MessageBox.Show(
                    "Cетевое имя сервера SQL\r\n  " +
                    tbServerTWT.Text +
                    "- недоступно\r\n"
                    , "Проверка соединения"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Warning
                    );
                BringToFront();                                                     //вернуть форму на передний план
            }
            else
                TestFormConnectionTwt();        //проверить соединение по настройкам формы
        }

        /// <summary>
        /// полчить строку соединения SQL по настройкам формы
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// проверить соединение c БД SQL по настройкам формы
        /// </summary>
        /// <returns></returns>
        private Boolean TestFormConnectionTwt()
        {
            bool ret = false;
            string connectionString = GetFormConnectionString();        //полчить строку соединения по настройкам формы
            StringBuilder Messages = new StringBuilder();
            string statusDB = clMsSqlDatabase.sqlConnectBase(connectionString);
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
            MessageBox.Show(
                Messages.ToString()
                , "Подключение к Базе Данных"
                , MessageBoxButtons.OK
                , MessageBoxIcon.Warning
                );
            BringToFront();                                                     //вернуть форму на передний план

            Properties.Settings.Default.twtConnectionSrting = statusDB;
            //TimeWorkTracking DataBase
            Properties.Settings.Default.twtServerName = tbServerTWT.Text;
            Properties.Settings.Default.twtDatabase = tbDatabaseTWT.Text;
            Properties.Settings.Default.twtAuthenticationDef = cbAutentificationTWT.Text;
            Properties.Settings.Default.twtLogin = tbUserNameTWT.Text;
            Properties.Settings.Default.twtPassword = tbPasswordTWT.Text;

            Properties.Settings.Default.Save();

            CallBack_FrmDataBaseSQL_outEvent.callbackEventHandler("", "", null);  //send a general notification
            return ret;
        }

        /// <summary>
        /// проверить соединение с базой SQL
        /// </summary>
        private void CheckConnects()
        {
            if (!clSystemSet.CheckPing(tbServerTWT.Text))
            {
                this.picStatusTWT.Image = Properties.Resources.no;
                /*
                   MessageBox.Show("Cетевое имя сервера SQL\r\n  " +
                                   tbServerTWT.Text +
                                   "- недоступно\r\n",
                                   "Проверка соединения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               */
            }
            else
            {
                if (clMsSqlDatabase.sqlConnectSimple(Properties.Settings.Default.twtConnectionSrting))
                    this.picStatusTWT.Image = Properties.Resources.ok;
                else
                    this.picStatusTWT.Image = Properties.Resources.no;

            }
        }

        #endregion

        #region //Работа с Базой Данных

        /// <summary>
        /// создать бд
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btCreateDBTwt_Click(object sender, EventArgs e)
        {
            string connectionString = GetFormConnectionString();        //полчить строку соединения по настройкам формы
            if (connectionString != "" && tbDatabaseTWT.Text != "")
            {
                bool mode = false;
                DialogResult result = MessageBox.Show(
                    "Загрузить минимальные настройки данных?"
                    , "Создание структуры Базы Данных"
                    , MessageBoxButtons.YesNo
                    , MessageBoxIcon.Information
                    , MessageBoxDefaultButton.Button2
                    , MessageBoxOptions.DefaultDesktopOnly
                    );
                BringToFront();                                                     //вернуть форму на передний план

                if (result == DialogResult.Yes)
                    mode = true;

                clMsSqlDatabase.CreateDataBase(connectionString, mode);
                System.Threading.Thread.Sleep(2000);                    //пауза 2 сек чтобы база вписалась в сервер

                if (TestFormConnectionTwt())                            //проверить соединение по настройкам формы
                    this.Close();// Hide();                             //закрыть форму
            }
        }

        #endregion

        #region //Interface

        /// <summary>
        /// проверка вводимых симолов нового пароля логина 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (clSystemSet.checkChar(e.KeyChar))       //проверить допустимые символы
                e.Handled = true;
        }

        #endregion

        #region //CALLBACK InPut (подписка на внешние сообщения)

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

        #endregion
    }

    #region //CALLBACK OutPut (собственные сообщения)

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

    #endregion
}
