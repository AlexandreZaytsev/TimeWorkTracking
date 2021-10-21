
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
            this.dgDataBase = new System.Windows.Forms.DataGridView();
            this.splitContainerEdit = new System.Windows.Forms.SplitContainer();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.lstDataBase = new System.Windows.Forms.ListBox();
            this.chUse = new System.Windows.Forms.CheckBox();
            this.imglStatus = new System.Windows.Forms.ImageList(this.components);
            this.tbCodeLetter = new System.Windows.Forms.TextBox();
            this.tbCodeDigital = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbNote = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstwDataBase = new System.Windows.Forms.ListView();
            this.used = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.num = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.code = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgDataBase)).BeginInit();
            this.splitContainerEdit.Panel1.SuspendLayout();
            this.splitContainerEdit.Panel2.SuspendLayout();
            this.splitContainerEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgDataBase
            // 
            this.dgDataBase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDataBase.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgDataBase.Location = new System.Drawing.Point(0, 0);
            this.dgDataBase.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgDataBase.Name = "dgDataBase";
            this.dgDataBase.RowHeadersWidth = 51;
            this.dgDataBase.Size = new System.Drawing.Size(174, 261);
            this.dgDataBase.TabIndex = 0;
            // 
            // splitContainerEdit
            // 
            this.splitContainerEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerEdit.Location = new System.Drawing.Point(0, 0);
            this.splitContainerEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainerEdit.Name = "splitContainerEdit";
            // 
            // splitContainerEdit.Panel1
            // 
            this.splitContainerEdit.Panel1.Controls.Add(this.numericUpDown1);
            this.splitContainerEdit.Panel1.Controls.Add(this.lstDataBase);
            this.splitContainerEdit.Panel1.Controls.Add(this.dgDataBase);
            // 
            // splitContainerEdit.Panel2
            // 
            this.splitContainerEdit.Panel2.Controls.Add(this.button2);
            this.splitContainerEdit.Panel2.Controls.Add(this.button1);
            this.splitContainerEdit.Panel2.Controls.Add(this.chUse);
            this.splitContainerEdit.Panel2.Controls.Add(this.panel1);
            this.splitContainerEdit.Panel2.Controls.Add(this.label3);
            this.splitContainerEdit.Panel2.Controls.Add(this.lstwDataBase);
            this.splitContainerEdit.Size = new System.Drawing.Size(1623, 674);
            this.splitContainerEdit.SplitterDistance = 174;
            this.splitContainerEdit.SplitterWidth = 6;
            this.splitContainerEdit.TabIndex = 1;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(32, 271);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(75, 26);
            this.numericUpDown1.TabIndex = 1;
            // 
            // lstDataBase
            // 
            this.lstDataBase.FormattingEnabled = true;
            this.lstDataBase.ItemHeight = 20;
            this.lstDataBase.Location = new System.Drawing.Point(32, 307);
            this.lstDataBase.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstDataBase.Name = "lstDataBase";
            this.lstDataBase.Size = new System.Drawing.Size(346, 104);
            this.lstDataBase.TabIndex = 0;
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
            this.chUse.Location = new System.Drawing.Point(690, 5);
            this.chUse.Name = "chUse";
            this.chUse.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chUse.Size = new System.Drawing.Size(271, 30);
            this.chUse.TabIndex = 11;
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
            this.imglStatus.Images.SetKeyName(3, "on5.png");
            this.imglStatus.Images.SetKeyName(4, "off5.png");
            this.imglStatus.Images.SetKeyName(5, "on5j.jpg");
            this.imglStatus.Images.SetKeyName(6, "off5j.jpg");
            this.imglStatus.Images.SetKeyName(7, "on5b.bmp");
            this.imglStatus.Images.SetKeyName(8, "off5b.bmp");
            this.imglStatus.Images.SetKeyName(9, "on4.png");
            this.imglStatus.Images.SetKeyName(10, "off4.png");
            this.imglStatus.Images.SetKeyName(11, "on1_.png");
            this.imglStatus.Images.SetKeyName(12, "off1_.png");
            this.imglStatus.Images.SetKeyName(13, "on2.png");
            this.imglStatus.Images.SetKeyName(14, "off_.png");
            this.imglStatus.Images.SetKeyName(15, "off2.png");
            this.imglStatus.Images.SetKeyName(16, "on3.png");
            this.imglStatus.Images.SetKeyName(17, "off3.png");
            this.imglStatus.Images.SetKeyName(18, "on_.png");
            this.imglStatus.Images.SetKeyName(19, "on.png");
            this.imglStatus.Images.SetKeyName(20, "off.png");
            this.imglStatus.Images.SetKeyName(21, "sel_.png");
            this.imglStatus.Images.SetKeyName(22, "twt.ico");
            this.imglStatus.Images.SetKeyName(23, "sel.png");
            this.imglStatus.Images.SetKeyName(24, "ok.png");
            // 
            // tbCodeLetter
            // 
            this.tbCodeLetter.Location = new System.Drawing.Point(358, 183);
            this.tbCodeLetter.Name = "tbCodeLetter";
            this.tbCodeLetter.Size = new System.Drawing.Size(52, 26);
            this.tbCodeLetter.TabIndex = 10;
            this.tbCodeLetter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbCodeDigital
            // 
            this.tbCodeDigital.Location = new System.Drawing.Point(131, 183);
            this.tbCodeDigital.Name = "tbCodeDigital";
            this.tbCodeDigital.Size = new System.Drawing.Size(52, 26);
            this.tbCodeDigital.TabIndex = 9;
            this.tbCodeDigital.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(229, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Буквенный код";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Цифровой код";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(241, 402);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Код";
            // 
            // tbNote
            // 
            this.tbNote.Location = new System.Drawing.Point(7, 88);
            this.tbNote.Multiline = true;
            this.tbNote.Name = "tbNote";
            this.tbNote.Size = new System.Drawing.Size(403, 86);
            this.tbNote.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Описание";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(7, 34);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(403, 26);
            this.tbName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Наименование";
            // 
            // lstwDataBase
            // 
            this.lstwDataBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstwDataBase.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.used,
            this.num,
            this.code,
            this.name});
            this.lstwDataBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lstwDataBase.HideSelection = false;
            this.lstwDataBase.Location = new System.Drawing.Point(4, 5);
            this.lstwDataBase.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstwDataBase.MultiSelect = false;
            this.lstwDataBase.Name = "lstwDataBase";
            this.lstwDataBase.Size = new System.Drawing.Size(553, 350);
            this.lstwDataBase.TabIndex = 1;
            this.lstwDataBase.UseCompatibleStateImageBehavior = false;
            this.lstwDataBase.View = System.Windows.Forms.View.SmallIcon;
            this.lstwDataBase.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstwDataBase_ColumnClick);
            this.lstwDataBase.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.lstwDataBase_ColumnWidthChanging);
            this.lstwDataBase.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lstwDataBase_DrawColumnHeader);
            this.lstwDataBase.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lstwDataBase_DrawItem);
            this.lstwDataBase.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lstwDataBase_DrawSubItem);
            this.lstwDataBase.ItemActivate += new System.EventHandler(this.lstwDataBase_ItemActivate);
            this.lstwDataBase.SelectedIndexChanged += new System.EventHandler(this.lstwDataBase_SelectedIndexChanged);
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
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbCodeLetter);
            this.panel1.Controls.Add(this.tbName);
            this.panel1.Controls.Add(this.tbCodeDigital);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.tbNote);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(564, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(424, 220);
            this.panel1.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(564, 318);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 37);
            this.button1.TabIndex = 13;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(889, 318);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 37);
            this.button2.TabIndex = 14;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // frmSpecialMarks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1623, 674);
            this.Controls.Add(this.splitContainerEdit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmSpecialMarks";
            this.Text = "Специальные отметки";
            this.Load += new System.EventHandler(this.frmSpecialMarks_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgDataBase)).EndInit();
            this.splitContainerEdit.Panel1.ResumeLayout(false);
            this.splitContainerEdit.Panel2.ResumeLayout(false);
            this.splitContainerEdit.Panel2.PerformLayout();
            this.splitContainerEdit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgDataBase;
        private System.Windows.Forms.SplitContainer splitContainerEdit;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ListBox lstDataBase;
        private System.Windows.Forms.ListView lstwDataBase;
        private System.Windows.Forms.ColumnHeader num;
        private System.Windows.Forms.ColumnHeader code;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader used;
        private System.Windows.Forms.ImageList imglStatus;
        private System.Windows.Forms.CheckBox chUse;
        private System.Windows.Forms.TextBox tbCodeLetter;
        private System.Windows.Forms.TextBox tbCodeDigital;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbNote;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}