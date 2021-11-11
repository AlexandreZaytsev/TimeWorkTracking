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
    public partial class frmLogIn : Form
    {
        public frmLogIn()
        {
            //подписка события внешних форм 
            CallBack_FrmMain_outEvent.callbackEventHandler = new CallBack_FrmMain_outEvent.callbackEvent(this.CallbackReload);    //subscribe (listen) to the general notification
            InitializeComponent();
            cbTypeAccount.Text = "Пользователь";
        }


        //выбор учетной записи
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbTypeAccount.Text) 
            {
                case "Администратор":
                    panelAdmin.Visible = true;
                    lbInfo.Visible = false;
                    gPanelPasswordChange.Enabled = chChangePassword.Checked;
                    break;
                case "Пользователь":
                    panelAdmin.Visible = false;
                    lbInfo.Visible = true;
                    break;
            }
            CallBack_FrmLogIn_outEvent.callbackEventHandler(cbTypeAccount.Text, "", null);  //send a general notification
        }

        private void chChangePassword_CheckedChanged(object sender, EventArgs e)
        {
            gPanelPasswordChange.Enabled = chChangePassword.Checked;
        }

        //закрыть диалог по Enter
        private void frmLogIn_KeyDown(object sender, KeyEventArgs e)
        {
 
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Escape)
            {
                if (sender.GetType().Name==this.Name)
                    this.Close();
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
