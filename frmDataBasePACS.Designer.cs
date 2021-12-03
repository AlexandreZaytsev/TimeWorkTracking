
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
            this.picStatusPACS = new System.Windows.Forms.PictureBox();
            this.tbPasswordPASC = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbUserNamePACS = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbHostNamePACS = new System.Windows.Forms.TextBox();
            this.btTestConnectionPacs = new System.Windows.Forms.Button();
            this.mainPanelPACS = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.tbHostPortPACS = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbHostSchemePACS = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picStatusPACS)).BeginInit();
            this.mainPanelPACS.SuspendLayout();
            this.SuspendLayout();
            // 
            // picStatusPACS
            // 
            this.picStatusPACS.Image = global::TimeWorkTracking.Properties.Resources.no;
            this.picStatusPACS.Location = new System.Drawing.Point(306, 104);
            this.picStatusPACS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picStatusPACS.Name = "picStatusPACS";
            this.picStatusPACS.Size = new System.Drawing.Size(30, 28);
            this.picStatusPACS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picStatusPACS.TabIndex = 14;
            this.picStatusPACS.TabStop = false;
            // 
            // tbPasswordPASC
            // 
            this.tbPasswordPASC.Location = new System.Drawing.Point(97, 77);
            this.tbPasswordPASC.Margin = new System.Windows.Forms.Padding(4);
            this.tbPasswordPASC.Name = "tbPasswordPASC";
            this.tbPasswordPASC.Size = new System.Drawing.Size(239, 21);
            this.tbPasswordPASC.TabIndex = 12;
            this.tbPasswordPASC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPasswordPASC_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 80);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 15);
            this.label9.TabIndex = 11;
            this.label9.Text = "Password";
            // 
            // tbUserNamePACS
            // 
            this.tbUserNamePACS.Location = new System.Drawing.Point(97, 54);
            this.tbUserNamePACS.Margin = new System.Windows.Forms.Padding(1);
            this.tbUserNamePACS.Name = "tbUserNamePACS";
            this.tbUserNamePACS.Size = new System.Drawing.Size(239, 21);
            this.tbUserNamePACS.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 57);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 15);
            this.label10.TabIndex = 9;
            this.label10.Text = "User Name";
            // 
            // label8
            // 
            this.label8.AccessibleName = "";
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 33);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 15);
            this.label8.TabIndex = 4;
            this.label8.Text = "Host Name";
            // 
            // tbHostNamePACS
            // 
            this.tbHostNamePACS.AccessibleName = "";
            this.tbHostNamePACS.Location = new System.Drawing.Point(97, 30);
            this.tbHostNamePACS.Margin = new System.Windows.Forms.Padding(4);
            this.tbHostNamePACS.Name = "tbHostNamePACS";
            this.tbHostNamePACS.Size = new System.Drawing.Size(239, 21);
            this.tbHostNamePACS.TabIndex = 3;
            // 
            // btTestConnectionPacs
            // 
            this.btTestConnectionPacs.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btTestConnectionPacs.Location = new System.Drawing.Point(97, 102);
            this.btTestConnectionPacs.Margin = new System.Windows.Forms.Padding(4);
            this.btTestConnectionPacs.Name = "btTestConnectionPacs";
            this.btTestConnectionPacs.Size = new System.Drawing.Size(202, 30);
            this.btTestConnectionPacs.TabIndex = 1;
            this.btTestConnectionPacs.Text = "Проверитиь соединение";
            this.btTestConnectionPacs.UseVisualStyleBackColor = true;
            this.btTestConnectionPacs.Click += new System.EventHandler(this.btTestConnectionPacs_Click);
            // 
            // mainPanelPACS
            // 
            this.mainPanelPACS.Controls.Add(this.label2);
            this.mainPanelPACS.Controls.Add(this.tbHostPortPACS);
            this.mainPanelPACS.Controls.Add(this.label1);
            this.mainPanelPACS.Controls.Add(this.tbHostSchemePACS);
            this.mainPanelPACS.Controls.Add(this.label10);
            this.mainPanelPACS.Controls.Add(this.picStatusPACS);
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
            this.mainPanelPACS.Size = new System.Drawing.Size(349, 139);
            this.mainPanelPACS.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AccessibleName = "";
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(216, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 15);
            this.label2.TabIndex = 18;
            this.label2.Text = "Port";
            // 
            // tbHostPortPACS
            // 
            this.tbHostPortPACS.AccessibleName = "";
            this.tbHostPortPACS.Location = new System.Drawing.Point(258, 6);
            this.tbHostPortPACS.Margin = new System.Windows.Forms.Padding(4);
            this.tbHostPortPACS.Name = "tbHostPortPACS";
            this.tbHostPortPACS.Size = new System.Drawing.Size(78, 21);
            this.tbHostPortPACS.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AccessibleName = "";
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 16;
            this.label1.Text = "Scheme";
            // 
            // tbHostSchemePACS
            // 
            this.tbHostSchemePACS.AccessibleName = "";
            this.tbHostSchemePACS.Location = new System.Drawing.Point(97, 6);
            this.tbHostSchemePACS.Margin = new System.Windows.Forms.Padding(4);
            this.tbHostSchemePACS.Name = "tbHostSchemePACS";
            this.tbHostSchemePACS.Size = new System.Drawing.Size(78, 21);
            this.tbHostSchemePACS.TabIndex = 15;
            // 
            // frmDataBasePACS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 139);
            this.Controls.Add(this.mainPanelPACS);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDataBasePACS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Подключение web сервису СКУД";
            this.Load += new System.EventHandler(this.frmDataBasePACS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picStatusPACS)).EndInit();
            this.mainPanelPACS.ResumeLayout(false);
            this.mainPanelPACS.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox picStatusPACS;
        private System.Windows.Forms.TextBox tbPasswordPASC;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbUserNamePACS;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbHostNamePACS;
        private System.Windows.Forms.Button btTestConnectionPacs;
        private System.Windows.Forms.Panel mainPanelPACS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbHostSchemePACS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbHostPortPACS;
    }
}