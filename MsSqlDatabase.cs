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
                    sqlCommand.CommandText = "CREATE TABLE UserWorkScheme (" +
                        "Id int PRIMARY KEY IDENTITY, " +
                        "Name NVARCHAR(150) NOT NULL UNIQUE" +                                          //*наименование
                        ")";
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.CommandText = "INSERT INTO UserWorkScheme(Name) VALUES " +
                        "(N'Почасовой'), " +
                        "(N'Поминутный')";
                    sqlCommand.ExecuteNonQuery();

                    //Тип даты производственного календаря (таблица для списка) Выходной/Сокращенный
                    sqlCommand.CommandText = "CREATE TABLE CalendarDateType (" +
                        "Id int PRIMARY KEY IDENTITY, " +
                        "Name NVARCHAR(150) NOT NULL UNIQUE" +                                          //*наименование
                        ")";
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.CommandText = "INSERT INTO CalendarDateType(Name) VALUES " +
                        "(N'Выходной'), " +
                        "(N'Сокращенный')";
                    sqlCommand.ExecuteNonQuery();

                    //Наименование даты производственного календаря (таблица для списка) 
                    sqlCommand.CommandText = "CREATE TABLE CalendarDateName (" +
                        "Id int PRIMARY KEY IDENTITY, " +
                        "Name NVARCHAR(150) NOT NULL UNIQUE, " +                                        //*наименование
                        "Note NVARCHAR(150))";                                                          //расшифровка
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.CommandText = "INSERT INTO CalendarDateName(Name, Note) VALUES " +
                        "(N'Новый год', N'1 января'), " +
                        "(N'Новогодние каникулы', ''), " +
                        "(N'Рождество Христово', N'7 января'), " +
                        "(N'День защитника Отечества', N'23 февраля'), " +
                        "(N'Международный женский день', N'8 марта'), " +
                        "(N'Праздник весны и труда', N'1 мая'), " +
                        "(N'День Победы', N'9 мая'), " +
                        "(N'День России', N'12 июня'), " +
                        "(N'День народного единства', N'4 ноября'), " +
                        "(N'Нерабочие дни', '')";
                    sqlCommand.ExecuteNonQuery();

                    //Подразделение (таблица для списка)
                    sqlCommand.CommandText = "CREATE TABLE UserDepartment (" +
                        "Id int PRIMARY KEY IDENTITY, " +
                        "Name NVARCHAR(150) NOT NULL UNIQUE " +                                         //*наименование
                        ")";
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.CommandText = "INSERT INTO UserDepartment(Name) VALUES " +
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

                    //Должность (таблица для списка)
                    sqlCommand.CommandText = "CREATE TABLE UserPost (" +
                        "Id int PRIMARY KEY IDENTITY, " +
                        "Name NVARCHAR(150) NOT NULL UNIQUE " +                                         //*наименование
                        ")";
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.CommandText = "INSERT INTO UserPost(Name) VALUES " +
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

                    //Специальные отметки (самостоятельная таблица)
                    sqlCommand.CommandText = "CREATE TABLE SpecialMarks (" +
                        "Id int PRIMARY KEY IDENTITY, " +
                        "DigitalCode NVARCHAR(4) NOT NULL, " +                                          //числовой код 
                        "LetterCode NVARCHAR(4) NOT NULL, " +                                           //строковый код
                        "Name NVARCHAR(150) NOT NULL UNIQUE, " +                                        //*наименование
                        "Note NVARCHAR(1024) NULL, " +                                                  //расшифровка
                        "Uses bit NOT NULL " +                                                          //флаг доступа для использования
                        ")";
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.CommandText = "INSERT INTO SpecialMarks(DigitalCode, LetterCode, Name, Note, Uses) VALUES " +
                        "('01', N'Я', N'-', N'Продолжительность работы в дневное время', 1), " +
                        "('02', N'Н', N'Ночные работы', N'Продолжительность работы в ночное время', 0), " +
                        "('03', N'РВ', N'Работа в выходные', N'Продолжительность работы в выходные и нерабочие праздничные дни', 0), " +
                        "('04', N'C', N'Сверхурочная работа', N'Продолжительность сверхурочной работы', 0), " +
                        "('05', N'ВМ', N'Работа на вахте', N'Продолжительность работы вахтовым методом', 0), " +
                        "('06', N'К', N'Служебная командировка', N'Служебная командировка', 0), " +

                        "('09', N'ОТ', N'Отпуск', N'Ежегодный основной оплачиваемый отпуск', 1), " +
                        "('10', N'ОД', N'дополнительный Отпуск', N'Ежегодный дополнительный оплачиваемый отпуск', 0), " +

                        "('14', N'Р', N'Отпуск по беременности и родам', N'Отпуск по беременности и родам (в связи с усыновлением новорожденного ребенка)', 0), " +
                        "('15', N'ОЖ', N'Отпуск по уходу за ребенком', N'Отпуск по уходу за ребенком до достижения им возраста трех лет', 0), " +
                        "('16', N'ДО', N'Отгул', N'Отпуск без сохранения заработной платы, предоставленный работнику по разрешению работодателя', 1), " +

                        "('19', N'Б', N'Больничный с оплатой', N'Временная нетрудоспособность (кроме случаев, предусмотренных кодом «Т») с назначением пособия согласно законодательству', 1), " +
                        "('20', N'Т', N'Больничный без оплаты', N'Временная нетрудоспособность без назначения пособия в случаях, предусмотренных законодательством', 1), " +

                        "('24', N'ПР', N'Прогул', N'Прогулы (отсутствие на рабочем месте без уважительных причин в течение времени, установленного законодательством)', 0), " +
                        "('29', N'ЗБ', N'Забастовка', N'Забастовка (при условиях и в порядке, предусмотренных законом)', 1), " +
                        "('30', N'НН', N'Неявка', N'Неявки по невыясненным причинам (до выяснения обстоятельств)', 0), " +

                        "('00', 'СЗ', N'Служебное задание', '' , 1), " +
                        "('00', 'РД', N'Работа из дома', '', 0), " +
                        "('00', 'ОД', N'Общественное дело', '', 1), " +
                        "('00', 'ЛД', N'Личные дела', '', 1), " +
                        "('00', 'УД', N'Удаленка', '', 1)";
                    sqlCommand.ExecuteNonQuery();

                    //Производственный Календарь (таблица использующая внешние данные)
                    sqlCommand.CommandText = "CREATE TABLE Calendars (" +
                        "Id int PRIMARY KEY IDENTITY, " +
                        "OriginalDate Date NOT NULL UNIQUE, " +                                         //*оригинальная дата
                        "TransferDate Date NOT NULL, " +                                                //реальная дата (перенос)
                        "DateTypeId int NOT NULL FOREIGN KEY REFERENCES CalendarDateType(Id), " +       //->ссылка на тип даты
                        "DateNameId int NOT NULL FOREIGN KEY REFERENCES CalendarDateName(Id) " +        //->ссылка на наименование даты    
                        ")";
                    sqlCommand.ExecuteNonQuery();

                    //Пользователь (таблица использующая внешние данные)
                    sqlCommand.CommandText = "CREATE TABLE Users (" +
                        "Id int PRIMARY KEY IDENTITY, " +
                        "ExchangeKey NVARCHAR(20) NOT NULL UNIQUE, " +                                  //*внешний id для интеграции
                        "Name NVARCHAR(150) NOT NULL UNIQUE, " +                                        //*наименование
                        "DerartmentId int NOT NULL FOREIGN KEY REFERENCES UserDepartment(Id), " +       //->ссылка на департамент
                        "PostId int NOT NULL FOREIGN KEY REFERENCES UserPost(Id), " +                   //->ссылка на должность
                        "TimeStart time, " +                                                            //время начала работы по графику (без даты)    
                        "TimeStop time, " +                                                             //время окончания работы по графику (без даты)
                        "Lunch bit NOT NULL, " +                                                        //флаг признака обеда
                        "WorkSchemeId int NOT NULL FOREIGN KEY REFERENCES UserWorkScheme(Id), " +       //->ссылка на схему работы
                        "Uses bit NOT NULL " +                                                          //флаг доступа для использования
                        ")"; 
                    sqlCommand.ExecuteNonQuery();

                    //Учет рабочего времени (таблица использующая внешние данные)
                    sqlCommand.CommandText = "CREATE TABLE EventsPass (" +
                        "Id bigint PRIMARY KEY IDENTITY, " +
                        "Author NVARCHAR(150) NOT NULL, " +                                             //имя учетной записи сеанса
                        "passDate Date NOT NULL UNIQUE, " +                                             //*дата события (без времени) 
                        "passUserId int NOT NULL UNIQUE FOREIGN KEY REFERENCES Users(ExchangeKey), " +  //*->ссылка на внешний id пользователя
                        "passTimeStart time NOT NULL, " +                                               //время первого входа (без даты)
                        "passTimeStop time NOT NULL, " +                                                //время последнего выхода (без даты)
                        "infoLunchId bit NOT NULL DEFAULT 1, " +                                        //флаг признака обеда
                        "infoWorkSchemeId int NULL FOREIGN KEY REFERENCES UserWorkScheme(Id), " +       //->ссылка на схему работы
                        "timeScheduleFact int NOT NULL  DEFAULT 0, " +                                  //отработанное время (мин)
                        "timeScheduleWithoutLunch int NOT NULL  DEFAULT 0, " +                          //отработанное время без обеда (мин)
                        "timeScheduleLess int NOT NULL DEFAULT 0, " +                                   //время недоработки (мин)
                        "timeScheduleOver int NOT NULL DEFAULT 0, " +                                   //время переработки (мин)
                        "specmarkNameId int NULL FOREIGN KEY REFERENCES SpecialMarks(Id), " +           //->ссылка на специальные отметки
                        "specmarkTimeStart Datetime NULL, " +                                           //датавремя начала действия специальных отметок
                        "specmarkTimeStop Datetime NULL, " +                                            //датавремя окончания специальных отметок
                        "specmarkNote NVARCHAR(1024) NULL, " +                                          //комментарий к специальным отметкам
                        "totalHoursInWork int NOT NULL DEFAULT 0, " +                                   //итог рабочего времени в графике (мин)
                        "totalHoursOutsideWork int NOT NULL DEFAULT 0" +                                //итог рабочего времени вне графика (мин)
                        ")";
                    sqlCommand.ExecuteNonQuery();

                    //UDF (пользовательски функции для ускорения процесса выборки)
                    //возвращает информацию пользователя по внешнему идентификатору   
                    sqlCommand.CommandText = "Create function twt_GetUserInfo(@extUserID varchar(20) = '') " +
                        "Returns table as Return " +
                        "(" +
                        "SELECT " +
                        "u.id id, " + 
                        "u.ExchangeKey extId, " +                                                       //внешний id для интеграции                                                 
                        "u.Name fio, " +                                                                //ФИО           
                        "d.Name department, " +                                                         //департамент пользователя
                        "p.Name post, " +                                                               //должность пользователя
                        "u.TimeStart startT, " +                                                        //время начала работы по графику (без даты)
                        "u.TimeStop stopT, " +                                                          //время окончания работы по графику (без даты)
                        "u.Lunch lunch, " +                                                             //флаг признака обеда   
                        "w.Name work, " +                                                               //схема работы
                        "u.Uses access " +                                                              //флаг доступа для использования
                        "FROM Users u, UserDepartment d, UserPost p, UserWorkScheme w " +
                        "WHERE u.DerartmentId = d.Id AND " +
                        "u.PostId = p.id and " +
                        "u.WorkSchemeId = w.Id and " +
                        "u.ExchangeKey like('%' + @extUserID + '%') " +
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
                /*
                using (var command = sqlConnection.CreateCommand())
                {
                    command.CommandText = $"SELECT db_id('{databaseName}')";
                    return command.ExecuteScalar() != DBNull.Value;
                }
                */
                using (SqlCommand cmd = new SqlCommand($"SELECT db_id('{databaseName}')", sqlConnection)) 
                {
                    return cmd.ExecuteScalar() != DBNull.Value;
                }

            }
        }

        //проверить что и соединение и бд существует
        private static bool FullConnectExists(string connectionString)
        {
            bool ret = false;
            if (connectionString != "")
            {
         //       StringBuilder errorMessages = new StringBuilder();
                var sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
                using (var sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
                {
                    try
                    {
                        sqlConnection.Open();
                        ret = true;
                    }
                    catch (SqlException)
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

        //выполнить запрос на обновление создание и удаление
        // connectionString - строка соединения
        // sqlRequest - запрос
        // errMode - false- не показывать ошибки true- показывать ошибки
        //возврат - количество обработанных строк
        private static int GetRequestNonQuery(string connectionString, string sqlRequest, Boolean errMode)
        {
            int ret = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var sqlCommand = connection.CreateCommand())
                {
                    sqlCommand.CommandText = sqlRequest;
                    try
                    {
                        ret = sqlCommand.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        if (errMode)                        //показывать ошибки или нет
                        {
                        }
                    }
                }
                connection.Close();                         //Close the connection
            }
            return ret;
        }

        //выполнить запрос возвращающий одно значение
        // connectionString - строка соединения
        // sqlRequest - запрос
        // errMode - false- не показывать ошибки true- показывать ошибки
        //возврат - количество обработанных строк
        private static string GetRequesScalar(string connectionString, string sqlRequest, Boolean errMode)
        {
            string ret = "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var sqlCommand = connection.CreateCommand())
                {
                    sqlCommand.CommandText = sqlRequest;
                    try
                    {
                        object result = sqlCommand.ExecuteScalar();
                        if (result != null)
                        {
                            ret = result.ToString();
                        }
                    }
                    catch (SqlException)
                    {
                        if (errMode)                        //показывать ошибки или нет
                        {
                        }
                    }
                }
                connection.Close();                         //Close the connection
            }
            return ret;
        }

        //выполнить запрос и вернуть DataSet
        private static DataTable GetTableRequest(string connectionString, string sqlRequest)
        {
            DataSet ds= new DataSet();  // Создаем объект Dataset
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // Создаем объект DataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter(sqlRequest, connectionString);
                // Создаем объект Dataset
                //DataSet ds = new DataSet();
                
                adapter.Fill(ds);       // Заполняем Dataset
            }
            return ds.Tables[0]; //ds.Tables[tableName];    // Возвращаем первую таблицу из набора Dataset
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
                    //$ - использхование вставки параметров в строку без конкатенации
                    //@ - строка без экранирующих символов
                    sqlCommand.CommandText = $@"
                    ALTER DATABASE {databaseName} SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                    DROP DATABASE [{databaseName}]
                    ";
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }


        //PUBLIC------------------------------------------------------------------------

        //пересоздать БД 
        public static void CreateDataBase(string connectionstring)
        {
            if (DatabaseExists(connectionstring))
            {
                DropDatabase(connectionstring);
            }
            CreateDatabase(connectionstring); 
        }

        //проверить соединение отдельно по соединению (на базе master) и по имени базы в списке баз
        //выдать расшифровку ошибок
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

        //проверить соединение сразу по строке подключения
        //без выдачи ошибок
        public static bool CheckConnectWithConnectionStr(string connectionString)
        {
            return FullConnectExists(connectionString);
        }

        //выполнить запрос и вернуть DataSet
        public static DataTable TableRequest(string connectionString, string sqlRequest)
        {
            return GetTableRequest(connectionString, sqlRequest);
        }

        //выполнить запрос на создание удаление обновление 
        //возврат true или false
        public static bool RequestNonQuery(string connectionString, string sqlRequest, Boolean errMode)
        {
            return GetRequestNonQuery(connectionString, sqlRequest, errMode) > 0;
        }
        //выполнить скалярный запрос и вернуть строку
        public static string RequesScalar(string connectionString, string sqlRequest, Boolean errMode)
        {
            return GetRequesScalar(connectionString, sqlRequest, errMode);
        }

    }
}
