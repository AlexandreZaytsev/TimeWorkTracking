using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace TimeWorkTracking
{
    public partial class frmSpecialMarks : Form
    {
        ListViewItemComparer _lvwItemComparer;
        public frmSpecialMarks()
        {
            InitializeComponent();
            lMsg.Visible = false;               //погасить сообщение о записи в БД
 //           tbID.Visible = false;
        }
        //загрузка формы
        private void frmSpecialMarks_Load(object sender, EventArgs e)
        {
            string cs = Properties.Settings.Default.twtConnectionSrting;    //connection string
            mainPanelSpecialMarks.Enabled = MsSqlDatabase.CheckConnectWithConnectionStr(cs);
            if (mainPanelSpecialMarks.Enabled) 
            {
                InitializeListView();
                LoadList(MsSqlDatabase.TableRequest(cs, "Select * From SpecialMarks order by id"));

                if (lstwDataBaseSpecialMarks.Items.Count != 0)
                    lstwDataBaseSpecialMarks.Items[0].Selected = true;     //выделить элемент по индексу
            }
        }
        // Initialize ListView
        private void InitializeListView()
        {
            lstwDataBaseSpecialMarks.View = View.Details;               // Set the view to show details.
            lstwDataBaseSpecialMarks.LabelEdit = true;                  // Allow the user to edit item text.
            lstwDataBaseSpecialMarks.AllowColumnReorder = true;         // Allow the user to rearrange columns.
            lstwDataBaseSpecialMarks.FullRowSelect = true;              // Select the item and subitems when selection is made.
            lstwDataBaseSpecialMarks.GridLines = true;                  // Display grid lines.
            lstwDataBaseSpecialMarks.Sorting = SortOrder.Ascending;     // Sort the items in the list in ascending order.

            // The ListViewItemSorter property allows you to specify the
            // object that performs the sorting of items in the ListView.
            // You can use the ListViewItemSorter property in combination
            // with the Sort method to perform custom sorting.
            _lvwItemComparer = new ListViewItemComparer
            {
                SortColumn = 5,                             //сортировка по id бд
                Order = SortOrder.Ascending
            };
            lstwDataBaseSpecialMarks.ListViewItemSorter = _lvwItemComparer;
        }

        //Загрузить Data из DataSet в ListView
        private void LoadList(DataTable dtable)
        {
            lstwDataBaseSpecialMarks.Items.Clear();         // Clear the ListView control
            for (int i = 0; i < dtable.Rows.Count; i++)     // Display items in the ListView control
            {
                DataRow drow = dtable.Rows[i];
                if (drow.RowState != DataRowState.Deleted)  // Only row that have not been deleted
                {
                    // Define the list items
                    lstwDataBaseSpecialMarks.LabelEdit = false;      //запрет редактирования item
                    ListViewItem lvi = new ListViewItem(drow["uses"].ToString(), 0) //имя для сортировки
                    {
                        ImageIndex = (Boolean)drow["uses"] ? 1 : 0
                        , StateImageIndex = (Boolean)drow["uses"] ? 1 : 0
                        , Checked = (Boolean)drow["uses"]
                        //                        , UseItemStyleForSubItems = true
                    };

                    //    lvi.Checked = (Boolean)drow["Uses"];
                    //       lvi.SubItems.Add(drow["Uses"].ToString());
                    lvi.SubItems.Add(drow["digitalCode"].ToString());
                    lvi.SubItems.Add(drow["letterCode"].ToString());
                    lvi.SubItems.Add(drow["name"].ToString());
                    lvi.SubItems.Add(drow["note"].ToString());
                    lvi.SubItems.Add(drow["id"].ToString().PadLeft(8, '0'));        //используется для строковой сортировки по колонке
                    lvi.SubItems.Add(drow["id"].ToString());
                    
                    lstwDataBaseSpecialMarks.Items.Add(lvi);                        // Add the list items to the ListView
                }
            }
        }
        //сортировка по заголовке столбца
        private void lstwDataBaseSpecialMarks_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == _lvwItemComparer.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (_lvwItemComparer.Order == SortOrder.Ascending)
                    _lvwItemComparer.Order = SortOrder.Descending;
                else
                    _lvwItemComparer.Order = SortOrder.Ascending;
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                _lvwItemComparer.SortColumn = e.Column;
                _lvwItemComparer.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.lstwDataBaseSpecialMarks.Sort();
        }
 
        //выбор значения из списка
        private void lstwDataBaseSpecialMarks_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ind = lstwDataBaseSpecialMarks.SelectedIndex();
            if (ind >= 0) 
            {
                tbID.Text = lstwDataBaseSpecialMarks.Items[ind].SubItems[6].Text;
                tbCodeDigital.Text = lstwDataBaseSpecialMarks.Items[ind].SubItems[1].Text;
                tbCodeLetter.Text = lstwDataBaseSpecialMarks.Items[ind].SubItems[2].Text;
                tbName.Text = lstwDataBaseSpecialMarks.Items[ind].SubItems[3].Text;             //name
                tbNote.Text = lstwDataBaseSpecialMarks.Items[ind].SubItems[4].Text;             //note
                chUse.Checked = lstwDataBaseSpecialMarks.Items[ind].Text=="True";
            }
        }

        //запретить изменение размеров
        private void lstwDataBaseSpecialMarks_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = lstwDataBaseSpecialMarks.Columns[e.ColumnIndex].Width;
        }

        //чекбокс запись активна
        private void chUse_CheckedChanged(object sender, EventArgs e)
        {
            chUse.ImageIndex = chUse.Checked ? 1 : 0;
        }

        //редактирование ключевого поля Имя
        private void tbName_TextChanged(object sender, EventArgs e)
        {
            if (tbName.Text.Trim().Length == 0)                             //если поле пустое
            {
                tbName.BackColor = System.Drawing.SystemColors.Window;      //белый фон
                lstwDataBaseSpecialMarks.HideSelection = true;              //снять выделение со строки listview (без перевода фокуса на listwiew)
                btInsert.Enabled = false;                                   //заблокировать кнопку INSERT    
                btUpdate.Enabled = false;                                   //заблокировать кнопку UPDATE    
            }
            else                                                            //если поле не пустое          
            {
                btUpdate.Enabled = true;                                    //разблокировать кнопку записи в БД    
                if (lstwDataBaseSpecialMarks.Items.Cast<ListViewItem>()     //попробовать найти значение ключевого поля (name) в списке ListView
                    .Where(x => (x.SubItems[3].Text == tbName.Text.Trim()))
                    .FirstOrDefault() != null)
                {                                                           //значение есть
                    tbName.BackColor = System.Drawing.SystemColors.Control; //серый фон
                    lstwDataBaseSpecialMarks.HideSelection = false;         //установить выделение строки (без перевода фокуса на listwiew)

                    btInsert.Enabled = false;                               //заблокировать кнопку INSERT    
                    btUpdate.Enabled = true;                                //разблокировать кнопку UPDATE    
                }
                else                                                        //значения нет 
                {
                    tbName.BackColor = System.Drawing.SystemColors.Window;  //белый фон
                    lstwDataBaseSpecialMarks.HideSelection = true;          //снять выделение со строки listview (без перевода фокуса на listwiew)
                    btInsert.Enabled = true;                                //разблокировать кнопку INSERT    
                    btUpdate.Enabled = true;                                //разблокировать кнопку UPDATE    
                }
            }
        }
        //кнопка добавить запись в БД
        private void btInsert_Click(object sender, EventArgs e)
        {
            int index;
            string cs = Properties.Settings.Default.twtConnectionSrting;    //connection string
            string sql =
              "INSERT INTO SpecialMarks(" +
                "digitalCode, " +
                "letterCode, " +
                "name, " +
                "note, " +
                "uses) " +
              "VALUES ( " +
                "N'" + tbCodeDigital.Text.Trim() + "', " +
                "N'" + tbCodeLetter.Text.Trim() + "', " +
                "N'" + tbName.Text.Trim() + "', " +
                "N'" + tbNote.Text.Trim() + "', " +
                (chUse.Checked ? 1 : 0) +
                ")";
            MsSqlDatabase.RequestNonQuery(cs, sql, false);
            LoadList(MsSqlDatabase.TableRequest(cs, "Select * From SpecialMarks order by id"));// order by extId desc"));
            index = lstwDataBaseSpecialMarks.Items.Cast<ListViewItem>()
                .Where(x => (x.SubItems[3].Text == tbName.Text.Trim()))     //найти индекс поиск по полю name
                .FirstOrDefault().Index;
            //            lstwDataBaseUsers.HideSelection = false;                    //отображение выделения 
            lstwDataBaseSpecialMarks.Items[index].Selected = true;          //выделить элемент по индексу
            tbName_TextChanged(null, null);                                 //обновить поля и кнопки

            //            lstwDataBaseUsers.Focus();
            //            lstwDataBaseUsers_ColumnClick(null, new ColumnClickEventArgs(2)); //сортировка
            lstwDataBaseSpecialMarks.EnsureVisible(index);                  //показать в области видимости окна
        }
        //кнопка обновить запись в БД
        private void btUpdate_Click(object sender, EventArgs e)
        {
            int index;
            string cs = Properties.Settings.Default.twtConnectionSrting;    //connection string
            string sql =
              "UPDATE SpecialMarks Set " +
                "digitalCode = N'" + tbCodeDigital.Text.Trim() + "', " +
                "letterCode = N'" + tbCodeLetter.Text.Trim() + "', " +
                "name = N'" + tbName.Text.Trim() + "', " +
                "note = N'" + tbNote.Text.Trim() + "', " +
                "uses = " + (chUse.Checked ? 1 : 0) + " " +
              "WHERE id = " + tbID.Text.Trim() + "";
            MsSqlDatabase.RequestNonQuery(cs, sql, false);
            index = lstwDataBaseSpecialMarks.SelectedIndex();          //сохранить индекс
            LoadList(MsSqlDatabase.TableRequest(cs, "Select * From SpecialMarks order by id"));
            lstwDataBaseSpecialMarks.Items[index].Selected = true;     //выделить элемент по индексу
            lstwDataBaseSpecialMarks.EnsureVisible(index);             //показать в области видимости окна
        }

        //наехали на кнопку Insert загасили id
        private void btInsert_MouseHover(object sender, EventArgs e)
        {
            tbID.Visible = false;
            lMsg.Visible = true;
            btUpdate.Visible = false;
        }
        //уехали с кнопки Insert показали id
        private void btInsert_MouseLeave(object sender, EventArgs e)
        {
            tbID.Visible = true;
            lMsg.Visible = false;
            btUpdate.Visible = true;
        }
    }
}
