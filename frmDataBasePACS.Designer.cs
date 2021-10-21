
namespace TimeWorkTracking
{
    partial class FrmDataBasePACS
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
            this.label13 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbPasswordPASC = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbUserNamePACS = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbHostNamePACS = new System.Windows.Forms.TextBox();
            this.BtTestConnectionPacs = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Gainsboro;
            this.label13.Location = new System.Drawing.Point(12, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(226, 17);
            this.label13.TabIndex = 15;
            this.label13.Text = "Подключение web сервису СКУД";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TimeWorkTracking.Properties.Resources.no;
            this.pictureBox1.Location = new System.Drawing.Point(372, 9);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(27, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // tbPasswordPASC
            // 
            this.tbPasswordPASC.Location = new System.Drawing.Point(135, 94);
            this.tbPasswordPASC.Margin = new System.Windows.Forms.Padding(4);
            this.tbPasswordPASC.Name = "tbPasswordPASC";
            this.tbPasswordPASC.Size = new System.Drawing.Size(261, 22);
            this.tbPasswordPASC.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 98);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 17);
            this.label9.TabIndex = 11;
            this.label9.Text = "Password";
            // 
            // tbUserNamePACS
            // 
            this.tbUserNamePACS.Location = new System.Drawing.Point(135, 66);
            this.tbUserNamePACS.Margin = new System.Windows.Forms.Padding(4);
            this.tbUserNamePACS.Name = "tbUserNamePACS";
            this.tbUserNamePACS.Size = new System.Drawing.Size(261, 22);
            this.tbUserNamePACS.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 69);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 17);
            this.label10.TabIndex = 9;
            this.label10.Text = "User Name";
            // 
            // label8
            // 
            this.label8.AccessibleName = "";
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 41);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 17);
            this.label8.TabIndex = 4;
            this.label8.Text = "Host Name";
            // 
            // tbHostNamePACS
            // 
            this.tbHostNamePACS.AccessibleName = "";
            this.tbHostNamePACS.Location = new System.Drawing.Point(135, 37);
            this.tbHostNamePACS.Margin = new System.Windows.Forms.Padding(4);
            this.tbHostNamePACS.Name = "tbHostNamePACS";
            this.tbHostNamePACS.Size = new System.Drawing.Size(261, 22);
            this.tbHostNamePACS.TabIndex = 3;
            // 
            // BtTestConnectionPacs
            // 
            this.BtTestConnectionPacs.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BtTestConnectionPacs.Location = new System.Drawing.Point(135, 126);
            this.BtTestConnectionPacs.Margin = new System.Windows.Forms.Padding(4);
            this.BtTestConnectionPacs.Name = "BtTestConnectionPacs";
            this.BtTestConnectionPacs.Size = new System.Drawing.Size(263, 28);
            this.BtTestConnectionPacs.TabIndex = 1;
            this.BtTestConnectionPacs.Text = "Проверитиь соединение";
            this.BtTestConnectionPacs.UseVisualStyleBackColor = true;
            this.BtTestConnectionPacs.Click += new System.EventHandler(this.btTestConnectionPacs_Click_1);
            // 
            // frmDataBasePACS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 161);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tbPasswordPASC);
            this.Controls.Add(this.BtTestConnectionPacs);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbHostNamePACS);
            this.Controls.Add(this.tbUserNamePACS);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label10);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDataBasePACS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "СКУД Настройка соединения ";
            this.Load += new System.EventHandler(this.frmDataBasePACS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tbPasswordPASC;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbUserNamePACS;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbHostNamePACS;
        private System.Windows.Forms.Button BtTestConnectionPacs;
    }
}