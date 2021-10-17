﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //For SQL Connection

namespace TimeWorkTracking
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            //подписка события внешних форм 
            CallBack_FrmDataBaseSQL_outEvent.callbackEventHandler = new CallBack_FrmDataBaseSQL_outEvent.callbackEvent(this.CallbackReload);    //subscribe (listen) to the general notification
            CallBack_FrmDataBasePACS_outEvent.callbackEventHandler = new CallBack_FrmDataBasePACS_outEvent.callbackEvent(this.CallbackReload);    //subscribe (listen) to the general notification

            InitializeComponent();
        }
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;

        void GetList()
        {
            con = new SqlConnection(@"Data Source=.\SQLEXPRESS; Initial Catalog=TimeWorkTracking; Integrated Security=True");
            da = new SqlDataAdapter("Select *From Student", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Student");
            dataGridView1.DataSource = ds.Tables["Student"];
            con.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //  GetList();
            CheckConnects();           //проверить соединение с базами

        }

        private void button1_Click(object sender, EventArgs e) //insert
        {
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "insert into Student(ID,FirstName,LastName) values (" + textBox1.Text + ",'" + textBox2.Text + "','" + textBox3.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            GetList();
        }

        private void button2_Click(object sender, EventArgs e) //update
        {
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "update Student set FirstName='" + textBox2.Text + "',LastName='" + textBox3.Text + "' where ID=" + textBox1.Text + "";
            cmd.ExecuteNonQuery();
            con.Close();
            GetList();
        }

        private void button3_Click(object sender, EventArgs e) //delete
        {
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "delete from Student where ID=" + textBox1.Text + "";
            cmd.ExecuteNonQuery();
            con.Close();
            GetList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String str;
            SqlConnection myConn = new SqlConnection("Server=localhost;Integrated security=SSPI;database=master");
/*
            str = "CREATE DATABASE MyDatabase ON PRIMARY " +
             "(NAME = TimeWorkTracking_dt, " +
             "FILENAME = 'C:\\MyDatabaseData.mdf', " +
             "SIZE = 2MB, MAXSIZE = 10MB, FILEGROWTH = 10%)" +
             "LOG ON (NAME = MyDatabase_Log, " +
             "FILENAME = 'C:\\MyDatabaseLog.ldf', " +
             "SIZE = 1MB, " +
             "MAXSIZE = 5MB, " +
             "FILEGROWTH = 10%)";
*/
            str = "CREATE DATABASE TimeWorkTracking_dt";

            SqlCommand myCommand = new SqlCommand(str, myConn);
            try
            {
                myConn.Open();
                myCommand.ExecuteNonQuery();
                MessageBox.Show("DataBase is Created Successfully", "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
        }

        static private string GetConnectionString()
        {
            // To avoid storing the connection string in your code,
            // you can retrieve it from a configuration file.
            return "Data Source=localost;Initial Catalog=TimeWorkTracking;"
                + "Integrated Security=true;";
        }



        // No point of passing a bool if all you do is return it...
        private bool CheckDatabase(string databaseName)
        {
            // You know it's a string, use var
            //            var connString = "Server=localhost\\SQLEXPRESS;Integrated Security=SSPI;database=master";
            var connString=@"Data Source=.\SQLEXPRESS; Initial Catalog=TimeWorkTracking; Integrated Security=True";
          //  var sqlConnection1 = new SqlConnection("Data Source=localhost; Integrated Security=SSPI; Initial Catalog=TimeWorkTracking;");
          //  sqlConnection1.Open();


            // Note: It's better to take the connection string from the config file.

            var cmdText = "select count(*) from master.dbo.sysdatabases where name=@database";

            using (var sqlConnection = new SqlConnection(connString))
            {
                using (var sqlCmd = new SqlCommand(cmdText, sqlConnection))
                {
                    // Use parameters to protect against Sql Injection
                    sqlCmd.Parameters.Add("@database", System.Data.SqlDbType.NVarChar).Value = databaseName;

                    // Open the connection as late as possible
                    sqlConnection.Open();
                    // count(*) will always return an int, so it's safe to use Convert.ToInt32
                    return Convert.ToInt32(sqlCmd.ExecuteScalar()) == 1;
                }
            }

        }


        private void connect_db_Click(object sender, EventArgs e)
        {

/*
            using Microsoft.Data.ConnectionUI;

            DataConnectionDialog dcd = new Microsoft.Data.ConnectionUI.DataConnectionDialog();
            DataSource.AddStandardDataSources(dcd);
            if (DataConnectionDialog.Show(dcd) == DialogResult.OK)
            {
                string cons = dcd.ConnectionString;
            }
*/



            string connectionString = GetConnectionString();

                using (SqlConnection connection = new SqlConnection())
                {
                    connection.ConnectionString = connectionString;

                    connection.Open();

                    Console.WriteLine("State: {0}", connection.State);
                    Console.WriteLine("ConnectionString: {0}",
                        connection.ConnectionString);
                }




        }



        private void tabRegistration_Click(object sender, EventArgs e)
        {

        }
//events





/*
        private void picSetting_MouseUp(object sender, MouseEventArgs e)
        {
           picSetting.BackColor= System.Drawing.SystemColors.Control;
        }

        private void picSetting_MouseDown(object sender, MouseEventArgs e)
        {
            picSetting.BackColor = System.Drawing.SystemColors.ControlDark;
        }
*/
        //кнока help
        private void frmMain_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            frmAbout aboutBox = new frmAbout();
            aboutBox.ShowDialog(this);
        }

        private void tsbtDataBaseSQL_ButtonClick(object sender, EventArgs e)
        {
            frmDataBaseSQL frm = new frmDataBaseSQL();
            frm.Owner = this;
            CallBack_FrmMain_outEvent.callbackEventHandler("", "", null);  //send a general notification
            frm.ShowDialog();
        }

        private void tsbtDataBasePACS_Click(object sender, EventArgs e)
        {
            frmDataBasePACS frm = new frmDataBasePACS();
            frm.Owner = this;
            CallBack_FrmMain_outEvent.callbackEventHandler("", "", null);  //send a general notification
            frm.ShowDialog();
        }

        //проверить соединение с базами
        private void CheckConnects()
        {
            if (MsSqlDatabase.CheckConnectWithConnectionStr(Properties.Settings.Default.twtConnectionSrting))
                this.tsbtDataBaseSQL.Image = Properties.Resources.ok;
            else
                this.tsbtDataBaseSQL.Image = Properties.Resources.no;
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
            CheckConnects();        //проверить соединение с базами
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
    public static class CallBack_FrmMain_outEvent
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