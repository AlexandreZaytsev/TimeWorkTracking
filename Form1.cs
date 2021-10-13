using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
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
            tbServerTWT.Text = Properties.Settings.Default.twtServerName;
            tbDatabaseTWT.Text = Properties.Settings.Default.twtDatabase;
            cbAutentificationTWT.DataSource = Properties.Settings.Default.twtAuthentication;
            cbAutentificationTWT.SelectedItem = Properties.Settings.Default.twtAuthenticationDef;
            tbUserNameTWT.Text = Properties.Settings.Default.twtLogin;
            tbPasswordTWT.Text = Properties.Settings.Default.twtPassword;
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

            str = "CREATE DATABASE MyDatabase ON PRIMARY " +
             "(NAME = TimeWorkTracking_dt, " +
             "FILENAME = 'C:\\MyDatabaseData.mdf', " +
             "SIZE = 2MB, MAXSIZE = 10MB, FILEGROWTH = 10%)" +
             "LOG ON (NAME = MyDatabase_Log, " +
             "FILENAME = 'C:\\MyDatabaseLog.ldf', " +
             "SIZE = 1MB, " +
             "MAXSIZE = 5MB, " +
             "FILEGROWTH = 10%)";

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

        private void button4_Click_1(object sender, EventArgs e)
        {
            var ch = CheckDatabase("TimeWorkTracking");
        }

        private void tabRegistration_Click(object sender, EventArgs e)
        {

        }
//events
        private void cbAutentificationTWT_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool auth = cbAutentificationTWT.Text== "SQL Server Autentification" ? true : false;
            tbUserNameTWT.Enabled = auth;
            tbPasswordTWT.Enabled = auth;
        }

//test Connrection TWT (TimeWorkTracking database )
        private void btTestConnectionTwt_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.twtServerName= tbServerTWT.Text;
            Properties.Settings.Default.twtDatabase= tbDatabaseTWT.Text;
            Properties.Settings.Default.twtAuthenticationDef= cbAutentificationTWT.SelectedText;
            Properties.Settings.Default.twtLogin= tbUserNameTWT.Text;
            Properties.Settings.Default.twtPassword= tbPasswordTWT.Text;

            Properties.Settings.Default.Save();
        }

    }
}
