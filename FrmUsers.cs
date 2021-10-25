﻿using System;
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
            string cs = Properties.Settings.Default.twtConnectionSrting;    //connection string
            mainPanelUsers.Enabled = MsSqlDatabase.CheckConnectWithConnectionStr(cs);
            if (mainPanelUsers.Enabled)
            {
                cbDepartment.DisplayMember = "Name";
                cbDepartment.ValueMember = "id";
                cbDepartment.DataSource = MsSqlDatabase.TableRequest(cs, "Select id, name From UserDepartment");

                cbPost.DisplayMember = "Name";
                cbPost.ValueMember = "id";
                cbPost.DataSource = MsSqlDatabase.TableRequest(cs, "Select id, name From UserPost");

                cbSheme.DisplayMember = "Name";
                cbSheme.ValueMember = "id";
                cbSheme.DataSource = MsSqlDatabase.TableRequest(cs, "Select id, name From UserWorkScheme order by name desc");

                InitializeListView();
                LoadList(MsSqlDatabase.TableRequest(cs, "select * from twt_GetUserInfo('') order by fio"));

                udBeforeH.Value = new DateTime(2000, 1, 1, 9, 0, 0);
                udBeforeM.Value = new DateTime(2000, 1, 1, 9, 0, 0);
                udAfterH.Value = new DateTime(2000, 1, 1, 18, 0, 0);
                udAfterH.Value = new DateTime(2000, 1, 1, 18, 0, 0);

                if (lstwDataBaseUsers.Items.Count == 0)
                    btImport.Visible = true;                        //загасить импорт если список не пустой
                else
                {
                    btImport.Visible = false;                       //загасить импорт если список не пустой
                    lstwDataBaseUsers.Items[0].Selected = true;     //выделить элемент по индексу
                }
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
//            lstwDataBaseUsers.StateImageList=
            // The ListViewItemSorter property allows you to specify the
            // object that performs the sorting of items in the ListView.
            // You can use the ListViewItemSorter property in combination
            // with the Sort method to perform custom sorting.
            _lvwItemComparer = new ListViewItemComparer
            {
                SortColumn = 1,// 1;// e.Column; (3 name)
                Order = SortOrder.Ascending
            };

            lstwDataBaseUsers.ListViewItemSorter = _lvwItemComparer;

        }

        //Загрузить Data из DataSet в ListView
        private void LoadList(DataTable dtable)
        {
            lstwDataBaseUsers.Items.Clear();                // Clear the ListView control
            for (int i = 0; i < dtable.Rows.Count; i++)     // Display items in the ListView control
            {
                DataRow drow = dtable.Rows[i];
                if (drow.RowState != DataRowState.Deleted)  // Only row that have not been deleted
                {
                    // Define the list items
                    lstwDataBaseUsers.LabelEdit=false;      //запрет редактирования item
                    ListViewItem lvi = new ListViewItem(drow["access"].ToString(), 0) //имя для сортировки
                    {
                        ImageIndex = (Boolean)drow["access"] ? 1 : 0
                        , StateImageIndex = (Boolean)drow["access"] ? 1 : 0
                        , Checked = (Boolean)drow["access"]
//                        , UseItemStyleForSubItems = true
                    };
                    lvi.SubItems.Add(drow["fio"].ToString());
                    lvi.SubItems.Add(drow["extId"].ToString());
                    lvi.SubItems.Add(drow["department"].ToString());
                    lvi.SubItems.Add(drow["post"].ToString());
                    lvi.SubItems.Add(drow["startTime"].ToString());
                    lvi.SubItems.Add(drow["stopTime"].ToString());
                    lvi.SubItems.Add(drow["noLunch"].ToString());
                    lvi.SubItems.Add(drow["work"].ToString());
                    lvi.SubItems.Add(drow["note"].ToString());
                    lvi.SubItems.Add(drow["crmId"].ToString());

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
                tbUserID.Text = lstwDataBaseUsers.Items[ind].SubItems[2].Text;                  //extID
                //crmId
                chUse.Checked = lstwDataBaseUsers.Items[ind].Text == "True";                    //access    
                tbName.Text = lstwDataBaseUsers.Items[ind].SubItems[1].Text;                    //fio
                tbNote.Text = lstwDataBaseUsers.Items[ind].SubItems[9].Text;                    //note
                cbDepartment.Text = lstwDataBaseUsers.Items[ind].SubItems[3].Text;              //department    
                cbPost.Text = lstwDataBaseUsers.Items[ind].SubItems[4].Text;                    //post
                dt= Convert.ToDateTime(lstwDataBaseUsers.Items[ind].SubItems[5].Text);          //date start
                udBeforeH.Value = dt;
                udBeforeM.Value = dt;
                dt = Convert.ToDateTime(lstwDataBaseUsers.Items[ind].SubItems[6].Text);         //date stop
                udAfterH.Value = dt;
                udAfterM.Value = dt;
                chbLunch.Checked = lstwDataBaseUsers.Items[ind].SubItems[7].Text == "True";     //lunch
                cbSheme.Text = lstwDataBaseUsers.Items[ind].SubItems[8].Text;                   //work    
            }
        }
        //запретить изменение размеров
        private void lstwDataBaseUsers_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = lstwDataBaseUsers.Columns[e.ColumnIndex].Width;
        }

        //чекбокс Сотрудник активен
        private void chUse_CheckedChanged(object sender, EventArgs e)
        {
            chUse.ImageIndex = chUse.Checked ? 1 : 0;
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
            if (tbName.Text.Trim().Length == 0)                             //если поле пустое
            {
                tbName.BackColor = System.Drawing.SystemColors.Window;      //белый фон
                lstwDataBaseUsers.HideSelection = true;                     //снять выделение со строки listview (без перевода фокуса на listwiew)

                btInsert.Enabled = false;                                   //заблокировать кнопку INSERT    
                btUpdate.Enabled = false;                                   //заблокировать кнопку UPDATE    

                //  rbUpdate.Checked = true;                                    //выбрать режим по умолчанию Update
                //  prBts.Enabled = false;                                      //заблокировать панель радиокнопок Insert/Update
                //  btUpdate.Enabled = false;                                   //заблокировать кнопку записи в БД    
            }
            else                                                            //если поле не пустое          
            {
                btUpdate.Enabled = true;                                    //разблокировать кнопку записи в БД    
                if (lstwDataBaseUsers.Items.Cast<ListViewItem>()            //попробовать найти значение поля в списке ListView
                    .Where(x => (x.SubItems[1].Text == tbName.Text.Trim()))         
                    .FirstOrDefault() != null)
                {                                                           //значение есть
                    tbName.BackColor = System.Drawing.SystemColors.Control; //серый фон
                    lstwDataBaseUsers.HideSelection = false;                //установить выделение строки (без перевода фокуса на listwiew)

                    btInsert.Enabled = false;                               //заблокировать кнопку INSERT    
                    btUpdate.Enabled = true;                                //разблокировать кнопку UPDATE    

//                    rbUpdate.Checked = true;                                //выбрать режим по умолчанию Update
//                    prBts.Enabled = false;                                  //заблокировать панель радиокнопок Insert/Update
                }
                else                                                        //значения нет 
                {
                    tbName.BackColor = System.Drawing.SystemColors.Window;  //белый фон
                    lstwDataBaseUsers.HideSelection = true;                 //снять выделение со строки listview (без перевода фокуса на listwiew)
                    if (tbUserID.Text.Trim().Length == 0)                   //проверить есть id или нет (при первом старте на пустом списке)  
                    {
                        btInsert.Enabled = true;                            //разблокировать кнопку INSERT    
                        btUpdate.Enabled = false;                           //заблокировать кнопку UPDATE    

                        //                        rbUpdate.Checked = false;                           //выбрать режим по умолчанию Insert
                        //                        prBts.Enabled = false;                              //заблокировать панель радиокнопок Insert/Update
                    }
                    else 
                    {
                        btInsert.Enabled = true;                            //разблокировать кнопку INSERT    
                        btUpdate.Enabled = true;                            //разблокировать кнопку UPDATE    

                        //                        rbUpdate.Checked = true;                            //выбрать режим по умолчанию Update
                        //                        prBts.Enabled = true;                               //заблокировать панель радиокнопок Insert/Update
                    }
                }
            }
        }

        //кнопка Добавить запись в БД
        private void btInsert_Click(object sender, EventArgs e)
        {
            int index;
            string cs = Properties.Settings.Default.twtConnectionSrting;    //connection string
            string id = DateTime.Now.ToString("yyyyMMddHHmmss");            //id из даты
            string sql =
              "INSERT INTO Users(" +
                "extId, " +
                "crmId, " +
                "name, " +
                "note, " +
                "departmentId, " +
                "postId, " +
                "timeStart, " +
                "timeStop, " +
                "noLunch, " +
                "workSchemeId, " +
                "uses) " +
              "VALUES (" +
                "N'" + id + "', " +
                0 + ", " +
                "N'" + tbName.Text.Trim() + "', " +
                "N'" + tbNote.Text.Trim() + "', " +
                ((DataRowView)cbDepartment.SelectedItem).Row["id"] + ", " +
                ((DataRowView)cbPost.SelectedItem).Row["id"] + ", " +
                "'" + udBeforeH.Value.ToString("HH") + ":" + udBeforeM.Value.ToString("mm") + "', " +
                "'" + udAfterH.Value.ToString("HH") + ":" + udAfterM.Value.ToString("mm") + "', " +
                (chbLunch.Checked ? 1 : 0) + ", " +
                ((DataRowView)cbSheme.SelectedItem).Row["id"] + ", " +
                (chUse.Checked ? 1 : 0) +
              ")";
            MsSqlDatabase.RequestNonQuery(cs, sql, false);
            LoadList(MsSqlDatabase.TableRequest(cs, "select * from twt_GetUserInfo('') order by fio"));// order by extId desc"));
            index = lstwDataBaseUsers.Items.Cast<ListViewItem>()
                .Where(x => (x.SubItems[2].Text == id))                 //найти индекс поиск по полю id
                .FirstOrDefault().Index;
            //            lstwDataBaseUsers.HideSelection = false;                    //отображение выделения 
            lstwDataBaseUsers.Items[index].Selected = true;             //выделить элемент по индексу
            tbName_TextChanged(null, null);                             //обновить поля и кнопки

            //            lstwDataBaseUsers.Focus();
            //            lstwDataBaseUsers_ColumnClick(null, new ColumnClickEventArgs(2)); //сортировка
            lstwDataBaseUsers.EnsureVisible(index);                     //показать в области видимости окна
        }
        /*
                       "id int PRIMARY KEY IDENTITY, " +
                        "extId VARCHAR(20) NOT NULL UNIQUE, " +                                         //*внешний id для интеграции
                        "crmId NUMERIC DEFAULT 0, " +                                                   //внешний id для интеграции с crm
                        "name VARCHAR(150) NOT NULL UNIQUE, " +                                         //*наименование
                        "note VARCHAR(1024) NULL, " +                                                   //расшифровка
                        "departmentId int NOT NULL FOREIGN KEY REFERENCES UserDepartment(id), " +       //->ссылка на департамент
                        "postId int NOT NULL FOREIGN KEY REFERENCES UserPost(id), " +                   //->ссылка на должность
                        "timeStart time NULL, " +                                                       //время начала работы по графику (без даты)    
                        "timeStop time NULL, " +                                                        //время окончания работы по графику (без даты)
                        "noLunch bit DEFAULT 1, " +                                                       //флаг признака обеда
                        "workSchemeId int NOT NULL FOREIGN KEY REFERENCES UserWorkScheme(id), " +       //->ссылка на схему работы
                        "uses bit DEFAULT 1 " +                                                         //флаг доступа для использования
           */





        //кнопка Обновить запись в БД
        private void btUpdate_Click(object sender, EventArgs e)
        {
            int index;
            string cs = Properties.Settings.Default.twtConnectionSrting;    //connection string
            string sql =
              "UPDATE Users Set " +
                "note = 'N" + tbNote.Text.Trim() + "', " +
                "departmentId = " + ((DataRowView)cbDepartment.SelectedItem).Row["id"] + ", " +
                "postId = " + ((DataRowView)cbPost.SelectedItem).Row["id"] + ", " +
                "timeStart = " + "'" + udBeforeH.Value.ToString("HH") + ":" + udBeforeM.Value.ToString("mm") + "', " +
                "timeStop = " + "'" + udAfterH.Value.ToString("HH") + ":" + udAfterM.Value.ToString("mm") + "', " +
                "noLunch = " + (chbLunch.Checked ? 1 : 0) + ", " +
                "workSchemeId = " + ((DataRowView)cbSheme.SelectedItem).Row["id"] + ", " +
                "uses = " + (chUse.Checked ? 1 : 0) + " " +
              "WHERE extId = '" + tbUserID.Text.Trim() + "'";
            MsSqlDatabase.RequestNonQuery(cs, sql, false);
            index = lstwDataBaseUsers.SelectedIndex();          //сохранить индекс
            LoadList(MsSqlDatabase.TableRequest(cs, "select * from twt_GetUserInfo('')"));
            lstwDataBaseUsers.Items[index].Selected = true;     //выделить элемент по индексу
            lstwDataBaseUsers.EnsureVisible(index);             //показать в области видимости окна
        }
        //кнопка импорт
        private void btImport_Click(object sender, EventArgs e)
        {
            ImportFromExel.ImportFromExcel();
        }

        private void rbInsertUpdate_CheckedChanged(object sender, EventArgs e)
        {
            btUpdate.ImageIndex = rbInsert.Checked ? 1 : 2;
            tbUserID.Visible = !rbInsert.Checked;                                    //отобразить id записи    
        }
        //навели мышкой на Insert загасили id
        private void btInsert_MouseHover(object sender, EventArgs e)
        {

        }
    }
}
