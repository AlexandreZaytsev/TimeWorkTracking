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
    class clMsSqlDatabase
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
        //ОГРАНИЧЕНИЯ ДЛЯ СТАРЫХ СЕРВЕРОВ
        //Insert по отдельности, типов Data и Time - нет, строковую дату передавать как yyyymmdd

        //выпадающие списки
                    //График работы (таблица для списка) Почасовой/Поминутный
                    sqlCommand.CommandText = "CREATE TABLE UserWorkScheme (" +
                        "id int PRIMARY KEY IDENTITY, " +
                        "name VARCHAR(150) NOT NULL UNIQUE, " +                                     //*наименование
                        "uses bit DEFAULT 1 " +                                                     //флаг доступа для использования
                        ")";
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.CommandText =
                        "\r\nINSERT INTO UserWorkScheme(name) VALUES (N'Почасовой') " +
                        "\r\nINSERT INTO UserWorkScheme(name) VALUES (N'Поминутный') ";
                    sqlCommand.ExecuteNonQuery();

                    //Тип дня производственного календаря (таблица для списка)
                    sqlCommand.CommandText = "CREATE TABLE CalendarDateType (" +
                        "id int PRIMARY KEY IDENTITY, " +
                        "name VARCHAR(150) NOT NULL UNIQUE, " +                                     //*наименование
                        "uses bit DEFAULT 1 " +                                                     //флаг доступа для использования
                        ")";
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.CommandText =
                        "\r\nINSERT INTO CalendarDateType(name) VALUES (N'Праздничный') " +
                        "\r\nINSERT INTO CalendarDateType(name) VALUES (N'Выходной') ";
                    sqlCommand.ExecuteNonQuery();

                    //Продолжительность дня производственного календаря (таблица для списка)
                    sqlCommand.CommandText = "CREATE TABLE CalendarLengthDay (" +
                        "id int PRIMARY KEY IDENTITY, " +
                        "name VARCHAR(150) NOT NULL UNIQUE, " +                                     //*наименование
                        "uses bit DEFAULT 1 " +                                                     //флаг доступа для использования
                        ")";
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.CommandText =
                        "\r\nINSERT INTO CalendarLengthDay(name) VALUES (N'Короткий') " +
                        "\r\nINSERT INTO CalendarLengthDay(name) VALUES (N'Полный') " +
                        "\r\nINSERT INTO CalendarLengthDay(name) VALUES (N'Длинный')";
                    sqlCommand.ExecuteNonQuery();

                    //Наименование даты производственного календаря (таблица для списка) 
                    sqlCommand.CommandText = "CREATE TABLE CalendarDateName (" +
                        "id int PRIMARY KEY IDENTITY, " +
                        "name VARCHAR(150) NOT NULL UNIQUE, " +                                     //*наименование
                        "date Datetime NULL, " +                                                    //дата (год не учитываем)
                        "dateTypeId int NOT NULL FOREIGN KEY REFERENCES CalendarDateType(id), " +   //->ссылка на тип дня (Праздничный/Выходной и т.д.)
                        "uses bit DEFAULT 1 " +                                                     //флаг доступа для использования
                        ")";                                                        
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.CommandText =
                        "\r\nINSERT INTO CalendarDateName(name, date, dateTypeId) VALUES (N'Новый год', '20000101', 1) " +
                        "\r\nINSERT INTO CalendarDateName(name, date, dateTypeId) VALUES (N'Новогодние каникулы', NULL, 1) " +
                        "\r\nINSERT INTO CalendarDateName(name, date, dateTypeId) VALUES (N'Рождество Христово', '20000107', 1) " +
                        "\r\nINSERT INTO CalendarDateName(name, date, dateTypeId) VALUES (N'День защитника Отечества', '20000223', 1) " +
                        "\r\nINSERT INTO CalendarDateName(name, date, dateTypeId) VALUES (N'Международный женский день', '20000308', 1) " +
                        "\r\nINSERT INTO CalendarDateName(name, date, dateTypeId) VALUES (N'Праздник весны и труда', '20000501', 1) " +
                        "\r\nINSERT INTO CalendarDateName(name, date, dateTypeId) VALUES (N'День Победы', '20000509', 1) " +
                        "\r\nINSERT INTO CalendarDateName(name, date, dateTypeId) VALUES (N'День России', '20000612', 1) " +
                        "\r\nINSERT INTO CalendarDateName(name, date, dateTypeId) VALUES (N'День народного единства', '20001104', 1) " +
                        "\r\nINSERT INTO CalendarDateName(name, date, dateTypeId) VALUES (N'Нерабочий день', NULL, 2) " +
                        "\r\nINSERT INTO CalendarDateName(name, date, dateTypeId) VALUES (N'Предпраздничный день', NULL, 2) ";                                                             //другое
                    sqlCommand.ExecuteNonQuery();

                    //Подразделение (таблица для списка)
                    sqlCommand.CommandText = "CREATE TABLE UserDepartment (" +
                        "id int PRIMARY KEY IDENTITY, " +
                        "name VARCHAR(150) NOT NULL UNIQUE, " +                                     //*наименование
                        "uses bit DEFAULT 1 " +                                                     //флаг доступа для использования
                        ")";
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.CommandText =
                        "\r\nINSERT INTO UserDepartment(name) VALUES (N'Бухгалтерия') " +
                        "\r\nINSERT INTO UserDepartment(name) VALUES (N'Департамент закупок и договоров') " +
                        "\r\nINSERT INTO UserDepartment(name) VALUES (N'Департамент маркетинга') " +
                        "\r\nINSERT INTO UserDepartment(name) VALUES (N'Департамент обеспечения бизнеса') " +
                        "\r\nINSERT INTO UserDepartment(name) VALUES (N'Департамент продаж') " +
                        "\r\nINSERT INTO UserDepartment(name) VALUES (N'Департамент Тендерных и Конкурсных поставок') " +
                        "\r\nINSERT INTO UserDepartment(name) VALUES (N'Департамент технической поддержки') " +
                        "\r\nINSERT INTO UserDepartment(name) VALUES (N'Департамент ЧПУ') " +
                        "\r\nINSERT INTO UserDepartment(name) VALUES (N'Общее руководство') " +
                        "\r\nINSERT INTO UserDepartment(name) VALUES (N'Представительство Академия САПР и ГИС') ";
                    sqlCommand.ExecuteNonQuery();

                    //Должность (таблица для списка)
                    sqlCommand.CommandText = "CREATE TABLE UserPost (" +
                        "id int PRIMARY KEY IDENTITY, " +
                        "name VARCHAR(150) NOT NULL UNIQUE, " +                                     //*наименование
                        "uses bit DEFAULT 1 " +                                                     //флаг доступа для использования
                        ")";
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.CommandText =
                        "\r\nINSERT INTO UserPost(name) VALUES (N'Ассистент менеджера') " +
                        "\r\nINSERT INTO UserPost(name) VALUES (N'Бухгалтер') " +
                        "\r\nINSERT INTO UserPost(name) VALUES (N'Ведущий инженер') " +
                        "\r\nINSERT INTO UserPost(name) VALUES (N'Ведущий менеджер') " +
                        "\r\nINSERT INTO UserPost(name) VALUES (N'Главный Бухгалтер') " +
                        "\r\nINSERT INTO UserPost(name) VALUES (N'Дизайнер') " +
                        "\r\nINSERT INTO UserPost(name) VALUES (N'Инженер') " +
                        "\r\nINSERT INTO UserPost(name) VALUES (N'Курьер') " +
                        "\r\nINSERT INTO UserPost(name) VALUES (N'Логист') " +
                        "\r\nINSERT INTO UserPost(name) VALUES (N'Менеджер') " +
                        "\r\nINSERT INTO UserPost(name) VALUES (N'Руководитель') " +
                        "\r\nINSERT INTO UserPost(name) VALUES (N'Руководитель департамента') " +
                        "\r\nINSERT INTO UserPost(name) VALUES (N'Руководитель направления') " +
                        "\r\nINSERT INTO UserPost(name) VALUES (N'Руководитель учебного центра') " +
                        "\r\nINSERT INTO UserPost(name) VALUES (N'Секретарь') " +
                        "\r\nINSERT INTO UserPost(name) VALUES (N'Системный администратор') " +
                        "\r\nINSERT INTO UserPost(name) VALUES (N'Юрист') " +
                        "\r\nINSERT INTO UserPost(name) VALUES (N'Ведущий менеджер отдела продаж') " +
                        "\r\nINSERT INTO UserPost(name) VALUES (N'Заместитель генерального директора') " +
                        "\r\nINSERT INTO UserPost(name) VALUES (N'и.о. Руководителя') ";
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
                    sqlCommand.CommandText =
                        "\r\nINSERT INTO SpecialMarks(digitalCode, letterCode, name, note, uses) VALUES ('01', N'Я', N'-', N'Продолжительность работы в дневное время', 1) " +
                        "\r\nINSERT INTO SpecialMarks(digitalCode, letterCode, name, note, uses) VALUES ('02', N'Н', N'Ночные работы', N'Продолжительность работы в ночное время', 0) " +
                        "\r\nINSERT INTO SpecialMarks(digitalCode, letterCode, name, note, uses) VALUES ('03', N'РВ', N'Работа в выходные', N'Продолжительность работы в выходные и нерабочие праздничные дни', 0) " +
                        "\r\nINSERT INTO SpecialMarks(digitalCode, letterCode, name, note, uses) VALUES ('04', N'C', N'Сверхурочная работа', N'Продолжительность сверхурочной работы', 0) " +
                        "\r\nINSERT INTO SpecialMarks(digitalCode, letterCode, name, note, uses) VALUES ('05', N'ВМ', N'Работа на вахте', N'Продолжительность работы вахтовым методом', 0) " +
                        "\r\nINSERT INTO SpecialMarks(digitalCode, letterCode, name, note, uses) VALUES ('06', N'К', N'Служебная командировка', N'Служебная командировка', 0) " +

                        "\r\nINSERT INTO SpecialMarks(digitalCode, letterCode, name, note, uses) VALUES ('09', N'ОТ', N'Отпуск', N'Ежегодный основной оплачиваемый отпуск', 1) " +
                        "\r\nINSERT INTO SpecialMarks(digitalCode, letterCode, name, note, uses) VALUES ('10', N'ОД', N'дополнительный Отпуск', N'Ежегодный дополнительный оплачиваемый отпуск', 0) " +

                        "\r\nINSERT INTO SpecialMarks(digitalCode, letterCode, name, note, uses) VALUES ('14', N'Р', N'Отпуск по беременности и родам', N'Отпуск по беременности и родам (в связи с усыновлением новорожденного ребенка)', 0) " +
                        "\r\nINSERT INTO SpecialMarks(digitalCode, letterCode, name, note, uses) VALUES ('15', N'ОЖ', N'Отпуск по уходу за ребенком', N'Отпуск по уходу за ребенком до достижения им возраста трех лет', 0) " +
                        "\r\nINSERT INTO SpecialMarks(digitalCode, letterCode, name, note, uses) VALUES ('16', N'ДО', N'Отгул', N'Отпуск без сохранения заработной платы, предоставленный работнику по разрешению работодателя', 1) " +

                        "\r\nINSERT INTO SpecialMarks(digitalCode, letterCode, name, note, uses) VALUES ('19', N'Б', N'Больничный с оплатой', N'Временная нетрудоспособность (кроме случаев, предусмотренных кодом «Т») с назначением пособия согласно законодательству', 1) " +
                        "\r\nINSERT INTO SpecialMarks(digitalCode, letterCode, name, note, uses) VALUES ('20', N'Т', N'Больничный без оплаты', N'Временная нетрудоспособность без назначения пособия в случаях, предусмотренных законодательством', 1) " +

                        "\r\nINSERT INTO SpecialMarks(digitalCode, letterCode, name, note, uses) VALUES ('24', N'ПР', N'Прогул', N'Прогулы (отсутствие на рабочем месте без уважительных причин в течение времени, установленного законодательством)', 0) " +
                        "\r\nINSERT INTO SpecialMarks(digitalCode, letterCode, name, note, uses) VALUES ('29', N'ЗБ', N'Забастовка', N'Забастовка (при условиях и в порядке, предусмотренных законом)', 1) " +
                        "\r\nINSERT INTO SpecialMarks(digitalCode, letterCode, name, note, uses) VALUES ('30', N'НН', N'Неявка', N'Неявки по невыясненным причинам (до выяснения обстоятельств)', 0) " +

                        "\r\nINSERT INTO SpecialMarks(digitalCode, letterCode, name, note, uses) VALUES ('00', 'СЗ', N'Служебное задание', '' , 1) " +
                        "\r\nINSERT INTO SpecialMarks(digitalCode, letterCode, name, note, uses) VALUES ('00', 'РД', N'Работа из дома', '', 0) " +
                        "\r\nINSERT INTO SpecialMarks(digitalCode, letterCode, name, note, uses) VALUES ('00', 'ОД', N'Общественное дело', '', 1) " +
                        "\r\nINSERT INTO SpecialMarks(digitalCode, letterCode, name, note, uses) VALUES ('00', 'ЛД', N'Личные дела', '', 1) " +
                        "\r\nINSERT INTO SpecialMarks(digitalCode, letterCode, name, note, uses) VALUES ('00', 'УД', N'Удаленка', '', 1) ";
                    sqlCommand.ExecuteNonQuery();

                    //таблицы
                    //Производственный Календарь (таблица использующая внешние данные)
                    sqlCommand.CommandText = "CREATE TABLE Calendars (" +
                        "id int PRIMARY KEY IDENTITY, " +
                        "originalDate Datetime NOT NULL , " +                                           //оригинальная дата
                        "transferDate Datetime NOT NULL UNIQUE, " +                                     //*реальная дата (перенос)
                        "dateNameId int NOT NULL FOREIGN KEY REFERENCES CalendarDateName(id), " +       //->ссылка на наименование даты (наименование даты и т.д.)
                        "dayLengthId int NOT NULL FOREIGN KEY REFERENCES CalendarLengthDay(id), " +     //->ссылка на продолжительность дня (сокращенный, полный и т.д.)
                        "uses bit DEFAULT 1 " +                                                         //флаг доступа для использования
                        ")";
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.CommandText =
                        "\r\nINSERT INTO Calendars(originalDate, transferDate, dateNameId, dayLengthId, uses) VALUES ('20210101', '20210101', 1, 2, 1) " +
                        "\r\nINSERT INTO Calendars(originalDate, transferDate, dateNameId, dayLengthId, uses) VALUES ('20210102', '20211105', 2, 2, 1) " +
                        "\r\nINSERT INTO Calendars(originalDate, transferDate, dateNameId, dayLengthId, uses) VALUES ('20210103', '20211231', 2, 2, 1) " +
                        "\r\nINSERT INTO Calendars(originalDate, transferDate, dateNameId, dayLengthId, uses) VALUES ('20210104', '20210104', 2, 2, 1) " +
                        "\r\nINSERT INTO Calendars(originalDate, transferDate, dateNameId, dayLengthId, uses) VALUES ('20210105', '20210105', 2, 2, 1) " +
                        "\r\nINSERT INTO Calendars(originalDate, transferDate, dateNameId, dayLengthId, uses) VALUES ('20210106', '20210106', 2, 2, 1) " +
                        "\r\nINSERT INTO Calendars(originalDate, transferDate, dateNameId, dayLengthId, uses) VALUES ('20210107', '20210107', 3, 2, 1) " +
                        "\r\nINSERT INTO Calendars(originalDate, transferDate, dateNameId, dayLengthId, uses) VALUES ('20210108', '20210108', 2, 2, 1) " +
                        "\r\nINSERT INTO Calendars(originalDate, transferDate, dateNameId, dayLengthId, uses) VALUES ('20210220', '20210222', 10, 1, 1) " +
                        "\r\nINSERT INTO Calendars(originalDate, transferDate, dateNameId, dayLengthId, uses) VALUES ('20210223', '20210223', 4, 2, 1) " +
                        "\r\nINSERT INTO Calendars(originalDate, transferDate, dateNameId, dayLengthId, uses) VALUES ('20210308', '20210308', 5, 2, 1) " +
                        "\r\nINSERT INTO Calendars(originalDate, transferDate, dateNameId, dayLengthId, uses) VALUES ('20210501', '20210501', 6, 2, 1) " +
                        "\r\nINSERT INTO Calendars(originalDate, transferDate, dateNameId, dayLengthId, uses) VALUES ('20210509', '20210509', 7, 2, 1) " +
                        "\r\nINSERT INTO Calendars(originalDate, transferDate, dateNameId, dayLengthId, uses) VALUES ('20210612', '20210612', 8, 2, 1) " +
                        "\r\nINSERT INTO Calendars(originalDate, transferDate, dateNameId, dayLengthId, uses) VALUES ('20211104', '20211104', 9, 2, 1) " +

                        "\r\nINSERT INTO Calendars(originalDate, transferDate, dateNameId, dayLengthId, uses) VALUES ('20220101', '20220503', 1, 2, 1) " +
                        "\r\nINSERT INTO Calendars(originalDate, transferDate, dateNameId, dayLengthId, uses) VALUES ('20220102', '20220510', 2, 2, 1) " +
                        "\r\nINSERT INTO Calendars(originalDate, transferDate, dateNameId, dayLengthId, uses) VALUES ('20220103', '20220103', 2, 2, 1) " +
                        "\r\nINSERT INTO Calendars(originalDate, transferDate, dateNameId, dayLengthId, uses) VALUES ('20220104', '20220104', 2, 2, 1) " +
                        "\r\nINSERT INTO Calendars(originalDate, transferDate, dateNameId, dayLengthId, uses) VALUES ('20220105', '20220105', 2, 2, 1) " +
                        "\r\nINSERT INTO Calendars(originalDate, transferDate, dateNameId, dayLengthId, uses) VALUES ('20220106', '20220106', 2, 2, 1) " +
                        "\r\nINSERT INTO Calendars(originalDate, transferDate, dateNameId, dayLengthId, uses) VALUES ('20220107', '20220107', 3, 2, 1) " +
                        "\r\nINSERT INTO Calendars(originalDate, transferDate, dateNameId, dayLengthId, uses) VALUES ('20220108', '20220108', 2, 2, 1) " +
                        "\r\nINSERT INTO Calendars(originalDate, transferDate, dateNameId, dayLengthId, uses) VALUES ('20220223', '20220223', 4, 2, 1) " +
                        "\r\nINSERT INTO Calendars(originalDate, transferDate, dateNameId, dayLengthId, uses) VALUES ('20220305', '20220310', 10, 1, 1) " +
                        "\r\nINSERT INTO Calendars(originalDate, transferDate, dateNameId, dayLengthId, uses) VALUES ('20220308', '20220308', 5, 2, 1) " +
                        "\r\nINSERT INTO Calendars(originalDate, transferDate, dateNameId, dayLengthId, uses) VALUES ('20220501', '20220501', 6, 2, 1) " +
                        "\r\nINSERT INTO Calendars(originalDate, transferDate, dateNameId, dayLengthId, uses) VALUES ('20220509', '20220509', 7, 2, 1) " +
                        "\r\nINSERT INTO Calendars(originalDate, transferDate, dateNameId, dayLengthId, uses) VALUES ('20220612', '20220612', 8, 2, 1) " +
                        "\r\nINSERT INTO Calendars(originalDate, transferDate, dateNameId, dayLengthId, uses) VALUES ('20221104', '20221104', 9, 2, 1) ";

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
                        "timeStart Datetime NULL, " +                                                   //время начала работы по графику (без даты)    
                        "timeStop Datetime NULL, " +                                                    //время окончания работы по графику (без даты)
                        "noLunch bit DEFAULT 1, " +                                                 //флаг признака обеда
                        "workSchemeId int NOT NULL FOREIGN KEY REFERENCES UserWorkScheme(id), " +   //->ссылка на схему работы
                        "uses bit DEFAULT 1 " +                                                     //флаг доступа для использования
                        ")";
                    sqlCommand.ExecuteNonQuery();

                    //Учет рабочего времени (таблица использующая внешние данные)
                    sqlCommand.CommandText = "CREATE TABLE EventsPass (" +
                        "id bigint PRIMARY KEY IDENTITY, " +
                        "author VARCHAR(150) NOT NULL, " +                                          //имя учетной записи сеанса
                        "passDate Datetime NOT NULL, " +                                            //*дата события (без времени) 
                        "passId VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES Users(extId), " +       //*->ссылка на внешний id пользователя
                        "passTimeStart Datetime NOT NULL, " +                                       //время первого входа (без даты)
                        "passTimeStop Datetime NOT NULL, " +                                        //время последнего выхода (без даты)
                        "pacsTimeStart Datetime NULL, " +                                           //время первого входа по СКУД (без даты)
                        "pacsTimeStop Datetime NULL, " +                                            //время последнего выхода по СКУД (без даты)
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
                        "\r\n  e.passDate " +
                        "\r\n  , Case When e.passDate is null Then 0 Else 1 END used " +
                        "\r\n  , u.extId " +
                        "\r\n  , u.name fio " +
                        "\r\n  , u.timeStart gtStart " +
                        "\r\n  , u.timeStop gtStop " +
                        "\r\n  , u.noLunch " +
                        "\r\n  , u.workSchemeId " +
                        "\r\n  , e.passTimeStart ptSart " +
                        "\r\n  , e.passTimeStop ptStop " +
                        "\r\n  , e.specmarkId " +
                        "\r\n  , e.specmarkNote " +
                        "\r\n  , e.specmarkTimeStart stSatrt " +
                        "\r\n  , e.specmarkTimeStop stStop " +
                        "\r\n  , e.timeScheduleFact " +
                        "\r\n  , e.timeScheduleLess " +
                        "\r\n  , e.timeScheduleOver " +
                        "\r\n  , e.timeScheduleWithoutLunch " +
                        "\r\n  , e.totalHoursInWork " +
                        "\r\n  , e.totalHoursOutsideWork " +
                        "\r\nFrom " +
                        "\r\n  (Select * " +
                        "\r\n     From Users " +
                        "\r\n    Where extId like('%' + @extUserID + '%') " +
                        "\r\n          and uses = 1) as u " +
                        "\r\n  left join " +
                        "\r\n  (Select * " +
                        "\r\n     From EventsPass " +
                        "\r\n    Where passDate = @bDate) as e --cast('2021/01/02' as date)) as e " +
                        "\r\n  on u.ExtId = e.passId";
                    sqlCommand.ExecuteNonQuery();

                    /*only >2005

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
                        "(N'Сокращенный'), " +
                        "(N'Удлиненный'), " +
                        "(N'Праздничный'), " +
                        "(N'Выходной')";
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
                        "(N'Нерабочий день', NULL), " +
                        "(N'Предпраздничный день', NULL)";                                                             //другое
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
                        "dateNameId int NOT NULL FOREIGN KEY REFERENCES CalendarDateName(id), " +   //->ссылка на наименование даты (наименование даты и т.д.)
                        "dateTypeId int NOT NULL FOREIGN KEY REFERENCES CalendarDateType(id), " +   //->ссылка на тип даты (тип дня сокращенный, полный и т.д.)
                        "uses bit DEFAULT 1 " +                                                     //флаг доступа для использования
                        ")";
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.CommandText = "INSERT INTO Calendars(originalDate, transferDate, dateNameId, dateTypeId, uses) VALUES " +
                        "('2021-01-01', '2021-01-01', 1, 1, 1), " +
                        "('2021-01-02', '2021-11-05', 2, 1, 1), " +
                        "('2021-01-03', '2021-12-31', 2, 1, 1), " +
                        "('2021-01-04', '2021-01-04', 2, 1, 1), " +
                        "('2021-01-05', '2021-01-05', 2, 1, 1), " +
                        "('2021-01-06', '2021-01-06', 2, 1, 1), " +
                        "('2021-01-07', '2021-01-07', 3, 1, 1), " +
                        "('2021-01-08', '2021-01-08', 2, 1, 1), " +
                        "('2021-02-20', '2021-02-22', 10, 1, 1), " +
                        "('2021-02-23', '2021-02-23', 4, 1, 1), " +
                        "('2021-03-08', '2021-03-08', 5, 1, 1), " +
                        "('2021-05-01', '2021-05-01', 6, 1, 1), " +
                        "('2021-05-09', '2021-05-09', 7, 1, 1), " +
                        "('2021-06-12', '2021-06-12', 8, 1, 1), " +
                        "('2021-11-04', '2021-11-04', 9, 1, 1)";
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
                        "\r\n" +
                        "\r\n-- возвращает информацию о дате" + 
                        "\r\n--   по части (like) наименования" +
                        "\r\n--   или по дате без года (4 символа в формате MMDD) с ведущими нулями" +
                        "\r\n
                    " +
                        "\r\nReturns table as Return " +
                        "\r\n(" +
                        "\r\nSelect " +
                        "\r\n  c.id id, " +
                        "\r\n  c.transferDate dWork, " +                                            //рабочая дата (перенос или исходная)
                        "\r\n  c.originalDate dSource, " +                                          //исходная дата
                        "\r\n  n.name dName, " +                                                    //наименование дня
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
                        "\r\n--" +
                        "\r\n-- возвращает информацию о сотруднике по внешнему идентификатору" +
                        "\r\n--   по части (like) наименования" +
                        "\r\n--" +
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
                        "\r\n--" +
                        "\r\n-- возвращает данные для формы регистрации по запрашиваемой дате и активным пользователям" +
                        "\r\n--   - если пользователь есть в истории проходов - время из истории (таблица EventsPass)" +
                        "\r\n--   - если пользователя нет в истории проходов - время из рабочего графика (таблица Users)" +
                        "\r\n--" +
                        "\r\nReturns table as Return " +
                        "\r\nSelect " +
                        "\r\n  e.passDate " +
                        "\r\n  , Case When e.passDate is null Then 0 Else 1 END used " +
                        "\r\n  , u.extId " +
                        "\r\n  , u.name fio " +
                        "\r\n  , u.timeStart gtStart " +
                        "\r\n  , u.timeStop gtStop " +
                        "\r\n  , u.noLunch " +
                        "\r\n  , u.workSchemeId " +
                        "\r\n  , e.specmarkId " +
                        "\r\n  , e.specmarkNote " +
                        "\r\n  , e.specmarkTimeStart stSatrt " +
                        "\r\n  , e.specmarkTimeStop stStop " +
                        "\r\n  , e.passTimeStart ptSart " +
                        "\r\n  , e.passTimeStop ptStop " +
                        "\r\n  , e.timeScheduleFact " +
                        "\r\n  , e.timeScheduleLess " +
                        "\r\n  , e.timeScheduleOver " +
                        "\r\n  , e.timeScheduleWithoutLunch " +
                        "\r\n  , e.totalHoursInWork " +
                        "\r\n  , e.totalHoursOutsideWork " +
                        "\r\nFrom " +
                        "\r\n  (Select * " +
                        "\r\n     From Users " +
                        "\r\n    Where extId like('%' + @extUserID + '%') " +
                        "\r\n          and uses = 1) as u " +
                        "\r\n  left join " +
                        "\r\n  (Select * " +
                        "\r\n     From EventsPass " +
                        "\r\n    Where passDate = @bDate) as e --cast('2021/01/02' as date)) as e " +
                        "\r\n  on u.ExtId = e.passId";
                    sqlCommand.ExecuteNonQuery();




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
