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
                sqlConnection.Close();
            }
            InitDataBase(connectionString);
        }
        //инициализировать БД по строке подключения
        private static void InitDataBase(string connectionString)
        { 
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
        //СТРУКТУРА ДАННЫХ
        //выпадающие списки
                    //График работы (таблица для списка) Почасовой/Поминутный
                    sqlCommand.CommandText = "CREATE TABLE UserWorkScheme (" +
                        "id int PRIMARY KEY IDENTITY, " +
                        "name VARCHAR(150) NOT NULL UNIQUE, " +                                     //*наименование
                        "uses bit DEFAULT 1 " +                                                     //флаг доступа для использования
                        ")";
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.CommandText = "INSERT INTO UserWorkScheme(name) VALUES " +
                        "(N'Почасовой'), " +
                        "(N'Поминутный')";
                    sqlCommand.ExecuteNonQuery();

                    //Тип даты производственного календаря (таблица для списка) Выходной/Сокращенный
                    sqlCommand.CommandText = "CREATE TABLE CalendarDateType (" +
                        "id int PRIMARY KEY IDENTITY, " +
                        "name VARCHAR(150) NOT NULL UNIQUE, " +                                     //*наименование
                        "uses bit DEFAULT 1 " +                                                     //флаг доступа для использования
                        ")";
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.CommandText = "INSERT INTO CalendarDateType(name) VALUES " +
                        "(N'Полный'), " +
                        "(N'Сокращенный')";
                    sqlCommand.ExecuteNonQuery();

                    //Наименование даты производственного календаря (таблица для списка) 
                    sqlCommand.CommandText = "CREATE TABLE CalendarDateName (" +
                        "id int PRIMARY KEY IDENTITY, " +
                        "name VARCHAR(150) NOT NULL UNIQUE, " +                                     //*наименование
                        "date Date NULL, " +                                                        //дата (год не учитываем)            
                        "uses bit DEFAULT 1 " +                                                     //флаг доступа для использования
                        ")";                                                        
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.CommandText = "INSERT INTO CalendarDateName(name, date) VALUES " +
                        "(N'Новый год', '2000.01.01'), " +
                        "(N'Новогодние каникулы', NULL), " +
                        "(N'Рождество Христово', '2000.01.07'), " +
                        "(N'День защитника Отечества', '2000.02.23'), " +
                        "(N'Международный женский день', '2000.03.08'), " +
                        "(N'Праздник весны и труда', '2000.05.01'), " +
                        "(N'День Победы', '2000.05.09'), " +
                        "(N'День России', '2000.06.12'), " +
                        "(N'День народного единства', '2000.11.04'), " +
                        "(N'Нерабочие дни', NULL), " +
                        "(N'Сокращенные дни', NULL)";
                    sqlCommand.ExecuteNonQuery();

                    //Подразделение (таблица для списка)
                    sqlCommand.CommandText = "CREATE TABLE UserDepartment (" +
                        "id int PRIMARY KEY IDENTITY, " +
                        "name VARCHAR(150) NOT NULL UNIQUE, " +                                     //*наименование
                        "uses bit DEFAULT 1 " +                                                     //флаг доступа для использования
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
                        "name VARCHAR(150) NOT NULL UNIQUE, " +                                     //*наименование
                        "uses bit DEFAULT 1 " +                                                     //флаг доступа для использования
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
                        "digitalCode VARCHAR(4) NOT NULL, " +                                       //числовой код 
                        "letterCode VARCHAR(4) NOT NULL, " +                                        //строковый код
                        "name VARCHAR(150) NOT NULL UNIQUE, " +                                     //*наименование
                        "note VARCHAR(1024) NULL, " +                                               //расшифровка
                        "uses bit DEFAULT 1 " +                                                     //флаг доступа для использования
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

                    //таблицы
                    //Производственный Календарь (таблица использующая внешние данные)
                    sqlCommand.CommandText = "CREATE TABLE Calendars (" +
                        "id int PRIMARY KEY IDENTITY, " +
                        "originalDate Date NOT NULL , " +                                           //оригинальная дата
                        "transferDate Date NOT NULL UNIQUE, " +                                     //*реальная дата (перенос)
                        "dateTypeId int NOT NULL FOREIGN KEY REFERENCES CalendarDateType(id), " +   //->ссылка на тип даты
                        "dateNameId int NOT NULL FOREIGN KEY REFERENCES CalendarDateName(id), " +   //->ссылка на наименование даты
                        "uses bit DEFAULT 1 " +                                                     //флаг доступа для использования
                        ")";
                    sqlCommand.ExecuteNonQuery();

                    //Пользователь (таблица использующая внешние данные)
                    sqlCommand.CommandText = "CREATE TABLE Users (" +
                        "id int PRIMARY KEY IDENTITY, " +
                        "extId VARCHAR(20) NOT NULL UNIQUE, " +                                     //*внешний id для интеграции
                        "crmId NUMERIC DEFAULT 0, " +                                               //внешний id для интеграции с crm
                        "name VARCHAR(150) NOT NULL UNIQUE, " +                                     //*наименование
                        "note VARCHAR(1024) NULL, " +                                               //расшифровка
                        "departmentId int NOT NULL FOREIGN KEY REFERENCES UserDepartment(id), " +   //->ссылка на департамент
                        "postId int NOT NULL FOREIGN KEY REFERENCES UserPost(id), " +               //->ссылка на должность
                        "timeStart time NULL, " +                                                   //время начала работы по графику (без даты)    
                        "timeStop time NULL, " +                                                    //время окончания работы по графику (без даты)
                        "noLunch bit DEFAULT 1, " +                                                 //флаг признака обеда
                        "workSchemeId int NOT NULL FOREIGN KEY REFERENCES UserWorkScheme(id), " +   //->ссылка на схему работы
                        "uses bit DEFAULT 1 " +                                                     //флаг доступа для использования
                        ")";
                    sqlCommand.ExecuteNonQuery();

                    //Учет рабочего времени (таблица использующая внешние данные)
                    sqlCommand.CommandText = "CREATE TABLE EventsPass (" +
                        "id bigint PRIMARY KEY IDENTITY, " +
                        "author VARCHAR(150) NOT NULL, " +                                          //имя учетной записи сеанса
                        "passDate Date NOT NULL, " +                                                //*дата события (без времени) 
                        "passId VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES Users(extId), " +       //*->ссылка на внешний id пользователя
                        "passTimeStart time NOT NULL, " +                                           //время первого входа (без даты)
                        "passTimeStop time NOT NULL, " +                                            //время последнего выхода (без даты)
                        "infoLunchId bit DEFAULT 1, " +                                             //флаг признака обеда
                        "infoWorkSchemeId int NULL FOREIGN KEY REFERENCES UserWorkScheme(id), " +   //->ссылка на схему работы
                        "timeScheduleFact int DEFAULT 0, " +                                        //отработанное время (мин)
                        "timeScheduleWithoutLunch int DEFAULT 0, " +                                //отработанное время без обеда (мин)
                        "timeScheduleLess int DEFAULT 0, " +                                        //время недоработки (мин)
                        "timeScheduleOver int DEFAULT 0, " +                                        //время переработки (мин)
                        "specmarkId int NOT NULL FOREIGN KEY REFERENCES SpecialMarks(id), " +       //->ссылка на специальные отметки
                        "specmarkTimeStart Datetime NULL, " +                                       //датавремя начала действия специальных отметок
                        "specmarkTimeStop Datetime NULL, " +                                        //датавремя окончания специальных отметок
                        "specmarkNote VARCHAR(1024) NULL, " +                                       //комментарий к специальным отметкам
                        "totalHoursInWork int DEFAULT 0, " +                                        //итог рабочего времени в графике (мин)
                        "totalHoursOutsideWork int DEFAULT 0" +                                     //итог рабочего времени вне графика (мин)
                        "UNIQUE(passDate, passId) " +                                               //уникальность на уровне таблицы
                        ")";
                    sqlCommand.ExecuteNonQuery();

                    //UDF (пользовательски функции для ускорения процесса выборки)
                    sqlCommand.CommandText = "Create function twt_GetDateInfo\r\n(\r\n@Name varchar(20) = '', \r\n@Date varchar(4) = ''\r\n)" +
                        "\r\n/*" +
                        "\r\n возвращает информацию о дате" + 
                        "\r\n   по части (like) наименования" +
                        "\r\n   или по дате без года (4 символа в формате MMDD) с ведущими нулями" +
                        "\r\n*/" +
                        "\r\nReturns table as Return " +
                        "\r\n(" +
                        "\r\nSelect " +
                        "\r\n  c.id id, " +
                        "\r\n  c.transferDate dWork, " +                                            //рабочая дата (перенос или исходная)
                        "\r\n  c.originalDate dSource, " +                                          //исходная дата
                        "\r\n  n.name name, " +                                                     //наименование дня
                        "\r\n  t.name dType, " +                                                    //тип дня (полный/сокращенный)
                        "\r\n  c.uses access " +                                                    //флаг доступа для использования
                        "\r\nFrom Calendars c, CalendarDateName n, CalendarDateType t " +
                        "\r\nWhere c.dateNameId = n.id " +
                        "\r\n  and c.dateTypeId = t.id " +
                        "\r\n  and (len(n.name)>0 and n.name like('%' + @Name + '%')) " +
                        "\r\n  or (not c.originalDate IS NULL and right(CONVERT(varchar(8), c.originalDate, 112),4) = @Date) " +
                        "\r\n)";
                    sqlCommand.ExecuteNonQuery();

                    sqlCommand.CommandText = "Create function twt_GetUserInfo\r\n(\r\n@extUserID varchar(20) = ''\r\n)" +
                        "\r\n/*" +
                        "\r\n возвращает информацию о сотруднике по внешнему идентификатору" +
                        "\r\n   по части (like) наименования" +
                        "\r\n*/" +
                        "\r\nReturns table as Return " +
                        "\r\n(" +
                        "\r\nSelect " +
                        "\r\n  u.id id, " +
                        "\r\n  u.extId extId, " +                                                   //внешний id для интеграции с СКУД                                                 
                        "\r\n  u.crmId crmId, " +                                                   //внешний id для интеграции с CRM                                                 
                        "\r\n  u.name fio, " +                                                      //ФИО           
                        "\r\n  u.note note, " +                                                     //комментарий           
                        "\r\n  d.name department, " +                                               //департамент пользователя
                        "\r\n  p.name post, " +                                                     //должность пользователя
                        "\r\n  u.timeStart startTime, " +                                           //время начала работы по графику (без даты)
                        "\r\n  u.timeStop stopTime, " +                                             //время окончания работы по графику (без даты)
                        "\r\n  u.noLunch noLunch, " +                                               //флаг признака обеда   
                        "\r\n  w.name work, " +                                                     //схема работы
                        "\r\n  u.uses access " +                                                    //флаг доступа для использования
                        "\r\nFrom Users u, UserDepartment d, UserPost p, UserWorkScheme w " +
                        "\r\nWhere u.departmentId = d.Id AND " +
                        "\r\n  u.postId = p.id and " +
                        "\r\n  u.workSchemeId = w.Id and " +
                        "\r\n  u.extId like('%' + @extUserID + '%') " +
                        "\r\n)";
                    sqlCommand.ExecuteNonQuery();

                    sqlCommand.CommandText = "Create function twt_GetPassFormData\r\n(\r\n@bDate datetime, \r\n@extUserID varchar(20) = ''\r\n)" +
                        "\r\n/*" +
                        "\r\n возвращает данные для формы регистрации по запрашиваемой дате и активным пользователям" +
                        "\r\n   - если пользователь есть в истории проходов - время из истории (таблица EventsPass)" +
                        "\r\n   - если пользователя нет в истории проходов - время из рабочего графика (таблица Users)" +
                        "\r\n*/" +
                        "\r\nReturns table as Return " +
                        "\r\nSelect " +
                        "\r\n  e.passDate, "+
                        "\r\n  u.extId "+
                        "\r\nFrom " +
                        "\r\n  (Select * from Users where uses = 1 ) as u " +
                        "\r\n  left join " +
                        "\r\n  (Select * from EventsPass where passDate = cast('2021/01/02' as date)) as e " +
                        "\r\n  on u.ExtId = e.passId";
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
