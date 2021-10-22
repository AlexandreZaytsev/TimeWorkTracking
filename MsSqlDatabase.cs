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
                        "id int PRIMARY KEY IDENTITY, " +
                        "name NVARCHAR(150) NOT NULL UNIQUE" +                                          //*наименование
                        ")";
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.CommandText = "INSERT INTO UserWorkScheme(name) VALUES " +
                        "(N'Почасовой'), " +
                        "(N'Поминутный')";
                    sqlCommand.ExecuteNonQuery();

                    //Тип даты производственного календаря (таблица для списка) Выходной/Сокращенный
                    sqlCommand.CommandText = "CREATE TABLE CalendarDateType (" +
                        "id int PRIMARY KEY IDENTITY, " +
                        "name NVARCHAR(150) NOT NULL UNIQUE" +                                          //*наименование
                        ")";
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.CommandText = "INSERT INTO CalendarDateType(name) VALUES " +
                        "(N'Выходной'), " +
                        "(N'Сокращенный')";
                    sqlCommand.ExecuteNonQuery();

                    //Наименование даты производственного календаря (таблица для списка) 
                    sqlCommand.CommandText = "CREATE TABLE CalendarDateName (" +
                        "id int PRIMARY KEY IDENTITY, " +
                        "name NVARCHAR(150) NOT NULL UNIQUE, " +                                        //*наименование
                        "note NVARCHAR(150))";                                                          //расшифровка
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.CommandText = "INSERT INTO CalendarDateName(name, note) VALUES " +
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
                        "id int PRIMARY KEY IDENTITY, " +
                        "name NVARCHAR(150) NOT NULL UNIQUE " +                                         //*наименование
                        ")";
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.CommandText = "INSERT INTO UserDepartment(name) VALUES " +
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
                        "id int PRIMARY KEY IDENTITY, " +
                        "name NVARCHAR(150) NOT NULL UNIQUE " +                                         //*наименование
                        ")";
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.CommandText = "INSERT INTO UserPost(name) VALUES " +
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
                        "id int PRIMARY KEY IDENTITY, " +
                        "digitalCode NVARCHAR(4) NOT NULL, " +                                          //числовой код 
                        "letterCode NVARCHAR(4) NOT NULL, " +                                           //строковый код
                        "name NVARCHAR(150) NOT NULL UNIQUE, " +                                        //*наименование
                        "note NVARCHAR(1024) NULL, " +                                                  //расшифровка
                        "uses bit NOT NULL " +                                                          //флаг доступа для использования
                        ")";
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.CommandText = "INSERT INTO SpecialMarks(digitalCode, letterCode, name, note, uses) VALUES " +
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
                        "id int PRIMARY KEY IDENTITY, " +
                        "originalDate Date NOT NULL UNIQUE, " +                                         //*оригинальная дата
                        "transferDate Date NOT NULL, " +                                                //реальная дата (перенос)
                        "dateTypeId int NOT NULL FOREIGN KEY REFERENCES CalendarDateType(id), " +       //->ссылка на тип даты
                        "dateNameId int NOT NULL FOREIGN KEY REFERENCES CalendarDateName(id) " +        //->ссылка на наименование даты    
                        ")";
                    sqlCommand.ExecuteNonQuery();

                    //Пользователь (таблица использующая внешние данные)
                    sqlCommand.CommandText = "CREATE TABLE Users (" +
                        "id int PRIMARY KEY IDENTITY, " +
                        "extId NVARCHAR(20) NOT NULL UNIQUE, " +                                        //*внешний id для интеграции
                        "name NVARCHAR(150) NOT NULL UNIQUE, " +                                        //*наименование
                        "departmentId int NOT NULL FOREIGN KEY REFERENCES UserDepartment(id), " +       //->ссылка на департамент
                        "postId int NOT NULL FOREIGN KEY REFERENCES UserPost(id), " +                   //->ссылка на должность
                        "timeStart time NULL, " +                                                       //время начала работы по графику (без даты)    
                        "timeStop time NULL, " +                                                        //время окончания работы по графику (без даты)
                        "lunch bit DEFAULT 1, " +                                                       //флаг признака обеда
                        "workSchemeId int NOT NULL FOREIGN KEY REFERENCES UserWorkScheme(id), " +       //->ссылка на схему работы
                        "uses bit DEFAULT 1 " +                                                         //флаг доступа для использования
                        ")"; 
                    sqlCommand.ExecuteNonQuery();

                    //Учет рабочего времени (таблица использующая внешние данные)
                    sqlCommand.CommandText = "CREATE TABLE EventsPass (" +
                        "id bigint PRIMARY KEY IDENTITY, " +
                        "author NVARCHAR(150) NOT NULL, " +                                             //имя учетной записи сеанса
                        "passDate Date NOT NULL, " +                                                    //*дата события (без времени) 
                        "passId NVARCHAR(20) NOT NULL FOREIGN KEY REFERENCES Users(extId), " +          //*->ссылка на внешний id пользователя
                        "passTimeStart time NOT NULL, " +                                               //время первого входа (без даты)
                        "passTimeStop time NOT NULL, " +                                                //время последнего выхода (без даты)
                        "infoLunchId bit DEFAULT 1, " +                                                 //флаг признака обеда
                        "infoWorkSchemeId int NULL FOREIGN KEY REFERENCES UserWorkScheme(id), " +       //->ссылка на схему работы
                        "timeScheduleFact int DEFAULT 0, " +                                            //отработанное время (мин)
                        "timeScheduleWithoutLunch int DEFAULT 0, " +                                    //отработанное время без обеда (мин)
                        "timeScheduleLess int DEFAULT 0, " +                                            //время недоработки (мин)
                        "timeScheduleOver int DEFAULT 0, " +                                            //время переработки (мин)
                        "specmarkId int NOT NULL FOREIGN KEY REFERENCES SpecialMarks(id), " +           //->ссылка на специальные отметки
                        "specmarkTimeStart Datetime NULL, " +                                           //датавремя начала действия специальных отметок
                        "specmarkTimeStop Datetime NULL, " +                                            //датавремя окончания специальных отметок
                        "specmarkNote NVARCHAR(1024) NULL, " +                                          //комментарий к специальным отметкам
                        "totalHoursInWork int DEFAULT 0, " +                                            //итог рабочего времени в графике (мин)
                        "totalHoursOutsideWork int DEFAULT 0" +                                         //итог рабочего времени вне графика (мин)
                        "UNIQUE(passDate, passId) " +                                                   //уникальность на уровне таблицы
                        ")";
                    sqlCommand.ExecuteNonQuery();

                    //UDF (пользовательски функции для ускорения процесса выборки)
                    //возвращает информацию пользователя по внешнему идентификатору   
                    sqlCommand.CommandText = "Create function twt_GetUserInfo(@extUserID varchar(20) = '') " +
                        "Returns table as Return " +
                        "(" +
                        "SELECT " +
                            "u.id id, " +
                            "u.extId extId, " +                                                         //внешний id для интеграции                                                 
                            "u.name fio, " +                                                            //ФИО           
                            "d.name department, " +                                                     //департамент пользователя
                            "p.name post, " +                                                           //должность пользователя
                            "u.timeStart startT, " +                                                    //время начала работы по графику (без даты)
                            "u.timeStop stopT, " +                                                      //время окончания работы по графику (без даты)
                            "u.lunch lunch, " +                                                         //флаг признака обеда   
                            "w.name work, " +                                                           //схема работы
                            "u.uses access " +                                                          //флаг доступа для использования
                        "FROM Users u, UserDepartment d, UserPost p, UserWorkScheme w " +
                        "WHERE u.departmentId = d.Id AND " +
                            "u.postId = p.id and " +
                            "u.workSchemeId = w.Id and " +
                            "u.extId like('%' + @extUserID + '%') " +
                        ")";
                    sqlCommand.ExecuteNonQuery();

                    //возвращает данные для формы регистрации по запрашиваемой дате и активным пользователям
                    // - если пользователь есть в истории проходов - время из истории (таблица EventsPass)
                    // - если пользователя нет в истории проходов - время из рабочего графика (таблица Users)
                    sqlCommand.CommandText = "Create function twt_GetPassFormData(@bDate datetime, @extUserID varchar(20) = '') " +
                        "Returns table as Return " +
                        "Select " +
                            "e.passDate, "+
                            "u.extId "+
                        "From " +
                            "(Select * from Users where uses = 1 ) as u " +
                            "left join " +
                            "(Select * from EventsPass where passDate = cast('2021/01/02' as date)) as e " +
                            "on u.ExtId = e.passId";
                    sqlCommand.ExecuteNonQuery(); 

                    /*
                     --select * from twt_GetUserInfo('')
select * from Users
select * from EventsPass --where passDate=convert(date,'01/01/2021 00:00:00',104)

select 
*
 -- e.passDate,
 -- u.extId
 from 
 (Select * from Users where uses=1 ) as u 
 left join 
 (Select * from EventsPass where passDate=cast('2021/01/02' as date)) as e
 on u.ExtId=e.passId* 
                     */


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
