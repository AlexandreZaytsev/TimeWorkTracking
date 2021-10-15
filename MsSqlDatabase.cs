using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace TimeWorkTracking
{
    class MsSqlDatabase
    {
        //пересоздать БД 
        public void Create(string connectionstring)
        {
            if (DatabaseExists(connectionstring))
            {
                DropDatabase(connectionstring);
            }
            CreateDatabase(connectionstring);
        }

        //создать БД по строке подключения
        private static void CreateDatabase(string connectionString)
        {
            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
            var databaseName = sqlConnectionStringBuilder.InitialCatalog;
            sqlConnectionStringBuilder.InitialCatalog = "master";
            using (var sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
            {
                sqlConnection.Open();
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = $"CREATE DATABASE {databaseName}";
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        //проверить что соединение есть в принципе
        private static bool ConnectExists(string connectionString)
        {
            bool ret = false;
            StringBuilder errorMessages = new StringBuilder();
            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
       //     var databaseName = sqlConnectionStringBuilder.InitialCatalog;
            sqlConnectionStringBuilder.InitialCatalog = "master";
            using (var sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
            {
                try
                {
                    sqlConnection.Open();
                    ret = true;
                }
                catch (SqlException ex)
                {
                    for (int i = 0; i < ex.Errors.Count; i++)
                    {
                        errorMessages.Append("Index #" + i + "\n" +
                            "Message: " + ex.Errors[i].Message + "\n" +
                            "Number: " + ex.Errors[i].Number + "\n" +
                            "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                            "Source: " + ex.Errors[i].Source + "\n" +
                            "Procedure: " + ex.Errors[i].Procedure + "\n");
                    }
                    MessageBox.Show(errorMessages.ToString(),
                                   "Подключение к Базе Данных",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                }
                finally
                {
                    if (sqlConnection != null)
                    {
                        sqlConnection.Close();                         //Close the connection
                    }
                }
                return ret;
            }
        }

        //проверить что бд существует
        private static bool DatabaseExists(string connectionString)
        {
            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
            var databaseName = sqlConnectionStringBuilder.InitialCatalog;
            sqlConnectionStringBuilder.InitialCatalog = "master";
            using (var sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
            {
                sqlConnection.Open();
                using (var command = sqlConnection.CreateCommand())
                {
                    command.CommandText = $"SELECT db_id('{databaseName}')";
                    return command.ExecuteScalar() != DBNull.Value;
                }
            }
        }
        //удалить бд
        private static void DropDatabase(string connectionString)
        {
            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
            var databaseName = sqlConnectionStringBuilder.InitialCatalog;
            sqlConnectionStringBuilder.InitialCatalog = "master";
            using (var sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
            {
               sqlConnection.Open();
               using (var sqlCommand = sqlConnection.CreateCommand())
               {
                   sqlCommand.CommandText = $@"
                    ALTER DATABASE {databaseName} SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                    DROP DATABASE [{databaseName}]
                ";
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        public static string GetSqlConnection(string connectionString) 
        {
            if (ConnectExists(connectionString))
            {
                if (DatabaseExists(connectionString))
                    return connectionString;
                else
                    return "-1";
            }
            else
                return "-9";
            
            //string connectionString;
           // StringBuilder errorMessages = new StringBuilder();
            /*
            switch (autehtification)
            {
                case "SQL Server Autentification":
                    connectionString = @"Data Source=" + datasource + ";Initial Catalog=" + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;
                    break;
                case "Windows Autentification":
                    connectionString = @"Data Source=" + datasource + "; Initial Catalog=" + database + "; Integrated Security=True";
                    break;
                default:
                    connectionString="";
                    break;
            }

            string cmdText = "select count(*) from master.dbo.sysdatabases where name=@database";
            */
            /*
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                using (var sqlCmd = new SqlCommand(cmdText, sqlConnection))
                {
                    sqlCmd.Parameters.Add("@database", System.Data.SqlDbType.NVarChar).Value = database;
                    try
                    {
                        sqlConnection.Open();
                        if (Convert.ToInt32(sqlCmd.ExecuteScalar()) == 1)
                            MessageBox.Show(
                                "Соединение установлено" + "\n\n" +
                                "Свойства подключения:" + "\n" +
                                $"\tСтрока подключения: {sqlConnection.ConnectionString}" + "\n" +
                                $"\tБаза данных: {sqlConnection.Database}" + "\n" +
                                $"\tСервер: {sqlConnection.DataSource}" + "\n" +
                                $"\tВерсия сервера: {sqlConnection.ServerVersion}" + "\n" +
                                $"\tСостояние: {sqlConnection.State}" + "\n" +
                                $"\tWorkstationld: {sqlConnection.WorkstationId}",
                                "Подключение к Базе Данных",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        else
                        {
                            MessageBox.Show("База данных с именем:" + "\n" +
                            "'"+database+"'" + "\n" +
                            "не существует на сервере",
                            "Подключение к Базе Данных",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                            connectionString = "-1";
                        }
                    }
                    */
                    /*
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    */
            /*  
            catch (SqlException ex)
                    {
                        for (int i = 0; i < ex.Errors.Count; i++)
                        {
                            //https://docs.microsoft.com/ru-ru/sql/relational-databases/errors-events/database-engine-events-and-errors?view=sql-server-ver15#errors-4000-to-4999
                            errorMessages.Append("Index #" + i + "\n" +
                                "Message: " + ex.Errors[i].Message + "\n" +
                                "Number: " + ex.Errors[i].Number + "\n" +
                                "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                                "Source: " + ex.Errors[i].Source + "\n" +
                                "Procedure: " + ex.Errors[i].Procedure + "\n");
                        }
                        connectionString = "-9";
                        MessageBox.Show(errorMessages.ToString(),
                                       "Подключение к Базе Данных",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                    }
                    finally
                    {
                        if (sqlConnection != null)
                        {
                            sqlConnection.Close();                         //Close the connection
                        }
                    }
            */  
   //         }
     //       }

         



/*

            SqlConnection cn = new SqlConnection();     //Instantiate the connection
            SqlDataReader rdr = null;

            cn.ConnectionString = connectionString;
            try
            {
                cn.Open();                              //Open the connection
                MessageBox.Show("Свойства подключения:" + "\n" +
                                $"\tСтрока подключения: {cn.ConnectionString}" + "\n" +
                                $"\tБаза данных: {cn.Database}" + "\n" +
                                $"\tСервер: {cn.DataSource}" + "\n" +
                                $"\tВерсия сервера: {cn.ServerVersion}" + "\n" +
                                $"\tСостояние: {cn.State}" + "\n" +
                                $"\tWorkstationld: {cn.WorkstationId}",
                                "Подключение к Базе Данных",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                //дополнительная проверка что в БД есть наша база
                var cmd = new SqlCommand();
                cmd.CommandText = "select count(*) from master.dbo.sysdatabases where name=@" + database; 
 */
                /*
                                // 3. Pass the connection to a command object
                                SqlCommand cmd = new SqlCommand("select * from Customers", conn);

                                //
                                // 4. Use the connection
                                //

                                // get query results
                                rdr = cmd.ExecuteReader();

                                // print the CustomerID of each record
                                while (rdr.Read())
                                {
                                    Console.WriteLine(rdr[0]);
                                }
                */
 
     //       return connectionString;
        }
    }
}
