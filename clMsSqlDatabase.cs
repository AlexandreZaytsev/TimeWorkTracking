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
                        "cd datetime NOT NULL DEFAULT GETDATE(), " +
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
                        "cd datetime NOT NULL DEFAULT GETDATE(), " +
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
                        "cd datetime NOT NULL DEFAULT GETDATE(), " +
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
                        "cd datetime NOT NULL DEFAULT GETDATE(), " +
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
                        "cd datetime NOT NULL DEFAULT GETDATE(), " +
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
                        "cd datetime NOT NULL DEFAULT GETDATE(), " +
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
                        "cd datetime NOT NULL DEFAULT GETDATE(), " +
                        "digitalCode VARCHAR(4) NOT NULL, " +                                       //числовой код 
                        "letterCode VARCHAR(4) NOT NULL, " +                                        //строковый код
                        "name VARCHAR(150) NOT NULL UNIQUE, " +                                     //*наименование
                        "note VARCHAR(1024) NULL, " +                                               //расшифровка
                        "uses bit DEFAULT 1 " +                                                     //флаг доступа для использования
                        ")";
                    sqlCommand.ExecuteNonQuery();
                    //http://www.consultant.ru/document/cons_doc_LAW_47274/05305f7475e7ec92c38eb6e6e6b4ff56c94cd475/
                    sqlCommand.CommandText =
                        "\r\nINSERT INTO SpecialMarks(digitalCode, letterCode, name, note, uses) VALUES ('01', N'Я', N'-', N'Продолжительность работы в дневное время', 1) " +
                        "\r\nINSERT INTO SpecialMarks(digitalCode, letterCode, name, note, uses) VALUES ('02', N'Н', N'Ночные работы', N'Продолжительность работы в ночное время', 0) " +
                        "\r\nINSERT INTO SpecialMarks(digitalCode, letterCode, name, note, uses) VALUES ('03', N'РВ', N'Работа в выходные', N'Продолжительность работы в выходные и нерабочие праздничные дни', 0) " +
                        "\r\nINSERT INTO SpecialMarks(digitalCode, letterCode, name, note, uses) VALUES ('04', N'C', N'Сверхурочная работа', N'Продолжительность сверхурочной работы', 0) " +
                        "\r\nINSERT INTO SpecialMarks(digitalCode, letterCode, name, note, uses) VALUES ('05', N'ВМ', N'Работа на вахте', N'Продолжительность работы вахтовым методом', 0) " +
                        "\r\nINSERT INTO SpecialMarks(digitalCode, letterCode, name, note, uses) VALUES ('06', N'К', N'Служебная командировка', N'Служебная командировка', 0) " +
                        "\r\nINSERT INTO SpecialMarks(digitalCode, letterCode, name, note, uses) VALUES ('07', N'ПК', N'Повышение квалификации с отрывом от работы', N'Повышение квалификации с отрывом от работы', 0) " +
                        "\r\nINSERT INTO SpecialMarks(digitalCode, letterCode, name, note, uses) VALUES ('08', N'ПМ', N'Повышение квалификации с отрывом от работы в другой местности', N'Повышение квалификации с отрывом от работы в другой местности', 0) " +
                        "\r\nINSERT INTO SpecialMarks(digitalCode, letterCode, name, note, uses) VALUES ('09', N'ОТ', N'Отпуск', N'Ежегодный основной оплачиваемый отпуск', 1) " +
                        "\r\nINSERT INTO SpecialMarks(digitalCode, letterCode, name, note, uses) VALUES ('10', N'ОД', N'Дополнительный отпуск с сохранением з.п.', N'Ежегодный дополнительный оплачиваемый отпуск', 0) " +
                        "\r\nINSERT INTO SpecialMarks(digitalCode, letterCode, name, note, uses) VALUES ('11', N'У', N'Отпуск на учебу с сохранением средней з.п.', N'Дополнительный отпуск в связи с обучением с сохранением среднего заработка работникам, совмещающим работу с обучением', 0) " +
                        "\r\nINSERT INTO SpecialMarks(digitalCode, letterCode, name, note, uses) VALUES ('12', N'УВ', N'Отпуск на учебу с частичным сохранением з.п.', N'Сокращенная продолжительность рабочего времени для обучающихся без отрыва от производства с частичным сохранением заработной платы ', 0) " +
                        "\r\nINSERT INTO SpecialMarks(digitalCode, letterCode, name, note, uses) VALUES ('13', N'УД', N'Отпуск на учебу без сохранения з.п.', N'Дополнительный отпуск в связи с обучением без сохранения заработной платыДополнительный отпуск в связи с обучением с сохранением среднего заработка работникам, совмещающим работу с обучением', 0) " +
                        "\r\nINSERT INTO SpecialMarks(digitalCode, letterCode, name, note, uses) VALUES ('14', N'Р', N'Отпуск по беременности и родам', N'Отпуск по беременности и родам (в связи с усыновлением новорожденного ребенка)', 0) " +
                        "\r\nINSERT INTO SpecialMarks(digitalCode, letterCode, name, note, uses) VALUES ('15', N'ОЖ', N'Отпуск по уходу за ребенком', N'Отпуск по уходу за ребенком до достижения им возраста трех лет', 0) " +
                        "\r\nINSERT INTO SpecialMarks(digitalCode, letterCode, name, note, uses) VALUES ('16', N'ДО', N'Отпуск (от работодателя) без сохранения з.п.', N'Отпуск без сохранения заработной платы, предоставленный работнику по разрешению работодателя', 0) " +
                        "\r\nINSERT INTO SpecialMarks(digitalCode, letterCode, name, note, uses) VALUES ('17', N'ОЗ', N'Отпуск (от РФ) без сохранения з.п.', N'Отпуск без сохранения заработной платы при условиях, предусмотренных действующим законодательством Российской Федерации', 0) " +
                        "\r\nINSERT INTO SpecialMarks(digitalCode, letterCode, name, note, uses) VALUES ('18', N'ДБ', N'Дополнительный отпуск без сохранения з.п.', N'Ежегодный дополнительный отпуск без сохранения заработной платы', 0) " +
                        "\r\nINSERT INTO SpecialMarks(digitalCode, letterCode, name, note, uses) VALUES ('19', N'Б', N'Больничный с оплатой', N'Временная нетрудоспособность (кроме случаев, предусмотренных кодом «Т») с назначением пособия согласно законодательству', 1) " +
                        "\r\nINSERT INTO SpecialMarks(digitalCode, letterCode, name, note, uses) VALUES ('20', N'Т', N'Больничный без оплаты', N'Временная нетрудоспособность без назначения пособия в случаях, предусмотренных законодательством', 0) " +

                        "\r\nINSERT INTO SpecialMarks(digitalCode, letterCode, name, note, uses) VALUES ('24', N'ПР', N'Прогул', N'Прогулы (отсутствие на рабочем месте без уважительных причин в течение времени, установленного законодательством)', 0) " +
                        "\r\nINSERT INTO SpecialMarks(digitalCode, letterCode, name, note, uses) VALUES ('29', N'ЗБ', N'Забастовка', N'Забастовка (при условиях и в порядке, предусмотренных законом)', 0) " +
                        "\r\nINSERT INTO SpecialMarks(digitalCode, letterCode, name, note, uses) VALUES ('30', N'НН', N'Неявка', N'Неявки по невыясненным причинам (до выяснения обстоятельств)', 0) " +

                        "\r\nINSERT INTO SpecialMarks(digitalCode, letterCode, name, note, uses) VALUES ('00', 'СЗ', N'Служебное задание', '' , 1) " +
                        "\r\nINSERT INTO SpecialMarks(digitalCode, letterCode, name, note, uses) VALUES ('00', 'РД', N'Работа из дома', '', 1) " +
                        "\r\nINSERT INTO SpecialMarks(digitalCode, letterCode, name, note, uses) VALUES ('00', 'ОД', N'Общественное дело', '', 1) " +
                        "\r\nINSERT INTO SpecialMarks(digitalCode, letterCode, name, note, uses) VALUES ('00', 'ЛД', N'Личные дела', '', 1) " +
                        "\r\nINSERT INTO SpecialMarks(digitalCode, letterCode, name, note, uses) VALUES ('00', 'УД', N'Удаленка', '', 1) ";
                    sqlCommand.ExecuteNonQuery();

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
