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
    public partial class frmCalendar : Form
    {
        ListViewItemComparer _lvwItemComparer;
        public frmCalendar()
        {
            InitializeComponent();
            lMsg.Visible = false;               //погасить сообщение о записи в БД
            tbID.Visible = false;
        }
        //загрузка формы
        private void frmCalendar_Load(object sender, EventArgs e)
        {
            string cs = Properties.Settings.Default.twtConnectionSrting;    //connection string
            mainPanelCalendar.Enabled = MsSqlDatabase.CheckConnectWithConnectionStr(cs);
            if (mainPanelCalendar.Enabled)
            {
                //таблица календаря
                InitializeListViewCalendar();
                LoadListCalendar(MsSqlDatabase.TableRequest(cs, "Select * From twt_GetDateInfo('','') where access=1 order by dWork"));     //сортировка по рабочей (перенос) дате
                if (lstwDataBaseCalendar.Items.Count != 0)
                    lstwDataBaseCalendar.Items[0].Selected = true;     //выделить элемент по индексу
                //таблица типа дня
                InitializeListViewDaysCalendar();
                LoadListDaysCalendar(MsSqlDatabase.TableRequest(cs, "Select * From CalendarDateName where uses=1"));     //сортировка по рабочей (перенос) дате
                if (lstwDataBaseDaysCalendar.Items.Count != 0)
                    lstwDataBaseDaysCalendar.Items[0].Selected = true;     //выделить элемент по индексу
            }
        }
        // Initialize ListView календаря
        private void InitializeListViewCalendar()
        {
            lstwDataBaseCalendar.View = View.Details;               // Set the view to show details.
            lstwDataBaseCalendar.LabelEdit = true;                  // Allow the user to edit item text.
            lstwDataBaseCalendar.AllowColumnReorder = true;         // Allow the user to rearrange columns.
            lstwDataBaseCalendar.FullRowSelect = true;              // Select the item and subitems when selection is made.
            lstwDataBaseCalendar.GridLines = true;                  // Display grid lines.
            lstwDataBaseCalendar.Sorting = SortOrder.Ascending;     // Sort the items in the list in ascending order.

            // The ListViewItemSorter property allows you to specify the
            // object that performs the sorting of items in the ListView.
            // You can use the ListViewItemSorter property in combination
            // with the Sort method to perform custom sorting.
            _lvwItemComparer = new ListViewItemComparer
            {
                SortColumn = 1,                             //сортировка по рабочей дате
                Order = SortOrder.Ascending
            };
            lstwDataBaseCalendar.ListViewItemSorter = _lvwItemComparer;
        }
        //Загрузить Data из DataSet в ListView календаря
        private void LoadListCalendar(DataTable dtable)
        {
            lstwDataBaseCalendar.Items.Clear();         // Clear the ListView control
            for (int i = 0; i < dtable.Rows.Count; i++)     // Display items in the ListView control
            {
                DataRow drow = dtable.Rows[i];
                if (drow.RowState != DataRowState.Deleted)  // Only row that have not been deleted
                {
                    // Define the list items
                    lstwDataBaseCalendar.LabelEdit = false;      //запрет редактирования item
                    ListViewItem lvi = new ListViewItem(drow["access"].ToString(), 0) //имя для сортировки
                    {
                        ImageIndex = (Boolean)drow["access"] ? 1 : 0,
                        StateImageIndex = (Boolean)drow["access"] ? 1 : 0,
                        Checked = (Boolean)drow["access"]
                        //                        , UseItemStyleForSubItems = true
                    };

                    //    lvi.Checked = (Boolean)drow["Uses"];
                    //       lvi.SubItems.Add(drow["Uses"].ToString());
                    lvi.SubItems.Add(((DateTime)drow["dWork"]).ToString("yyyy-MM-dd"));
                    lvi.SubItems.Add(((DateTime)drow["dSource"]).ToString("yyyy-MM-dd"));
                    lvi.SubItems.Add(drow["dName"].ToString());
                    lvi.SubItems.Add(drow["dType"].ToString());

                    lstwDataBaseCalendar.Items.Add(lvi);                        // Add the list items to the ListView
                }
            }
        }
        // Initialize ListView дней календаря
        private void InitializeListViewDaysCalendar()
        {
            lstwDataBaseDaysCalendar.View = View.Details;               // Set the view to show details.
            lstwDataBaseDaysCalendar.LabelEdit = true;                  // Allow the user to edit item text.
            lstwDataBaseDaysCalendar.AllowColumnReorder = true;         // Allow the user to rearrange columns.
            lstwDataBaseDaysCalendar.FullRowSelect = true;              // Select the item and subitems when selection is made.
            lstwDataBaseDaysCalendar.GridLines = true;                  // Display grid lines.
            lstwDataBaseDaysCalendar.Sorting = SortOrder.Ascending;     // Sort the items in the list in ascending order.

            // The ListViewItemSorter property allows you to specify the
            // object that performs the sorting of items in the ListView.
            // You can use the ListViewItemSorter property in combination
            // with the Sort method to perform custom sorting.
            _lvwItemComparer = new ListViewItemComparer
            {
                SortColumn = 3,                             //сортировка по рабочей дате
                Order = SortOrder.Ascending
            };
            lstwDataBaseDaysCalendar.ListViewItemSorter = _lvwItemComparer;
        }
        //Загрузить Data из DataSet в ListView дней календаря
        private void LoadListDaysCalendar(DataTable dtable)
        {
            lstwDataBaseDaysCalendar.Items.Clear();         // Clear the ListView control
            for (int i = 0; i < dtable.Rows.Count; i++)     // Display items in the ListView control
            {
                DataRow drow = dtable.Rows[i];
                if (drow.RowState != DataRowState.Deleted)  // Only row that have not been deleted
                {
                    // Define the list items
                    lstwDataBaseDaysCalendar.LabelEdit = false;      //запрет редактирования item
                    ListViewItem lvi = new ListViewItem(drow["uses"].ToString(), 0) //имя для сортировки
                    {
                        ImageIndex = (Boolean)drow["uses"] ? 1 : 0,
                        StateImageIndex = (Boolean)drow["uses"] ? 1 : 0,
                        Checked = (Boolean)drow["uses"]
                        //                        , UseItemStyleForSubItems = true
                    };

                    //    lvi.Checked = (Boolean)drow["Uses"];
                    //       lvi.SubItems.Add(drow["Uses"].ToString());
                    lvi.SubItems.Add(drow["date"].ToString() == "" ? "-":((DateTime)drow["date"]).ToString("d MMMMM"));
                    lvi.SubItems.Add(drow["name"].ToString());
                    lvi.SubItems.Add(drow["id"].ToString().PadLeft(8, '0'));        //используется для строковой сортировки по колонке
                    lvi.SubItems.Add(drow["id"].ToString());

                    lstwDataBaseDaysCalendar.Items.Add(lvi);                        // Add the list items to the ListView
                }
            }
        }

    }
}
