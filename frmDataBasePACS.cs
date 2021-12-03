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
     //   private UriBuilder uriPacs;
        public frmDataBasePACS()
        {
            //подписка события внешних форм 
            CallBack_FrmMain_outEvent.callbackEventHandler = new CallBack_FrmMain_outEvent.callbackEvent(this.CallbackReload);    //subscribe (listen) to the general notification
            InitializeComponent();
        }

        //test Connrection СКУД (web сервис PACS)
        private void btTestConnectionPacs_Click(object sender, EventArgs e)
        {
            UriBuilder uriPacs = GetFormConnectionString();
            string cs = uriPacs.Uri.OriginalString.Replace(uriPacs.Uri.UserInfo + "@", "");
 //           cs = cs.Substring(0, cs.IndexOf('#'));
 //            cs = cs.Replace(uriPacs.Uri.UserInfo + "@", "")
            //            if (!clSystemSet.CheckHost(GetFormConnectionString().AbsoluteUri.Replace(uriPacs.Uri.UserInfo + "@", "")))
//            if (!clSystemSet.CheckHost(cs))
            if (!clSystemSet.CheckPing(uriPacs.Host))
                    MessageBox.Show("Cетевое имя сервера PACS\r\n  " +
                                tbHostNamePACS.Text +
                                "- недоступно\r\n",
                                "Проверка соединения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                TestFormConnectionPACS(uriPacs);        //проверить соединение по настройкам формы
        }
        //полчить строку соединения PACS по настройкам формы
        private UriBuilder GetFormConnectionString()
        {
            UriBuilder uriPacs = new UriBuilder();
            uriPacs.Scheme = tbHostSchemePACS.Text;
            uriPacs.Port = Convert.ToInt32(tbHostPortPACS.Text);
            uriPacs.Host = tbHostNamePACS.Text;
            string pass = clSystemSet.getMD5(clSystemSet.getMD5(clSystemSet.getMD5(tbPasswordPASC.Text) + "F593B01C562548C6B7A31B30884BDE53"));
            // "admin 88020F057FE7287D8D57494382356F97"
            uriPacs.Password = pass;                                                    //хеш пароль                               
            uriPacs.UserName = tbUserNamePACS.Text;
            //uriPacs.Path = "json/";// Authenticate/";
            /*
            string query =
                "{" +
                "\"PasswordHash\":\"" + pass + "\", " +
                "\"UserName\":\"" + tbUserNamePACS.Text + "\"" +
                 "}";
            uriPacs.Fragment = query;
            */
            return uriPacs;// uriPacs.Uri.AbsoluteUri.Replace(uriPacs.Uri.UserInfo + "@", "");     //вернуть строку без логина и пароля
        }

        //проверить соединение по настройкам формы
        private Boolean TestFormConnectionPACS(UriBuilder uriPacs)
        {
            bool ret = false;
            StringBuilder Messages = new StringBuilder();
            string statusDB = clWebServiceDataBase.pacsConnectBase(uriPacs);
                        switch (statusDB)
                        {
                            case "-9":      //соединение установить не удалось
                                statusDB = "";
                                picStatusPACS.Image = global::TimeWorkTracking.Properties.Resources.no;
                                btTestConnectionPacs.Visible = true;
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
            */

            //PACS DataBase
            Properties.Settings.Default.pacsScheme = tbHostSchemePACS.Text.Trim();
            Properties.Settings.Default.pacsPort = Convert.ToInt32(tbHostPortPACS.Text.Trim());
            Properties.Settings.Default.pacsHost = tbHostNamePACS.Text.Trim();
            Properties.Settings.Default.pascLogin = tbUserNamePACS.Text.Trim();
            Properties.Settings.Default.pacsPassword = tbPasswordPASC.Text.Trim();

            Properties.Settings.Default.Save();

            CallBack_FrmDataBasePACS_outEvent.callbackEventHandler("", "", null);  //send a general notification
            return ret;
        }

        private void frmDataBasePACS_Load(object sender, EventArgs e)
        {
            //PACS DataBase
            tbHostSchemePACS.Text = Properties.Settings.Default.pacsScheme;
            tbHostPortPACS.Text = Properties.Settings.Default.pacsPort.ToString();
            tbHostNamePACS.Text = Properties.Settings.Default.pacsHost;
            tbUserNamePACS.Text = Properties.Settings.Default.pascLogin;
            tbPasswordPASC.Text = Properties.Settings.Default.pacsPassword;
 //           GetFormConnectionString();          //инициализируем uri   
        }

        //проверка вводимых симолов нового пароля
        private void tbPasswordPASC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (clSystemSet.checkChar(e.KeyChar))       //проверить допустимые символы
                e.Handled = true;
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
