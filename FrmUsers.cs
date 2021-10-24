using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimeWorkTracking
{
    public partial class frmUsers : Form
    {
        ListViewItemComparer _lvwItemComparer;
        public frmUsers()
        {
            InitializeComponent();
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            mainPanelUsers.Enabled = MsSqlDatabase.CheckConnectWithConnectionStr(Properties.Settings.Default.twtConnectionSrting);
            if (mainPanelUsers.Enabled)
            {
                cbDepartment.DisplayMember = "Name";
                cbDepartment.ValueMember = "id";
                cbDepartment.DataSource = MsSqlDatabase.TableRequest(Properties.Settings.Default.twtConnectionSrting, "Select id, name From UserDepartment");

                cbPost.DisplayMember = "Name";
                cbPost.ValueMember = "id";
                cbPost.DataSource = MsSqlDatabase.TableRequest(Properties.Settings.Default.twtConnectionSrting, "Select id, name From UserPost");

                cbSheme.DisplayMember = "Name";
                cbSheme.ValueMember = "id";
                cbSheme.DataSource = MsSqlDatabase.TableRequest(Properties.Settings.Default.twtConnectionSrting, "Select id, name From UserWorkScheme");

                InitializeListView();
                LoadList(MsSqlDatabase.TableRequest(Properties.Settings.Default.twtConnectionSrting, "select * from twt_GetUserInfo('')"));

                udBeforeH.Value = new DateTime(2000, 1, 1, 9, 0, 0);
                udBeforeM.Value = new DateTime(2000, 1, 1, 9, 0, 0);
                udAfterH.Value = new DateTime(2000, 1, 1, 18, 0, 0);
                udAfterH.Value = new DateTime(2000, 1, 1, 18, 0, 0);
            }
        }
        // Initialize ListView
        private void InitializeListView()
        {
            lstwDataBaseUsers.View = View.Details;               // Set the view to show details.
            lstwDataBaseUsers.LabelEdit = true;                  // Allow the user to edit item text.
            lstwDataBaseUsers.AllowColumnReorder = true;         // Allow the user to rearrange columns.
            lstwDataBaseUsers.FullRowSelect = true;              // Select the item and subitems when selection is made.
            lstwDataBaseUsers.GridLines = true;                  // Display grid lines.
            lstwDataBaseUsers.Sorting = SortOrder.Ascending;     // Sort the items in the list in ascending order.

            // The ListViewItemSorter property allows you to specify the
            // object that performs the sorting of items in the ListView.
            // You can use the ListViewItemSorter property in combination
            // with the Sort method to perform custom sorting.
            _lvwItemComparer = new ListViewItemComparer
            {
                SortColumn = 2,// 1;// e.Column; (3 name)
                Order = SortOrder.Ascending
            };

            lstwDataBaseUsers.ListViewItemSorter = _lvwItemComparer;

        }

        // Load Data from the DataSet into the ListView
        private void LoadList(DataTable dtable)
        {
            lstwDataBaseUsers.Items.Clear();                // Clear the ListView control
            for (int i = 0; i < dtable.Rows.Count; i++)     // Display items in the ListView control
            {
                DataRow drow = dtable.Rows[i];
                if (drow.RowState != DataRowState.Deleted)  // Only row that have not been deleted
                {
                    // Define the list items
                    ListViewItem lvi = new ListViewItem(drow["access"].ToString(), 0)
                    {
                        ImageIndex = (Boolean)drow["access"] ? 1 : 0,
                        StateImageIndex = (Boolean)drow["access"] ? 1 : 0
                    };
                    lvi.SubItems.Add(drow["fio"].ToString());
                    lvi.SubItems.Add(drow["extId"].ToString());
                    lvi.SubItems.Add(drow["department"].ToString());
                    lvi.SubItems.Add(drow["post"].ToString());
                    lvi.SubItems.Add(drow["startTime"].ToString());
                    lvi.SubItems.Add(drow["stopTime"].ToString());
                    lvi.SubItems.Add(drow["noLunch"].ToString());
                    lvi.SubItems.Add(drow["work"].ToString());
                    
                    lstwDataBaseUsers.Items.Add(lvi);       // Add the list items to the ListView
                }
            }
        }
        //сортировка по заголовке столбца
        private void lstwDataBaseUsers_ColumnClick(object sender, ColumnClickEventArgs e)
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
            this.lstwDataBaseUsers.Sort();
        }

        //выбор значения из списка инициализация переменных формы
        private void lstwDataBaseUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime dt;
            int ind = lstwDataBaseUsers.SelectedIndex();
            if (ind >= 0)
            {
                tbUserID.Text = "id: "+lstwDataBaseUsers.Items[ind].SubItems[2].Text;
                chUse.Checked = lstwDataBaseUsers.Items[ind].Text == "True";
                tbName.Text = lstwDataBaseUsers.Items[ind].SubItems[1].Text;
                cbDepartment.Text = lstwDataBaseUsers.Items[ind].SubItems[3].Text;
                cbPost.Text = lstwDataBaseUsers.Items[ind].SubItems[4].Text;
                dt= Convert.ToDateTime(lstwDataBaseUsers.Items[ind].SubItems[5].Text);
                udBeforeH.Value = dt;
                udBeforeM.Value = dt;
                dt = Convert.ToDateTime(lstwDataBaseUsers.Items[ind].SubItems[6].Text);
                udAfterH.Value = dt;
                udAfterM.Value = dt;
                chbLunch.Checked = lstwDataBaseUsers.Items[ind].SubItems[7].Text == "True";
                cbSheme.Text = lstwDataBaseUsers.Items[ind].SubItems[8].Text;
            }
        }
        //запретить изменение размеров
        private void lstwDataBaseUsers_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = lstwDataBaseUsers.Columns[e.ColumnIndex].Width;
        }

        //чекбокс
        private void chUse_CheckedChanged(object sender, EventArgs e)
        {
            if (chUse.Checked)
                chUse.ImageIndex = 1;
            else
                chUse.ImageIndex = 0;
        }
        //импорт
        private void btImport_Click(object sender, EventArgs e)
        {
            ImportFromExel.ImportFromExcel();
        }
        //редактирование списка Департамент
        private void cbDepartment_TextChanged(object sender, EventArgs e)
        {
            if (cbDepartment.FindString(cbDepartment.Text) == -1)
                cbDepartment.BackColor=System.Drawing.SystemColors.Window;
            else
                cbDepartment.BackColor = System.Drawing.SystemColors.Control;
        }
        //редактирование списка Должность
        private void cbPost_TextChanged(object sender, EventArgs e)
        {
            if (cbPost.FindString(cbPost.Text) == -1)
                cbPost.BackColor = System.Drawing.SystemColors.Window;
            else
                cbPost.BackColor = System.Drawing.SystemColors.Control;
        }
        //редактирование ключевого поля Имя
        private void tbName_TextChanged(object sender, EventArgs e)
        {
            var s = lstwDataBaseUsers.Items.Cast<ListViewItem>()
                   .Where(x => (x.SubItems[1].Text == tbName.Text.Trim()))
                   .FirstOrDefault();
            var n = s != null || tbName.Text.Trim().Length!=0;

            if (lstwDataBaseUsers.Items.Cast<ListViewItem>()
                .Where(x => (x.SubItems[1].Text == tbName.Text.Trim()))
                .FirstOrDefault() != null)
            {
                tbName.BackColor = System.Drawing.SystemColors.Control;
                lstwDataBaseUsers.HideSelection = false;
                tbUserID.Visible = true;
                btUpdate.Enabled = true;
                btInsert.Enabled = false;
            }
            else
            {
                tbName.BackColor = System.Drawing.SystemColors.Window;
                lstwDataBaseUsers.HideSelection = true;
                tbUserID.Visible = false;
                btUpdate.Enabled = false;
                btInsert.Enabled = tbName.Text.Trim().Length != 0;  //если поле пустое
            }
        }

    }
}
