
namespace TimeWorkTracking
{
    partial class frmCalendar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCalendar));
            this.mainPanelCalendar = new System.Windows.Forms.Panel();
            this.btUpdate = new System.Windows.Forms.Button();
            this.btInsert = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbCodeLetter = new System.Windows.Forms.TextBox();
            this.chUse = new System.Windows.Forms.CheckBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbCodeDigital = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbNote = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lstwDataBaseCalendar = new System.Windows.Forms.ListView();
            this.used = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.num = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.code = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lMsg = new System.Windows.Forms.Label();
            this.imgListStatusCalendar = new System.Windows.Forms.ImageList(this.components);
            this.imgListButtonCalendar = new System.Windows.Forms.ImageList(this.components);
            this.toolTipMsgCalendar = new System.Windows.Forms.ToolTip(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.mainPanelCalendar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanelCalendar
            // 
            this.mainPanelCalendar.Controls.Add(this.btUpdate);
            this.mainPanelCalendar.Controls.Add(this.btInsert);
            this.mainPanelCalendar.Controls.Add(this.panel1);
            this.mainPanelCalendar.Controls.Add(this.lstwDataBaseCalendar);
            this.mainPanelCalendar.Controls.Add(this.lMsg);
            this.mainPanelCalendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanelCalendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mainPanelCalendar.Location = new System.Drawing.Point(0, 0);
            this.mainPanelCalendar.Margin = new System.Windows.Forms.Padding(2);
            this.mainPanelCalendar.Name = "mainPanelCalendar";
            this.mainPanelCalendar.Size = new System.Drawing.Size(693, 250);
            this.mainPanelCalendar.TabIndex = 3;
            // 
            // btUpdate
            // 
            this.btUpdate.Enabled = false;
            this.btUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btUpdate.ImageIndex = 2;
            this.btUpdate.ImageList = this.imgListButtonCalendar;
            this.btUpdate.Location = new System.Drawing.Point(564, 202);
            this.btUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.btUpdate.Name = "btUpdate";
            this.btUpdate.Size = new System.Drawing.Size(105, 26);
            this.btUpdate.TabIndex = 19;
            this.btUpdate.Text = "Обновить";
            this.btUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btUpdate.UseVisualStyleBackColor = true;
            // 
            // btInsert
            // 
            this.btInsert.Enabled = false;
            this.btInsert.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btInsert.ImageIndex = 1;
            this.btInsert.ImageList = this.imgListButtonCalendar;
            this.btInsert.Location = new System.Drawing.Point(384, 202);
            this.btInsert.Margin = new System.Windows.Forms.Padding(2);
            this.btInsert.Name = "btInsert";
            this.btInsert.Size = new System.Drawing.Size(105, 26);
            this.btInsert.TabIndex = 18;
            this.btInsert.Text = "Добавить";
            this.btInsert.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btInsert.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btInsert.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
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
            // tbID
            // 
            this.tbID.BackColor = System.Drawing.SystemColors.Control;
            this.tbID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbID.Enabled = false;
            this.tbID.Location = new System.Drawing.Point(132, 7);
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(36, 14);
            this.tbID.TabIndex = 21;
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
            this.chUse.ImageList = this.imgListStatusCalendar;
            this.chUse.Location = new System.Drawing.Point(194, 2);
            this.chUse.Margin = new System.Windows.Forms.Padding(2);
            this.chUse.Name = "chUse";
            this.chUse.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chUse.Size = new System.Drawing.Size(84, 25);
            this.chUse.TabIndex = 16;
            this.chUse.Text = "Доступ";
            this.chUse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTipMsgCalendar.SetToolTip(this.chUse, "Дата активна");
            this.chUse.UseVisualStyleBackColor = true;
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
            this.toolTipMsgCalendar.SetToolTip(this.tbNote, "Комментарий");
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
            // lstwDataBaseCalendar
            // 
            this.lstwDataBaseCalendar.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.used,
            this.num,
            this.code,
            this.name});
            this.lstwDataBaseCalendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lstwDataBaseCalendar.HideSelection = false;
            this.lstwDataBaseCalendar.LabelWrap = false;
            this.lstwDataBaseCalendar.Location = new System.Drawing.Point(8, 10);
            this.lstwDataBaseCalendar.Margin = new System.Windows.Forms.Padding(2);
            this.lstwDataBaseCalendar.MultiSelect = false;
            this.lstwDataBaseCalendar.Name = "lstwDataBaseCalendar";
            this.lstwDataBaseCalendar.Size = new System.Drawing.Size(370, 218);
            this.lstwDataBaseCalendar.TabIndex = 15;
            this.lstwDataBaseCalendar.UseCompatibleStateImageBehavior = false;
            this.lstwDataBaseCalendar.View = System.Windows.Forms.View.SmallIcon;
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
            this.lMsg.ImageList = this.imgListButtonCalendar;
            this.lMsg.Location = new System.Drawing.Point(507, 206);
            this.lMsg.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lMsg.Name = "lMsg";
            this.lMsg.Size = new System.Drawing.Size(157, 17);
            this.lMsg.TabIndex = 20;
            this.lMsg.Text = "      Новая запись в БД";
            this.lMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // imgListStatusCalendar
            // 
            this.imgListStatusCalendar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListStatusCalendar.ImageStream")));
            this.imgListStatusCalendar.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListStatusCalendar.Images.SetKeyName(0, "off5m.png");
            this.imgListStatusCalendar.Images.SetKeyName(1, "on5m.png");
            this.imgListStatusCalendar.Images.SetKeyName(2, "db_add_48x72.png");
            this.imgListStatusCalendar.Images.SetKeyName(3, "db_edit_48x72.png");
            // 
            // imgListButtonCalendar
            // 
            this.imgListButtonCalendar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListButtonCalendar.ImageStream")));
            this.imgListButtonCalendar.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListButtonCalendar.Images.SetKeyName(0, "db_48.png");
            this.imgListButtonCalendar.Images.SetKeyName(1, "db_add_48.png");
            this.imgListButtonCalendar.Images.SetKeyName(2, "db_edit_48.png");
            this.imgListButtonCalendar.Images.SetKeyName(3, "db_find_48.png");
            this.imgListButtonCalendar.Images.SetKeyName(4, "db_lock_48.png");
            this.imgListButtonCalendar.Images.SetKeyName(5, "db_unlock_48.png");
            this.imgListButtonCalendar.Images.SetKeyName(6, "db_upload_48.png");
            this.imgListButtonCalendar.Images.SetKeyName(7, "db_import_48.png");
            this.imgListButtonCalendar.Images.SetKeyName(8, "db_export_48.png");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(113, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 15);
            this.label2.TabIndex = 22;
            this.label2.Text = "id:";
            // 
            // frmCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 250);
            this.Controls.Add(this.mainPanelCalendar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmCalendar";
            this.Text = "Производственный календарь";
            this.Load += new System.EventHandler(this.frmCalendar_Load);
            this.mainPanelCalendar.ResumeLayout(false);
            this.mainPanelCalendar.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanelCalendar;
        private System.Windows.Forms.Button btUpdate;
        private System.Windows.Forms.Button btInsert;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCodeLetter;
        private System.Windows.Forms.CheckBox chUse;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbCodeDigital;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbNote;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lstwDataBaseCalendar;
        private System.Windows.Forms.ColumnHeader used;
        private System.Windows.Forms.ColumnHeader num;
        private System.Windows.Forms.ColumnHeader code;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.Label lMsg;
        private System.Windows.Forms.ImageList imgListStatusCalendar;
        private System.Windows.Forms.ImageList imgListButtonCalendar;
        private System.Windows.Forms.ToolTip toolTipMsgCalendar;
        private System.Windows.Forms.Label label2;
    }
}