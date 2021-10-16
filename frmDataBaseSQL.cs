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
    public partial class frmDataBaseSQL : Form
    {
        public frmDataBaseSQL()
        {
            InitializeComponent();
        }

        private void tabSetting_Selected(object sender, TabControlEventArgs e)
        {
            //Read Setting
            //TimeWorkTracking DataBase
            tbServerTWT.Text = Properties.Settings.Default.twtServerName;
            tbDatabaseTWT.Text = Properties.Settings.Default.twtDatabase;
            if (Properties.Settings.Default.twtAuthenticationDef != "")
                cbAutentificationTWT.SelectedItem = Properties.Settings.Default.twtAuthenticationDef;
            else
                cbAutentificationTWT.SelectedItem = "Windows Autentification";

            tbUserNameTWT.Text = Properties.Settings.Default.twtLogin;
            tbPasswordTWT.Text = Properties.Settings.Default.twtPassword;

            if (Properties.Settings.Default.twtConnectionSrting != "")
                picStatusTWT.Image = global::TimeWorkTracking.Properties.Resources.ok;
            else
                picStatusTWT.Image = global::TimeWorkTracking.Properties.Resources.no;



            btCreateDBTwt.Visible = false;

            // btTestConnectionTwt_Click(null, null);
        }

        private void cbAutentificationTWT_SelectedIndexChanged(object sender, EventArgs e)
        {

            bool auth = cbAutentificationTWT.Text == "SQL Server Autentification";   //если да то true если нет то false
            tbUserNameTWT.Enabled = auth;
            tbPasswordTWT.Enabled = auth;
        }

        //test Connrection TWT (TimeWorkTracking database )
        private void btTestConnectionTwt_Click(object sender, EventArgs e)
        {
            string connectionString;
            StringBuilder Messages = new StringBuilder();
            switch (cbAutentificationTWT.Text)
            {
                case "SQL Server Autentification":
                    connectionString = @"Data Source=" + tbServerTWT.Text + ";Initial Catalog=" + tbDatabaseTWT.Text + ";Persist Security Info=True;User ID=" + tbUserNameTWT.Text + ";Password=" + tbPasswordTWT.Text;
                    break;
                case "Windows Autentification":
                    connectionString = @"Data Source=" + tbServerTWT.Text + "; Initial Catalog=" + tbDatabaseTWT.Text + "; Integrated Security=True";
                    break;
                default:
                    connectionString = "";
                    break;
            }

            string statusDB = MsSqlDatabase.GetSqlConnection(connectionString);
            switch (statusDB)
            {
                case "-1":      //бд не существует
                    statusDB = "";
                    picStatusTWT.Image = global::TimeWorkTracking.Properties.Resources.no;
                    btCreateDBTwt.Visible = true;
                    Messages.Append("База данных с именем:" + "\n" +
                                                "'" + tbDatabaseTWT.Text + "'" + "\n" +
                                                "не существует на сервере");
                    break;
                case "-9":      //соединение установить не удалось
                    statusDB = "";
                    picStatusTWT.Image = global::TimeWorkTracking.Properties.Resources.no;
                    btCreateDBTwt.Visible = false;
                    string msg = cbAutentificationTWT.Text == "SQL Server Autentification" ? $"\tИмя пользователя: { tbUserNameTWT.Text}" + "\n" + $"\tПароль: {tbPasswordTWT.Text}" + "\n" : "";
                    Messages.Append("Соединение:" + "\n" +
                                $"\tСервер: {tbServerTWT.Text}" + "\n" +
                                $"\tАутентификация: {cbAutentificationTWT.Text}" + "\n" + msg +
                                $"\tБаза данных: {tbDatabaseTWT.Text}" + "\n" +
                                "установить не удалось");
                    break;
                default:        //все чики-пуки
                    picStatusTWT.Image = global::TimeWorkTracking.Properties.Resources.ok;
                    btCreateDBTwt.Visible = false;
                    Messages.Append("Соединение установлено");
                    break;
            }
            MessageBox.Show(Messages.ToString(),
                            "Подключение к Базе Данных",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Warning);

            Properties.Settings.Default.twtConnectionSrting = statusDB;
            //TimeWorkTracking DataBase
            Properties.Settings.Default.twtServerName = tbServerTWT.Text;
            Properties.Settings.Default.twtDatabase = tbDatabaseTWT.Text;
            Properties.Settings.Default.twtAuthenticationDef = cbAutentificationTWT.Text;
            Properties.Settings.Default.twtLogin = tbUserNameTWT.Text;
            Properties.Settings.Default.twtPassword = tbPasswordTWT.Text;

            Properties.Settings.Default.Save();
        }



        //создать бд
        private void btCreateDBTwt_Click(object sender, EventArgs e)
        {
            string connectionstring = Properties.Settings.Default.twtConnectionSrting;
            if (connectionstring != "" && tbDatabaseTWT.Text != "")
            {
                //   if (MsSqlDatabase.CreateDataBase(connectionstring))
                //   {
                //       btCreateDBTwt.Visible = false;
                //   }
            }
        }
    }
}
