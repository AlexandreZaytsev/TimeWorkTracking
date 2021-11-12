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
    public partial class frmLogIn : Form
    {
        private bool pass=true;                                         //регистрация одобрена
        private string adminPassword = Properties.Settings.Default.adminPass;
        private int timerSec = 5;                                       //количество секунд до входа
        public frmLogIn()
        {
            //подписка события внешних форм 
            CallBack_FrmMain_outEvent.callbackEventHandler = new CallBack_FrmMain_outEvent.callbackEvent(this.CallbackReload);    //subscribe (listen) to the general notification
            InitializeComponent();
            //затащим все в одну панель    
            this.panelAction.Controls.Add(this.panelUser);
            this.panelAction.Controls.Add(this.panelAdmin);
            this.panelAction.Controls.Add(this.panelPasswordChange);
            panelUser.Dock = DockStyle.Fill;
            panelAdmin.Dock = DockStyle.Top;
            panelPasswordChange.Dock = DockStyle.Fill;
            this.Width = 335;
            this.Height = 222;
            this.KeyPreview = false;                                    //обрабатывать нажатия на форме      

//            cbTypeAccount.Text = "Пользователь";
            //tbNewPassword.PasswordChar = '\u25CF';
            chChangePassword.Visible = false;
            cbTypeAccount.SelectedIndex = 0;
        }

        //выбор учетной записи
        private void cbTypeAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbTypeAccount.Text) 
            {
                case "Администратор":
                    panelUser.Visible = false;
                    panelAdmin.Visible = true;
                    panelPasswordChange.Visible = false;

                    timerLogIn.Stop();                                  //запустить таймер на вход для пользователя
//                    panelAdmin.Visible = true;
//                    panelAdmin.Dock = DockStyle.Fill;
//                    lbInfo.Visible = false;
                    panelPasswordChange.Enabled = chChangePassword.Checked;
                    //                   pass = false;
                    checkBasePassword();                                //проверить пароль
                    break;
                case "Пользователь":
                    panelUser.Visible = true;
                    panelAdmin.Visible = false;
                    panelPasswordChange.Visible = false;

                    pictureBoxLogIn.Image = Properties.Resources.open_48;
                    timerSec = 5;
                    timerLogIn.Start();                                 //запустить таймер на вход для пользователя
//                    panelAdmin.Visible = false;
//                    lbInfo.Visible = true;
//                    lbInfo.Dock = DockStyle.Fill;
                    pass = true;
                    break;
            }
            lbInfo.Text = "";
            checkLoginAndSendEvent();                                   //проинформировать родителя
        }

        //Вход Пользователя-----------------------------------------------------------------------------------

        //события таймера
        private void timerLogIn_Tick(object sender, EventArgs e)
        {
            if (timerSec >= 0)
            {
                lbInfo.Text = "до автоматического входа в систему осталось - " + timerSec.ToString().PadLeft(2, '0') + " сек.";
                timerSec -= 1;
            }
            else
            {
                timerLogIn.Stop();
                lbInfo.Text = "";
                this.Close();
            }
        }

        //Вход Администратора---------------------------------------------------------------------------------

        //включить изменение пароля
        private void chChangePassword_CheckedChanged(object sender, EventArgs e)
        {
            panelPasswordChange.Enabled = chChangePassword.Checked;
            tbPassword.Enabled = !chChangePassword.Checked;

            if (chChangePassword.Checked)                               //сбросим поле с рабочим паролем
                tbPassword.Text = "";
            
            checkBasePassword();                                        //проверить пароль
            checkLoginAndSendEvent();                                   //проинформировать родителя
        }
        //ввод рабочего пароля
        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            checkBasePassword();                                        //проверить пароль
            checkLoginAndSendEvent();                                   //проинформировать родителя
        }
        //ввод старого пароля при изменении 
        private void tbOldPassword_TextChanged(object sender, EventArgs e)
        {
            checkBasePassword();                                        //проверить пароль
        }
        //проверка вводимых симолов нового пароля
        private void tbNewPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            char val = e.KeyChar;
            if (!Char.IsLetterOrDigit(val) && !Char.IsDigit(val) && val != 8 && (val <= 39 || val >= 46) && val != 47 && val != 61) //калькулятор
            {
                e.Handled = true;
            }
        }
        //показать пароль при наезде на кнопку
        private void btSave_MouseHover(object sender, EventArgs e)
        {
            tbNewPassword.PasswordChar = '\0';
        }
        //скрыть пароль при съезде с кнопки
        private void btSave_MouseLeave(object sender, EventArgs e)
        {
            tbNewPassword.PasswordChar = '*';//Convert.ToChar("*");//'\u25CF';
        }


        //проверим корректность введенного пароля
        private void checkBasePassword()
        {
            if (!chChangePassword.Checked) 
            {                                                           //работаем с главным паролем               
                if (tbPassword.Text == adminPassword)                   //пароль из настроек и из текстбокса совпадают
                {
                    pass = true;
                    tbPassword.BackColor = SystemColors.Control;
                    pictureBoxLogIn.Image = Properties.Resources.open_48;
                    chChangePassword.Visible = true;
                }
                else
                {
                    pass = false;
                    tbPassword.BackColor = SystemColors.Window;
                    pictureBoxLogIn.Image = Properties.Resources.closed_48;
                    chChangePassword.Visible = false;
                }
                pictureBoxLogIn.Visible = true;
            }
            else
            {                                                           //работаем с изменением пароля
                pass = false;
                chChangePassword.Visible = false;
                if (tbOldPassword.Text == adminPassword)                //пароль из настроек и из текстбокса совпадают
                {
//                    pass = true;
                    tbOldPassword.BackColor = SystemColors.Control;
                    tbNewPassword.Enabled = true;
                    btSave.Enabled = true;
                }
                else
                {
//                    pass = false;
                    tbOldPassword.BackColor = SystemColors.Window;
                    tbNewPassword.Enabled = false;
                    btSave.Enabled = false;
                }
                pictureBoxLogIn.Visible = false;
            }
        }
        //сохранить новый пароль
        private void btSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.adminPass = tbNewPassword.Text;
            Properties.Settings.Default.Save();                         //сохраним новый пароль в настройках
            adminPassword = tbNewPassword.Text;                         //сохраним его в глобальной переменной
            chChangePassword.Checked = false;                           //вернемся на ввод главного пароля      
        }
        //отказ от нового пароля
        private void btCancel_Click(object sender, EventArgs e)
        {
            chChangePassword.Checked = false;                           //вернемся на ввод главного пароля      
        }

        //проверим корректность данный и пошлем сообщение главному
        private void checkLoginAndSendEvent()
        {
            string login = cbTypeAccount.Text;
            if (!pass)                                                      
                login = "Пользователь";                                         //если доступ не прошел проверку работаем в режиме регистратора
            CallBack_FrmLogIn_outEvent.callbackEventHandler(login, "", null);   //send a general notification
        }

        //закрыть диалог по Enter
        private void frmLogIn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            else if (e.KeyCode == Keys.Enter && pass)   //если Enter и данные подтверждены                                                                                //
                this.Close();
        }

        //Кнопка Вход
        private void btOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //при закрытии формы    
        private void frmLogIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            checkLoginAndSendEvent();                   //проинформировать родителя
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
    public static class CallBack_FrmLogIn_outEvent
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
