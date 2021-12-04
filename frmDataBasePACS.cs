﻿using System;
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
            UriBuilder uriPacs = new UriBuilder
            {
                Scheme = cbHostSchemePACS.Text,
                Port = Convert.ToInt32(nHostPortPACS.Text),
                Host = tbHostNamePACS.Text
            };
            string pass = clSystemSet.getMD5(clSystemSet.getMD5(clSystemSet.getMD5(tbPasswordPASC.Text) + "F593B01C562548C6B7A31B30884BDE53"));
            // "admin 88020F057FE7287D8D57494382356F97"
            uriPacs.Password = pass;                                                    //хеш пароль                               
            uriPacs.UserName = tbUserNamePACS.Text;
            return uriPacs;// uriPacs.Uri.AbsoluteUri.Replace(uriPacs.Uri.UserInfo + "@", "");     //вернуть строку без логина и пароля
        }

        //проверить соединение по настройкам формы
        private Boolean TestFormConnectionPACS(UriBuilder uriPacs)
        {
            bool ret = false;
            StringBuilder Messages = new StringBuilder();
            string statusDB = clPacsWebDataBase.pacsConnectBase(uriPacs);
                        switch (statusDB)
                        {
                            case "-9":      //соединение установить не удалось
                                statusDB = "";
                                picStatusPACS.Image = global::TimeWorkTracking.Properties.Resources.no;
//                                btTestConnectionPacs.Visible = true;
                                Messages.Append("Соединение:" + "\n" +
                                            $"  Схема: {cbHostSchemePACS.Text}" + "\n" +
                                            $"  Порт: {nHostPortPACS.Text}" + "\n" +
                                            $"  Сервер: {tbHostNamePACS.Text}" + "\n" +
                                            $"  Логин: {tbUserNamePACS.Text}" + "\n" +
                                            $"  Пароль: {tbPasswordPASC.Text}" + "\n" +
                                            "установить не удалось");
                                break;
                            default:        //все чики-пуки
                                picStatusPACS.Image = Properties.Resources.ok;
//                                btTestConnectionPacs.Visible = true;
                                  Messages.Append("Соединение установлено");
                                ret = true;
                                break;
                        }
                        MessageBox.Show(Messages.ToString(),
                                        "Подключение к Базе Данных",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Warning);

            Properties.Settings.Default.pacsConnectionString = statusDB;
            //PACS DataBase
            Properties.Settings.Default.pacsScheme = cbHostSchemePACS.Text.Trim();
            Properties.Settings.Default.pacsPort = Convert.ToInt32(nHostPortPACS.Text.Trim());
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
            cbHostSchemePACS.Text = Properties.Settings.Default.pacsScheme;
            nHostPortPACS.Text = Properties.Settings.Default.pacsPort.ToString();
            tbHostNamePACS.Text = Properties.Settings.Default.pacsHost;
            tbUserNamePACS.Text = Properties.Settings.Default.pascLogin;
            tbPasswordPASC.Text = Properties.Settings.Default.pacsPassword;

            CheckConnects();        //проверить соединение с базами
        }
        //проверить соединение с базами
        private void CheckConnects()
        {
            if (!clSystemSet.CheckPing(tbHostNamePACS.Text))
            {
                this.picStatusPACS.Image = Properties.Resources.no;
                /*
                   MessageBox.Show("Cетевое имя сервера PACS\r\n  " +
                                   tbServerTWT.Text +
                                   "- недоступно\r\n",
                                   "Проверка соединения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               */
            }
            else
            {
                if (clPacsWebDataBase.pacsConnectSimple(Properties.Settings.Default.pacsConnectionString))
                    this.picStatusPACS.Image = Properties.Resources.ok;
                else
                    this.picStatusPACS.Image = Properties.Resources.no;

            }
        }
        //проверка вводимых симолов нового пароля логина
        private void tb_KeyPress(object sender, KeyPressEventArgs e)
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
