
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
            this.panelAdmin = new System.Windows.Forms.Panel();
            this.gPanelPasswordChange = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chChangePassword = new System.Windows.Forms.CheckBox();
            this.lbPassword = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbTypeAccount = new System.Windows.Forms.ComboBox();
            this.lbInfo = new System.Windows.Forms.Label();
            this.toolTipMsgLogIn = new System.Windows.Forms.ToolTip(this.components);
            this.mainPanelLogIn.SuspendLayout();
            this.panelAdmin.SuspendLayout();
            this.gPanelPasswordChange.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanelLogIn
            // 
            this.mainPanelLogIn.Controls.Add(this.panelAdmin);
            this.mainPanelLogIn.Controls.Add(this.label2);
            this.mainPanelLogIn.Controls.Add(this.cbTypeAccount);
            this.mainPanelLogIn.Controls.Add(this.lbInfo);
            this.mainPanelLogIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanelLogIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mainPanelLogIn.Location = new System.Drawing.Point(0, 0);
            this.mainPanelLogIn.Name = "mainPanelLogIn";
            this.mainPanelLogIn.Size = new System.Drawing.Size(266, 161);
            this.mainPanelLogIn.TabIndex = 0;
            // 
            // panelAdmin
            // 
            this.panelAdmin.Controls.Add(this.gPanelPasswordChange);
            this.panelAdmin.Controls.Add(this.chChangePassword);
            this.panelAdmin.Controls.Add(this.lbPassword);
            this.panelAdmin.Controls.Add(this.textBox1);
            this.panelAdmin.Location = new System.Drawing.Point(3, 32);
            this.panelAdmin.Name = "panelAdmin";
            this.panelAdmin.Size = new System.Drawing.Size(260, 121);
            this.panelAdmin.TabIndex = 7;
            // 
            // gPanelPasswordChange
            // 
            this.gPanelPasswordChange.Controls.Add(this.textBox3);
            this.gPanelPasswordChange.Controls.Add(this.label4);
            this.gPanelPasswordChange.Controls.Add(this.textBox2);
            this.gPanelPasswordChange.Controls.Add(this.label3);
            this.gPanelPasswordChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gPanelPasswordChange.Location = new System.Drawing.Point(3, 35);
            this.gPanelPasswordChange.Name = "gPanelPasswordChange";
            this.gPanelPasswordChange.Size = new System.Drawing.Size(252, 80);
            this.gPanelPasswordChange.TabIndex = 5;
            this.gPanelPasswordChange.TabStop = false;
            this.gPanelPasswordChange.Text = "Изменить пароль";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox3.Location = new System.Drawing.Point(107, 45);
            this.textBox3.Name = "textBox3";
            this.textBox3.PasswordChar = '*';
            this.textBox3.Size = new System.Drawing.Size(139, 24);
            this.textBox3.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(2, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Новый пароль";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.Location = new System.Drawing.Point(107, 18);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new System.Drawing.Size(139, 24);
            this.textBox2.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(2, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Старый пароль";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(110, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '*';
            this.textBox1.Size = new System.Drawing.Size(122, 24);
            this.textBox1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(7, 10);
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
            this.cbTypeAccount.Location = new System.Drawing.Point(113, 5);
            this.cbTypeAccount.Name = "cbTypeAccount";
            this.cbTypeAccount.Size = new System.Drawing.Size(145, 26);
            this.cbTypeAccount.TabIndex = 1;
            this.cbTypeAccount.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lbInfo
            // 
            this.lbInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbInfo.Location = new System.Drawing.Point(3, 37);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(255, 121);
            this.lbInfo.TabIndex = 0;
            this.lbInfo.Text = "lbInfo";
            // 
            // frmLogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 161);
            this.Controls.Add(this.mainPanelLogIn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmLogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Авторизация";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLogIn_KeyDown);
            this.mainPanelLogIn.ResumeLayout(false);
            this.panelAdmin.ResumeLayout(false);
            this.panelAdmin.PerformLayout();
            this.gPanelPasswordChange.ResumeLayout(false);
            this.gPanelPasswordChange.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanelLogIn;
        private System.Windows.Forms.ComboBox cbTypeAccount;
        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chChangePassword;
        private System.Windows.Forms.GroupBox gPanelPasswordChange;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.ToolTip toolTipMsgLogIn;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelAdmin;
    }
}