using System;
using System.Collections.Generic;
using System.Drawing;
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

            //затащим все в одну панель (для редактирования дизайна - компануем панели здесь)    
            //            this.panelAction.Controls.Add(this.panelUser);
            //            this.panelAction.Controls.Add(this.panelAdmin);
            //this.panelAction.Controls.Add(this.panelPasswordChange);
            panelUser.Dock = DockStyle.Fill;
            panelAdmin.Dock = DockStyle.Top;
            panelPasswordChange.Left = 58;
            panelPasswordChange.Top = 49;
            // panelPasswordChange.Dock = DockStyle.Fill;
            this.Width = 325;// 335;
            this.Height = 175;// 185;

            this.KeyPreview = false;                                    //обрабатывать нажатия на форме      

//            cbTypeAccount.Text = "Пользователь";
            //tbNewPassword.PasswordChar = '\u25CF';
            chChangePassword.Visible = false;
            cbTypeAccount.SelectedIndex = 0;
        }

        /// <summary>
        /// выбор учетной записи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbTypeAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbTypeAccount.Text) 
            {
                case "Администратор":
                    panelUser.Visible = false;                          //панель пользователя
                    panelAdmin.Visible = true;                          //панель администратора
                    panelPasswordChange.Visible = false;                //панель изменения пароля
                    timerLogIn.Stop();                                  //остановить таймер на вход для пользователя
                    checkBasePassword();                                //проверить пароль (доп управление админскими панелями)
                    break;
                case "Пользователь":
                    panelUser.Visible = true;                           //панель пользователя
                    panelAdmin.Visible = false;                         //панель администратора
                    panelPasswordChange.Visible = false;                //панель изменения пароля
                    pictureBoxLogIn.Image = Properties.Resources.open_48;
                    timerSec = 5;
                    timerLogIn.Start();                                 //запустить таймер на вход для пользователя
                    btOk.Enabled = true;                                //кнопка входа
                    btOk.Visible = true;
                    pass = true;                                        //доступ разрешен в любом случае
                    break;
            }
//            lbInfo.Text = "";
            checkLoginAndSendEvent();                                   //проинформировать родителя
        }

        /// <summary>
        /// кнопка Вход
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// проверим кто входит откорректируем если нужно и пошлем сообщение главному 
        /// </summary>
        private void checkLoginAndSendEvent()
        {
            string login = cbTypeAccount.Text;
            if (!pass)
                login = "Пользователь";                                         //если доступ не прошел проверку работаем в режиме регистратора
            CallBack_FrmLogIn_outEvent.callbackEventHandler(login, "", null);   //send a general notification
        }

        #region //Вход Пользователя

        /// <summary>
        /// события таймера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        #endregion

        #region //Вход Администратора

        /// <summary>
        /// включить изменение пароля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chChangePassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chChangePassword.Checked)                               //сбросим поле с рабочим паролем
                tbPassword.Text = "";
            
            checkBasePassword();                                        //проверить пароль
            checkLoginAndSendEvent();                                   //проинформировать родителя
        }

        /// <summary>
        /// ввод рабочего пароля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            checkBasePassword();                                        //проверить пароль
            checkLoginAndSendEvent();                                   //проинформировать родителя
        }

        /// <summary>
        /// ввод старого пароля при изменении
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbOldPassword_TextChanged(object sender, EventArgs e)
        {
            checkBasePassword();                                        //проверить пароль
        }

        /// <summary>
        /// проверим корректность введенного пароля
        /// </summary>
        private void checkBasePassword()
        {
            if (!chChangePassword.Checked)
            {                                                           //работаем с главным паролем
                this.Text = "Авторизация";
                panelAdmin.Visible = true;                              //панель администратора
                panelPasswordChange.Visible = false;                    //панель изменения пароля
                btOk.Visible = true;
                if (tbPassword.Text == adminPassword)                   //пароль из настроек и из текстбокса совпадают
                {
                    pass = true;
                    tbPassword.BackColor = SystemColors.Control;
                    pictureBoxLogIn.Image = Properties.Resources.open_48;
                    chChangePassword.Visible = true;
                    btOk.Enabled = true;
                }
                else
                {
                    pass = false;
                    tbPassword.BackColor = SystemColors.Window;
                    pictureBoxLogIn.Image = Properties.Resources.closed_48;
                    chChangePassword.Visible = false;
                    btOk.Enabled = false;
                }
            }
            else
            {                                                           //работаем с изменением пароля
                this.Text = "Изменение пароля администратора";
                panelAdmin.Visible = false;                             //панель администратора
                panelPasswordChange.Visible = true;                     //панель изменения пароля     
                btOk.Visible = false;

                pass = false;
                chChangePassword.Visible = false;
                if (tbOldPassword.Text == adminPassword)                //пароль из настроек и из текстбокса совпадают
                {
                    pictureBoxLogIn.Image = Properties.Resources.open_48;
                    tbOldPassword.BackColor = SystemColors.Control;
                    tbNewPassword.Enabled = true;
                    btSave.Enabled = true;
                }
                else
                {
                    pictureBoxLogIn.Image = Properties.Resources.closed_48;
                    tbOldPassword.BackColor = SystemColors.Window;
                    tbNewPassword.Enabled = false;
                    btSave.Enabled = false;
                }
            }
        }

        /// <summary>
        /// сохранить новый пароль
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.adminPass = tbNewPassword.Text;
            Properties.Settings.Default.Save();                         //сохраним новый пароль в настройках
            adminPassword = tbNewPassword.Text;                         //сохраним его в глобальной переменной
            chChangePassword.Checked = false;                           //вернемся на ввод главного пароля      
        }

        /// <summary>
        /// отказ от нового пароля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btCancel_Click(object sender, EventArgs e)
        {
            chChangePassword.Checked = false;                           //вернемся на ввод главного пароля      
        }

        #endregion

        #region //Interface

        /// <summary>
        /// проверка вводимых симолов нового пароля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbNewPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (clSystemSet.checkChar(e.KeyChar))       //проверить допустимые символы
                e.Handled = true;
        }

        /// <summary>
        /// Hover показать пароль при наезде на кнопку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btSave_MouseHover(object sender, EventArgs e)
        {
            tbNewPassword.PasswordChar = '\0';
        }

        /// <summary>
        /// Leave скрыть пароль при съезде с кнопки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btSave_MouseLeave(object sender, EventArgs e)
        {
            tbNewPassword.PasswordChar = '*';//Convert.ToChar("*");//'\u25CF';
        }

        /// <summary>
        /// закрыть диалог по Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmLogIn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            else if (e.KeyCode == Keys.Enter && pass)   //если Enter и данные подтверждены                                                                                //
                this.Close();
        }

        /// <summary>
        /// при закрытии формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmLogIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            checkLoginAndSendEvent();                   //проинформировать родителя
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

    #endregion
}
