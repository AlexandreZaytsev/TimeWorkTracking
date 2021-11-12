
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelAdmin = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBoxLogIn = new System.Windows.Forms.PictureBox();
            this.panelPasswordChange = new System.Windows.Forms.Panel();
            this.btCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbNewPassword = new System.Windows.Forms.TextBox();
            this.btSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbOldPassword = new System.Windows.Forms.TextBox();
            this.chChangePassword = new System.Windows.Forms.CheckBox();
            this.lbPassword = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.lbInfo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbTypeAccount = new System.Windows.Forms.ComboBox();
            this.toolTipMsgLogIn = new System.Windows.Forms.ToolTip(this.components);
            this.mainPanelLogIn.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogIn)).BeginInit();
            this.panelPasswordChange.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanelLogIn
            // 
            this.mainPanelLogIn.Controls.Add(this.panel2);
            this.mainPanelLogIn.Controls.Add(this.panel1);
            this.mainPanelLogIn.Controls.Add(this.label2);
            this.mainPanelLogIn.Controls.Add(this.cbTypeAccount);
            this.mainPanelLogIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanelLogIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mainPanelLogIn.Location = new System.Drawing.Point(0, 0);
            this.mainPanelLogIn.Name = "mainPanelLogIn";
            this.mainPanelLogIn.Size = new System.Drawing.Size(712, 467);
            this.mainPanelLogIn.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.pictureBoxLogIn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(52, 467);
            this.panel2.TabIndex = 9;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TimeWorkTracking.Properties.Resources.pass;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(8, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(37, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelAdmin);
            this.panel1.Controls.Add(this.lbInfo);
            this.panel1.Location = new System.Drawing.Point(211, 170);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(479, 285);
            this.panel1.TabIndex = 8;
            // 
            // panelAdmin
            // 
            this.panelAdmin.Controls.Add(this.panel4);
            this.panelAdmin.Controls.Add(this.panelPasswordChange);
            this.panelAdmin.Controls.Add(this.chChangePassword);
            this.panelAdmin.Controls.Add(this.lbPassword);
            this.panelAdmin.Controls.Add(this.tbPassword);
            this.panelAdmin.Location = new System.Drawing.Point(20, 13);
            this.panelAdmin.Name = "panelAdmin";
            this.panelAdmin.Size = new System.Drawing.Size(407, 172);
            this.panelAdmin.TabIndex = 7;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Location = new System.Drawing.Point(8, 34);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(240, 1);
            this.panel4.TabIndex = 29;
            // 
            // pictureBoxLogIn
            // 
            this.pictureBoxLogIn.Image = global::TimeWorkTracking.Properties.Resources.closed_48;
            this.pictureBoxLogIn.Location = new System.Drawing.Point(8, 232);
            this.pictureBoxLogIn.Name = "pictureBoxLogIn";
            this.pictureBoxLogIn.Size = new System.Drawing.Size(33, 31);
            this.pictureBoxLogIn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogIn.TabIndex = 9;
            this.pictureBoxLogIn.TabStop = false;
            // 
            // panelPasswordChange
            // 
            this.panelPasswordChange.Controls.Add(this.btCancel);
            this.panelPasswordChange.Controls.Add(this.label1);
            this.panelPasswordChange.Controls.Add(this.tbNewPassword);
            this.panelPasswordChange.Controls.Add(this.btSave);
            this.panelPasswordChange.Controls.Add(this.label3);
            this.panelPasswordChange.Controls.Add(this.tbOldPassword);
            this.panelPasswordChange.Location = new System.Drawing.Point(73, 49);
            this.panelPasswordChange.Name = "panelPasswordChange";
            this.panelPasswordChange.Size = new System.Drawing.Size(252, 92);
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
            // lbInfo
            // 
            this.lbInfo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lbInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbInfo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbInfo.Location = new System.Drawing.Point(81, 203);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(230, 22);
            this.lbInfo.TabIndex = 0;
            this.lbInfo.Text = resources.GetString("lbInfo.Text");
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(65, 10);
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
            this.cbTypeAccount.Location = new System.Drawing.Point(168, 5);
            this.cbTypeAccount.Name = "cbTypeAccount";
            this.cbTypeAccount.Size = new System.Drawing.Size(143, 26);
            this.cbTypeAccount.TabIndex = 1;
            this.cbTypeAccount.SelectedIndexChanged += new System.EventHandler(this.cbTypeAccount_SelectedIndexChanged);
            // 
            // frmLogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 467);
            this.Controls.Add(this.mainPanelLogIn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmLogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Авторизация";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLogIn_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLogIn_KeyDown);
            this.mainPanelLogIn.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panelAdmin.ResumeLayout(false);
            this.panelAdmin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogIn)).EndInit();
            this.panelPasswordChange.ResumeLayout(false);
            this.panelPasswordChange.PerformLayout();
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBoxLogIn;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btCancel;
    }
}