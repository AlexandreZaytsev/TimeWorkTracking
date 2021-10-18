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
                    //График работы (таблица для списка) Почасовой/Поминутный
                    sqlCommand.CommandText = "CREATE TABLE WorkScheme (Id int PRIMARY KEY IDENTITY, Name NVARCHAR(150) NOT NULL UNIQUE)";
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.CommandText = "INSERT INTO WorkScheme(Name) VALUES (N'Почасовой'), (N'Поминутный')";
                    sqlCommand.ExecuteNonQuery();

                    //Тип даты производственного календаря (таблица для списка) Выходной/Сокращенный
                    sqlCommand.CommandText = "CREATE TABLE DateType (Id int PRIMARY KEY IDENTITY, Name NVARCHAR(150) NOT NULL UNIQUE)";
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.CommandText = "INSERT INTO DateType(Name) VALUES (N'Выходной'), (N'Сокращенный')";
                    sqlCommand.ExecuteNonQuery();

                    //Наименование даты производственного календаря (таблица для списка) 
                    sqlCommand.CommandText = "CREATE TABLE DateName (Id int PRIMARY KEY IDENTITY, Name NVARCHAR(150) NOT NULL UNIQUE, Note NVARCHAR(150))";
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.CommandText = "INSERT INTO DateName(Name, Note) VALUES " +
                        "(N'Новый год', '1 января'), " +
                        "(N'Новогодние каникулы', ''), " +
                        "(N'Рождество Христово', '7 января'), " +
                        "(N'День защитника Отечества', '23 февраля'), " +
                        "(N'Международный женский день', '8 марта'), " +
                        "(N'Праздник весны и труда', '1 мая'), " +
                        "(N'День Победы', '9 мая'), " +
                        "(N'День России', '12 июня'), " +
                        "(N'День народного единства', '4 ноября')";
                    sqlCommand.ExecuteNonQuery();

                    //Подразделение (таблица для списка)
                    sqlCommand.CommandText = "CREATE TABLE Department (" +
                        "Id int PRIMARY KEY IDENTITY, " +
                        "ExchangeKey NVARCHAR(20) NOT NULL UNIQUE, " +
                        "Name NVARCHAR(150) NOT NULL UNIQUE " +
                        ")";
                    sqlCommand.ExecuteNonQuery();
/*
                    //вставляем данные
                    sqlCommand.CommandText = "INSERT INTO Department(Name) VALUES " +
                        "(N'Бухгалтерия'), " +
                        "(N'Департамент закупок и договоров'), " +
                        "(N'Департамент маркетинга'), " +
                        "(N'Департамент обеспечения бизнеса'), " +
                        "(N'Департамент продаж'), " +
                        "(N'Департамент Тендерных и Конкурсных поставок'), " +
                        "(N'Департамент технической поддержки'), " +
                        "(N'Департамент ЧПУ'), " +
                        "(N'Общее руководство'), " +
                        "(N'Представительство Академия САПР и ГИС')";
                    sqlCommand.ExecuteNonQuery();
 */ 
                    //Должность (таблица для списка)
                    sqlCommand.CommandText = "CREATE TABLE Post (" +
                        "Id int PRIMARY KEY IDENTITY, " +
                        "ExchangeKey NVARCHAR(20) NOT NULL UNIQUE, " +
                        "Name NVARCHAR(150) NOT NULL UNIQUE " +
                        ")";
                    sqlCommand.ExecuteNonQuery();
/*
                    //вставляем данные
                    sqlCommand.CommandText = "INSERT INTO Post(Name) VALUES " +
                        "(N'Ассистент менеджера'), " +
                        "(N'Бухгалтер'), " +
                        "(N'Ведущий инженер'), " +
                        "(N'Ведущий менеджер'), " +
                        "(N'Главный Бухгалтер'), " +
                        "(N'Дизайнер'), " +
                        "(N'Инженер'), " +
                        "(N'Курьер'), " +
                        "(N'Логист'), " +
                        "(N'Менеджер'), " +
                        "(N'Руководитель'), " +
                        "(N'Руководитель департамента'), " +
                        "(N'Руководитель направления'), " +
                        "(N'Руководитель учебного центра'), " +
                        "(N'Секретарь'), " +
                        "(N'Системный администратор'), " +
                        "(N'Юрист'), " +
                        "(N'Ведущий менеджер отдела продаж'), " +
                        "(N'Заместитель генерального директора'), " +
                        "(N'и.о. Руководителя')";
                    sqlCommand.ExecuteNonQuery();
*/
                    //Специальные отметки (самостоятельная таблица)
                    sqlCommand.CommandText = "CREATE TABLE SpecialMarks (" +
                        "Id int PRIMARY KEY IDENTITY, " +
                        "ExchangeKey NVARCHAR(20) NOT NULL UNIQUE, " +
                        "Name NVARCHAR(150) NOT NULL UNIQUE, " +
                        "ShortNameCode NVARCHAR(4) NOT NULL, " +
                        "ShortName NVARCHAR(4) NOT NULL, " +
                        "Uses bit NOT NULL " +
                        ")";
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.CommandText = "INSERT INTO SpecialMarks(ExchangeKey, Name, ShortNameCode, ShortName, Uses) VALUES " +
                        "(N'20141107083705', '-', 'Я', '01', 1), " +
                        "(N'20141107083706', 'Служебное задание', 'СЗ', '00', 1), " +
                        "(N'20141107083707', 'Работа из дома', 'РД', '00', 0), " +
                        "(N'20141107083708', 'Отпуск', 'ОТ', '09', 1), " +
                        "(N'20141107083709', 'Общественное дело', 'ОД', '00', 1), " +
                        "(N'20141107083710', 'Личные дела', 'ЛД', '00', 1), " +
                        "(N'20141107083711', 'Служебная командировка', 'К', '06', 0), " +
                        "(N'20141107083712', 'Отпуск по беременности и родам', 'Р', '13', 0), " +
                        "(N'20141107083713', 'Отпуск по уходу за ребенком', 'ОЖ', '15', 0), " +
                        "(N'20141107083714', 'Отгул', 'ДО', '16', 1), " +
                        "(N'20141107083715', 'Больничный', 'Б', '19', 1), " +
                        "(N'20141107083716', 'Прогул', 'ПР', '26', 0), " +
                        "(N'20210701135120', 'Удаленка', 'УД', '01', 1)";
                    sqlCommand.ExecuteNonQuery();

                    //Производственный Календарь (таблица использующая внешние данные)
                    sqlCommand.CommandText = "CREATE TABLE ProductionCalendar (" +
                        "Id int PRIMARY KEY IDENTITY, " +
                        "ExchangeKey NVARCHAR(20) NOT NULL UNIQUE, " +
                        "OriginalDate Date NOT NULL UNIQUE, " +
                        "TransferDate Date NOT NULL, " +
                        "DateTypeId int NOT NULL FOREIGN KEY REFERENCES DateType(Id), " +
                        "DateNameId int NOT NULL FOREIGN KEY REFERENCES DateName(Id) " +
                        ")";
                    sqlCommand.ExecuteNonQuery();

                    //Пользователь (таблица использующая внешние данные)
                    sqlCommand.CommandText = "CREATE TABLE Users (" +
                        "Id int PRIMARY KEY IDENTITY, " +
                        "ExchangeKey NVARCHAR(20) NOT NULL UNIQUE, " +
                        "Name NVARCHAR(150) NOT NULL UNIQUE, " +
                        "DerartmentId int NOT NULL FOREIGN KEY REFERENCES Department(Id), " +
                        "PostId int NOT NULL FOREIGN KEY REFERENCES Post(Id), " +
                        "TimeStart time NOT NULL, " +
                        "TimeStop time NOT NULL, " +
                        "Lunch bit NOT NULL, " +
                        "WorkSchemeId int NOT NULL FOREIGN KEY REFERENCES WorkScheme(Id), " +
                        "Uses bit NOT NULL " +
                        ")"; 
                    sqlCommand.ExecuteNonQuery();

                    //Учет рабочего времени (таблица использующая внешние данные)
                    sqlCommand.CommandText = "CREATE TABLE PassEvents (" +
                        "Id bigint PRIMARY KEY IDENTITY, " +
                        "Author NVARCHAR(150) NOT NULL, " +
                        "passDate Date NOT NULL UNIQUE, " +
                        "passUserId int NOT NULL UNIQUE FOREIGN KEY REFERENCES Users(Id), " +
                        "passTimeStart time NOT NULL, " +
                        "passTimeStop time NOT NULL, " +
                        "infoLunchId bit NOT NULL DEFAULT 1, " +
                        "infoWorkSchemeId int NULL FOREIGN KEY REFERENCES WorkScheme(Id), " +
                        "timeScheduleFact int NOT NULL  DEFAULT 0, " +
                        "timeScheduleWithoutLunch int NOT NULL  DEFAULT 0, " +
                        "timeScheduleLess int NOT NULL DEFAULT 0, " +
                        "timeScheduleOver int NOT NULL DEFAULT 0, " +
                        "specmarkNameId int NULL UNIQUE FOREIGN KEY REFERENCES SpecialMarks(Id), " +
                        "specmarkTimeStart Datetime NULL, " +
                        "specmarkTimeStop Datetime NULL, " +
                        "specmarkNote NVARCHAR(1024) NULL, " +
                        "totalHoursInWork int NOT NULL DEFAULT 0, " +
                        "totalHoursOutsideWork int NOT NULL DEFAULT 0" +
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
