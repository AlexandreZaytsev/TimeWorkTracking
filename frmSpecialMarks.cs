using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;


namespace TimeWorkTracking
{
    public partial class frmSpecialMarks : Form
    {
        clListViewItemComparer _lvwItemComparer;
        public frmSpecialMarks()
        {
            InitializeComponent();
            lMsg.Visible = false;               //погасить сообщение о записи в БД
                                                //           tbID.Visible = false;
        }

        /// <summary>
        /// загрузка формы 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSpecialMarks_Load(object sender, EventArgs e)
        {
            string cs = Properties.Settings.Default.twtConnectionSrting;    //connection string
            mainPanelSpecialMarks.Enabled = clMsSqlDatabase.sqlConnectSimple(cs);
            if (mainPanelSpecialMarks.Enabled)
            {
                InitializeListView();
                LoadList(clMsSqlDatabase.TableRequest(cs, "Select * From SpecialMarks order by id"));
                if (lstwDataBaseSpecialMarks.Items.Count != 0)
                    lstwDataBaseSpecialMarks.Items[0].Selected = true;     //выделить элемент по индексу
            }
        }

        #region//Список(Таблица) данных СПЕЦИАЛЬНЫЕ ОТМЕТКИ (данные)

        /// <summary>
        /// Инициализация списка(таблицы) данных
        /// </summary>
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
            _lvwItemComparer = new clListViewItemComparer
            {
                SortColumn = 5,                             //сортировка по id бд
                Order = SortOrder.Ascending
            };
            lstwDataBaseSpecialMarks.ListViewItemSorter = _lvwItemComparer;
        }

        /// <summary>
        /// Загрузка списка(таблицы) данных (Data из DataSet в ListView)
        /// </summary>
        /// <param name="dtable"></param>
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
                        ImageIndex = (Boolean)drow["uses"] ? 1 : 0,
                        StateImageIndex = (Boolean)drow["uses"] ? 1 : 0,
                        Checked = (Boolean)drow["uses"]
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
            //после загрузки списка установить авторазмер последней колонки
            lstwDataBaseSpecialMarks.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);      //растягиваем последний столбец
        }

        /// <summary>
        /// Сортировка списка(таблицы) данных по заголовкам столбцов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Выбор значения в списке(таблице) данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstwDataBaseSpecialMarks_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string sql;
            //string key = tbName.Text.Trim();                                    //ключевое поле
            //string cs = Properties.Settings.Default.twtConnectionSrting;        //connection string

            int ind = lstwDataBaseSpecialMarks.extSelectedIndex();
            if (ind >= 0)
            {
                tbID.Text = lstwDataBaseSpecialMarks.Items[ind].SubItems[6].Text;
                tbCodeDigital.Text = lstwDataBaseSpecialMarks.Items[ind].SubItems[1].Text;
                tbCodeLetter.Text = lstwDataBaseSpecialMarks.Items[ind].SubItems[2].Text;
                tbName.Text = lstwDataBaseSpecialMarks.Items[ind].SubItems[3].Text;             //name
                tbNote.Text = lstwDataBaseSpecialMarks.Items[ind].SubItems[4].Text;             //note
                chUse.Checked = lstwDataBaseSpecialMarks.Items[ind].Text == "True";

                /*
                //проверка специальной отметки на достоверность
                sql = "select count(*) from EventsPass where specmarkId = " + tbID.Text;
                int status = Convert.ToInt32(clMsSqlDatabase.RequesScalar(cs, sql, false));     //посмотреть в проходах - была ли такая отметка
                if (status == 0 && chUse.Checked)       //если отметка отсутствует в списке проходов но отмечена как активна - сбросить ее
                {
                    sql = "UPDATE SpecialMarks Set uses = 0 Where id = " + tbID.Text;
                    clMsSqlDatabase.RequestNonQuery(cs, sql, false);

                    LoadList(clMsSqlDatabase.TableRequest(cs, "Select * From SpecialMarks order by id"));// order by extId desc"));
                    lstwDataBaseSpecialMarks.extFindListByColValue(3, key);             //найти и выделить позицию
                    tbName_TextChanged(null, null);                                     //обновить поля и кнопки

                    chUse.Enabled = true;
                }
                else
                    chUse.Enabled = !chUse.Checked;                                    //ошибки нет - работаем нормально 
                */
            }
        }

        /// <summary>
        /// Запрет изменения размеров ширины колонок списка(таблицы) данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstwDataBaseSpecialMarks_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = lstwDataBaseSpecialMarks.Columns[e.ColumnIndex].Width;
        }

        #endregion

        /// <summary>
        /// запись доступна для использования (чекбокс)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chUse_CheckedChanged(object sender, EventArgs e)
        {
            chUse.ImageIndex = chUse.Checked ? 1 : 0;
        }

        /// <summary>
        /// Редактирование ключевого поля Имя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbName_TextChanged(object sender, EventArgs e)
        {
            if (tbName.Text.Trim() == "Работа в дневное время")
            {
                panel1.Enabled = false;                                         //значение не радактируется
                btPanel.Enabled = false;
            }
            else
            {
                panel1.Enabled = true;
                btPanel.Enabled = true;
                if (tbName.Text.Trim().Length == 0)                             //если поле пустое
                {
                    tbName.BackColor = System.Drawing.SystemColors.Window;      //белый фон
                    lstwDataBaseSpecialMarks.HideSelection = true;              //сбросить выделение строки при потере фокуса ListView
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
                        lstwDataBaseSpecialMarks.HideSelection = false;         //оставить выделение строки при потере фокуса ListView

                        btInsert.Enabled = false;                               //заблокировать кнопку INSERT    
                        btUpdate.Enabled = true;                                //разблокировать кнопку UPDATE    
                    }
                    else                                                        //значения нет 
                    {
                        tbName.BackColor = System.Drawing.SystemColors.Window;  //белый фон
                        lstwDataBaseSpecialMarks.HideSelection = true;          //сбросить выделение строки при потере фокуса ListView
                        btInsert.Enabled = true;                                //разблокировать кнопку INSERT    
                        btUpdate.Enabled = true;                                //разблокировать кнопку UPDATE    
                    }
                }
            }
        }

        #region//Запись в БД 

        /// <summary>
        /// кнопка Добавить запись в БД
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btInsert_Click(object sender, EventArgs e)
        {
            string key = tbName.Text.Trim();                                //ключевое поле
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
                "N'" + key + "', " +                                            //*наименование
                "N'" + tbNote.Text.Trim().Replace("'", "''") + "', " +          //экранировать одинарную кавычку задвоив ее
                (chUse.Checked ? 1 : 0) +
                ")";
            clMsSqlDatabase.RequestNonQuery(cs, sql, false);

            LoadList(clMsSqlDatabase.TableRequest(cs, "Select * From SpecialMarks order by id"));// order by extId desc"));
            lstwDataBaseSpecialMarks.extFindListByColValue(3, key);            //найти и выделить позицию
            tbName_TextChanged(null, null);                                     //обновить поля и кнопки
        }

        /// <summary>
        /// кнопка Обновить запись в БД
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btUpdate_Click(object sender, EventArgs e)
        {
            string key = tbName.Text.Trim();                                    //ключевое поле
            string cs = Properties.Settings.Default.twtConnectionSrting;        //connection string
            string sql =
              "UPDATE SpecialMarks Set " +
                "digitalCode = N'" + tbCodeDigital.Text.Trim() + "', " +
                "letterCode = N'" + tbCodeLetter.Text.Trim() + "', " +
                "name = N'" + key + "', " +                                     //*наименование
                "note = N'" + tbNote.Text.Trim().Replace("'", "''") + "', " +   //экранировать одинарную кавычку задвоив ее
                "uses = " + (chUse.Checked ? 1 : 0) + " " +
              "WHERE id = " + tbID.Text.Trim() + "";
            clMsSqlDatabase.RequestNonQuery(cs, sql, false);

            LoadList(clMsSqlDatabase.TableRequest(cs, "Select * From SpecialMarks order by id"));// order by extId desc"));
            lstwDataBaseSpecialMarks.extFindListByColValue(3, key);             //найти и выделить позицию
            tbName_TextChanged(null, null);                                     //обновить поля и кнопки
        }

        #endregion

        #region//Interface

        /// <summary>
        /// Hover наехали на кнопку Insert загасили id
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btInsert_MouseHover(object sender, EventArgs e)
        {
            tbID.Visible = false;
            lMsg.Visible = true;
            btUpdate.Visible = false;
        }

        /// <summary>
        /// Leave уехали с кнопки Insert показали id 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btInsert_MouseLeave(object sender, EventArgs e)
        {
            tbID.Visible = true;
            lMsg.Visible = false;
            btUpdate.Visible = true;
        }

        #endregion
    }
}
