using System;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace TimeWorkTracking
{
    static class clSystemSet
    {
        #region kill процесса Excel

        [DllImport("user32.dll")]
        static extern int GetWindowThreadProcessId(int hWnd, out int lpdwProcessId);

        /// <summary>
        /// получить ID процесса Excel 
        /// </summary>
        /// <param name="excelApp"></param>
        /// <returns></returns>
        static public Process GetExcelProcess(Excel.Application excelApp)
        {
            GetWindowThreadProcessId(excelApp.Hwnd, out int id);
            return Process.GetProcessById(id);
        }

        /// <summary>
        /// закрыть процесс Excel
        /// </summary>
        /// <param name="iProcessId"></param>
        public static void killExcel(int iProcessId)
        {

            System.Diagnostics.Process[] process = System.Diagnostics.Process.GetProcessesByName("Excel");
            foreach (System.Diagnostics.Process p in process)
            {
                if (p.Id == iProcessId)
                {
                    try
                    {
                        p.Kill();
                    }
                    catch { }
                }
            }
        }
        public static void GC()
        {
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        #endregion

        /// <summary>
        /// получить хеш строку MD5
        /// </summary>
        /// <param name="input">исходная строка</param>
        /// <returns>хеш строки</returns>
        public static string getMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        /// <summary>
        /// проверить доступ к сетевым ресурсам используя ping
        /// </summary>
        /// <param name="addrPing">адрес ресурса</param>
        /// <returns>true в случае успеха</returns>
        static public bool CheckPing(string addrPing)
        {
            Ping Pinger = new Ping();
            //int timeout = 4000;                 //4 сек 
            //PingOptions options = new PingOptions(64, true);
            //string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            //byte[] buffer = Encoding.ASCII.GetBytes(data);
            try
            {
                PingReply reply = Pinger.Send(addrPing);//, timeout);//, buffer, options);
                if (reply.Status == IPStatus.Success)
                    return true;
                else
                    return false;
            }
            catch (PingException)// e)
            {
                return false;
            }
        }

        /// <summary>
        /// проверить доступ к http хосту используя webclient 
        /// </summary>
        /// <param name="uriHost">адрес ресурса</param>
        /// <returns>true в случае успеха</returns>
        static public bool CheckHost(string uriHost)
        {
            //https://professorweb.ru/my/csharp/web/level2/2_4.php
            try
            {
                return new System.Net.WebClient().DownloadString(uriHost).Contains("");
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// проверить провайдеров для работы с Excel
        /// </summary>
        /// <returns>true в случае успеха</returns>
        static public bool checkProvider()
        {
            //проверим наличие провайдера
            OleDbEnumerator enumerator = new OleDbEnumerator();
            DataTable table1 = enumerator.GetElements();
            bool aceOleDb = false;
            bool excel = false;
            foreach (DataRow row in table1.Rows)
            {
                //bool jetOleDb;
                //if (row["SOURCES_NAME"].ToString() == "Microsoft.Jet.OLEDB.4.0") jetOleDb = true;
                if (row["SOURCES_NAME"].ToString() == "Microsoft.ACE.OLEDB.12.0") aceOleDb = true;
            }

            Type officeType = Type.GetTypeFromProgID("Excel.Application");
            if (officeType != null)
                excel = true;

            if (!(aceOleDb && excel))
            {
                System.Windows.Forms.MessageBox.Show(
                    "В системе отсутствует провайдер\r\n" +
                    " - Microsoft.ACE.OLEDB.12.0\r\n\r\n" +
                    "функционал Экспорт/Импорт/Отчеты\r\n - недоступен\r\n" +
                    "установите пожалуйста MS Excel2010 или выше",
                    "Ошибка окружения", MessageBoxButtons.OK, MessageBoxIcon.Exclamation
                    );
                return false;
            }
            else
                return true;
        }

        /// <summary>
        /// проверка символов при вводе логинов паролей
        /// </summary>
        /// <param name="chr">входящий символ</param>
        /// <returns>true в случае успеха</returns>
        static public bool checkChar(Char chr)
        {
            //http://website-lab.ru/article/regexp/shpargalka_po_regulyarnyim_vyirajeniyam/
            string input = chr.ToString();
            //            var regex = new Regex(@"[^a-zA-Z0-9\s[\b]]");
            //            var regex = new Regex(@"[a-zA-Z\d\b]");
            var regexOk = new Regex(@"[^\w\b]");                        //все символы по текущей локализации + цифры + backspace
            var regexExc = new Regex(@"[\._\@\:\-\/\*\(\)]");           //кроме
            //            var hasNumber = new Regex(@"[0-9]+");
            //            var hasUpperChar = new Regex(@"[A-Z]+");
            //            var hasMinimum8Chars = new Regex(@".{8,}");
            bool isValidated = regexOk.IsMatch(input) && regexExc.IsMatch(input);

            return isValidated;
            /*
                        char val = e.KeyChar;
                        if (!Char.IsLetterOrDigit(val) && !Char.IsDigit(val) && val != 8 && (val <= 39 || val >= 46) && val != 47 && val != 61) //калькулятор
                        {
                            e.Handled = true;
                        }
            */
        }
    }

    #region //РАСШИРЕНИЯ
    public static class Extension
    {

        /// <summary>
        /// получить значение элемента (для выбора по DisplayMember или ValueMember)
        /// </summary>
        /// <param name="list">проверяемый контрол</param>
        /// <param name="item">проверяемый элемент</param>
        /// <returns>значение в виде объекта</returns>
        public static object extGetItemValue(this ListControl list, object item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            if (string.IsNullOrEmpty(list.ValueMember))
                return item;

            var property = TypeDescriptor.GetProperties(item)[list.ValueMember];
            if (property == null)
                throw new ArgumentException(
                    string.Format("item doesn't contain '{0}' property or column.",
                    list.ValueMember));
            return property.GetValue(item);
        }

        /// <summary>
        /// получить индекс выделенной строки ListView
        /// </summary>
        /// <param name="listView">исследуемый List</param>
        /// <returns>найденный индекс или -1 если не нашли</returns>
        public static int extSelectedIndex(this ListView listView)
        {
            for (int index = 0; index <= listView.Items.Count - 1; index++)
            {
                if (listView.Items[index].Selected)
                    return index;
            }
            return -1;
            /*
                        if (listView.SelectedIndices.Count > 0)
                            return listView.SelectedIndices[0];
                        else
                            return ret;
            */
        }

        /// <summary>
        /// найти индекс строки ListView в колонке SubItem по значению
        /// </summary>
        /// <param name="lstView">исследуемый List</param>
        /// <param name="numCol">номер колонки SubItem</param>
        /// <param name="find">значение для поиска</param>
        /// <returns>найденный индекс или -1 если не нашли</returns>
        //
        public static int extFindListByColValue(this ListView lstView, int numCol, string find)
        {
            int ret = -1;
            if (lstView.Items.Count > 0)
            {
                for (int index = 0; index <= lstView.Items.Count - 1; index++)
                {
                    if (lstView.Items[index].SubItems[numCol].Text == find)
                    {
                        ret = index;
                        lstView.Items[ret].Selected = true;
                    }
                    else
                    {
                        lstView.Items[index].Selected = false;
                    }
                }
            }

            if (ret == -1)
                lstView.HideSelection = true;           //сбросить выделение строки при потере фокуса ListView
            else
            {
                lstView.HideSelection = false;          //оставить выделение строки при потере фокуса ListView
                lstView.EnsureVisible(ret);             //показать в области видимости окна
            }

            return ret;
        }

        /// <summary>
        /// получить base64 (HTML) из байтового массива картинки из ресурса
        /// </summary>
        /// <param name="image">картинка</param>
        /// <param name="format">формат картинки</param>
        /// <returns>base64 (HTML)</returns>
        public static string extImageToBase64Converter(this Image image, ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, format);
                return Convert.ToBase64String(ms.ToArray());
            }
        }

        /// <summary>
        /// конвертировать цвет в HEX строку
        /// </summary>
        /// <param name="color">системный цвет</param>
        /// <returns>строка HEX цвет</returns>
        public static String extHexConverter(this System.Drawing.Color color)
        {
            return "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
        }

        /// <summary>
        /// конвертировать цвет в RGB строку
        /// </summary>
        /// <param name="color">системный цвет</param>
        /// <returns>строка RGB цвет</returns>
        public static String extRGBConverter(this System.Drawing.Color color)
        {
            return "RGB(" + color.R.ToString() + "," + color.G.ToString() + "," + color.B.ToString() + ")";
        }

        /// <summary>
        /// разбить длинное предложение на части (по словам) не превышающие длину max и собрать его обратно используя разделитель delimeter
        /// https://ru.stackoverflow.com/questions/707937/c-%D0%BF%D0%B5%D1%80%D0%B5%D0%BD%D0%BE%D1%81-%D1%81%D0%BB%D0%BE%D0%B2-%D0%B2-%D1%81%D1%82%D1%80%D0%BE%D0%BA%D0%B5-%D1%81-%D1%80%D0%B0%D0%B7%D0%B1%D0%B8%D0%B2%D0%BA%D0%BE%D0%B9-%D0%BD%D0%B0-%D0%BE%D0%BF%D1%80%D0%B5%D0%B4%D0%B5%D0%BB%D0%B5%D0%BD%D0%BD%D1%83%D1%8E-%D0%B4%D0%BB%D0%B8%D0%BD%D1%83
        /// </summary>
        /// <param name="text">исходное предложение</param>
        /// <param name="max">максимальная длина строки до разделителя</param>
        /// <param name="delimeter">разделитель</param>
        /// <returns></returns>
        public static string Wrap(this string text, int max, string delimeter)
        {
            var charCount = 0;
            var lines = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] ret = lines.GroupBy(w => (charCount += (((charCount % max) + w.Length + 1 >= max)
                            ? max - (charCount % max) : 0) + w.Length + 1) / max)
                        .Select(g => string.Join(" ", g.ToArray()))
                        .ToArray();
            return string.Join(delimeter, ret);
        }
    }

    #endregion

}
