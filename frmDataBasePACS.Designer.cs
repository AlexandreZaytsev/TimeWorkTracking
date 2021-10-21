
namespace TimeWorkTracking
{
    partial class frmDataBasePACS
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
            this.btTestConnectionPacs = new System.Windows.Forms.Button();
            this.mainPanelPACS = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.mainPanelPACS.SuspendLayout();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Gainsboro;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(17, 11);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(284, 20);
            this.label13.TabIndex = 15;
            this.label13.Text = "Подключение web сервису СКУД";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TimeWorkTracking.Properties.Resources.no;
            this.pictureBox1.Location = new System.Drawing.Point(416, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // tbPasswordPASC
            // 
            this.tbPasswordPASC.Location = new System.Drawing.Point(153, 103);
            this.tbPasswordPASC.Margin = new System.Windows.Forms.Padding(4);
            this.tbPasswordPASC.Name = "tbPasswordPASC";
            this.tbPasswordPASC.Size = new System.Drawing.Size(293, 24);
            this.tbPasswordPASC.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 106);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 18);
            this.label9.TabIndex = 11;
            this.label9.Text = "Password";
            // 
            // tbUserNamePACS
            // 
            this.tbUserNamePACS.Location = new System.Drawing.Point(153, 74);
            this.tbUserNamePACS.Margin = new System.Windows.Forms.Padding(1);
            this.tbUserNamePACS.Name = "tbUserNamePACS";
            this.tbUserNamePACS.Size = new System.Drawing.Size(293, 24);
            this.tbUserNamePACS.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 77);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 18);
            this.label10.TabIndex = 9;
            this.label10.Text = "User Name";
            // 
            // label8
            // 
            this.label8.AccessibleName = "";
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 49);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 18);
            this.label8.TabIndex = 4;
            this.label8.Text = "Host Name";
            // 
            // tbHostNamePACS
            // 
            this.tbHostNamePACS.AccessibleName = "";
            this.tbHostNamePACS.Location = new System.Drawing.Point(153, 45);
            this.tbHostNamePACS.Margin = new System.Windows.Forms.Padding(4);
            this.tbHostNamePACS.Name = "tbHostNamePACS";
            this.tbHostNamePACS.Size = new System.Drawing.Size(293, 24);
            this.tbHostNamePACS.TabIndex = 3;
            // 
            // btTestConnectionPacs
            // 
            this.btTestConnectionPacs.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btTestConnectionPacs.Location = new System.Drawing.Point(150, 135);
            this.btTestConnectionPacs.Margin = new System.Windows.Forms.Padding(4);
            this.btTestConnectionPacs.Name = "btTestConnectionPacs";
            this.btTestConnectionPacs.Size = new System.Drawing.Size(296, 32);
            this.btTestConnectionPacs.TabIndex = 1;
            this.btTestConnectionPacs.Text = "Проверитиь соединение";
            this.btTestConnectionPacs.UseVisualStyleBackColor = true;
            this.btTestConnectionPacs.Click += new System.EventHandler(this.btTestConnectionPacs_Click_1);
            // 
            // mainPanelPACS
            // 
            this.mainPanelPACS.Controls.Add(this.label13);
            this.mainPanelPACS.Controls.Add(this.label10);
            this.mainPanelPACS.Controls.Add(this.pictureBox1);
            this.mainPanelPACS.Controls.Add(this.label8);
            this.mainPanelPACS.Controls.Add(this.tbPasswordPASC);
            this.mainPanelPACS.Controls.Add(this.tbUserNamePACS);
            this.mainPanelPACS.Controls.Add(this.btTestConnectionPacs);
            this.mainPanelPACS.Controls.Add(this.tbHostNamePACS);
            this.mainPanelPACS.Controls.Add(this.label9);
            this.mainPanelPACS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanelPACS.Location = new System.Drawing.Point(0, 0);
            this.mainPanelPACS.Margin = new System.Windows.Forms.Padding(2);
            this.mainPanelPACS.Name = "mainPanelPACS";
            this.mainPanelPACS.Size = new System.Drawing.Size(455, 173);
            this.mainPanelPACS.TabIndex = 16;
            // 
            // frmDataBasePACS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 173);
            this.Controls.Add(this.mainPanelPACS);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDataBasePACS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "СКУД Настройка соединения ";
            this.Load += new System.EventHandler(this.frmDataBasePACS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.mainPanelPACS.ResumeLayout(false);
            this.mainPanelPACS.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Button btTestConnectionPacs;
        private System.Windows.Forms.Panel mainPanelPACS;
    }
}