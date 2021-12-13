using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace TimeWorkTracking
{
    class clMsSqlDatabase
    {
        #region //Private

        #region //Подключения и проверки

        /// <summary>
        /// проверить что соединение есть в принципе на базе master
        /// </summary>
        /// <param name="connectionString">строка соединения</param>
        /// <returns></returns>
        private static bool CheckConnectBase(string connectionString)
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
                                    MessageBoxIcon.Exclamation,
                                    MessageBoxDefaultButton.Button1,
                                    MessageBoxOptions.ServiceNotification);
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

        /// <summary>
        /// проверить что и соединение и бд существует
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        private static bool CheckConnectSimple(string connectionString)
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

        /// <summary>
        /// проверить что бд существует
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        private static bool CheckDatabaseExists(string connectionString)
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

        #endregion

        #region //Действия с базой данных

        /// <summary>
        /// создать БД по строке подключения
        /// </summary>
        /// <param name="connectionString">строка соединения</param>
        /// <param name="mode">режим инициализации</param>
        private static void CreateDB(string connectionString, bool mode)
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
            InitDB(connectionString, mode);
        }

        /// <summary>
        /// инициализировать БД по строке подключения
        /// </summary>
        /// <param name="connectionString">строка подключения</param>
        /// <param name="mode">режим инициализации false- не заполнять начальные данные true- заполнять</param>
        private static void InitDB(string connectionString, bool mode)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    string sql;
                    //СТРУКТУРА ДАННЫХ
                    //ОГРАНИЧЕНИЯ ДЛЯ СТАРЫХ СЕРВЕРОВ
                    //Insert по отдельности, типов Data и Time - нет, строковую дату передавать как yyyymmdd

                    //выпадающие списки
                    //График работы (таблица для списка) Почасовой/Поминутный
                    sqlCommand.CommandText = "CREATE TABLE UserWorkScheme (" +
                        "id int PRIMARY KEY IDENTITY, " +
                        "cd datetime NOT NULL DEFAULT GETDATE(), " +
                        "name VARCHAR(150) NOT NULL UNIQUE, " +                                     //*наименование
                        "uses bit DEFAULT 1 " +                                                     //флаг доступа для использования
                        ")";
                    sqlCommand.ExecuteNonQuery();

                    if (mode)
                    {
                        sql = "\r\nINSERT INTO UserWorkScheme(name) VALUES ";
                        sqlCommand.CommandText =
                            sql + "(N'Почасовой') " +
                            sql + "(N'Поминутный') ";
                        sqlCommand.ExecuteNonQuery();
                    }

                    //Тип дня производственного календаря (таблица для списка)
                    sqlCommand.CommandText = "CREATE TABLE CalendarDateType (" +
                        "id int PRIMARY KEY IDENTITY, " +
                        "cd datetime NOT NULL DEFAULT GETDATE(), " +
                        "name VARCHAR(150) NOT NULL UNIQUE, " +                                     //*наименование
                        "uses bit DEFAULT 1 " +                                                     //флаг доступа для использования
                        ")";
                    sqlCommand.ExecuteNonQuery();

                    if (mode)
                    {
                        sql = "\r\nINSERT INTO CalendarDateType(name) VALUES ";
                        sqlCommand.CommandText =
                            sql + "(N'Праздничный') " +
                            sql + "(N'Выходной') ";
                        sqlCommand.ExecuteNonQuery();
                    }

                    //Продолжительность дня производственного календаря (таблица для списка)
                    sqlCommand.CommandText = "CREATE TABLE CalendarLengthDay (" +
                        "id int PRIMARY KEY IDENTITY, " +
                        "cd datetime NOT NULL DEFAULT GETDATE(), " +
                        "name VARCHAR(150) NOT NULL UNIQUE, " +                                     //*наименование
                        "uses bit DEFAULT 1 " +                                                     //флаг доступа для использования
                        ")";
                    sqlCommand.ExecuteNonQuery();

                    if (mode)
                    {
                        sql = "\r\nINSERT INTO CalendarLengthDay(name) VALUES ";
                        sqlCommand.CommandText =
                            sql + "(N'Короткий') " +
                            sql + "(N'Полный') " +
                            "\r\nINSERT INTO CalendarLengthDay(name) VALUES (N'Длинный')";
                        sqlCommand.ExecuteNonQuery();
                    }

                    //Наименование даты производственного календаря (таблица для списка) 
                    sqlCommand.CommandText = "CREATE TABLE CalendarDateName (" +
                        "id int PRIMARY KEY IDENTITY, " +
                        "cd datetime NOT NULL DEFAULT GETDATE(), " +
                        "name VARCHAR(150) NOT NULL UNIQUE, " +                                     //*наименование
                        "date Datetime NULL, " +                                                    //дата (год не учитываем)
                        "dateTypeId int NOT NULL FOREIGN KEY REFERENCES CalendarDateType(id), " +   //->ссылка на тип дня (Праздничный/Выходной и т.д.)
                        "uses bit DEFAULT 1 " +                                                     //флаг доступа для использования
                        ")";
                    sqlCommand.ExecuteNonQuery();

                    if (mode)
                    {
                        sql = "\r\nINSERT INTO CalendarDateName(name, date, dateTypeId) VALUES ";
                        sqlCommand.CommandText =
                            sql + "(N'Новый год', '20000101', 1) " +
                            sql + "(N'Новогодние каникулы', NULL, 1) " +
                            sql + "(N'Рождество Христово', '20000107', 1) " +
                            sql + "(N'День защитника Отечества', '20000223', 1) " +
                            sql + "(N'Международный женский день', '20000308', 1) " +
                            sql + "(N'Праздник весны и труда', '20000501', 1) " +
                            sql + "(N'День Победы', '20000509', 1) " +
                            sql + "(N'День России', '20000612', 1) " +
                            sql + "(N'День народного единства', '20001104', 1) " +
                            sql + "(N'Нерабочий день', NULL, 2) " +
                            sql + "(N'Предпраздничный день', NULL, 2) ";                                                             //другое
                        sqlCommand.ExecuteNonQuery();
                    }

                    //Подразделение (таблица для списка)
                    sqlCommand.CommandText = "CREATE TABLE UserDepartment (" +
                        "id int PRIMARY KEY IDENTITY, " +
                        "cd datetime NOT NULL DEFAULT GETDATE(), " +
                        "name VARCHAR(150) NOT NULL UNIQUE, " +                                     //*наименование
                        "uses bit DEFAULT 1 " +                                                     //флаг доступа для использования
                        ")";
                    sqlCommand.ExecuteNonQuery();

                    if (mode)
                    {
                        sql = "\r\nINSERT INTO UserDepartment(name) VALUES ";
                        sqlCommand.CommandText =
                            sql + "(N'Бухгалтерия') " +
                            sql + "(N'Департамент закупок и договоров') " +
                            sql + "(N'Департамент маркетинга') " +
                            sql + "(N'Департамент обеспечения бизнеса') " +
                            sql + "(N'Департамент продаж') " +
                            sql + "(N'Департамент Тендерных и Конкурсных поставок') " +
                            sql + "(N'Департамент технической поддержки') " +
                            sql + "(N'Департамент ЧПУ') " +
                            sql + "(N'Общее руководство') " +
                            sql + "(N'Представительство Академия САПР и ГИС') ";
                        sqlCommand.ExecuteNonQuery();
                    }

                    //Должность (таблица для списка)
                    sqlCommand.CommandText = "CREATE TABLE UserPost (" +
                        "id int PRIMARY KEY IDENTITY, " +
                        "cd datetime NOT NULL DEFAULT GETDATE(), " +
                        "name VARCHAR(150) NOT NULL UNIQUE, " +                                     //*наименование
                        "uses bit DEFAULT 1 " +                                                     //флаг доступа для использования
                        ")";
                    sqlCommand.ExecuteNonQuery();

                    if (mode)
                    {
                        sql = "\r\nINSERT INTO UserPost(name) VALUES ";
                        sqlCommand.CommandText =
                            sql + "(N'Ассистент менеджера') " +
                            sql + "(N'Бухгалтер') " +
                            sql + "(N'Ведущий инженер') " +
                            sql + "(N'Ведущий менеджер') " +
                            sql + "(N'Главный Бухгалтер') " +
                            sql + "(N'Дизайнер') " +
                            sql + "(N'Инженер') " +
                            sql + "(N'Курьер') " +
                            sql + "(N'Логист') " +
                            sql + "(N'Менеджер') " +
                            sql + "(N'Руководитель') " +
                            sql + "(N'Руководитель департамента') " +
                            sql + "(N'Руководитель направления') " +
                            sql + "(N'Руководитель учебного центра') " +
                            sql + "(N'Секретарь') " +
                            sql + "(N'Системный администратор') " +
                            sql + "(N'Юрист') " +
                            sql + "(N'Ведущий менеджер отдела продаж') " +
                            sql + "(N'Заместитель генерального директора') " +
                            sql + "(N'и.о. Руководителя') ";
                        sqlCommand.ExecuteNonQuery();
                    }

                    //Специальные отметки (самостоятельная таблица)
                    sqlCommand.CommandText = "CREATE TABLE SpecialMarks (" +
                        "id int PRIMARY KEY IDENTITY, " +
                        "cd datetime NOT NULL DEFAULT GETDATE(), " +
                        "digitalCode VARCHAR(4) NOT NULL UNIQUE, " +                                //*числовой код 
                        "letterCode VARCHAR(4) NOT NULL UNIQUE, " +                                 //*строковый код
                        "name VARCHAR(150) NOT NULL UNIQUE, " +                                     //*наименование
                        "note VARCHAR(1024) NULL, " +                                               //расшифровка
                        "rating int DEFAULT 0, " +                                                  //рейтинг для сортировки    
                        "uses bit DEFAULT 1 " +                                                     //флаг доступа для использования
                        ")";
                    sqlCommand.ExecuteNonQuery();
                    //http://www.consultant.ru/document/cons_doc_LAW_47274/05305f7475e7ec92c38eb6e6e6b4ff56c94cd475/

                    if (mode)
                    {
                        sql = "\r\nINSERT INTO SpecialMarks(digitalCode, letterCode, name, note, rating, uses) VALUES ";
                        sqlCommand.CommandText =
                            //Продолжительность работы
                            sql + "('01', N'Я',  N'Работа в дневное время', N'Продолжительность работы в дневное время', 0, 1) " +
                            sql + "('02', N'Н',  N'Работа в ночное время', N'Продолжительность работы в ночное время', 0, 0) " +
                            sql + "('03', N'РВ', N'Работа в выходные', N'Продолжительность работы в выходные и нерабочие праздничные дни', 0, 0) " +
                            sql + "('04', N'C',  N'Сверхурочная работа', N'Продолжительность сверхурочной работы', 0, 0) " +
                            sql + "('05', N'ВМ', N'Работа на вахте', N'Продолжительность работы вахтовым методом', 0, 0) " +
                            sql + "('12', N'УВ', N'Отпуск на учебу (частично-оплачиваемый)', N'Сокращенная продолжительность рабочего времени для обучающихся без отрыва от производства с частичным сохранением заработной платы ', 0, 0) " +
                            sql + "('21', N'ЛЧ', N'Сокращенный день (законодательство РФ)', N'Сокращенная продолжительность рабочего времени против нормальной продолжительности рабочего дня в случаях, предусмотренных законодательством', 0, 0) " +
                            sql + "('25', N'НС', N'Сокращенный день (работодатель)', N'Продолжительность работы в режиме неполного рабочего времени по инициативе работодателя в случаях, предусмотренных законодательством', 0, 0) " +
                            //Командировка
                            sql + "('06', N'К',  N'Служебная командировка', N'Служебная командировка', 0, 0) " +
                            //Повышение квалификации
                            sql + "('07', N'ПК', N'Повышение квалификации с отрывом от работы', N'Повышение квалификации с отрывом от работы', 0, 0) " +
                            sql + "('08', N'ПМ', N'Повышение квалификации с отрывом от работы в другой местности', N'Повышение квалификации с отрывом от работы в другой местности', 0, 0) " +
                            //Отпуск
                            sql + "('09', N'ОТ', N'Отпуск ежегодный (оплачиваемый)', N'Ежегодный основной оплачиваемый отпуск', 0, 1) " +
                            sql + "('10', N'ОД', N'(Отгул) Дополнительный ежегодный отпуск (оплачиваемый)', N'Ежегодный дополнительный оплачиваемый отпуск', 0, 0) " +
                            sql + "('11', N'У',  N'Отпуск на учебу (средне-оплачиваемый)', N'Дополнительный отпуск в связи с обучением с сохранением среднего заработка работникам, совмещающим работу с обучением', 0, 0) " +
                            sql + "('13', N'УД', N'Отпуск на учебу (не оплачиваемый)', N'Дополнительный отпуск в связи с обучением без сохранения заработной платыДополнительный отпуск в связи с обучением с сохранением среднего заработка работникам, совмещающим работу с обучением', 0, 0) " +
                            sql + "('14', N'Р',  N'Отпуск по беременности и родам', N'Отпуск по беременности и родам (в связи с усыновлением новорожденного ребенка)', 0, 0) " +
                            sql + "('15', N'ОЖ', N'Отпуск по уходу за ребенком', N'Отпуск по уходу за ребенком до достижения им возраста трех лет', 0, 0) " +
                            sql + "('16', N'ДО', N'Отпуск (не оплачиваемый)(работодатель)', N'Отпуск без сохранения заработной платы, предоставленный работнику по разрешению работодателя', 0, 0) " +
                            sql + "('17', N'ОЗ', N'Отпуск (не оплачиваемый)(законодательство РФ)', N'Отпуск без сохранения заработной платы при условиях, предусмотренных действующим законодательством Российской Федерации', 0, 0) " +
                            sql + "('18', N'ДБ', N'Дополнительный ежегодный отпуск (не оплачиваемый)', N'Ежегодный дополнительный отпуск без сохранения заработной платы', 0, 0) " +
                            //Нетрудоспособность
                            sql + "('19', N'Б',  N'Больничный (оплачиваемый)', N'Временная нетрудоспособность (кроме случаев, предусмотренных кодом «Т») с назначением пособия согласно законодательству', 0, 1) " +
                            sql + "('20', N'Т',  N'Больничный (не оплачиваемый)', N'Временная нетрудоспособность без назначения пособия в случаях, предусмотренных законодательством', 0, 0) " +
                            //Прогулы, неявки
                            sql + "('22', N'ПВ', N'Вынужденный прогул', N'Время вынужденного прогула в случае признания увольнения, перевода на другую работу или отстранения от работы незаконными с восстановлением на прежней работе', 0, 0) " +
                            sql + "('23', N'Г',  N'Не выход на общественные работы (законодательство РФ)', N'Невыходы на время исполнения государственных или общественных обязанностей согласно законодательству', 0, 0) " +
                            sql + "('24', N'ПР', N'Прогул', N'Прогулы (отсутствие на рабочем месте без уважительных причин в течение времени, установленного законодательством)', 0, 0) " +
                            sql + "('30', N'НН', N'Неявка', N'Неявки по невыясненным причинам (до выяснения обстоятельств)', 0, 0) " +
                            //Выходные дни
                            sql + "('26', N'В',  N'Выходные (еженедельный отпуск) и праздники', N'Выходные дни (еженедельный отпуск) и  нерабочие праздничные дни', 0, 0) " +
                            sql + "('27', N'ОВ', N'Дополнительный выходной (оплачиваемый)', N'Дополнительные выходные дни (оплачиваемые)', 0, 0) " +
                            sql + "('28', N'НВ', N'Дополнительный выходной (не оплачиваемый)', N'Дополнительные выходные дни (без сохранения заработной платы)', 0, 0) " +
                            //Забастовка
                            sql + "('29', N'ЗБ', N'Забастовка (законодательство РФ)', N'Забастовка (при условиях и в порядке, предусмотренных законом)', 0, 0) " +
                            //Простой
                            sql + "('31', N'РП', N'Простой (работодатель)', N'Время простоя по вине работодателя', 0, 0) " +
                            sql + "('32', N'НП', N'Простой (форс-мажор)', N'Время простоя по причинам, не зависящим от работодателя и работника', 0, 0) " +
                            sql + "('33', N'ВП', N'Простой (работник)', N'Время простоя по вине работника', 0, 0) " +
                            sql + "('36', N'НЗ', N'Приостановка работы при задержке оплаты', N'Время приостановки работы в случае задержки выплаты заработной платы', 0, 0) " +
                            //Отстранение от работы
                            sql + "('34', N'НО', N'Отстранение от работы (оплачиваемое)(законодательство РФ)', N'Отстранение от работы (недопущение к работе) с оплатой(пособием) в соответствии с законодательством ', 0, 0) " +
                            sql + "('35', N'НБ', N'Отстранение от работы (не оплачиваемое)(законодательство РФ)', N'Отстранение от работы (недопущение к работе) по причинам, предусмотренным законодательством, без начисления заработной платы ', 0, 0) " +
                            //местные кодировки
                            // sql + "('00', 'СЗ', N'Служебное задание', '', 0, 1) " +
                            sql + "('100', 'РД', N'Работа из дома', '', 0, 1) " +
                            // sql + "('101', 'ОД', N'Общественное дело', '', 0, 1) " +
                            sql + "('102', 'ЛД', N'Личные дела', '', 0, 1) " +
                            sql + "('103', 'УДЛ', N'Удаленка', '', 0, 1) ";
                        sqlCommand.ExecuteNonQuery();
                    }

                    //таблицы
                    //Производственный Календарь (таблица использующая внешние данные)
                    sqlCommand.CommandText = "CREATE TABLE Calendars (" +
                        "id int PRIMARY KEY IDENTITY, " +
                        "cd datetime NOT NULL DEFAULT GETDATE(), " +
                        "originalDate Datetime NOT NULL , " +                                           //оригинальная дата
                        "transferDate Datetime NOT NULL UNIQUE, " +                                     //*реальная дата (перенос)
                        "dateNameId int NOT NULL FOREIGN KEY REFERENCES CalendarDateName(id), " +       //->ссылка на наименование даты (наименование даты и т.д.)
                        "dayLengthId int NOT NULL FOREIGN KEY REFERENCES CalendarLengthDay(id), " +     //->ссылка на продолжительность дня (сокращенный, полный и т.д.)
                        "uses bit DEFAULT 1 " +                                                         //флаг доступа для использования
                        ")";
                    sqlCommand.ExecuteNonQuery();

                    if (mode)
                    {
                        sql = "\r\nINSERT INTO Calendars(originalDate, transferDate, dateNameId, dayLengthId, uses) VALUES ";
                        sqlCommand.CommandText =
                            sql + "('20210101', '20210101', 1, 2, 1) " +
                            sql + "('20210102', '20211105', 2, 2, 1) " +
                            sql + "('20210103', '20211231', 2, 2, 1) " +
                            sql + "('20210104', '20210104', 2, 2, 1) " +
                            sql + "('20210105', '20210105', 2, 2, 1) " +
                            sql + "('20210106', '20210106', 2, 2, 1) " +
                            sql + "('20210107', '20210107', 3, 2, 1) " +
                            sql + "('20210108', '20210108', 2, 2, 1) " +
                            sql + "('20210220', '20210222', 10, 1, 1) " +
                            sql + "('20210223', '20210223', 4, 2, 1) " +
                            sql + "('20210308', '20210308', 5, 2, 1) " +
                            sql + "('20210501', '20210501', 6, 2, 1) " +
                            sql + "('20210509', '20210509', 7, 2, 1) " +
                            sql + "('20210612', '20210612', 8, 2, 1) " +
                            sql + "('20211104', '20211104', 9, 2, 1) " +

                            sql + "('20220101', '20220503', 1, 2, 1) " +
                            sql + "('20220102', '20220510', 2, 2, 1) " +
                            sql + "('20220103', '20220103', 2, 2, 1) " +
                            sql + "('20220104', '20220104', 2, 2, 1) " +
                            sql + "('20220105', '20220105', 2, 2, 1) " +
                            sql + "('20220106', '20220106', 2, 2, 1) " +
                            sql + "('20220107', '20220107', 3, 2, 1) " +
                            sql + "('20220108', '20220108', 2, 2, 1) " +
                            sql + "('20220223', '20220223', 4, 2, 1) " +
                            sql + "('20220305', '20220310', 10, 1, 1) " +
                            sql + "('20220308', '20220308', 5, 2, 1) " +
                            sql + "('20220501', '20220501', 6, 2, 1) " +
                            sql + "('20220509', '20220509', 7, 2, 1) " +
                            sql + "('20220612', '20220612', 8, 2, 1) " +
                            sql + "('20221104', '20221104', 9, 2, 1) ";
                        sqlCommand.ExecuteNonQuery();
                    }

                    //Пользователь (таблица использующая внешние данные)
                    sqlCommand.CommandText = "CREATE TABLE Users (" +
                        "id int PRIMARY KEY IDENTITY, " +
                        "cd datetime NOT NULL DEFAULT GETDATE(), " +
                        "extId VARCHAR(20) NOT NULL UNIQUE, " +                                     //*внешний id для интеграции (основной id)
                        "crmId NUMERIC DEFAULT 0, " +                                               //внешний id для интеграции с crm (дополнительны id)
                        "name VARCHAR(150) NOT NULL UNIQUE, " +                                     //*наименование
                        "note VARCHAR(1024) NULL, " +                                               //расшифровка
                        "departmentId int NOT NULL FOREIGN KEY REFERENCES UserDepartment(id), " +   //->ссылка на департамент
                        "postId int NOT NULL FOREIGN KEY REFERENCES UserPost(id), " +               //->ссылка на должность
                        "timeStart Datetime NULL, " +                                               //время начала работы по графику (без даты)    
                        "timeStop Datetime NULL, " +                                                //время окончания работы по графику (без даты)
                        "noLunch bit DEFAULT 1, " +                                                 //флаг признака обеда
                        "workSchemeId int NOT NULL FOREIGN KEY REFERENCES UserWorkScheme(id), " +   //->ссылка на схему работы
                        "uses bit DEFAULT 1 " +                                                     //флаг доступа для использования
                        ")";
                    sqlCommand.ExecuteNonQuery();

                    //Внешние поставщики времени (СКУД и т.д.) (таблица использующая внешние данные)
                    sqlCommand.CommandText = "CREATE TABLE TimeProvider (" +
                        "id int PRIMARY KEY IDENTITY, " +
                        "cd datetime NOT NULL DEFAULT GETDATE(), " +
                        "passDate Datetime NOT NULL, " +                                            //*дата события (без времени) 
                        "passId VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES Users(extId), " +       //*->ссылка на внешний id пользователя
                        "pacsName VARCHAR(150) NOT NULL, " +                                        //наименование провайдера (СКУД)
                        "pacsUserId VARCHAR(20) NOT NULL, " +                                       //внутренний id пользователя провайдера (СКУД)
                        "pacsTimeStart Datetime NULL, " +                                           //время первого входа по СКУД (без даты)
                        "pacsTimeStop Datetime NULL " +                                             //время последнего выхода по СКУД (без даты)
                        "UNIQUE(passDate, passId, pacsName, pacsUserId) " +                         //уникальность на уровне таблицы
                        ")";
                    sqlCommand.ExecuteNonQuery();

                    //Учет рабочего времени (таблица использующая внешние данные)
                    sqlCommand.CommandText = "CREATE TABLE EventsPass (" +
                        "id bigint PRIMARY KEY IDENTITY, " +
                        "cd datetime NOT NULL DEFAULT GETDATE(), " +
                        "author VARCHAR(150) NOT NULL, " +                                          //имя учетной записи сеанса
                        "passDate Datetime NOT NULL, " +                                            //*дата события (без времени) 
                        "passId VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES Users(extId), " +       //*->ссылка на внешний id пользователя
                        "passTimeStart Datetime NOT NULL, " +                                       //время первого входа (без даты)
                        "passTimeStop Datetime NOT NULL, " +                                        //время последнего выхода (без даты)
                        "timeScheduleFact int DEFAULT 0, " +                                        //отработанное время (мин)
                        "timeScheduleWithoutLunch int DEFAULT 0, " +                                //отработанное время без обеда (мин)
                        "timeScheduleLess int DEFAULT 0, " +                                        //время недоработки (мин)
                        "timeScheduleOver int DEFAULT 0, " +                                        //время переработки (мин)
                        "specmarkId int NOT NULL FOREIGN KEY REFERENCES SpecialMarks(id), " +       //->ссылка на специальные отметки
                        "specmarkTimeStart Datetime NULL, " +                                       //датавремя начала действия специальных отметок
                        "specmarkTimeStop Datetime NULL, " +                                        //датавремя окончания специальных отметок
                        "specmarkNote VARCHAR(1024) NULL, " +                                       //комментарий к специальным отметкам
                        "totalHoursInWork int DEFAULT 0, " +                                        //итог рабочего времени в графике (мин)
                        "totalHoursOutsideWork int DEFAULT 0 " +                                    //итог рабочего времени вне графика (мин)
                        "UNIQUE(passDate, passId) " +                                               //уникальность на уровне таблицы
                        ")";
                    sqlCommand.ExecuteNonQuery();

                    //UDF информация о дате календаря (пользовательски функции для ускорения процесса выборки)
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
                        "\r\n  n.name dName, " +                                                    //наименование дня
                        "\r\n  t.name dType, " +                                                    //тип дня (праздничный/выходной)
                        "\r\n  l.name dLength, " +                                                  //длина дня (полный/сокращенный)
                        "\r\n  c.uses access " +                                                    //флаг доступа для использования
                        "\r\nFrom Calendars c, CalendarDateName n, CalendarDateType t, CalendarLengthDay l " +
                        "\r\nWhere c.dateNameId = n.id " +
                        "\r\n  and c.dayLengthId = l.id " +
                        "\r\n  and n.dateTypeId = t.id " +
                        "\r\n  and (len(n.name)>0 and n.name like('%' + @Name + '%')) " +
                        "\r\n  or (not c.originalDate IS NULL and right(CONVERT(varchar(8), c.originalDate, 112),4) = @Date) " +
                        "\r\n)";
                    sqlCommand.ExecuteNonQuery();

                    //UDF информация о сотрудниках (пользовательски функции для ускорения процесса выборки)
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

                    //UDF информация о проходах на дату (пользовательски функции для ускорения процесса выборки)
                    sqlCommand.CommandText = "Create function twt_GetPassFormData\r\n(\r\n@bDate datetime, \r\n@extUserID varchar(20) = ''\r\n)" +
                        "\r\n/*" +
                        "\r\n возвращает данные для формы регистрации по запрашиваемой дате и активным пользователям" +
                        "\r\n   - если пользователь есть в истории проходов - время из истории (таблица EventsPass)" +
                        "\r\n   - если пользователя нет в истории проходов - время из рабочего графика (таблица Users)" +
                        "\r\n*/" +
                        "\r\nReturns table as Return " +
                        "\r\nSelect " +
                        "\r\n  e.passDate " +
                        "\r\n  , Case When e.passDate is null Then 0 Else 1 END used " +
                        "\r\n  , u.extId " +
                        "\r\n  , u.name fio " +
                        "\r\n  , u.timeStart userTimeIn " +
                        "\r\n  , u.timeStop userTimeOut " +
                        "\r\n  , u.noLunch " +
                        "\r\n  , u.workSchemeId " +
                        "\r\n  , e.passTimeStart passTimeIn " +
                        "\r\n  , e.passTimeStop passTimeOut " +
                        "\r\n  , e.specmarkId " +
                        "\r\n  , e.specmarkNote " +
                        "\r\n  , e.specmarkTimeStart markTimeIn " +
                        "\r\n  , e.specmarkTimeStop markTimeOut " +
                        "\r\n  , e.timeScheduleFact " +
                        "\r\n  , e.timeScheduleLess " +
                        "\r\n  , e.timeScheduleOver " +
                        "\r\n  , e.timeScheduleWithoutLunch " +
                        "\r\n  , e.totalHoursInWork " +
                        "\r\n  , e.totalHoursOutsideWork " +
                        "\r\n  , p.pacsUserId " +
                        "\r\n  , p.pacsTimeStart pacsTimeIn " +
                        "\r\n  , p.pacsTimeStop pacsTimeOut " +
                        "\r\nFrom " +
                        "\r\n  (Select * " +
                        "\r\n     From Users " +
                        "\r\n    Where extId like('%' + @extUserID + '%') " +
                        "\r\n          and uses = 1) as u " +
                        "\r\n  left join " +
                        "\r\n  (Select * " +
                        "\r\n     From EventsPass " +
                        "\r\n    Where passDate = @bDate) as e --cast('2021/01/02' as date)) as e " +
                        "\r\n  on u.ExtId = e.passId " +
                        "\r\n  left join " +
                        "\r\n  (Select * " +
                        "\r\n     From TimeProvider " +
                        "\r\n    Where passDate = @bDate) as p " +
                        "\r\n  on u.ExtId = p.passId";
                    sqlCommand.ExecuteNonQuery();

                    //UDF календарь дат (вспомогательная функция для тотального отчета)
                    sqlCommand.CommandText = "Create function getCalendar\r\n(\r\n@fromdate datetime, \r\n@todate datetime\r\n)" +
                        "\r\n/*" +
                        "\r\n возвращает таблицу дат формата 112 от @fromdate до @todate" +
                        "\r\n*/" +
                        "\r\nReturns @tcaldate TABLE(dt nvarchar(30)) as " +
                        "\r\n   BEGIN " +
                        "\r\n       INSERT INTO @tcaldate " +
                        "\r\n           SELECT TOP(DATEDIFF(DAY, @fromdate, @todate) + 1) " +
                        "\r\n               convert(nvarchar(30), DATEADD(DAY, ROW_NUMBER() OVER(ORDER BY a.object_id) - 1, @fromdate), 112) " +
                        "\r\n           FROM sys.all_objects a " +
                        "\r\n           CROSS JOIN sys.all_objects b; " +
                        "\r\n       RETURN " +
                        "\r\n   END ";
                    sqlCommand.ExecuteNonQuery();

                    //UDF заполняет календарь дат данными проходов (вспомогательная функция для тотального отчета)
                    sqlCommand.CommandText = "Create function twt_uploadCalendar\r\n(\r\n@fromdate datetime, \r\n@todate datetime\r\n)" +
                        "\r\n/*" +
                        "\r\n возвращает таблицу календаря (колонки - даты) с данными проходов (id юзера для синхронизации + данные с разделителями" +
                        "\r\n*/" +
                        "\r\nReturns table as Return " +
                        "\r\n   ( " +
                        "\r\n   Select calendar.dt daysCalendar, " +
                        "\r\n       pass.userId, " +
                        "\r\n       pass.pivotStr   --!!! внимание ограничение на длину строки 50 символов (дальше Pivot не обрабатывает) " +
                        "\r\n   From " +
                        "\r\n       (Select * From getCalendar(@fromdate, @todate)) as calendar --получить даты календаря " +
                        "\r\n           left join " +
                        "\r\n       (Select                                                     --дополнить их данными таблицы проходов " +
                        "\r\n           e.pDate passDate,                                       --дата прохода " +
                        "\r\n           u.usId userId,                                          --id фио " +
                        "\r\n           '|' + CONVERT(varchar(10), e.timeScheduleWithoutLunch)  --время без обеда " +
                        "\r\n           + '|' + CONVERT(varchar(10), e.timeScheduleLess)        --время недоработки " +
                        "\r\n           + '|' + CONVERT(varchar(10), e.timeScheduleOver)        --время переработки " +
                        "\r\n           + '|' + e.smName                                        --короткое имя спецотметки " +
                        "\r\n           + '|' + CONVERT(varchar(10), e.totalHoursInWork)        --общее время в рамках рабочего дня " +
                        "\r\n           + '|' + CONVERT(varchar(10), e.totalHoursOutsideWork)   --общее время вне рамок рабочего дня " +
                        "\r\n           + '|' pivotStr " +
                        "\r\n       From " +
                        "\r\n           (Select " +
                        "\r\n               us.extId usId                                       --id фио " +
                        "\r\n           From Users us " +
                        "\r\n           Where " +
                        "\r\n               us.uses = 1) as u " +
                        "\r\n       left join " +
                        "\r\n           (Select  " +
                        "\r\n               ep.passDate pDate,                                  --дата прохода " +
                        "\r\n               ep.passId usId,                                     --id фио " +
                        "\r\n               ep.timeScheduleWithoutLunch,                        --время без обеда " +
                        "\r\n               ep.timeScheduleLess,                                --время недоработки " +
                        "\r\n               ep.timeScheduleOver,                                --время переработки " +
                        "\r\n               sm.letterCode smName,                               --короткое имя спецотметки " +
                        "\r\n               ep.totalHoursInWork,                                --общее время в рамках рабочего дня " +
                        "\r\n               ep.totalHoursOutsideWork                            --общее время вне рамок рабочего дня " +
                        "\r\n           From EventsPass ep, SpecialMarks sm " +
                        "\r\n           Where sm.id=ep.specmarkId " +
                        "\r\n               and passDate between @fromdate and @todate) as e " +
                        "\r\n       on u.usId = e.usId ) as pass " +
                        "\r\n   on pass.passDate=calendar.dt " +
                        "\r\n   ) ";
                    sqlCommand.ExecuteNonQuery();

                    //SP формирование итогового сводного отчета за период (вспомогательная процедура для тотального отчета)
                    sqlCommand.CommandText = "Create PROCEDURE twt_TotalReport\r\n(\r\n@fromdate NVARCHAR(100), \r\n@todate NVARCHAR(100)\r\n)" +
                        "\r\n/*" +
                        "\r\n создает таблицу календаря для динамического формирования столбцов временной таблицы отчета и pivot запроса" +
                        "\r\n загружает календарь событий (не более 500 дат)(id юзера для синхронизации + данные с разделителями)" +
                        "\r\n добавляет полученные данные к активным пользователям" +
                        "\r\n возвращает таблицу для передачи клиенту C#" +
                        "\r\n*/" +
                        "\r\nAS BEGIN " +
                        "\r\n   BEGIN TRY                                                       --Обработчик ошибок" +
                        "\r\n       SET NOCOUNT ON;                                             --Отключаем вывод количества строк" +
                        "\r\n   --таблица для формирования имен колонок(для расширененя вренной таблицы и динамического pivot) " +
                        "\r\n       DECLARE @daysRange TABLE(colName NVARCHAR(30),              --табличная переменная(имя колонки и id колонки) " +
                        "\r\n                                colId int identity(1, 1)); " +
                        "\r\n       INSERT INTO @daysRange(colName)                             --заполним диапазоном дат " +
                        "\r\n       SELECT top 500 convert(NVARCHAR(30), dt, 112) dt            --вставим ограничение 500(2000 столбцов ограничение SQL) " +
                        "\r\n       FROM getCalendar(@fromdate, @todate); " +
                        "\r\n   --столбцы pivot " +
                        "\r\n   --заголовки колонок Pivot " +
                        "\r\n       DECLARE @colNamesHeaderPivot NVARCHAR(MAX);                 --sql строка заголовков столбцов для pivot " +
                        "\r\n       SELECT @colNamesHeaderPivot = ISNULL(@colNamesHeaderPivot + ', ', '') " +
                        "\r\n                               + 'COALESCE(' " +
                        "\r\n                               + QUOTENAME(colName) " +
                        "\r\n                               + ', NULL ) AS                      '--значение по умолчанию NULL для агрегатной функции MAX " +
                        "\r\n                               + QUOTENAME(colName) " +
                        "\r\n       FROM @daysRange; " +
                        "\r\n   --перечень колонок Pivot " +
                        "\r\n       DECLARE @colNamesPivot NVARCHAR(MAX);                       --sql строка столбцов для pivot " +
                        "\r\n       SELECT @colNamesPivot = ISNULL(@colNamesPivot + ', ', '') " +
                        "\r\n                               + QUOTENAME(colName)                --сформируем ее " +
                        "\r\n       FROM @daysRange; " +
                        "\r\n   --временная таблица Report " +
                        "\r\n       DECLARE @max int,                                           --переменная для цикла " +
                        "\r\n               @id int,                                            --переменная для цикла " +
                        "\r\n               @Query NVARCHAR(MAX),                               --переменная для хранения строки запроса " +
                        "\r\n               @colName NVARCHAR(50)                               --наименование заголовка столбца " +
                        "\r\n       SET @id = 1 " +
                        "\r\n       SELECT @max = MAX(colId) FROM @daysRange " +
                        "\r\n       CREATE TABLE #twt_Report(userID NVARCHAR(30));              --создадим временную таблицу для отчета " +
                        "\r\n       WHILE(@id <= @max)                                          --расширим ее нужным количеством столбцов " +
                        "\r\n           BEGIN                                                   --**возможно не самое красивое решение " +
                        "\r\n               SELECT @colName = colName FROM @daysRange WHERE colId = @id " +
                        "\r\n               SET @Query = 'ALTER TABLE #twt_Report ADD ' + QUOTENAME(@colName) + ' NVARCHAR(50);' " +
                        "\r\n               EXEC(@Query) " +
                        "\r\n               SET @id = @id + 1 " +
                        "\r\n           END " +
                        "\r\n   --Формируем строку с запросом PIVOT и вставкой в таблицу Report " +
                        "\r\n       DECLARE @TableSRC NVARCHAR(100)--Таблица источник(Представление) " +
                        "\r\n       SET @TableSRC = '(select * from twt_uploadCalendar(''' + @fromdate + ''', ''' + @todate + ''')) pivotSrc'; " +
                        "\r\n       SET @Query = N'SELECT userId, ' + @colNamesHeaderPivot + '  " +
                        "\r\n                       FROM(SELECT userId, daysCalendar, pivotStr'  " +
                        "\r\n                       + ' FROM ' + @TableSRC + ') AS SRC " +
                        "\r\n                       PIVOT(MAX(pivotStr)' +' FOR ' +  " +
                        "\r\n                           'daysCalendar IN (' + @colNamesPivot + ')) AS PVT " +
                        "\r\n                       ORDER BY userId; ' " +
                        "\r\n       INSERT INTO #twt_Report EXEC(@Query)                        --вставим результаты запроса во временную таблицу Отчета " +
                        "\r\n   --формируем отчет " +
                        "\r\n       SELECT * " +
                        "\r\n       FROM " +
                        "\r\n           (SELECT " +
                        "\r\n               u.name fio, " +
                        "\r\n               p.name post, " +
                        "\r\n               u.extId extId " +
                        "\r\n           FROM Users u, UserDepartment d, UserPost p--, UserWorkScheme w " +
                        "\r\n           WHERE u.departmentId = d.Id " +
                        "\r\n               AND u.postId = p.id " +
                        "\r\n               AND u.uses = 1) as u " +
                        "\r\n           left join " +
                        "\r\n           (SELECT* " +
                        "\r\n           FROM #twt_Report " +
                        "\r\n           ) as r " +
                        "\r\n       on u.ExtId = r.userID " +
                        "\r\n       DROP TABLE #twt_Report;                                     --удалим временную таблицу отчета " +
                        "\r\n       SET NOCOUNT OFF; --Включаем обратно вывод количества строк " +
                        "\r\n   END TRY " +
                        "\r\n   BEGIN CATCH " +
                        "\r\n   --В случае ошибки, возвращаем номер и описание этой ошибки " +
                        "\r\n       SELECT ERROR_NUMBER() AS[Номер ошибки],  " +
                        "\r\n               ERROR_MESSAGE() AS[Описание ошибки] " +
                        "\r\n   END CATCH " +
                        "\r\nEND ";
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// удалить бд
        /// </summary>
        /// <param name="connectionString">строка подключения</param>
        private static void DropDB(string connectionString)
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

        /// <summary>
        /// очистить таблицу Базы Данных со сбросом счетчика столбца identy
        /// </summary>
        /// <param name="connectionstring">строка соединения</param>
        /// <param name="tableName">имя таблицы</param>
        public static void ClearTableDB(string connectionstring, string tableName)
        {
            using (var sqlConnection = new SqlConnection(connectionstring))
            {
                sqlConnection.Open();
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = "DELETE FROM " + tableName + ";\r\n" +
                                             "DBCC CHECKIDENT('" + tableName + "', RESEED, 0)";
                    sqlCommand.ExecuteScalar();
                }
                sqlConnection.Close();
            }
        }

        #endregion

        #region //Запросы

        /// <summary>
        /// выполнить запрос на обновление создание и удаление
        /// </summary>
        /// <param name="connectionString">строка соединения</param>
        /// <param name="sqlRequest">запрос</param>
        /// <param name="errMode">false- не показывать ошибки true- показывать ошибки</param>
        /// <returns>количество обработанных строк</returns>
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

        /// <summary>
        /// выполнить запрос возвращающий одно значение
        /// </summary>
        /// <param name="connectionString">строка соединения</param>
        /// <param name="sqlRequest">запрос</param>
        /// <param name="errMode">false- не показывать ошибки true- показывать ошибки</param>
        /// <returns>количество обработанных строк</returns>
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

        /// <summary>
        /// выполнить запрос и вернуть DataSet
        /// </summary>
        /// <param name="connectionString">строка соединения</param>
        /// <param name="sqlRequest">запрос</param>
        /// <returns>результаты в DataSet</returns>
        private static DataTable GetTableRequest(string connectionString, string sqlRequest)
        {
            DataSet ds = new DataSet();  // Создаем объект Dataset
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

        #endregion

        #endregion

        #region//PUBLIC

        #region //Подключения и проверки

        /// <summary>
        ///проверить соединение отдельно по соединению (на базе master) и по имени базы в списке баз
        ///выдать расшифровку ошибок
        ///(проверка только из формы настроек соединения)
        /// </summary>
        /// <param name="connectionString">строка соединения</param>
        /// <returns>строка с каким то номером ошибки</returns>
        public static string sqlConnectBase(string connectionString)
        {
            if (CheckConnectBase(connectionString))
            {
                if (CheckDatabaseExists(connectionString))
                    return connectionString;
                else
                    return "-1";        //база данных не существует
            }
            else
                return "-9";            //соединение установить не удалось
        }

        /// <summary>
        ///проверить соединение сразу по строке подключения
        ///без выдачи ошибок
        ///(проверки из всех модулей)
        /// </summary>
        /// <param name="connectionString">строка соединения</param>
        /// <returns></returns>
        public static bool sqlConnectSimple(string connectionString)
        {
            return CheckConnectSimple(connectionString);
        }

        #endregion

        #region //Действия с базой данных

        /// <summary>
        /// создать БД по строке подключения
        /// </summary>
        /// <param name="connectionString">строка соединения</param>
        /// <param name="mode">режим инициализации</param>
        public static void CreateDataBase(string connectionstring, bool mode)
        {
            if (CheckDatabaseExists(connectionstring))
            {
                DropDB(connectionstring);
            }
            CreateDB(connectionstring, mode);
        }

        /// <summary>
        /// очиститбь таблицу Базы Данных 
        /// </summary>
        /// <param name="connectionstring">строка соединения</param>
        /// <param name="tableName">имя таблицы</param>
        public static void ClearTableDataBase(string connectionstring, string tableName)
        {
            ClearTableDB(connectionstring, tableName);
        }

        #endregion

        //Запросы
        #region //Запросы

        /// <summary>
        /// выполнить запрос на обновление создание и удаление
        /// </summary>
        /// <param name="connectionString">строка соединения</param>
        /// <param name="sqlRequest">запрос</param>
        /// <param name="errMode">false- не показывать ошибки true- показывать ошибки</param>
        /// <returns>вернуть true или false</returns>
        public static bool RequestNonQuery(string connectionString, string sqlRequest, Boolean errMode)
        {
            return GetRequestNonQuery(connectionString, sqlRequest, errMode) > 0;
        }

        /// <summary>
        /// выполнить запрос возвращающий одно значение
        /// </summary>
        /// <param name="connectionString">строка соединения</param>
        /// <param name="sqlRequest">запрос</param>
        /// <param name="errMode">false- не показывать ошибки true- показывать ошибки</param>
        /// <returns>количество обработанных строк</returns>
        public static string RequesScalar(string connectionString, string sqlRequest, Boolean errMode)
        {
            return GetRequesScalar(connectionString, sqlRequest, errMode);
        }

        /// <summary>
        /// выполнить запрос и вернуть DataSet
        /// </summary>
        /// <param name="connectionString">строка соединения</param>
        /// <param name="sqlRequest">запрос</param>
        /// <returns>результаты в DataSet</returns>
        public static DataTable TableRequest(string connectionString, string sqlRequest)
        {
            return GetTableRequest(connectionString, sqlRequest);
        }


        #endregion
        #endregion

    }
}
