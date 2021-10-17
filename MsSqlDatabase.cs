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
        //создать БД по строке подключения
        private static void CreateDatabase(string connectionString)
        {
            //https://metanit.com/sharp/adonetcore/2.4.php
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
            sqlConnectionStringBuilder.InitialCatalog = databaseName;
            using (var sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
            {
                sqlConnection.Open();
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = "CREATE TABLE Users (" +
                        "Id INT PRIMARY KEY IDENTITY, " +
                        "Age INT NOT NULL, " +
                        "Name NVARCHAR(100) NOT NULL" +
                        ")";
                    sqlCommand.ExecuteNonQuery();
                }
            }

        }

        //проверить что соединение есть в принципе на базе master
        private static bool ConnectExists(string connectionString)
        {
            bool ret = false;
            StringBuilder errorMessages = new StringBuilder();
            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString)
            {
                //     var databaseName = sqlConnectionStringBuilder.InitialCatalog;
                InitialCatalog = "master"
            };
            using (var sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
            {
                try
                {
                    sqlConnection.Open();
                    ret = true;
                }
                catch (SqlException ex)
                {
                    //https://docs.microsoft.com/ru-ru/sql/relational-databases/errors-events/database-engine-events-and-errors?view=sql-server-ver15#errors-4000-to-4999
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

        //PUBLIC


        //пересоздать БД 
        public static void CreateDataBase(string connectionstring)
        {
            if (DatabaseExists(connectionstring))
            {
                DropDatabase(connectionstring);
            }
            CreateDatabase(connectionstring); 
        }
        public static string GetSqlConnection(string connectionString) 
        {
            if (ConnectExists(connectionString))
            {
                if (DatabaseExists(connectionString))
                    return connectionString;
                else
                    return "-1";        //база данных не существует
            }
            else
                return "-9";            //соединение установить не удалось
        }

        //проверить соединение по строке подключения
        public static bool CheckConnectWithConnectionStr(string connectionString)
        {
            bool ret = false;
            if (connectionString != "")
            {
                StringBuilder errorMessages = new StringBuilder();
                var sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
                using (var sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
                {
                    try
                    {
                        sqlConnection.Open();
                        ret = true;
                    }
                    catch (SqlException ex)
                    { }
                    finally
                    {
                        if (sqlConnection != null)
                        {
                            sqlConnection.Close();                         //Close the connection
                        }
                    }
                }
            }
            return ret;
        }
    }
}
