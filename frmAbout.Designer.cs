
namespace TimeWorkTracking
{
    partial class frmAbout
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            this.panelAbout = new System.Windows.Forms.Panel();
            this.lbCompanyName = new System.Windows.Forms.Label();
            this.lbCopyright = new System.Windows.Forms.Label();
            this.lbVersion = new System.Windows.Forms.Label();
            this.lbProductName = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBoxLogIn = new System.Windows.Forms.PictureBox();
            this.panelAbout.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogIn)).BeginInit();
            this.SuspendLayout();
            // 
            // panelAbout
            // 
            this.panelAbout.Controls.Add(this.lbCompanyName);
            this.panelAbout.Controls.Add(this.lbCopyright);
            this.panelAbout.Controls.Add(this.lbVersion);
            this.panelAbout.Controls.Add(this.lbProductName);
            this.panelAbout.Controls.Add(this.okButton);
            this.panelAbout.Controls.Add(this.textBoxDescription);
            this.panelAbout.Controls.Add(this.panel2);
            this.panelAbout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panelAbout.Location = new System.Drawing.Point(0, 0);
            this.panelAbout.Name = "panelAbout";
            this.panelAbout.Size = new System.Drawing.Size(424, 199);
            this.panelAbout.TabIndex = 1;
            // 
            // lbCompanyName
            // 
            this.lbCompanyName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbCompanyName.Location = new System.Drawing.Point(55, 59);
            this.lbCompanyName.Name = "lbCompanyName";
            this.lbCompanyName.Size = new System.Drawing.Size(365, 18);
            this.lbCompanyName.TabIndex = 29;
            this.lbCompanyName.Text = "Название организации";
            this.lbCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbCopyright
            // 
            this.lbCopyright.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbCopyright.Location = new System.Drawing.Point(55, 41);
            this.lbCopyright.Name = "lbCopyright";
            this.lbCopyright.Size = new System.Drawing.Size(365, 18);
            this.lbCopyright.TabIndex = 28;
            this.lbCopyright.Text = "Авторские права";
            this.lbCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbVersion
            // 
            this.lbVersion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbVersion.Location = new System.Drawing.Point(55, 23);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(365, 18);
            this.lbVersion.TabIndex = 27;
            this.lbVersion.Text = "Версия";
            this.lbVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbProductName
            // 
            this.lbProductName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbProductName.Location = new System.Drawing.Point(55, 7);
            this.lbProductName.Name = "lbProductName";
            this.lbProductName.Size = new System.Drawing.Size(365, 18);
            this.lbProductName.TabIndex = 26;
            this.lbProductName.Text = "Название продукта";
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.Location = new System.Drawing.Point(346, 172);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 22);
            this.okButton.TabIndex = 25;
            this.okButton.Text = "&ОК";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(55, 84);
            this.textBoxDescription.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDescription.Size = new System.Drawing.Size(365, 84);
            this.textBoxDescription.TabIndex = 24;
            this.textBoxDescription.TabStop = false;
            this.textBoxDescription.Text = resources.GetString("textBoxDescription.Text");
            this.textBoxDescription.DoubleClick += new System.EventHandler(this.textBoxDescription_DoubleClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.Controls.Add(this.pictureBoxLogIn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(52, 199);
            this.panel2.TabIndex = 10;
            // 
            // pictureBoxLogIn
            // 
            this.pictureBoxLogIn.Image = global::TimeWorkTracking.Properties.Resources.info;
            this.pictureBoxLogIn.Location = new System.Drawing.Point(6, 7);
            this.pictureBoxLogIn.Name = "pictureBoxLogIn";
            this.pictureBoxLogIn.Size = new System.Drawing.Size(40, 40);
            this.pictureBoxLogIn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogIn.TabIndex = 9;
            this.pictureBoxLogIn.TabStop = false;
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 199);
            this.Controls.Add(this.panelAbout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAbout";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AboutBox1";
            this.panelAbout.ResumeLayout(false);
            this.panelAbout.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogIn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelAbout;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBoxLogIn;
        private System.Windows.Forms.Label lbProductName;
        private System.Windows.Forms.Label lbCompanyName;
        private System.Windows.Forms.Label lbCopyright;
        private System.Windows.Forms.Label lbVersion;
    }
}
