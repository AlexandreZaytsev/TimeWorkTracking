using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace TimeWorkTracking
{
    public partial class frmSetting : Form
    {
        private Excel.Application excelApp;
        private Excel.Workbook workBook;
        private Excel.Worksheet workSheet;
        private Excel.Range workRange;
        readonly object mis = Type.Missing;
        private int timerSec = 4;                                       //количество секунд после выходв из потока

        /// <summary>
        /// конструктор
        /// </summary>
        public frmSetting()
        {
            //подписка события внешних форм 
            CallBack_FrmMain_outEvent.callbackEventHandler = new CallBack_FrmMain_outEvent.callbackEvent(this.CallbackReload);    //subscribe (listen) to the general notification
            InitializeComponent();
            InitializeBackgroundWorker();
        }

        /// <summary>
        /// события таймера очистить прогрессбар имя и значение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerImportExport_Tick(object sender, EventArgs e)
        {
            if (timerSec >= 0)
            {
                //toolStripProgressBarImport.Visible = false;
                timerSec -= 1;
            }
            else
            {
                timerImportExport.Stop();
                toolStripStatusLabelInfo.Text = "";
                toolStripProgressBarImport.Value = 0;
                //toolStripProgressBarImport.Visible = true;
            }
        }

        #region BackgroundWorker (работа в фоне)

        /// <summary>
        /// Настройка объекта BackgroundWorker добавим свои события.
        /// </summary>
        private void InitializeBackgroundWorker()
        {
            backgroundWorkerSetting.DoWork += new DoWorkEventHandler(backgroundWorkerSetting_DoWork);
            backgroundWorkerSetting.ProgressChanged += new ProgressChangedEventHandler(backgroundWorkerSetting_ProgressChanged);
            backgroundWorkerSetting.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorkerSetting_RunWorkerCompleted);
            backgroundWorkerSetting.WorkerReportsProgress = true;       //Разрешить использовать событие по отображению прогресса
            backgroundWorkerSetting.WorkerSupportsCancellation = true;  //Разрешить использовать средства остановки(отмены выполнения) потока.
                                                                        //            backgroundWorkerSetting.GenerateMember = true;              
        }

        /// <summary>
        ///Событие возникает после запуска потока методом RunAsync()
        ///В обработчик этого события вписывается код выполнения потока.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorkerSetting_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;           //передать объект (BackgroundWorker) вызвавший данное событие

            List<string> arg = e.Argument as List<string>;
            //Назначить результат вычисления к свойству результата DoWorkEventArgs объект.
            //Это будет доступно обработчику событий RunWorkerCompleted.
            switch (arg[0])   // the 'argument' parameter resurfaces here
            {
                case "users":
                    e.Result = ImportUserDataFromExcel(worker, e);
                    break;
                case "pass":
                    e.Result = ImportPassDataFromExcel(worker, e);
                    break;
                case "export":
                    e.Result = MainExportToExcel(worker, e);
                    break;
                case "import":
                    e.Result = MainImportFromExcel(worker, e);
                    break;
            }
        }

        /// <summary>
        ///Событие возникает когда происходит завершение потока выполнения
        ///В обработчик этого события целесообразно вписывать код завершающих операций, вывод соответствующих сообщений и т.п.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorkerSetting_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //    List<string> arg = e.Argument as List<string>;
            // Проверить как завершился поток с ошибками или без
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                // Next, handle the case where the user canceled 
                // the operation.
                // Note that due to a race condition in 
                // the DoWork event handler, the Cancelled
                // flag may not have been set, even though
                // CancelAsync was called.
                toolStripStatusLabelInfo.Text = "Canceled";
            }
            else
            {
                // Finally, handle the case where the operation 
                // succeeded.
                //toolStripStatusLabelInfo.Text = ""; //e.Result.ToString();
                //toolStripProgressBarImport.Value = 0;
                switch (e.Result.ToString())
                {
                    case "users":                                                           //если завершился иморт пользователей
                        CallBack_FrmImport_outEvent.callbackEventHandler("", "", null);     //отправитьс ообщение главной форме что импрот произошел
                        toolStripStatusLabelInfo.Text = "Список сотрудников загружен в БД ";// + e.Result.ToString(); 
                        break;
                    case "pass":                                                            //если завершился иморт проходов
                        toolStripStatusLabelInfo.Text = "Список проходов загружен в БД ";// + e.Result.ToString();
                        break;
                    case "export":                                                            //если завершился иморт проходов
                        toolStripStatusLabelInfo.Text = "Экспорт данных из БД завершен ";// + e.Result.ToString();
                        break;
                    case "import":                                                            //если завершился иморт проходов
                        toolStripStatusLabelInfo.Text = "Импорт данных в таблицу БД завершен ";// + e.Result.ToString();
                        break;
                }
                timerImportExport.Start();
            }
        }

        /// <summary>
        ///Событие возникает, когда рабочий поток указывает на то, что был достигнут некоторый прогресс
        ///вызывается из DoWork запуском ReportProgress которое вызывает данное событие
        ///В обработчике события ProgressChanged указывается код визуализации прогресса с помощью известных компонент, таких как ProgressBar, Label и т.д.;
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorkerSetting_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            List<string> arg = e.UserState as List<string>;
            switch (arg[0])
            {
                case "init":                                                //инициализируем прогрессбар
                    toolStripProgressBarImport.Minimum = Convert.ToInt32(arg[1]);
                    toolStripProgressBarImport.Maximum = Convert.ToInt32(arg[2]);
                    toolStripProgressBarImport.Step = Convert.ToInt32(arg[3]);
                    toolStripStatusLabelInfo.Text = arg[4];
                    break;
                case "work":                                                //двигаем прогрессбар
                    //Задать изменение процента в progressBar
                    toolStripProgressBarImport.PerformStep();               //сдвинуться на шаг
                    //toolStripProgressBarImport.Value = e.ProgressPercentage;
                    //            this.toolStripProgressBarImport.Value = e.ProgressPercentage;
                    //Отобразить процент и текст
                    toolStripStatusLabelInfo.Text = "таблица " + arg[1] + " Обработано " +
                                                    toolStripProgressBarImport.Value.ToString() + " из " +
                                                    toolStripProgressBarImport.Maximum.ToString() + " (" +
                                                    Convert.ToString(e.ProgressPercentage) + "%)";
                    break;
            }
        }

        #endregion

        private void frmSetting_Load(object sender, EventArgs e)
        {
            if (!clSystemSet.checkProvider()) this.Close();
            checkFileImport(Properties.Settings.Default.importFilename);

            string cs = Properties.Settings.Default.twtConnectionSrting;    //connection string
            mainPanelSetting.Enabled = clMsSqlDatabase.sqlConnectSimple(cs);
            tbCompanyName.Text = Properties.Settings.Default.companyName;   //наименование компании
            nDaysInWorkWeek.Value = Properties.Settings.Default.daysInWorkWeek;
            nHoursInFullWorkDay.Value = Properties.Settings.Default.hoursInFullWorkDay;
            nMinutesChangingFullWorkDay.Value = Properties.Settings.Default.minutesChangingFullWorkDay;
            nMinutesLunchBreakTime.Value = Properties.Settings.Default.minutesLunchBreakTime;

            checkPathExportImport();                        // проверить существование путей экспорта импорта
        }

        /// <summary>
        /// получить DataTable из SQL по имени таблицы
        /// </summary>
        /// <param name="nameTabble"></param>
        /// <param name="dTable"></param>
        private void getDataTableSQL(string nameTabble, ref DataTable dTable)
        {
            string cs = Properties.Settings.Default.twtConnectionSrting;    //connection string
            dTable = clMsSqlDatabase.TableRequest(cs, "select * from " + nameTabble);
        }

        /// <summary>
        /// получить имена листов книги Excel
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private List<string> getnameSheetsExcel(string path)
        {
            List<string> sh = new List<string>();
            try
            {
                string csExcel = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source ={path};Extended Properties = " + "\"Excel 12.0 Xml;HDR=YES; IMEX = 1\"";
                using (OleDbConnection cnExcel = new OleDbConnection(csExcel))
                {
                    cnExcel.Open();
                    //прочитать имена листов
                    DataTable dtTablesList = cnExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    //Фактические имена листов заканчиваются на $ или $'
                    foreach (DataRow drTable in dtTablesList.Rows)
                    {
                        if (drTable["Table_Name"].ToString().EndsWith("$") || drTable["Table_Name"].ToString().EndsWith("$'"))
                        {
                            string shName = drTable["Table_Name"].ToString();
                            shName = shName.Substring(0, shName.IndexOf("$"));
                            if (shName.Substring(0, 1) == "'") shName = shName.Substring(1, shName.Length - 1);
                            sh.Add(shName);
                        }
                    }
                    cnExcel.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return sh;
        }

        #region Open Save Dialod and Setting

        /// <summary>
        /// диалог выбора файла 
        /// </summary>
        /// <returns></returns>
        private string getFileName(string name, string filter)
        {
            openFileDialogSetting.Title = name;
            openFileDialogSetting.Filter = filter;

            DialogResult dr = openFileDialogSetting.ShowDialog();
            if (dr == DialogResult.Abort)
                return "";
            if (dr == DialogResult.Cancel)
                return "";

            return openFileDialogSetting.FileName.ToString();
        }

        /// <summary>
        /// диалог сохранения файла 
        /// </summary>
        /// <returns></returns>
        private string setFileName(string name, string filter, string filename)
        {
            saveFileDialogSetting.Title = name;
            saveFileDialogSetting.Filter = filter;
            saveFileDialogSetting.FileName = filename;

            DialogResult dr = saveFileDialogSetting.ShowDialog();
            if (dr == DialogResult.Abort)
                return "";
            if (dr == DialogResult.Cancel)
                return "";

            return saveFileDialogSetting.FileName.ToString();
        }

        /// <summary>
        /// главный импорт
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btMainImportPathOpen_Click(object sender, EventArgs e)
        {
            tbMainImportPath.Text = getFileName(
                "Выбор файла импорта",
                "Excel 2010(*.xls; *.xlsx; *.xlsm) | *.xls; *.xlsx; *.xlsm | XML Documents(*.xml)|*.xml | All files (*.*)|*.*"
                );
            checkPathExportImport();                        // проверить существование путей экспорта импорта
        }

        /// <summary>
        /// главный экспорт
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btMainExportPathSave_Click(object sender, EventArgs e)
        {
            tbMainExportPath.Text = setFileName(
                "Выбор файла экспорта",
                "Excel 2010(*.xlsx; *.xls) | *.xlsx; *.xls | XML Documents(*.xml)|*.xml | All files (*.*)|*.*",
                "TimeWorkTracking_export_" + DateTime.Now.ToString("yyyyMMddHHmm")
                );
            checkPathExportImport();                        // проверить существование путей экспорта импорта
        }

        /// <summary>
        /// импрорт начального заполнения данных из истории
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btFileName_Click(object sender, EventArgs e)
        {
            tbPathImport.Text = getFileName(
                "Выбор файла импорта (...восстановление из истории)",
                "Excel 2010(*.xlsm) | *.xlsm"
            );
            checkFileImport(tbPathImport.Text);
        }

        #endregion

        #region Setting Import Export Interface

        /// <summary>
        /// Импорт Истории проверить файл импорта и настройка
        /// </summary>
        /// <param name="newPath">путь к файлу с данными</param>
        private void checkFileImport(string newPath)
        {
            string parse;

            parse = Properties.Settings.Default.importUserRange;
            cbSheetUser.Text = parse.Substring(0, parse.IndexOf("$"));
            tbRangeUser.Text = parse.Substring(parse.IndexOf("$") + 1);

            parse = Properties.Settings.Default.importPassRange;
            cbSheetPass.Text = parse.Substring(0, parse.IndexOf("$"));
            tbRangePass.Text = parse.Substring(parse.IndexOf("$") + 1);

            if (newPath == "" || !(File.Exists(newPath)))
            {
                tbPathImport.Text = "";
                groupBox1.Enabled = false;
            }
            else
            {
                string[] sName = getnameSheetsExcel(newPath).ToArray();
                cbSheetUser.Items.AddRange(sName);
                cbSheetPass.Items.AddRange(sName);

                Properties.Settings.Default.importFilename = @newPath;
                Properties.Settings.Default.importUserRange = cbSheetUser.Text + "$" + tbRangeUser.Text;
                Properties.Settings.Default.importPassRange = cbSheetPass.Text + "$" + tbRangePass.Text;

                Properties.Settings.Default.Save();

                tbPathImport.Text = newPath;
                groupBox1.Enabled = true;
            }
        }

        /// <summary>
        /// Экспорт Импорт проверить существование путей 
        /// </summary>
        private void checkPathExportImport()
        {
            //импорт
            cbSheetTable.Items.Clear();
            cbSheetTable.ResetText();
            if (tbMainImportPath.Text != "")
            {
                chAllData.Enabled = true;
                cbSheetTable.Items.AddRange(getnameSheetsExcel(tbMainImportPath.Text).ToArray());
                cbSheetTable.Enabled = true;
                chDeleteOnly.Enabled = true;
            }
            else
            {
                cbSheetTable.Items.Clear();
                chAllData.Enabled = false;
                cbSheetTable.Enabled = false;
                chDeleteOnly.Enabled = false;
            }
            chAllData_CheckedChanged(null, null);
            cbSheetTable_SelectedIndexChanged(null, null);

            //экспорт
            btMainExport.Enabled = tbMainExportPath.Text != "";
        }

        /// <summary>
        /// Флаг импортировать все таблицм или по одной
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chAllData_CheckedChanged(object sender, EventArgs e)
        {
            cbSheetTable.Enabled = tbMainImportPath.Text != "" && !chAllData.Checked;
            btMainImport.Enabled = chAllData.Checked;
        }

        /// <summary>
        /// проверить выбрана таблица или нет
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbSheetTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            btMainImport.Enabled = tbMainImportPath.Text != "" && !chAllData.Checked && cbSheetTable.Text != "";
        }

        #endregion

        #region Import Export Operation (кнопки и обработка)

        /// <summary>
        /// кнопка импорта таблицы со страницы Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btMainImport_Click(object sender, EventArgs e)
        {
            DialogResult response = MessageBox.Show(
                "Данные выбранных листов Excel" + "\r\n" +
                "будут сопоставлены с таблицами БД" + "\r\n" +
                "таблицы будут очищены и перезаписаны!!!" + "\r\n\r\n" +
                "*при активации флага - только очистка" + "\r\n" +
                "таблицы будут просто очищены" + "\r\n\r\n" +
                "Продолжить?" + "\r\n"
                , "Импорт данных из Excel"
                , MessageBoxButtons.YesNo
                , MessageBoxIcon.Information
                , MessageBoxDefaultButton.Button2
//                , MessageBoxOptions.DefaultDesktopOnly
                );
            BringToFront();                                                     //вернуть форму на передний план

            if (response == DialogResult.Yes)
            {
                string cs = Properties.Settings.Default.twtConnectionSrting;

                //прочитать имена всех таблиц БД (сортировка по времени создания)
                DataTable dt = clMsSqlDatabase.TableRequest(cs, "SELECT name FROM sys.objects WHERE type in (N'U') order by create_date");
                Dictionary<string, string> tableNames = dt.Rows.OfType<DataRow>().Select(k => k[0].ToString()).ToDictionary(k => k);
                bool ok;
                foreach (string tb in tableNames.Keys.ToList())
                {
                    ok = false;
                    if (chAllData.Checked)
                    {
                        for (int i = 0; i <= cbSheetTable.Items.Count; i++)
                        {
                            if (tb == cbSheetTable.Items[i].ToString()) //сравним имена из БД и листов Excel
                            {
                                ok = true;
                                break;
                            }
                        }
                    }
                    else
                        if (tb == cbSheetTable.Text)                    //сравним имена из БД и листа Excel
                        ok = true;

                    if (!ok)
                        tableNames[tb] = "";                            //если таблицы из Excel нет в БД - вычеркнем ее
                }
                string tableItems = string.Join("|", tableNames.Values.Select(x => x).Where(x => x.Length > 0).ToList().ToArray());

                //  tableNames = dt.Rows.OfType<DataRow>().Select(k => k[0].ToString()).ToList();

                List<string> arguments = new List<string>()
                {
                    "import",                                   //для вызова нужного метода
                    tbMainImportPath.Text,                      //путь к файлу импорта Excel
                    cs,                                         //connection string
                    tableItems,                                 //имена таблиц
                    chDeleteOnly.Checked ? "1" : "0"            //флаг только удаление
                };

                if (!backgroundWorkerSetting.IsBusy)            //Запустить фоновую операцию (поток)(с аргументами) вызвав событие DoWork
                {
                    backgroundWorkerSetting.RunWorkerAsync(arguments);
                }
            }
        }

        /// <summary>
        /// импорт данных через OleDbDataAdapter и DataSet
        /// </summary>
        /// <param name="worker"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public string MainImportFromExcel(BackgroundWorker worker, DoWorkEventArgs e)
        {
            List<string> inArgument = e.Argument as List<string>;   //распарсить входнык параметры
            List<string> outArguments = new List<string>();         //возврат аргументов из потока на обработку
            int countRows;                                          //общее количество строк в запросе
            try
            {
                //очистка таблиц
                string[] clearTable = inArgument[3].Split('|');
                Array.Reverse(clearTable);
                for (int i = 0; i < clearTable.Length; i++)
                {
                    clMsSqlDatabase.ClearTableDB(inArgument[2], clearTable[i]); //очистить таблицу
                }

                if (inArgument[4] == "0")                           //если нужно только очистить и заполнить таблицы 
                {
                    string[] nameTable = inArgument[3].Split('|');
                    string csExcel = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source ={inArgument[1]};Extended Properties = " + "\"Excel 12.0 Xml;HDR=YES; IMEX = 1\"";
                    using (OleDbConnection cnExcel = new OleDbConnection(csExcel))
                    {
                        cnExcel.Open();
                        OleDbDataAdapter da = new OleDbDataAdapter();
                        DataSet ds = new DataSet();
                        using (OleDbCommand cmdExcel = cnExcel.CreateCommand())
                        {
                            for (int i = 0; i < nameTable.Length; i++)
                            {
                                cmdExcel.CommandText = $"Select count(*) from [{nameTable[i] + "$"}]";
                                countRows = (int)cmdExcel.ExecuteScalar();

                                outArguments.Add("init");                       //init инициализация прогрессбара work отображение значения
                                outArguments.Add("0");                          //минимальное значение
                                outArguments.Add(countRows.ToString());         //максимальное значение
                                outArguments.Add("1");                          //шаг
                                outArguments.Add("импорт");                     //комментарий
                                worker.ReportProgress(0, outArguments);         //отобразить (вызвать событие) результаты progressbar

                                cmdExcel.CommandText = $"Select * from [{nameTable[i] + "$"}]";    //диапазон Data (без заголовка)
                                                                                                   //OleDbDataReader result = cmdExcel.ExecuteReader();
                                da.SelectCommand = cmdExcel;
                                da.Fill(ds);

                                DataTable Exceldt = ds.Tables[0];

                                /*
                                for  ( int  i = Exceldt.Rows.Count - 1; i> = 0; i--)  
                                {  
                                    if  (Exceldt.Rows [i] [ "Имя сотрудника" ] == DBNull.Value || Exceldt.Rows [i] [ "Электронная почта" ] == DBNull.Value)  
                                    {  
                                        Exceldt.Rows [i] .Delete ();  
                                    }  
                                }
                                */
                                using (SqlConnection sqlConnection = new SqlConnection(inArgument[2]))
                                {
                                    sqlConnection.Open();
                                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(sqlConnection))
                                    {
                                        DataTable schema = sqlConnection.GetSchema("Columns", new[] { null, null, nameTable[i], null });
                                        foreach (DataColumn sourceColumn in Exceldt.Columns)
                                        {
                                            foreach (DataRow row in schema.Rows)
                                            {
                                                if (string.Equals(sourceColumn.ColumnName, (string)row["COLUMN_NAME"], StringComparison.OrdinalIgnoreCase))
                                                {
                                                    bulkCopy.ColumnMappings.Add(sourceColumn.ColumnName, (string)row["COLUMN_NAME"]);
                                                    break;
                                                }
                                            }
                                        }
                                        bulkCopy.DestinationTableName = nameTable[i];
                                        bulkCopy.WriteToServer(Exceldt);
                                    }

                                    outArguments[0] = "work";                                          //init инициализация прогрессбара work отображение значения
                                    outArguments[1] = nameTable[i];                                   //init инициализация прогрессбара work отображение значения
                                    worker.ReportProgress((Exceldt.Rows.Count * 100) / Exceldt.Rows.Count, outArguments);  //отобразить (вызвать событие) результаты progressbar

                                    sqlConnection.Close();
                                    ds.Tables[0].Clear();
                                    ds.Tables.Remove(ds.Tables[0]);
                                }
                            }
                        }
                        cnExcel.Close();
                    }
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return inArgument[0];// "import";
        }

        /// <summary>
        /// кнопка экспорта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btMainExport_Click(object sender, EventArgs e)
        {
            DialogResult response = MessageBox.Show(
                "Все данные всех Таблиц БД\r\n" +
                "будут экспортированы в файл Excel" + "\r\n\r\n" +
                "Продолжить?" + "\r\n"
                , "Экспорт данных в Excel"
                , MessageBoxButtons.YesNo
                , MessageBoxIcon.Information
                , MessageBoxDefaultButton.Button2
//                , MessageBoxOptions.DefaultDesktopOnly
                );
            BringToFront();                                                     //вернуть форму на передний план

            if (response == DialogResult.Yes)
            {
                List<string> arguments = new List<string>
                {
                    "export",                                       //для вызова нужного метода
                    tbMainExportPath.Text,                          //путь к файлу импорта Excel
                    Properties.Settings.Default.twtConnectionSrting //connection string SQL
                };

                if (!backgroundWorkerSetting.IsBusy)            //Запустить фоновую операцию (поток)(с аргументами) вызвав событие DoWork
                {
                    backgroundWorkerSetting.RunWorkerAsync(arguments);
                    //                    MessageBox.Show("Экспорт данных из БД завершен");
                }
            }
        }

        /// <summary>
        /// экспорт данных через OleDbDataAdapter и DataSet
        /// </summary>
        /// <param name="worker"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public string MainExportToExcel(BackgroundWorker worker, DoWorkEventArgs e)
        {
            //https://question-it.com/questions/3902413/eksport-dannyh-sql-v-excel-ochen-medlenno
            List<string> inArgument = e.Argument as List<string>;   //распарсить входнык параметры
            List<string> outArguments = new List<string>();         //возврат аргументов из потока на обработку
            //int countRows;                                          //общее количество строк в запросе
            DataTable dt = new DataTable();
            string path = inArgument[1];

            try
            {
                int ColumnsCount;
                //прочитать имена всех таблиц сортировка по времени ясоздания
                DataTable tables = clMsSqlDatabase.TableRequest(inArgument[2], "SELECT name FROM sys.objects WHERE type in (N'U') order by create_date");

                //Объявляем приложение
                excelApp = new Excel.Application
                {
                    Visible = false,                                            //Отобразить Excel
                    SheetsInNewWorkbook = tables.Rows.Count                     //Количество листов в рабочей книге    
                };
                workBook = excelApp.Workbooks.Add(mis);                         //Добавить рабочую книгу

                //цикл по всем листам и заполнение их данными из таблиц (имя листа=имятаблицы)
                for (int t = 0; t < tables.Rows.Count; t++)     //цикл по DataTable и заполнение ListView 
                {
                    DataRow drow = tables.Rows[t];
                    if (drow.RowState != DataRowState.Deleted)  // Only row that have not been deleted
                    {
                        workSheet = (Excel.Worksheet)excelApp.Worksheets[t + 1];   //Получаем первый лист документа (счет начинается с 1)
                        workSheet.Name = drow[0].ToString();

                        getDataTableSQL(drow[0].ToString(), ref dt);
                        if (dt == null || (ColumnsCount = dt.Columns.Count) == 0)
                            throw new Exception("ExportToExcel: Null or empty input table!\n");

                        object[] Header = new object[ColumnsCount];

                        // column headings               
                        for (int i = 0; i < ColumnsCount; i++)
                            Header[i] = dt.Columns[i].ColumnName;

                        Excel.Range HeaderRange = workSheet.get_Range((Excel.Range)(workSheet.Cells[1, 1]), (Excel.Range)(workSheet.Cells[1, ColumnsCount]));
                        HeaderRange.Value = Header;
                        HeaderRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                        HeaderRange.Font.Bold = true;

                        outArguments.Add("init");                       //init инициализация прогрессбара work отображение значения
                        outArguments.Add("0");                          //минимальное значение
                        outArguments.Add(dt.Rows.Count.ToString());     //максимальное значение
                        outArguments.Add("1");                          //шаг
                        outArguments.Add("импорт");                     //комментарий
                        worker.ReportProgress(0, outArguments);         //отобразить (вызвать событие) результаты progressbar

                        // DataCells
                        int RowsCount = dt.Rows.Count;
                        object[,] Cells = new object[RowsCount, ColumnsCount];

                        for (int j = 0; j < RowsCount; j++)
                        {
                            for (int i = 0; i < ColumnsCount; i++)
                                Cells[j, i] = dt.Rows[j][i];

                            outArguments[0] = "work";                                        //init инициализация прогрессбара work отображение значения
                            outArguments[1] = drow[0].ToString();                            //init инициализация прогрессбара work отображение значения
                            worker.ReportProgress((j * 100) / dt.Rows.Count, outArguments);  //отобразить (вызвать событие) результаты progressbar
                        }
                        workSheet.get_Range((Excel.Range)(workSheet.Cells[2, 1]), (Excel.Range)(workSheet.Cells[RowsCount + 1, ColumnsCount])).Value = Cells;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ExportToExcel: \n" + ex.Message);
            }
            finally
            {

                try
                {
                    workBook.SaveAs(path, Excel.XlFileFormat.xlOpenXMLWorkbook, mis, mis, mis, mis, Excel.XlSaveAsAccessMode.xlNoChange, mis, mis, mis, mis, mis);
                    //   workBook.SaveAs(path);
                }
                catch (Exception ex)
                {
                    throw new Exception("ExportToExcel: Excel file could not be saved! Check filepath.\n"
                        + ex.Message);
                }
                workBook.Close(true);// null, null, null);
                while (Marshal.ReleaseComObject(workBook) > 0) { }
                workBook = null;
                //     while (Marshal.ReleaseComObject(sheets) > 0) { }
                //     sheets = null;
                while (Marshal.ReleaseComObject(workSheet) > 0) { }
                workSheet = null;
                if (workRange != null)
                {
                    while (Marshal.ReleaseComObject(workRange) > 0) { }
                    workRange = null;
                }
                //GC();

                // int iProcessId;
                // GetWindowThreadProcessId(excelApp.Hwnd, out iProcessId);
                Process excelProcess = clSystemSet.GetExcelProcess(excelApp);
                excelApp.Quit();
                while (Marshal.ReleaseComObject(excelApp) > 0) { }
                excelApp = null;
                //GC();
                clSystemSet.killExcel(excelProcess.Id);// iProcessId);

                /*
                                if (workRange != null) Marshal.ReleaseComObject(workRange);

                                foreach (Excel.Worksheet sheet in excelApp.Worksheets)
                                {
                                    if (sheet != null) Marshal.ReleaseComObject(sheet);
                                }
                                workSheet = null;
                                //                Marshal.ReleaseComObject(sheets);
                                excelApp.DisplayAlerts = false;
                                try
                                {
                                       workBook.SaveAs(path, Excel.XlFileFormat.xlOpenXMLWorkbook, mis, mis, mis, mis, Excel.XlSaveAsAccessMode.xlNoChange, mis, mis, mis, mis, mis);
                                 //   workBook.SaveAs(path);
                                }
                                catch (Exception ex)
                                {
                                    throw new Exception("ExportToExcel: Excel file could not be saved! Check filepath.\n"
                                        + ex.Message);
                                }

                                foreach (Excel.Workbook book in excelApp.Workbooks)
                                {
                                    book.Close(true);// null, null, null);
                                    if (book != null) Marshal.ReleaseComObject(book);
                                    //book = null;
                                }
                         //       workBook.Close(true);// null, null, null);
                         //       if(workBook != null) Marshal.ReleaseComObject(workBook);
                                workBook = null;
                //
                //
                //              Marshal.ReleaseComObject(workbooks);
                                excelApp.Quit();
                                if (excelApp != null) Marshal.ReleaseComObject(excelApp);
                                excelApp = null;

                                GC.Collect();
                */

            }
            return inArgument[0];// "export";
        }

        /// <summary>
        /// кнопка импорт сотрудников
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btImportUsers_Click(object sender, EventArgs e)
        {
            DialogResult response = MessageBox.Show(
                "Внимание Таблицы:\r\n" +
                "  EventsPass (События проходов)\r\n" +
                "  Users      (Список сотрудников)\r\n" +
                " будут перезаписаны!!!" + "\r\n\r\n" +
                "Продолжить?" + "\r\n",
                "Начальное заполнение данных"
                , MessageBoxButtons.YesNo
                , MessageBoxIcon.Information
                , MessageBoxDefaultButton.Button2
//                , MessageBoxOptions.DefaultDesktopOnly
                );
            BringToFront();                                                     //вернуть форму на передний план

            if (response == DialogResult.Yes)
            {
                List<string> arguments = new List<string>
                {
                    "users",                                        //для вызова нужного метода
                    tbPathImport.Text,                              //путь к файлу импорта Excel
                    cbSheetUser.Text + "$" + tbRangeUser.Text,      //диапазон ячеек формата ИМЯ_ЛИСТА$ДИАПАЗОН
                    Properties.Settings.Default.twtConnectionSrting //connection string SQL
                };

                if (!backgroundWorkerSetting.IsBusy)            //Запустить фоновую операцию (поток)(с аргументами) вызвав событие DoWork
                {
                    backgroundWorkerSetting.RunWorkerAsync(arguments);
                }
            }
        }

        /// <summary>
        /// импорт таблицы проходов через OleDbDataAdapter и DataSet 
        /// </summary>
        /// <param name="worker"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public string ImportUserDataFromExcel(BackgroundWorker worker, DoWorkEventArgs e)
        {
            List<string> inArgument = e.Argument as List<string>;   //распарсить входнык параметры
            List<string> outArguments = new List<string>();         //возврат аргументов из потока на обработку
            int countRows;                                          //общее количество строк в запросе
            try
            {
                string csExcel = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source ={inArgument[1]};Extended Properties = " + "\"Excel 12.0 Xml;HDR=YES; IMEX = 1\"";
                using (OleDbConnection cnExcel = new OleDbConnection(csExcel))
                {
                    cnExcel.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter();
                    DataSet ds = new DataSet();
                    using (OleDbCommand cmdExcel = cnExcel.CreateCommand())
                    {
                        cmdExcel.CommandText = $"Select count(*) from [{inArgument[2]}]";
                        countRows = (int)cmdExcel.ExecuteScalar();

                        outArguments.Add("init");                       //init инициализация прогрессбара work отображение значения
                        outArguments.Add("0");                          //минимальное значение
                        outArguments.Add(countRows.ToString());         //максимальное значение
                        outArguments.Add("1");                          //шаг
                        outArguments.Add("импорт");                     //комментарий
                        worker.ReportProgress(0, outArguments);         //отобразить (вызвать событие) результаты progressbar

                        cmdExcel.CommandText = $"Select * from [{inArgument[2]}]";    //диапазон Data (без заголовка)
                        //OleDbDataReader result = cmdExcel.ExecuteReader();
                        da.SelectCommand = cmdExcel;
                        da.Fill(ds);
                    }
                    cnExcel.Close();

                    clMsSqlDatabase.ClearTableDB(inArgument[3], "EventsPass");  //очистить таблицу
                    clMsSqlDatabase.ClearTableDB(inArgument[3], "Users");       //очистить таблицу
                    using (var sqlConnection = new SqlConnection(inArgument[3]))
                    {
                        sqlConnection.Open();
                        using (var sqlCommand = sqlConnection.CreateCommand())
                        {
                            int currentRow = 0;
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                //System.Threading.Thread.Sleep(50);
                                sqlCommand.CommandText = "SELECT id FROM UserDepartment Where name='" + row[1].ToString() + "'";
                                int departmentId = (int)sqlCommand.ExecuteScalar();
                                sqlCommand.CommandText = "SELECT id FROM UserPost Where name='" + row[2].ToString() + "'";
                                int postId = (int)sqlCommand.ExecuteScalar();
                                sqlCommand.CommandText = "SELECT id FROM UserWorkScheme Where name='" + row[7].ToString() + "'";
                                int workSchemeId = (int)sqlCommand.ExecuteScalar();

                                sqlCommand.CommandText =
                                    "UPDATE Users Set " +
                                        "departmentId = " + departmentId + ", " +
                                        "postId = " + postId + ", " +
                                        "timeStart = " + "'" + ((DateTime)row[4]).ToShortTimeString() + "', " +
                                        "timeStop = " + "'" + ((DateTime)row[5]).ToShortTimeString() + "', " +
                                        "noLunch = " + ((Boolean)row[6] ? 1 : 0) + ", " +
                                        "workSchemeId = " + workSchemeId + ", " +
                                        "uses = " + ((Boolean)row[8] ? 1 : 0) + " " +
                                    "WHERE extId = '" + row[0].ToString() + "' and name = '" + row[3].ToString() + "'; " +
                                    "IF @@ROWCOUNT = 0 " +
                                    "INSERT INTO Users(" +
                                        "extId, " +
                                        "name, " +
                                        "departmentId, " +
                                        "postId, " +
                                        "timeStart, " +
                                        "timeStop, " +
                                        "noLunch, " +
                                        "workSchemeId, " +
                                        "uses) " +
                                    "VALUES (" +
                                        "N'" + row[0].ToString() + "', " +
                                        "N'" + row[3].ToString() + "', " +
                                        departmentId + ", " +
                                        postId + ", " +
                                        "'" + ((DateTime)row[4]).ToShortTimeString() + "', " +
                                        "'" + ((DateTime)row[5]).ToShortTimeString() + "', " +
                                        ((Boolean)row[6] ? 1 : 0) + ", " +
                                        workSchemeId + ", " +
                                        ((Boolean)row[8] ? 1 : 0) +
                                        ")";
                                sqlCommand.ExecuteNonQuery();
                                currentRow += 1;

                                outArguments[0] = "work";                                          //init инициализация прогрессбара work отображение значения
                                outArguments[1] = "Users";                                         //init инициализация прогрессбара work отображение значения
                                worker.ReportProgress((currentRow * 100) / countRows, outArguments);  //отобразить (вызвать событие) результаты progressbar
                            }
                        }
                        sqlConnection.Close();
                    }
                }
                CallBack_FrmSetting_outEvent.callbackEventHandler("", "", null);    //отправитьс ообщение главной форме что импрот произошел
                System.Threading.Thread.Sleep(1000);    //пауза 1 сек чтобы главная форма успела обновить список юзеров
                                                        //                MessageBox.Show("Список сотрудников загружен в БД");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return inArgument[0];// "users";
        }

        /// <summary>
        /// кнопка импорт проходов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btImportPass_Click(object sender, EventArgs e)
        {
            DialogResult response = MessageBox.Show(
                "Внимание Таблица:\r\n" +
                "  EventsPass (События проходов)\r\n" +
                "  будет перезаписана!!!" + "\r\n\r\n" +
                "Продолжить?" + "\r\n",
                "Начальное заполнение данных"
                , MessageBoxButtons.YesNo
                , MessageBoxIcon.Information
                , MessageBoxDefaultButton.Button2
//                , MessageBoxOptions.DefaultDesktopOnly
            );
            BringToFront();                                                     //вернуть форму на передний план

            if (response == DialogResult.Yes)
            {
                List<string> arguments = new List<string>
                {
                    "pass",                                         //для вызова нужного метода
                    tbPathImport.Text,                              //путь к файлу импорта Excel
                    cbSheetPass.Text + "$" + tbRangePass.Text,      //диапазон ячеек формата ИМЯ_ЛИСТА$ДИАПАЗОН
                    Properties.Settings.Default.twtConnectionSrting //connection string SQL
                };

                if (!backgroundWorkerSetting.IsBusy)                        //Запустить фоновую операцию (поток)(с аргументами) вызвав событие DoWork
                    backgroundWorkerSetting.RunWorkerAsync(arguments);
            }
        }

        /// <summary>
        /// импорт таблицы проходов через OleDbDataAdapter и DataSet
        /// </summary>
        /// <param name="worker"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public string ImportPassDataFromExcel(BackgroundWorker worker, DoWorkEventArgs e)
        {
            List<string> inArgument = e.Argument as List<string>;   //распарсить входнык параметры
            List<string> outArguments = new List<string>();         //возврат аргументов из потока на обработку
            int countRows;                                          //общее количество строк в запросе
            try
            {
                string csExcel = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source ={inArgument[1]};Extended Properties = " + "\"Excel 12.0 Xml;HDR=YES; IMEX = 1\"";
                using (OleDbConnection cnExcel = new OleDbConnection(csExcel))
                {
                    cnExcel.Open();
                    using (OleDbCommand cmdExcel = cnExcel.CreateCommand())
                    {
                        cmdExcel.CommandText = $"Select count(*) from [{inArgument[2]}]";
                        countRows = (int)cmdExcel.ExecuteScalar();

                        outArguments.Add("init");                       //init инициализация прогрессбара work отображение значения
                        outArguments.Add("0");                          //минимальное значение
                        outArguments.Add(countRows.ToString());         //максимальное значение
                        outArguments.Add("1");                          //шаг
                        outArguments.Add("импорт");                     //комментарий
                        worker.ReportProgress(0, outArguments);         //отобразить (вызвать событие) результаты progressbar

                        cmdExcel.CommandText = $"Select * from [{inArgument[2]}]";    //диапазон Data (без заголовка)
                        OleDbDataReader result = cmdExcel.ExecuteReader();


                        clMsSqlDatabase.ClearTableDB(inArgument[3], "EventsPass");      //очистить таблицу
                        using (var sqlConnection = new SqlConnection(inArgument[3]))
                        {
                            sqlConnection.Open();
                            using (var sqlCommand = sqlConnection.CreateCommand())
                            {
                                //sqlCommand.CommandTimeout = 10;
                                int currentRow = 0;
                                while (result.Read())
                                {
                                    try
                                    {
                                        //Явное приведение типов
                                        string author = result.GetString(1);
                                        string passDate = result.GetDateTime(2).ToString("yyyyMMdd");
                                        string passId = Convert.ToString(result.GetValue(3));
                                        string passTimeStart = result.GetDateTime(5).ToString("yyyyMMdd HH:mm");
                                        string passTimeStop = result.GetDateTime(6).ToString("yyyyMMdd HH:mm");
                                        int timeScheduleFact = Convert.ToInt32(result.GetValue(9));
                                        int timeScheduleWithoutLunch = Convert.ToInt32(result.GetValue(10));
                                        int timeScheduleLess = Convert.ToInt32(result.GetValue(11));
                                        int timeScheduleOver = Convert.ToInt32(result.GetValue(12));
                                        string sp = result.GetString(13).Trim();
                                        switch (sp)
                                        {
                                            case "-":
                                                sp = "Работа в дневное время";
                                                break;
                                            case "Больничный":
                                                sp = "Больничный (оплачиваемый)";
                                                break;
                                            case "Отгул":
                                                sp = "(Отгул) Дополнительный ежегодный отпуск (оплачиваемый)";
                                                break;
                                            case "Отпуск":
                                                sp = "Отпуск ежегодный (оплачиваемый)";
                                                break;
                                            case "Общественное дело":
                                            case "Служебное задание":
                                                sp = "Служебная командировка";
                                                break;
                                        }

                                        sqlCommand.CommandText = "SELECT id FROM SpecialMarks Where name='" + sp + "'";
                                        int specialMarksId = (int)sqlCommand.ExecuteScalar();               //получить  id спец отметки                                   

                                        //поднять рейтинг спец отметки
                                        sqlCommand.CommandText = "SELECT rating FROM SpecialMarks Where id=" + specialMarksId;
                                        int specialMarksRating = (int)sqlCommand.ExecuteScalar();           //прочитать рейтинг
                                        specialMarksRating++;                                               //поднять рейтинг                        
                                        sqlCommand.CommandText = "UPDATE SpecialMarks Set rating = " + specialMarksRating + ", uses = 1 Where id=" + specialMarksId;
                                        sqlCommand.ExecuteNonQuery();                                       //обновить рейтинг

                                        string specmarkTimeStart = specialMarksId == 1 ? "NULL" : "'" + Convert.ToDateTime(result.GetValue(14)).ToString("yyyyMMdd HH:mm") + "'";
                                        string specmarkTimeStop = specialMarksId == 1 ? "NULL" : "'" + Convert.ToDateTime(result.GetValue(15)).ToString("yyyyMMdd HH:mm") + "'";
                                        string specmarkNote = result.GetValue(16) == DBNull.Value ? "NULL" : "N'" + Convert.ToString(result.GetValue(16)).Replace("'", "''") + "'";
                                        int totalHoursInWork = Convert.ToInt32(result.GetValue(17));
                                        int totalHoursOutsideWork = result.GetValue(18) == DBNull.Value ? 0 : Convert.ToInt32(result.GetValue(18));

                                        string sql =
                                            "UPDATE EventsPass Set " +
                                                "author = " + "N'" + author + "', " +
                                                "passTimeStart = " + "'" + passTimeStart + "', " +
                                                "passTimeStop = " + "'" + passTimeStop + "', " +
                                                //"pacsTimeStart = " + "NULL" + ", " +
                                                //"pacsTimeStop = " +  "NULL" + ", " +
                                                "timeScheduleFact = " + timeScheduleFact + ", " +
                                                "timeScheduleWithoutLunch = " + timeScheduleWithoutLunch + ", " +
                                                "timeScheduleLess = " + timeScheduleLess + ", " +
                                                "timeScheduleOver = " + timeScheduleOver + ", " +
                                                "specmarkId = " + specialMarksId + ", " +
                                                "specmarkTimeStart = " + specmarkTimeStart + ", " +
                                                "specmarkTimeStop = " + specmarkTimeStop + ", " +
                                                "specmarkNote = " + specmarkNote + ", " +
                                                "totalHoursInWork = " + totalHoursInWork + ", " +
                                                "totalHoursOutsideWork = " + totalHoursOutsideWork + " " +
                                            "WHERE passDate = '" + passDate + "' " +                   //*дата прохода
                                                "and passId = '" + passId + "' ; " +                   //*внешний id сотрудника
                                            "IF @@ROWCOUNT = 0 " +
                                            "INSERT INTO EventsPass(" +
                                                "author, " +                                    //имя учетной записи сеанса
                                                "passDate, " +                                  //*дата события (без времени)
                                                "passId, " +                                    //*внешний id пользователя
                                                "passTimeStart, " +                             //время первого входа (без даты)
                                                "passTimeStop, " +                              //время последнего выхода (без даты)
                                                                                                //"pacsTimeStart, " +                             //время первого входа по СКУД (без даты)
                                                                                                //"pacsTimeStop, " +                              //время последнего выхода по СКУД (без даты)
                                                "timeScheduleFact, " +                          //отработанное время (мин)
                                                "timeScheduleWithoutLunch, " +                  //отработанное время без обеда (мин)
                                                "timeScheduleLess, " +                          //время недоработки (мин)
                                                "timeScheduleOver, " +                          //время переработки (мин)
                                                "specmarkId, " +                                //->ссылка на специальные отметки
                                                "specmarkTimeStart, " +                         //датавремя начала действия специальных отметок
                                                "specmarkTimeStop, " +                          //датавремя окончания специальных отметок
                                                "specmarkNote, " +                              //комментарий к специальным отметкам
                                                "totalHoursInWork, " +                          //итог рабочего времени в графике (мин)
                                                "totalHoursOutsideWork) " +                     //итог рабочего времени вне графика (мин)
                                            "VALUES (" +
                                                "N'" + author + "', " +
                                                "'" + passDate + "', " +
                                                "'" + passId + "', " +
                                                "'" + passTimeStart + "', " +
                                                "'" + passTimeStop + "', " +
                                                //"NULL" + ", " +
                                                //"NULL" + ", " +
                                                timeScheduleFact + ", " +
                                                timeScheduleWithoutLunch + ", " +
                                                timeScheduleLess + ", " +
                                                timeScheduleOver + ", " +
                                                specialMarksId + ", " +
                                                specmarkTimeStart + ", " +
                                                specmarkTimeStop + ", " +
                                                specmarkNote + ", " +
                                                totalHoursInWork + ", " +
                                                totalHoursOutsideWork +
                                                ")";
                                        sqlCommand.CommandText = sql;
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message.ToString());
                                    }
                                    sqlCommand.ExecuteNonQuery();
                                    currentRow += 1;

                                    outArguments[0] = "work";                                           //init инициализация прогрессбара work отображение значения
                                    outArguments[1] = "EventsPass";                                     //init инициализация прогрессбара work отображение значения
                                    worker.ReportProgress((currentRow * 100) / countRows, outArguments);    //отобразить (вызвать событие) результаты progressbar
                                }
                            }
                            sqlConnection.Close();
                        }
                    }
                    cnExcel.Close();
                }
                //                    MessageBox.Show("Список проходов загружен в БД");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return inArgument[0];// "pass";
        }

        #endregion

        /// <summary>
        /// событие сохранить параметры перед закрытием формы 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.importFilename = tbPathImport.Text;
            Properties.Settings.Default.importUserRange = @cbSheetUser.Text + "$" + tbRangeUser.Text;
            Properties.Settings.Default.importPassRange = @cbSheetPass.Text + "$" + tbRangePass.Text;
            Properties.Settings.Default.companyName = tbCompanyName.Text.Trim();
            Properties.Settings.Default.daysInWorkWeek = (int)nDaysInWorkWeek.Value;
            Properties.Settings.Default.hoursInFullWorkDay = (int)nHoursInFullWorkDay.Value;
            Properties.Settings.Default.minutesChangingFullWorkDay = (int)nMinutesChangingFullWorkDay.Value;
            Properties.Settings.Default.minutesLunchBreakTime = (int)nMinutesLunchBreakTime.Value;

            Properties.Settings.Default.Save();
            CallBack_FrmSetting_outEvent.callbackEventHandler("", "", null);    //отправитьс ообщение главной форме что импрот произошел
        }

        /// <summary>
        /// событие перерисуем цвет кнопок вкладок Tab
        /// </summary>
        private void tabSetting_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage page = tabSetting.TabPages[e.Index];
            Color col = e.Index == 0 ? SystemColors.Control : Color.WhiteSmoke;
            e.Graphics.FillRectangle(new SolidBrush(col), e.Bounds);

            Rectangle paddedBounds = e.Bounds;
            int yOffset = (e.State == DrawItemState.Selected) ? -2 : 1;
            paddedBounds.Offset(1, yOffset);
            TextRenderer.DrawText(e.Graphics, page.Text, Font, paddedBounds, page.ForeColor);
        }

        #region CALLBACK InPut (подписка на внешние сообщения)

        /// <summary>
        /// Callbacks the reload.
        /// входящее асинхронное сообщение для подписанных слушателей с передачей текущих параметров
        /// </summary>
        /// <param name="controlName">имя CTRL</param>
        /// <param name="controlParentName">имя родителя CNTRL</param>
        /// <param name="param">параметры ключ-значение.</param>
        private void CallbackReload(string controlName, string controlParentName, Dictionary<String, String> param)
        {
            /*
            if (param.Count() != 0)
            {
                Control[] cntrl = this.FilterControls(c => c.Name != null && c.Name.Equals(controlName) && c is DataGridView);
                ((DataGridView)cntrl[0]).DataSource = param;
            }
            */
        }
        #endregion
    }

    #region CALLBACK OutPut (собственные сообщения)

    /// <summary>
    /// callbackEvent после импорта (первоначальное заполнение данных)
    /// </summary>
    public static class CallBack_FrmImport_outEvent
    {
        /// <summary>
        /// Delegate callbackEvent после импорта (первоначальное заполнение данных)
        /// </summary>
        /// <param name="controlName">имя CTRL</param>
        /// <param name="controlParentName">имя родителя CNTRL</param>
        /// <param name="parameterPairs">параметры ключ-значение</param>
        public delegate void callbackEvent(string controlName, string controlParentName, Dictionary<String, String> parameterPairs);

        /// <summary>
        /// The callback event handler
        /// </summary>
        public static callbackEvent callbackEventHandler;
    }

    /// <summary>
    /// callbackEvent изменение общих настроек
    /// </summary>
    public static class CallBack_FrmSetting_outEvent
    {
        /// <summary>
        /// Delegate callbackEvent изменение общих настроек
        /// </summary>
        /// <param name="controlName">имя CTRL</param>
        /// <param name="controlParentName">имя родителя CNTRL</param>
        /// <param name="parameterPairs">параметры ключ-значение</param>
        public delegate void callbackEvent(string controlName, string controlParentName, Dictionary<String, String> parameterPairs);

        /// <summary>
        /// The callback event handler
        /// </summary>
        public static callbackEvent callbackEventHandler;
    }

    #endregion
}



//---мусор
//http://www.codedigest.com/Articles/ASPNET/400_ImportUpload_Excel_Sheet_data_to_Sql_Server_in_C__and_AspNet.aspx#google_vignette
//https://csharp-tutorials1.blogspot.com/2017/03/import-excel-data-into-sql-table-using.html
//https://question-it.com/questions/1788823/kak-zagruzit-fajl-excel-v-tablitsu-bazy-dannyh-sql-s-pomoschju-prilozhenija-s-windows-form
//https://www.red-gate.com/simple-talk/databases/sql-server/t-sql-programming-sql-server/questions-about-using-tsql-to-import-excel-data-you-were-too-shy-to-ask/          
//https://metanit.com/sharp/tutorial/6.5.php

//https://www.nookery.ru/c-work-c-excel/
//https://yoursandmyideas.com/2011/02/05/how-to-read-or-write-excel-file-using-ace-oledb-data-provider/
//https://gist.github.com/maestrow/fd68246f6bca87891d2ace7a67d180e0
//https://www.codeproject.com/Tips/705470/Read-and-Write-Excel-Documents-Using-OLEDB
//--------------------------------------------------------------------------------------------------------------------------------------------------------------------
//https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.backgroundworker?redirectedfrom=MSDN&view=net-5.0
//https://www.bestprog.net/ru/2021/03/28/c-control-component-backgroundworker-ru/
//https://www.bestprog.net/ru/2021/03/31/c-windows-forms-the-backgroundworker-control-displays-the-progress-of-completed-work-canceling-the-execution-of-a-thread-ru/
//

