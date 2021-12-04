
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
            this.nHostPortPACS = new System.Windows.Forms.NumericUpDown();
            this.cbHostSchemePACS = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picStatusPACS)).BeginInit();
            this.mainPanelPACS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nHostPortPACS)).BeginInit();
            this.SuspendLayout();
            // 
            // picStatusPACS
            // 
            this.picStatusPACS.Image = global::TimeWorkTracking.Properties.Resources.no;
            this.picStatusPACS.Location = new System.Drawing.Point(306, 114);
            this.picStatusPACS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picStatusPACS.Name = "picStatusPACS";
            this.picStatusPACS.Size = new System.Drawing.Size(30, 28);
            this.picStatusPACS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picStatusPACS.TabIndex = 14;
            this.picStatusPACS.TabStop = false;
            // 
            // tbPasswordPASC
            // 
            this.tbPasswordPASC.Location = new System.Drawing.Point(97, 86);
            this.tbPasswordPASC.Margin = new System.Windows.Forms.Padding(4);
            this.tbPasswordPASC.Name = "tbPasswordPASC";
            this.tbPasswordPASC.Size = new System.Drawing.Size(239, 24);
            this.tbPasswordPASC.TabIndex = 12;
            this.tbPasswordPASC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 89);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 18);
            this.label9.TabIndex = 11;
            this.label9.Text = "Password";
            // 
            // tbUserNamePACS
            // 
            this.tbUserNamePACS.Location = new System.Drawing.Point(97, 60);
            this.tbUserNamePACS.Margin = new System.Windows.Forms.Padding(1);
            this.tbUserNamePACS.Name = "tbUserNamePACS";
            this.tbUserNamePACS.Size = new System.Drawing.Size(239, 24);
            this.tbUserNamePACS.TabIndex = 10;
            this.tbUserNamePACS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 63);
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
            this.label8.Location = new System.Drawing.Point(12, 37);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 18);
            this.label8.TabIndex = 4;
            this.label8.Text = "Host Name";
            // 
            // tbHostNamePACS
            // 
            this.tbHostNamePACS.AccessibleName = "";
            this.tbHostNamePACS.Location = new System.Drawing.Point(97, 34);
            this.tbHostNamePACS.Margin = new System.Windows.Forms.Padding(4);
            this.tbHostNamePACS.Name = "tbHostNamePACS";
            this.tbHostNamePACS.Size = new System.Drawing.Size(239, 24);
            this.tbHostNamePACS.TabIndex = 3;
            // 
            // btTestConnectionPacs
            // 
            this.btTestConnectionPacs.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btTestConnectionPacs.Location = new System.Drawing.Point(97, 112);
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
            this.mainPanelPACS.Controls.Add(this.nHostPortPACS);
            this.mainPanelPACS.Controls.Add(this.cbHostSchemePACS);
            this.mainPanelPACS.Controls.Add(this.label2);
            this.mainPanelPACS.Controls.Add(this.label1);
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
            this.mainPanelPACS.Size = new System.Drawing.Size(349, 151);
            this.mainPanelPACS.TabIndex = 16;
            // 
            // nHostPortPACS
            // 
            this.nHostPortPACS.Location = new System.Drawing.Point(258, 7);
            this.nHostPortPACS.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nHostPortPACS.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nHostPortPACS.Name = "nHostPortPACS";
            this.nHostPortPACS.Size = new System.Drawing.Size(78, 24);
            this.nHostPortPACS.TabIndex = 20;
            this.nHostPortPACS.Value = new decimal(new int[] {
            40001,
            0,
            0,
            0});
            // 
            // cbHostSchemePACS
            // 
            this.cbHostSchemePACS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHostSchemePACS.FormattingEnabled = true;
            this.cbHostSchemePACS.Items.AddRange(new object[] {
            "http",
            "https"});
            this.cbHostSchemePACS.Location = new System.Drawing.Point(97, 5);
            this.cbHostSchemePACS.Name = "cbHostSchemePACS";
            this.cbHostSchemePACS.Size = new System.Drawing.Size(78, 26);
            this.cbHostSchemePACS.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AccessibleName = "";
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(216, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 18);
            this.label2.TabIndex = 18;
            this.label2.Text = "Port";
            // 
            // label1
            // 
            this.label1.AccessibleName = "";
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 18);
            this.label1.TabIndex = 16;
            this.label1.Text = "Scheme";
            // 
            // frmDataBasePACS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 151);
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
            ((System.ComponentModel.ISupportInitialize)(this.nHostPortPACS)).EndInit();
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbHostSchemePACS;
        private System.Windows.Forms.NumericUpDown nHostPortPACS;
    }
}