
namespace TimeWorkTracking
{
    partial class frmLogIn
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogIn));
            this.mainPanelLogIn = new System.Windows.Forms.Panel();
            this.panelUser = new System.Windows.Forms.Panel();
            this.lbInfo = new System.Windows.Forms.Label();
            this.panelPasswordChange = new System.Windows.Forms.Panel();
            this.btCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbNewPassword = new System.Windows.Forms.TextBox();
            this.btSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbOldPassword = new System.Windows.Forms.TextBox();
            this.panelAction = new System.Windows.Forms.Panel();
            this.btOk = new System.Windows.Forms.Button();
            this.panelAdmin = new System.Windows.Forms.Panel();
            this.chChangePassword = new System.Windows.Forms.CheckBox();
            this.lbPassword = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBoxLogIn = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbTypeAccount = new System.Windows.Forms.ComboBox();
            this.toolTipMsgLogIn = new System.Windows.Forms.ToolTip(this.components);
            this.timerLogIn = new System.Windows.Forms.Timer(this.components);
            this.mainPanelLogIn.SuspendLayout();
            this.panelUser.SuspendLayout();
            this.panelPasswordChange.SuspendLayout();
            this.panelAdmin.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogIn)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanelLogIn
            // 
            this.mainPanelLogIn.Controls.Add(this.panelUser);
            this.mainPanelLogIn.Controls.Add(this.panelPasswordChange);
            this.mainPanelLogIn.Controls.Add(this.panelAction);
            this.mainPanelLogIn.Controls.Add(this.btOk);
            this.mainPanelLogIn.Controls.Add(this.panelAdmin);
            this.mainPanelLogIn.Controls.Add(this.panel4);
            this.mainPanelLogIn.Controls.Add(this.panel2);
            this.mainPanelLogIn.Controls.Add(this.label2);
            this.mainPanelLogIn.Controls.Add(this.cbTypeAccount);
            this.mainPanelLogIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanelLogIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mainPanelLogIn.Location = new System.Drawing.Point(0, 0);
            this.mainPanelLogIn.Name = "mainPanelLogIn";
            this.mainPanelLogIn.Size = new System.Drawing.Size(625, 183);
            this.mainPanelLogIn.TabIndex = 0;
            // 
            // panelUser
            // 
            this.panelUser.Controls.Add(this.lbInfo);
            this.panelUser.Location = new System.Drawing.Point(344, 10);
            this.panelUser.Name = "panelUser";
            this.panelUser.Size = new System.Drawing.Size(258, 26);
            this.panelUser.TabIndex = 8;
            // 
            // lbInfo
            // 
            this.lbInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbInfo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lbInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbInfo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbInfo.Location = new System.Drawing.Point(0, 0);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(258, 26);
            this.lbInfo.TabIndex = 0;
            this.lbInfo.Tag = "";
            this.lbInfo.Text = "Добро пожаловать";
            this.lbInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelPasswordChange
            // 
            this.panelPasswordChange.Controls.Add(this.btCancel);
            this.panelPasswordChange.Controls.Add(this.label1);
            this.panelPasswordChange.Controls.Add(this.tbNewPassword);
            this.panelPasswordChange.Controls.Add(this.btSave);
            this.panelPasswordChange.Controls.Add(this.label3);
            this.panelPasswordChange.Controls.Add(this.tbOldPassword);
            this.panelPasswordChange.Location = new System.Drawing.Point(344, 90);
            this.panelPasswordChange.Name = "panelPasswordChange";
            this.panelPasswordChange.Size = new System.Drawing.Size(258, 92);
            this.panelPasswordChange.TabIndex = 8;
            // 
            // btCancel
            // 
            this.btCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btCancel.Location = new System.Drawing.Point(9, 63);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(74, 25);
            this.btCancel.TabIndex = 10;
            this.btCancel.Text = "Отмена";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(5, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Новый пароль";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbNewPassword
            // 
            this.tbNewPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbNewPassword.Location = new System.Drawing.Point(107, 35);
            this.tbNewPassword.Name = "tbNewPassword";
            this.tbNewPassword.PasswordChar = '*';
            this.tbNewPassword.Size = new System.Drawing.Size(142, 24);
            this.tbNewPassword.TabIndex = 9;
            this.tbNewPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNewPassword_KeyPress);
            // 
            // btSave
            // 
            this.btSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btSave.Location = new System.Drawing.Point(107, 63);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(141, 25);
            this.btSave.TabIndex = 7;
            this.btSave.Text = "Сохранить";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            this.btSave.MouseLeave += new System.EventHandler(this.btSave_MouseLeave);
            this.btSave.MouseHover += new System.EventHandler(this.btSave_MouseHover);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(6, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Старый пароль";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbOldPassword
            // 
            this.tbOldPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbOldPassword.Location = new System.Drawing.Point(107, 6);
            this.tbOldPassword.Name = "tbOldPassword";
            this.tbOldPassword.PasswordChar = '*';
            this.tbOldPassword.Size = new System.Drawing.Size(142, 24);
            this.tbOldPassword.TabIndex = 6;
            this.tbOldPassword.TextChanged += new System.EventHandler(this.tbOldPassword_TextChanged);
            // 
            // panelAction
            // 
            this.panelAction.Location = new System.Drawing.Point(58, 49);
            this.panelAction.Name = "panelAction";
            this.panelAction.Size = new System.Drawing.Size(256, 100);
            this.panelAction.TabIndex = 31;
            // 
            // btOk
            // 
            this.btOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btOk.Location = new System.Drawing.Point(168, 153);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(143, 25);
            this.btOk.TabIndex = 30;
            this.btOk.Text = "Вход";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // panelAdmin
            // 
            this.panelAdmin.Controls.Add(this.chChangePassword);
            this.panelAdmin.Controls.Add(this.lbPassword);
            this.panelAdmin.Controls.Add(this.tbPassword);
            this.panelAdmin.Location = new System.Drawing.Point(344, 49);
            this.panelAdmin.Name = "panelAdmin";
            this.panelAdmin.Size = new System.Drawing.Size(258, 35);
            this.panelAdmin.TabIndex = 7;
            // 
            // chChangePassword
            // 
            this.chChangePassword.AutoSize = true;
            this.chChangePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chChangePassword.Location = new System.Drawing.Point(235, 11);
            this.chChangePassword.Name = "chChangePassword";
            this.chChangePassword.Size = new System.Drawing.Size(15, 14);
            this.chChangePassword.TabIndex = 6;
            this.toolTipMsgLogIn.SetToolTip(this.chChangePassword, "изменить пароль");
            this.chChangePassword.UseVisualStyleBackColor = true;
            this.chChangePassword.CheckedChanged += new System.EventHandler(this.chChangePassword_CheckedChanged);
            // 
            // lbPassword
            // 
            this.lbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbPassword.Location = new System.Drawing.Point(5, 10);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(99, 15);
            this.lbPassword.TabIndex = 3;
            this.lbPassword.Text = "Пароль";
            this.lbPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(107, 5);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(125, 24);
            this.tbPassword.TabIndex = 4;
            this.tbPassword.TextChanged += new System.EventHandler(this.tbPassword_TextChanged);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Location = new System.Drawing.Point(63, 41);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(251, 1);
            this.panel4.TabIndex = 29;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.Controls.Add(this.pictureBoxLogIn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(52, 183);
            this.panel2.TabIndex = 9;
            // 
            // pictureBoxLogIn
            // 
            this.pictureBoxLogIn.Image = global::TimeWorkTracking.Properties.Resources.closed_48;
            this.pictureBoxLogIn.Location = new System.Drawing.Point(7, 5);
            this.pictureBoxLogIn.Name = "pictureBoxLogIn";
            this.pictureBoxLogIn.Size = new System.Drawing.Size(37, 37);
            this.pictureBoxLogIn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogIn.TabIndex = 9;
            this.pictureBoxLogIn.TabStop = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(65, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Учетная запись";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbTypeAccount
            // 
            this.cbTypeAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypeAccount.FormattingEnabled = true;
            this.cbTypeAccount.Items.AddRange(new object[] {
            "Пользователь",
            "Администратор"});
            this.cbTypeAccount.Location = new System.Drawing.Point(168, 10);
            this.cbTypeAccount.Name = "cbTypeAccount";
            this.cbTypeAccount.Size = new System.Drawing.Size(143, 26);
            this.cbTypeAccount.TabIndex = 1;
            this.cbTypeAccount.SelectedIndexChanged += new System.EventHandler(this.cbTypeAccount_SelectedIndexChanged);
            // 
            // timerLogIn
            // 
            this.timerLogIn.Interval = 1000;
            this.timerLogIn.Tick += new System.EventHandler(this.timerLogIn_Tick);
            // 
            // frmLogIn
            // 
            this.AcceptButton = this.btOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 183);
            this.Controls.Add(this.mainPanelLogIn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Авторизация";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLogIn_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLogIn_KeyDown);
            this.mainPanelLogIn.ResumeLayout(false);
            this.panelUser.ResumeLayout(false);
            this.panelPasswordChange.ResumeLayout(false);
            this.panelPasswordChange.PerformLayout();
            this.panelAdmin.ResumeLayout(false);
            this.panelAdmin.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogIn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanelLogIn;
        private System.Windows.Forms.ComboBox cbTypeAccount;
        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chChangePassword;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.ToolTip toolTipMsgLogIn;
        private System.Windows.Forms.TextBox tbOldPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelAdmin;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Panel panelPasswordChange;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNewPassword;
        private System.Windows.Forms.Panel panelUser;
        private System.Windows.Forms.PictureBox pictureBoxLogIn;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Panel panelAction;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Timer timerLogIn;
    }
}