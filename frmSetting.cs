using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using Excel = Microsoft.Office.Interop.Excel;



//using DocumentFormat.OpenXml;
//using DocumentFormat.OpenXml.Packaging;
//using DocumentFormat.OpenXml.Spreadsheet;

namespace TimeWorkTracking
{
    public partial class frmSetting : Form
    {
        private int numberToCompute = 0;
        private int highestPercentageReached = 0;
        public frmSetting()
        {
            //подписка события внешних форм 
            CallBack_FrmMain_outEvent.callbackEventHandler = new CallBack_FrmMain_outEvent.callbackEvent(this.CallbackReload);    //subscribe (listen) to the general notification
            InitializeComponent();
            InitializeBackgroundWorker();
        }

//--------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.backgroundworker?redirectedfrom=MSDN&view=net-5.0
        //https://www.bestprog.net/ru/2021/03/28/c-control-component-backgroundworker-ru/
        //https://www.bestprog.net/ru/2021/03/31/c-windows-forms-the-backgroundworker-control-displays-the-progress-of-completed-work-canceling-the-execution-of-a-thread-ru/
        //Настройка объекта BackgroundWorker добавим свои события.
        private void InitializeBackgroundWorker()
        {
            backgroundWorkerSetting.DoWork += new DoWorkEventHandler(backgroundWorkerSetting_DoWork);
            backgroundWorkerSetting.ProgressChanged += new ProgressChangedEventHandler(backgroundWorkerSetting_ProgressChanged);
            backgroundWorkerSetting.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorkerSetting_RunWorkerCompleted);
            backgroundWorkerSetting.WorkerReportsProgress = true;       //Разрешить использовать событие по отображению прогресса
            backgroundWorkerSetting.WorkerSupportsCancellation = true;  //Разрешить использовать средства остановки(отмены выполнения) потока.
//            backgroundWorkerSetting.GenerateMember = true;              
        }

        //Событие возникает после запуска потока методом RunAsync()
        //В обработчик этого события вписывается код выполнения потока.
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
            }
        }

        //Событие возникает когда происходит завершение потока выполнения
        //В обработчик этого события целесообразно вписывать код завершающих операций, вывод соответствующих сообщений и т.п.
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
                toolStripStatusLabelInfo.Text = ""; //e.Result.ToString();
                toolStripProgressBarImport.Value = 0;
                switch (e.Result.ToString())                
                {
                    case "users":                                                           //если завершился иморт пользователей
                        CallBack_FrmSetting_outEvent.callbackEventHandler("", "", null);    //отправитьс ообщение главной форме что импрот произошел
                        string cs = Properties.Settings.Default.twtConnectionSrting;        //connection string
                        int count = Convert.ToInt32(clMsSqlDatabase.RequesScalar(cs, "select count(*) from Users", false));
                        btImportUsers.Enabled = count == 0;
                        break;
                    case "pass":                                                            //если завершился иморт проходов
                        break;
                }
            }
        }

        //Событие возникает, когда рабочий поток указывает на то, что был достигнут некоторый прогресс
        //вызывается из DoWork запуском ReportProgress которое вызывает данное событие
        //В обработчике события ProgressChanged указывается код визуализации прогресса с помощью известных компонент, таких как ProgressBar, Label и т.д.;
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
                    toolStripStatusLabelInfo.Text = "Обработано " +
                                                    toolStripProgressBarImport.Value.ToString() + " из " +
                                                    toolStripProgressBarImport.Maximum.ToString() + " (" +
                                                    Convert.ToString(e.ProgressPercentage) + "%)";
                    break;
            }
        }
//--------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private void frmSetting_Load(object sender, EventArgs e)
        {
            if (!checkProvider()) this.Close();
            checkFileImport(Properties.Settings.Default.importFilename);

            string cs = Properties.Settings.Default.twtConnectionSrting;    //connection string
            mainPanelSetting.Enabled = clMsSqlDatabase.CheckConnectWithConnectionStr(cs);
        }   
        //проверить провайдеров для работы с Excel
        private bool checkProvider() 
        {
            //проверим наличие провайдера
            OleDbEnumerator enumerator = new OleDbEnumerator();
            DataTable table1 = enumerator.GetElements();
            bool jetOleDb = false, aceOleDb = false, excel = false;
            foreach (DataRow row in table1.Rows)
            {
                if (row["SOURCES_NAME"].ToString() == "Microsoft.Jet.OLEDB.4.0") jetOleDb = true;
                if (row["SOURCES_NAME"].ToString() == "Microsoft.ACE.OLEDB.12.0") aceOleDb = true;
            }

            Type officeType = Type.GetTypeFromProgID("Excel.Application");
            if (officeType != null)
                excel = true;

            if (!(aceOleDb && excel)) 
            {
                MessageBox.Show(
                    "В системе отсутствует провайдер\r\n"+
                    " - Microsoft.ACE.OLEDB.12.0\r\n\r\n" +
                    "функционал Экспорт/Импорт/Отчеты\r\n - недоступен\r\n" +
                    "установите пожалуйста MS Excel2010 или выше",
                    "Ошибка окружения",MessageBoxButtons.OK,MessageBoxIcon.Exclamation
                    );
                return false;
            }
            else
               return true;
        }

        //диалог выбора имени файла
        private void btFileName_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog
            {
                //   Filter = "Excel 2010(*.xlsm) | *.xlsm|XML Documents(*.xml)|*.xml";
                Filter = "Excel 2010(*.xlsm) | *.xlsm"//|XML Documents(*.xml)|*.xml";
            };
            DialogResult dr = od.ShowDialog();
            if (dr == DialogResult.Abort)
                tbPath.Text = "";
            if (dr == DialogResult.Cancel)
                tbPath.Text = "";

            tbPath.Text = od.FileName.ToString();
            checkFileImport(tbPath.Text);
        }


        //проверить файл импорта и настройка
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
                tbPath.Text = ""; 
                groupBox1.Enabled = false;
            }
            else
            {
                try
                {
                    string csExcel = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source ={newPath};Extended Properties = " + "\"Excel 12.0 Xml;HDR=YES; IMEX = 1\"";
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
                                cbSheetUser.Items.Add(shName);
                                cbSheetPass.Items.Add(shName);
                            }
                        }
                        cnExcel.Close();
                    }
                    Properties.Settings.Default.importFilename = @newPath;
                    Properties.Settings.Default.importUserRange = cbSheetUser.Text + "$" + tbRangeUser.Text;
                    Properties.Settings.Default.importPassRange = cbSheetPass.Text + "$" + tbRangePass.Text;

                    Properties.Settings.Default.Save();

                    tbPath.Text= newPath;
                    groupBox1.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        //кнопка импорт пользователей
        private void btImportUsers_Click(object sender, EventArgs e)
        {
            List<string> arguments = new List<string>();
            arguments.Add("users");                                     //для вызова нужного метода
            arguments.Add(tbPath.Text);                                 //путь к файлу импорта Excel
            arguments.Add(cbSheetUser.Text + "$" + tbRangeUser.Text);   //диапазон ячеек формата ИМЯ_ЛИСТА$ДИАПАЗОН

            if (!backgroundWorkerSetting.IsBusy)                        //Запустить фоновую операцию (поток)(с аргументами) вызвав событие DoWork
                backgroundWorkerSetting.RunWorkerAsync(arguments);
        }

        //импорт сотрудников через OleDbDataAdapter & DataSet
        public string ImportUserDataFromExcel(BackgroundWorker worker, DoWorkEventArgs e)
        {
            List<string> inArgument = e.Argument as List<string>;   //распарсить входнык параметры
            List<string> outArguments = new List<string>();         //возврат аргументов из потока на обработку
            int countRows;                                          //общее количество строк в запросе

            DialogResult response = MessageBox.Show(
                "Внимание Таблицы Прохода и Сотрудников будут Очищены" + "\r\n" +
                "Продолжить?" + "\r\n",
                "Начальное заполнение данных",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button2,
                MessageBoxOptions.DefaultDesktopOnly
                );
            if (response == DialogResult.Yes) 
            {
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
                        using (var sqlConnection = new SqlConnection(Properties.Settings.Default.twtConnectionSrting))
                        {
                            sqlConnection.Open();
                            using (var sqlCommand = sqlConnection.CreateCommand())
                            {
                                sqlCommand.CommandText = "DELETE FROM EventsPass";
                                sqlCommand.ExecuteScalar();
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
                                    worker.ReportProgress((currentRow*100)/ countRows, outArguments);  //отобразить (вызвать событие) результаты progressbar
                                }
                            }
                            sqlConnection.Close();
                        }
                    }
                    MessageBox.Show("Список сотрудников загружен в БД");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            return "users";
        }

        //кнопка импорт проходов 
        private void btImportPass_Click(object sender, EventArgs e) 
        {
            List<string> arguments = new List<string>();
            arguments.Add("pass");                                      //для вызова нужного метода
            arguments.Add(tbPath.Text);                                 //путь к файлу импорта Excel
            arguments.Add(cbSheetPass.Text + "$" + tbRangePass.Text);   //диапазон ячеек формата ИМЯ_ЛИСТА$ДИАПАЗОН

            if (!backgroundWorkerSetting.IsBusy)                        //Запустить фоновую операцию (поток)(с аргументами) вызвав событие DoWork
                backgroundWorkerSetting.RunWorkerAsync(arguments);
        }

        //импорт сотрудников через OleDbDataAdapter & DataSet
        public string ImportPassDataFromExcel(BackgroundWorker worker, DoWorkEventArgs e)
        {
            List<string> inArgument = e.Argument as List<string>;   //распарсить входнык параметры
            List<string> outArguments = new List<string>();         //возврат аргументов из потока на обработку
            int countRows;                                          //общее количество строк в запросе

            DialogResult response = MessageBox.Show(
                "Внимание Таблица Проходов будет Очищена" + "\r\n" +
                "Продолжить?" + "\r\n",
                "Начальное заполнение данных",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button2,
                MessageBoxOptions.DefaultDesktopOnly
                );
            if (response == DialogResult.Yes)
            {
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

                            using (var sqlConnection = new SqlConnection(Properties.Settings.Default.twtConnectionSrting))
                            {
                                sqlConnection.Open();
                                using (var sqlCommand = sqlConnection.CreateCommand())
                                { 
                                    //sqlCommand.CommandTimeout = 10;
                                    sqlCommand.CommandText = "DELETE FROM EventsPass";
                                    sqlCommand.ExecuteScalar();
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
                                                case "Больничный":
                                                    sp = "Больничный с оплатой";
                                                    break;
                                            }
                                            sqlCommand.CommandText = "SELECT id FROM SpecialMarks Where name='" + sp + "'";
                                            int specialMarksId = (int)sqlCommand.ExecuteScalar();
//                                            DateTime.ParseExact(result.GetValue(14).ToString(), "dd MMMM HH:mm", CultureInfo.GetCultureInfo("ru-RU"))
                                            string specmarkTimeStart = specialMarksId == 1 ? "NULL" : "'" + Convert.ToDateTime(result.GetValue(14)).ToString("yyyyMMdd HH:mm") + "'";
                                            string specmarkTimeStop = specialMarksId == 1 ? "NULL" : "'" + Convert.ToDateTime(result.GetValue(15)).ToString("yyyyMMdd HH:mm") + "'";
                                            string specmarkNote = result.GetValue(16) == DBNull.Value ? "NULL" : "N'" + Convert.ToString(result.GetValue(16)) + "'";
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

                                        outArguments[0] = "work";                                               //init инициализация прогрессбара work отображение значения
                                        worker.ReportProgress((currentRow * 100) / countRows, outArguments);    //отобразить (вызвать событие) результаты progressbar
                                    }
                                }
                                sqlConnection.Close();
                            }
                        }
                        cnExcel.Close();
                    }
                    MessageBox.Show("Список проходов загружен в БД");
                    toolStripProgressBarImport.Value = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            return "pass";
        }

        /*--------------------------------------------------------------------------------------------  
        CALLBACK InPut (подписка на внешние сообщения)
        --------------------------------------------------------------------------------------------*/
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
    }
    /*--------------------------------------------------------------------------------------------  
    CALLBACK OutPut (собственные сообщения)
    --------------------------------------------------------------------------------------------*/
    //general notification
    /// <summary>
    /// CallBack_GetParam
    /// исходящее асинхронное сообщение для подписанных слушателей с передачей текущих параметров 
    /// </summary>
    public static class CallBack_FrmSetting_outEvent
    {
        /// <summary>
        /// Delegate callbackEvent
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

/*
                string excelFilePath = getPathSourse();
                if (excelFilePath != "")
                {

                    List<string[]> d = import_xlsx(excelFilePath, 1);

*/

//    DataSet ds = new DataSet();

/*
    csExcel = "Provider=Microsoft.Jet.OLEDB.4.0; "Data Source=" + excelFilePath + Extended Properties=Excel 12.0 Macro;";
    csExcel = @"provider=microsoft.ACE.OLEDB.12.0;data source=" + excelFilePath + ";extended properties=" + "\"Excel 12.0 Macro;hdr=yes;\"";
    csExcel = $@"provider=microsoft.ACE.OLEDB.12.0;data source ={excelFilePath};extended properties=" + "\"excel 12.0;hdr=yes;\"";
    csExcel = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source ={excelFilePath};Extended Properties = " + "\"Excel 12.0 Xml;HDR=YES;ReadOnly=true\"";
    csExcel = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source ={excelFilePath};Extended Properties = " + "\"Excel 12.0 Xml;HDR=NO\"";
       HDR = YES | NO.HDR = YES означает, что первую строку листа, следует рассматривать как заголовки колонок. Т.о.значение из первой строки можно использовать как имена полей в sql запросах(любых: select, insert, update, delete).
      IMEX = 1 | 3. 1 - открыть соединение для чтения. 3 - для записи.

      "'[Учет рабочего времени.xlsm]Reference'!$B$4:$J$68"
    reqExcel = @"Select * from '[Учет рабочего времени.xlsm]Reference'!$B$4:$J$68";     //ругается на скобки
    reqExcel = @"Select * from 'Reference'!$B$4:$J$68";                                 //синтаксическая ошибка неполный запрос
    reqExcel = @"Select * from $B$4:$J$68";                                             //ошибка в предложении from
    reqExcel = "Select * from [Reference$B3:J68]";                                      //ок
    reqExcel = @"Select * from Reference!$B$4:$J$68";                                   //ошибка синтаксиса в предложении from
    reqExcel = "Select * from Reference!$B$4:$J$68";                                    //ошибка синтаксиса в предложении from
    reqExcel = "Select * from Reference$B3:J68";                                        //ошибка синтаксиса в предложении from
    reqExcel = "Select * from [Reference$B3:J68]";                                      //ок
    reqExcel = "Select * from [Reference$users]";                                       //не найжен ядром
    reqExcel = "Select * from [Reference$Users]";                                       //не найжен ядром
    reqExcel = "Select * from [users]";                                                 //не найжен ядром
    reqExcel = "Select * from [Users]";                                                 //не найжен ядром
    reqExcel = "Select * from Users";                                                   //не найжен ядром
    reqExcel = "Select * from users";                                                   //не найжен ядром
    reqExcel = "Select * from [B3:J68]";                                                //ок но лист не тот
    reqExcel = "Select * from B3:J68";                                                  //ок но лист не тот
    reqExcel = "Select * from Reference!B3:J68";                                        //ошибка синтаксиса в предложении from
    reqExcel = "Select * from Reference$B3:J68";                                        //ошибка синтаксиса в предложении from
    reqExcel = "Select * from [Reference$B3:J68]";                                      //ок
    reqExcel = "Select * from Data";
    reqExcel = "SELECT * FROM USERS";
    reqExcel = "SELECT * FROM DATA";
    reqExcel = "SELECT * FROM [Reference$]";
 */


/*
OleDbConnection connExcel = new OleDbConnection(csExcel);
OleDbCommand cmdExcel = new OleDbCommand();
try
{
    cmdExcel.Connection = connExcel;
    //Read Data from Sheet1
    connExcel.Open();
    OleDbDataAdapter da = new OleDbDataAdapter();
    DataSet ds = new DataSet();
 //   string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
    cmdExcel.CommandText = reqExcel;

    da.SelectCommand = cmdExcel;
    da.Fill(ds);
    connExcel.Close();

    toolStripProgressBarImport.Minimum = 0;
    toolStripProgressBarImport.Maximum = ds.Tables[0].Rows.Count;
    toolStripProgressBarImport.Value = 0;
    foreach (var row in ds.Tables[0].Rows) 
    {
        toolStripProgressBarImport.Value += 1;
    }

}
catch (Exception ex)
{
    MessageBox.Show(ex.Message.ToString());
}
finally
{
    cmdExcel.Dispose();
    connExcel.Dispose();
}










-----------------------------------------------------


string excelFilePath = "";// getPathSourse();
                if (excelFilePath != "")
                {
                    Excel.Application excelapp = new Excel.Application();
                    //excelapp.Visible = true;
                    Excel.Workbook workbook = excelapp.Workbooks.Open(
                        excelFilePath,
                        Type.Missing, true, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing);

                    Excel.Worksheet sheet = (Excel.Worksheet)workbook.Sheets["Reference"];
                    Excel.Range range = (Excel.Range)sheet.Range["Users"];// ().Cells[row, col];
                 
                    //   string n = "'" + range.Parent + "'!" + range.Address;
//                    Set b = Worksheets(2).Range("Users")
//s = "'" & b.Parent.name & "'!" & b.Address(External:= False)
                    foreach (var rangeName in workbook.Names)
                    {
                       // Range c = ws.Cells[row++, 3];
                       // c.Value = rangeName.NameLocal;
                    }
                    //                    string address= workbook.Worksheets[2].R
                    workbook.Close(false, Type.Missing, Type.Missing);  // Закройте книгу без сохранения изменений.
                    excelapp.Quit();                                   // Закройте сервер Excel.
                    using (var sqlConnection = new SqlConnection(Properties.Settings.Default.twtConnectionSrting))
                    {
                        string myexceldataquery = "Select * from [Reference$B3:J68]";
                        //               string myexceldataquery = "Select * from users";
                        try
                        {
                            string sexcelconnectionstring = @"provider=microsoft.ACE.OLEDB.12.0;data source=" + excelFilePath +
                            ";extended properties=" + "\"Excel 12.0 Macro;hdr=yes;\"";

                            sqlConnection.Open();
                            OleDbConnection oledbconn = new OleDbConnection(sexcelconnectionstring);
                            OleDbCommand oledbcmd = new OleDbCommand(myexceldataquery, oledbconn);
                            oledbconn.Open();
                            OleDbDataReader dr = oledbcmd.ExecuteReader();

                            object[] meta = new object[10];
                            bool read;

                            using (var sqlCommand = sqlConnection.CreateCommand())
                            {
                                sqlCommand.CommandText = "DELETE FROM EventsPass";
                                sqlCommand.ExecuteScalar();

                                sqlCommand.CommandText = "DELETE FROM Users";
                                sqlCommand.ExecuteScalar();
                                if (dr.Read() == true)
                                {
                                    do
                                    {
                                        int NumberOfColums = dr.GetValues(meta);

                                        sqlCommand.CommandText = "SELECT id FROM UserDepartment Where name='" + meta[1].ToString() + "'";
                                        int departmentId = (int)sqlCommand.ExecuteScalar();
                                        sqlCommand.CommandText = "SELECT id FROM UserPost Where name='" + meta[2].ToString() + "'";
                                        int postId = (int)sqlCommand.ExecuteScalar();
                                        sqlCommand.CommandText = "SELECT id FROM UserWorkScheme Where name='" + meta[7].ToString() + "'";
                                        int workSchemeId = (int)sqlCommand.ExecuteScalar();

                                        sqlCommand.CommandText =
                                            "UPDATE Users Set " +
                                              "departmentId = " + departmentId + ", " +
                                              "postId = " + postId + ", " +
                                              "timeStart = " + "'" + ((DateTime)meta[4]).ToShortTimeString() + "', " +
                                              "timeStop = " + "'" + ((DateTime)meta[5]).ToShortTimeString() + "', " +
                                              "noLunch = " + ((Boolean)meta[6] ? 1 : 0) + ", " +
                                              "workSchemeId = " + workSchemeId + ", " +
                                              "uses = " + ((Boolean)meta[8] ? 1 : 0) + " " +
                                            "WHERE extId = '" + meta[0].ToString() + "' and name = '" + meta[3].ToString() + "'; " +
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
                                              "N'" + meta[0].ToString() + "', " +
                                              "N'" + meta[3].ToString() + "', " +
                                              departmentId + ", " +
                                              postId + ", " +
                                              "'" + ((DateTime)meta[4]).ToShortTimeString() + "', " +
                                              "'" + ((DateTime)meta[5]).ToShortTimeString() + "', " +
                                              ((Boolean)meta[6] ? 1 : 0) + ", " +
                                              workSchemeId + ", " +
                                              ((Boolean)meta[8] ? 1 : 0) +
                                              ")";
                                        sqlCommand.ExecuteNonQuery();
                                        read = dr.Read();
                                    } while (read == true);
                                }
                            }
                            dr.Close();
                            oledbconn.Close();
                            MessageBox.Show("Список сотрудников загружен в БД");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString());
                        }
                    }
                }


*/