
namespace TimeWorkTracking
{
    partial class frmSpecialMarks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSpecialMarks));
            this.imgListStatus = new System.Windows.Forms.ImageList(this.components);
            this.mainPanelSpecialMarks = new System.Windows.Forms.Panel();
            this.btUpdate = new System.Windows.Forms.Button();
            this.imageButton = new System.Windows.Forms.ImageList(this.components);
            this.btInsert = new System.Windows.Forms.Button();
            this.chUse = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbCodeLetter = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbCodeDigital = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbNote = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lstwDataBaseSpecialMarks = new System.Windows.Forms.ListView();
            this.used = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.num = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.code = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolTipMsgMark = new System.Windows.Forms.ToolTip(this.components);
            this.lMsg = new System.Windows.Forms.Label();
            this.tbID = new System.Windows.Forms.TextBox();
            this.mainPanelSpecialMarks.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgListStatus
            // 
            this.imgListStatus.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListStatus.ImageStream")));
            this.imgListStatus.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListStatus.Images.SetKeyName(0, "off5m.png");
            this.imgListStatus.Images.SetKeyName(1, "on5m.png");
            this.imgListStatus.Images.SetKeyName(2, "db_add_48x72.png");
            this.imgListStatus.Images.SetKeyName(3, "db_edit_48x72.png");
            // 
            // mainPanelSpecialMarks
            // 
            this.mainPanelSpecialMarks.Controls.Add(this.btUpdate);
            this.mainPanelSpecialMarks.Controls.Add(this.btInsert);
            this.mainPanelSpecialMarks.Controls.Add(this.panel1);
            this.mainPanelSpecialMarks.Controls.Add(this.lstwDataBaseSpecialMarks);
            this.mainPanelSpecialMarks.Controls.Add(this.lMsg);
            this.mainPanelSpecialMarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanelSpecialMarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mainPanelSpecialMarks.Location = new System.Drawing.Point(0, 0);
            this.mainPanelSpecialMarks.Margin = new System.Windows.Forms.Padding(2);
            this.mainPanelSpecialMarks.Name = "mainPanelSpecialMarks";
            this.mainPanelSpecialMarks.Size = new System.Drawing.Size(674, 233);
            this.mainPanelSpecialMarks.TabIndex = 2;
            // 
            // btUpdate
            // 
            this.btUpdate.Enabled = false;
            this.btUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btUpdate.ImageIndex = 2;
            this.btUpdate.ImageList = this.imageButton;
            this.btUpdate.Location = new System.Drawing.Point(564, 202);
            this.btUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.btUpdate.Name = "btUpdate";
            this.btUpdate.Size = new System.Drawing.Size(105, 26);
            this.btUpdate.TabIndex = 19;
            this.btUpdate.Text = "Обновить";
            this.btUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btUpdate.UseVisualStyleBackColor = true;
            this.btUpdate.Click += new System.EventHandler(this.btUpdate_Click);
            // 
            // imageButton
            // 
            this.imageButton.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageButton.ImageStream")));
            this.imageButton.TransparentColor = System.Drawing.Color.Transparent;
            this.imageButton.Images.SetKeyName(0, "db_48.png");
            this.imageButton.Images.SetKeyName(1, "db_add_48.png");
            this.imageButton.Images.SetKeyName(2, "db_edit_48.png");
            this.imageButton.Images.SetKeyName(3, "db_find_48.png");
            this.imageButton.Images.SetKeyName(4, "db_lock_48.png");
            this.imageButton.Images.SetKeyName(5, "db_unlock_48.png");
            this.imageButton.Images.SetKeyName(6, "db_upload_48.png");
            this.imageButton.Images.SetKeyName(7, "db_import_48.png");
            this.imageButton.Images.SetKeyName(8, "db_export_48.png");
            // 
            // btInsert
            // 
            this.btInsert.Enabled = false;
            this.btInsert.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btInsert.ImageIndex = 1;
            this.btInsert.ImageList = this.imageButton;
            this.btInsert.Location = new System.Drawing.Point(384, 202);
            this.btInsert.Margin = new System.Windows.Forms.Padding(2);
            this.btInsert.Name = "btInsert";
            this.btInsert.Size = new System.Drawing.Size(105, 26);
            this.btInsert.TabIndex = 18;
            this.btInsert.Text = "Добавить";
            this.btInsert.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btInsert.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btInsert.UseVisualStyleBackColor = true;
            this.btInsert.Click += new System.EventHandler(this.btInsert_Click);
            this.btInsert.MouseLeave += new System.EventHandler(this.btInsert_MouseLeave);
            this.btInsert.MouseHover += new System.EventHandler(this.btInsert_MouseHover);
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
            this.chUse.ImageIndex = 0;
            this.chUse.ImageList = this.imgListStatus;
            this.chUse.Location = new System.Drawing.Point(194, 2);
            this.chUse.Margin = new System.Windows.Forms.Padding(2);
            this.chUse.Name = "chUse";
            this.chUse.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chUse.Size = new System.Drawing.Size(84, 25);
            this.chUse.TabIndex = 16;
            this.chUse.Text = "Доступ";
            this.chUse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chUse.UseVisualStyleBackColor = true;
            this.chUse.CheckedChanged += new System.EventHandler(this.chUse_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tbID);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbCodeLetter);
            this.panel1.Controls.Add(this.chUse);
            this.panel1.Controls.Add(this.tbName);
            this.panel1.Controls.Add(this.tbCodeDigital);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.tbNote);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(383, 11);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(286, 143);
            this.panel1.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Наименование";
            // 
            // tbCodeLetter
            // 
            this.tbCodeLetter.Location = new System.Drawing.Point(242, 115);
            this.tbCodeLetter.Margin = new System.Windows.Forms.Padding(2);
            this.tbCodeLetter.Name = "tbCodeLetter";
            this.tbCodeLetter.Size = new System.Drawing.Size(36, 21);
            this.tbCodeLetter.TabIndex = 10;
            this.tbCodeLetter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbName
            // 
            this.tbName.BackColor = System.Drawing.SystemColors.Window;
            this.tbName.HideSelection = false;
            this.tbName.Location = new System.Drawing.Point(8, 28);
            this.tbName.Margin = new System.Windows.Forms.Padding(2);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(270, 21);
            this.tbName.TabIndex = 3;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // tbCodeDigital
            // 
            this.tbCodeDigital.Location = new System.Drawing.Point(104, 115);
            this.tbCodeDigital.Margin = new System.Windows.Forms.Padding(2);
            this.tbCodeDigital.Name = "tbCodeDigital";
            this.tbCodeDigital.Size = new System.Drawing.Size(36, 21);
            this.tbCodeDigital.TabIndex = 9;
            this.tbCodeDigital.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(143, 117);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Буквенный код";
            // 
            // tbNote
            // 
            this.tbNote.Location = new System.Drawing.Point(8, 53);
            this.tbNote.Margin = new System.Windows.Forms.Padding(2);
            this.tbNote.Multiline = true;
            this.tbNote.Name = "tbNote";
            this.tbNote.Size = new System.Drawing.Size(270, 58);
            this.tbNote.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 117);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Цифровой код";
            // 
            // lstwDataBaseSpecialMarks
            // 
            this.lstwDataBaseSpecialMarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstwDataBaseSpecialMarks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.used,
            this.num,
            this.code,
            this.name});
            this.lstwDataBaseSpecialMarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lstwDataBaseSpecialMarks.HideSelection = false;
            this.lstwDataBaseSpecialMarks.Location = new System.Drawing.Point(8, 10);
            this.lstwDataBaseSpecialMarks.Margin = new System.Windows.Forms.Padding(2);
            this.lstwDataBaseSpecialMarks.MultiSelect = false;
            this.lstwDataBaseSpecialMarks.Name = "lstwDataBaseSpecialMarks";
            this.lstwDataBaseSpecialMarks.Size = new System.Drawing.Size(370, 218);
            this.lstwDataBaseSpecialMarks.SmallImageList = this.imgListStatus;
            this.lstwDataBaseSpecialMarks.TabIndex = 15;
            this.lstwDataBaseSpecialMarks.UseCompatibleStateImageBehavior = false;
            this.lstwDataBaseSpecialMarks.View = System.Windows.Forms.View.SmallIcon;
            this.lstwDataBaseSpecialMarks.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstwDataBaseSpecialMarks_ColumnClick);
            this.lstwDataBaseSpecialMarks.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.lstwDataBaseSpecialMarks_ColumnWidthChanging);
            this.lstwDataBaseSpecialMarks.SelectedIndexChanged += new System.EventHandler(this.lstwDataBaseSpecialMarks_SelectedIndexChanged);
            // 
            // used
            // 
            this.used.Text = "";
            this.used.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.used.Width = 29;
            // 
            // num
            // 
            this.num.Text = "№";
            this.num.Width = 30;
            // 
            // code
            // 
            this.code.Text = "Код";
            this.code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.code.Width = 40;
            // 
            // name
            // 
            this.name.Text = "Наименование";
            this.name.Width = 250;
            // 
            // lMsg
            // 
            this.lMsg.AutoSize = true;
            this.lMsg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lMsg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lMsg.ImageIndex = 6;
            this.lMsg.ImageList = this.imageButton;
            this.lMsg.Location = new System.Drawing.Point(507, 206);
            this.lMsg.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lMsg.Name = "lMsg";
            this.lMsg.Size = new System.Drawing.Size(157, 17);
            this.lMsg.TabIndex = 20;
            this.lMsg.Text = "      Новая запись в БД";
            this.lMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(115, 4);
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(25, 21);
            this.tbID.TabIndex = 21;
            // 
            // frmSpecialMarks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 233);
            this.Controls.Add(this.mainPanelSpecialMarks);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSpecialMarks";
            this.Text = "Специальные отметки";
            this.Load += new System.EventHandler(this.frmSpecialMarks_Load);
            this.mainPanelSpecialMarks.ResumeLayout(false);
            this.mainPanelSpecialMarks.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imgListStatus;
        private System.Windows.Forms.Panel mainPanelSpecialMarks;
        private System.Windows.Forms.Button btUpdate;
        private System.Windows.Forms.Button btInsert;
        private System.Windows.Forms.CheckBox chUse;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCodeLetter;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbCodeDigital;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbNote;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lstwDataBaseSpecialMarks;
        private System.Windows.Forms.ColumnHeader used;
        private System.Windows.Forms.ColumnHeader num;
        private System.Windows.Forms.ColumnHeader code;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ImageList imageButton;
        private System.Windows.Forms.ToolTip toolTipMsgMark;
        private System.Windows.Forms.Label lMsg;
        private System.Windows.Forms.TextBox tbID;
    }
}