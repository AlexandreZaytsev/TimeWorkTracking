
namespace TimeWorkTracking
{
    partial class frmUsers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsers));
            this.mainPanelUsers = new System.Windows.Forms.Panel();
            this.btImport = new System.Windows.Forms.Button();
            this.tbUserID = new System.Windows.Forms.TextBox();
            this.btUpdate = new System.Windows.Forms.Button();
            this.btInsert = new System.Windows.Forms.Button();
            this.chUse = new System.Windows.Forms.CheckBox();
            this.imglStatus = new System.Windows.Forms.ImageList(this.components);
            this.lstwDataBaseUsers = new System.Windows.Forms.ListView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.udAfterM = new System.Windows.Forms.DateTimePicker();
            this.udAfterH = new System.Windows.Forms.DateTimePicker();
            this.udBeforeM = new System.Windows.Forms.DateTimePicker();
            this.udBeforeH = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.chbLunch = new System.Windows.Forms.CheckBox();
            this.cbSheme = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbPost = new System.Windows.Forms.ComboBox();
            this.cbDepartment = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.access = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fio = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbName = new System.Windows.Forms.TextBox();
            this.mainPanelUsers.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanelUsers
            // 
            this.mainPanelUsers.Controls.Add(this.btImport);
            this.mainPanelUsers.Controls.Add(this.tbUserID);
            this.mainPanelUsers.Controls.Add(this.btUpdate);
            this.mainPanelUsers.Controls.Add(this.btInsert);
            this.mainPanelUsers.Controls.Add(this.chUse);
            this.mainPanelUsers.Controls.Add(this.lstwDataBaseUsers);
            this.mainPanelUsers.Controls.Add(this.panel3);
            this.mainPanelUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanelUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mainPanelUsers.Location = new System.Drawing.Point(0, 0);
            this.mainPanelUsers.Name = "mainPanelUsers";
            this.mainPanelUsers.Size = new System.Drawing.Size(892, 313);
            this.mainPanelUsers.TabIndex = 0;
            // 
            // btImport
            // 
            this.btImport.Location = new System.Drawing.Point(565, 275);
            this.btImport.Name = "btImport";
            this.btImport.Size = new System.Drawing.Size(120, 30);
            this.btImport.TabIndex = 23;
            this.btImport.Text = "Импорт";
            this.btImport.UseVisualStyleBackColor = true;
            this.btImport.Click += new System.EventHandler(this.btImport_Click);
            // 
            // tbUserID
            // 
            this.tbUserID.BackColor = System.Drawing.SystemColors.Control;
            this.tbUserID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbUserID.Enabled = false;
            this.tbUserID.Location = new System.Drawing.Point(397, 16);
            this.tbUserID.Name = "tbUserID";
            this.tbUserID.Size = new System.Drawing.Size(207, 17);
            this.tbUserID.TabIndex = 22;
            // 
            // btUpdate
            // 
            this.btUpdate.Enabled = false;
            this.btUpdate.Location = new System.Drawing.Point(762, 275);
            this.btUpdate.Name = "btUpdate";
            this.btUpdate.Size = new System.Drawing.Size(120, 30);
            this.btUpdate.TabIndex = 21;
            this.btUpdate.Text = "Обновить";
            this.btUpdate.UseVisualStyleBackColor = true;
            // 
            // btInsert
            // 
            this.btInsert.Enabled = false;
            this.btInsert.Location = new System.Drawing.Point(389, 275);
            this.btInsert.Name = "btInsert";
            this.btInsert.Size = new System.Drawing.Size(120, 30);
            this.btInsert.TabIndex = 20;
            this.btInsert.Text = "Добавить";
            this.btInsert.UseVisualStyleBackColor = true;
            // 
            // chUse
            // 
            this.chUse.Appearance = System.Windows.Forms.Appearance.Button;
            this.chUse.AutoSize = true;
            this.chUse.FlatAppearance.BorderSize = 0;
            this.chUse.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.chUse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.chUse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.chUse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chUse.ImageIndex = 2;
            this.chUse.ImageList = this.imglStatus;
            this.chUse.Location = new System.Drawing.Point(600, 11);
            this.chUse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chUse.Name = "chUse";
            this.chUse.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chUse.Size = new System.Drawing.Size(253, 28);
            this.chUse.TabIndex = 19;
            this.chUse.Text = "Доступно для использования";
            this.chUse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chUse.UseVisualStyleBackColor = true;
            this.chUse.CheckedChanged += new System.EventHandler(this.chUse_CheckedChanged);
            // 
            // imglStatus
            // 
            this.imglStatus.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglStatus.ImageStream")));
            this.imglStatus.TransparentColor = System.Drawing.Color.Transparent;
            this.imglStatus.Images.SetKeyName(0, "setting.ico");
            this.imglStatus.Images.SetKeyName(1, "on5m.png");
            this.imglStatus.Images.SetKeyName(2, "off5m.png");
            this.imglStatus.Images.SetKeyName(3, "mdb_add.png");
            this.imglStatus.Images.SetKeyName(4, "mdb_edit.png");
            this.imglStatus.Images.SetKeyName(5, "mdb_find.png");
            this.imglStatus.Images.SetKeyName(6, "db_min.png");
            // 
            // lstwDataBaseUsers
            // 
            this.lstwDataBaseUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.access,
            this.fio});
            this.lstwDataBaseUsers.HideSelection = false;
            this.lstwDataBaseUsers.Location = new System.Drawing.Point(11, 12);
            this.lstwDataBaseUsers.Name = "lstwDataBaseUsers";
            this.lstwDataBaseUsers.Size = new System.Drawing.Size(373, 294);
            this.lstwDataBaseUsers.SmallImageList = this.imglStatus;
            this.lstwDataBaseUsers.TabIndex = 18;
            this.lstwDataBaseUsers.UseCompatibleStateImageBehavior = false;
            this.lstwDataBaseUsers.View = System.Windows.Forms.View.SmallIcon;
            this.lstwDataBaseUsers.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstwDataBaseUsers_ColumnClick);
            this.lstwDataBaseUsers.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.lstwDataBaseUsers_ColumnWidthChanging);
            this.lstwDataBaseUsers.SelectedIndexChanged += new System.EventHandler(this.lstwDataBaseUsers_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.tbName);
            this.panel3.Controls.Add(this.udAfterM);
            this.panel3.Controls.Add(this.udAfterH);
            this.panel3.Controls.Add(this.udBeforeM);
            this.panel3.Controls.Add(this.udBeforeH);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Location = new System.Drawing.Point(389, 44);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(493, 222);
            this.panel3.TabIndex = 16;
            // 
            // udAfterM
            // 
            this.udAfterM.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.udAfterM.CustomFormat = "mm";
            this.udAfterM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.udAfterM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.udAfterM.Location = new System.Drawing.Point(406, 126);
            this.udAfterM.Name = "udAfterM";
            this.udAfterM.ShowUpDown = true;
            this.udAfterM.Size = new System.Drawing.Size(56, 30);
            this.udAfterM.TabIndex = 19;
            this.udAfterM.Value = new System.DateTime(2021, 10, 21, 18, 0, 0, 0);
            // 
            // udAfterH
            // 
            this.udAfterH.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.udAfterH.CustomFormat = "HH";
            this.udAfterH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.udAfterH.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.udAfterH.Location = new System.Drawing.Point(323, 126);
            this.udAfterH.Name = "udAfterH";
            this.udAfterH.ShowUpDown = true;
            this.udAfterH.Size = new System.Drawing.Size(56, 30);
            this.udAfterH.TabIndex = 18;
            this.udAfterH.Value = new System.DateTime(2021, 10, 21, 18, 0, 0, 0);
            // 
            // udBeforeM
            // 
            this.udBeforeM.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.udBeforeM.CustomFormat = "mm";
            this.udBeforeM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.udBeforeM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.udBeforeM.Location = new System.Drawing.Point(239, 126);
            this.udBeforeM.Name = "udBeforeM";
            this.udBeforeM.ShowUpDown = true;
            this.udBeforeM.Size = new System.Drawing.Size(56, 30);
            this.udBeforeM.TabIndex = 17;
            this.udBeforeM.Value = new System.DateTime(2021, 10, 21, 9, 0, 0, 0);
            // 
            // udBeforeH
            // 
            this.udBeforeH.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.udBeforeH.Checked = false;
            this.udBeforeH.CustomFormat = "HH";
            this.udBeforeH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.udBeforeH.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.udBeforeH.Location = new System.Drawing.Point(158, 126);
            this.udBeforeH.Name = "udBeforeH";
            this.udBeforeH.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.udBeforeH.ShowUpDown = true;
            this.udBeforeH.Size = new System.Drawing.Size(56, 30);
            this.udBeforeH.TabIndex = 16;
            this.udBeforeH.Value = new System.DateTime(2021, 10, 21, 9, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(22, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "ФИО";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.chbLunch);
            this.panel2.Controls.Add(this.cbSheme);
            this.panel2.Location = new System.Drawing.Point(7, 162);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(477, 44);
            this.panel2.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 18);
            this.label8.TabIndex = 12;
            this.label8.Text = "Тариф";
            // 
            // chbLunch
            // 
            this.chbLunch.AutoSize = true;
            this.chbLunch.Location = new System.Drawing.Point(274, 11);
            this.chbLunch.Name = "chbLunch";
            this.chbLunch.Size = new System.Drawing.Size(172, 22);
            this.chbLunch.TabIndex = 14;
            this.chbLunch.Text = "Работает без обеда";
            this.chbLunch.UseVisualStyleBackColor = true;
            // 
            // cbSheme
            // 
            this.cbSheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSheme.FormattingEnabled = true;
            this.cbSheme.Location = new System.Drawing.Point(138, 9);
            this.cbSheme.Name = "cbSheme";
            this.cbSheme.Size = new System.Drawing.Size(130, 26);
            this.cbSheme.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cbPost);
            this.panel1.Controls.Add(this.cbDepartment);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(7, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(477, 80);
            this.panel1.TabIndex = 2;
            // 
            // cbPost
            // 
            this.cbPost.BackColor = System.Drawing.SystemColors.Control;
            this.cbPost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPost.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbPost.FormattingEnabled = true;
            this.cbPost.Location = new System.Drawing.Point(138, 41);
            this.cbPost.Name = "cbPost";
            this.cbPost.Size = new System.Drawing.Size(326, 26);
            this.cbPost.TabIndex = 6;
            this.cbPost.TextChanged += new System.EventHandler(this.cbPost_TextChanged);
            // 
            // cbDepartment
            // 
            this.cbDepartment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbDepartment.BackColor = System.Drawing.SystemColors.Control;
            this.cbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDepartment.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbDepartment.FormattingEnabled = true;
            this.cbDepartment.Location = new System.Drawing.Point(138, 9);
            this.cbDepartment.Name = "cbDepartment";
            this.cbDepartment.Size = new System.Drawing.Size(326, 26);
            this.cbDepartment.TabIndex = 5;
            this.cbDepartment.TextChanged += new System.EventHandler(this.cbDepartment_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(7, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Должность";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(7, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Департамент";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(384, 128);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 25);
            this.label7.TabIndex = 10;
            this.label7.Text = ":";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "График";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(300, 128);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 25);
            this.label6.TabIndex = 8;
            this.label6.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(217, 128);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 25);
            this.label5.TabIndex = 6;
            this.label5.Text = ":";
            // 
            // access
            // 
            this.access.Text = "";
            this.access.Width = 29;
            // 
            // fio
            // 
            this.fio.Text = "ФИО";
            this.fio.Width = 300;
            // 
            // tbName
            // 
            this.tbName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbName.BackColor = System.Drawing.SystemColors.Control;
            this.tbName.Location = new System.Drawing.Point(146, 9);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(326, 24);
            this.tbName.TabIndex = 20;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // frmUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 313);
            this.Controls.Add(this.mainPanelUsers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmUsers";
            this.Text = "Пользователи";
            this.Load += new System.EventHandler(this.frmUsers_Load);
            this.mainPanelUsers.ResumeLayout(false);
            this.mainPanelUsers.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanelUsers;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbPost;
        private System.Windows.Forms.ComboBox cbDepartment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chbLunch;
        private System.Windows.Forms.ComboBox cbSheme;
        private System.Windows.Forms.ListView lstwDataBaseUsers;
        private System.Windows.Forms.ImageList imglStatus;
        private System.Windows.Forms.CheckBox chUse;
        private System.Windows.Forms.Button btUpdate;
        private System.Windows.Forms.Button btInsert;
        private System.Windows.Forms.TextBox tbUserID;
        private System.Windows.Forms.DateTimePicker udBeforeH;
        private System.Windows.Forms.DateTimePicker udAfterM;
        private System.Windows.Forms.DateTimePicker udAfterH;
        private System.Windows.Forms.DateTimePicker udBeforeM;
        private System.Windows.Forms.Button btImport;
        private System.Windows.Forms.ColumnHeader access;
        private System.Windows.Forms.ColumnHeader fio;
        private System.Windows.Forms.TextBox tbName;
    }
}