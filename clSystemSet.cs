using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows.Forms;

namespace TimeWorkTracking
{
    static class clSystemSet
    {
        //получить хеш строку MD5   
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

        //проверить доступ к сетевым ресурсам 
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
            catch (PingException e)
            {
                return false;
            }
        }

        //проверить доступ к хосту
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
        //проверить провайдеров для работы с Excel
        static public bool checkProvider()
        {
            //проверим наличие провайдера
            OleDbEnumerator enumerator = new OleDbEnumerator();
            DataTable table1 = enumerator.GetElements();
            bool jetOleDb = false, aceOleDb = false, excel = false;
            foreach (DataRow row in table1.Rows)
            {
                if (row["SOURCES_NAME"].ToString() == "Microsoft.Jet.OLEDB.4.0") jetOleDb = true;
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

        //проверка ввода логинов паролей
        static public bool checkChar(Char chr) 
        {
            //            var regex = new Regex(@"[^a-zA-Z0-9\s[\b]]");
            //            var regex = new Regex(@"[a-zA-Z\d\b]");
            var regex = new Regex(@"[^\w\b]");                          //все символы по текущей локализации + цифры + backspace
            return regex.IsMatch(chr.ToString());
/*
            char val = e.KeyChar;
            if (!Char.IsLetterOrDigit(val) && !Char.IsDigit(val) && val != 8 && (val <= 39 || val >= 46) && val != 47 && val != 61) //калькулятор
            {
                e.Handled = true;
            }
*/
        }
    }


    /*----------------------------------------------------------------------------------------------------------
      РАСШИРЕНИЯ
    -----------------------------------------------------------------------------------------------------------*/
    public static class Extension
    {

        //получить значение элемента (для выбора по DisplayMember или  )
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

        //получить индекс выделенной строки ListView
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
        //найти индекс строки ListView в колонке SubItem по значению
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

        //получить base64 из байтового массива картинки из ресурса
        public static string extImageToBase64Converter(this Image image, ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, format);
                return Convert.ToBase64String(ms.ToArray());
            }
        }
        //конвертировать цвет в HEX строку
        public static String extHexConverter(this System.Drawing.Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }

        //конвертировать цвет в RGB строку
        public static String extRGBConverter(this System.Drawing.Color c)
        {
            return "RGB(" + c.R.ToString() + "," + c.G.ToString() + "," + c.B.ToString() + ")";
        }

        //разбить длинное предложение на части (по словам) не превышающие длину max и собрать его обратно используя разделитель delimeter
        //https://ru.stackoverflow.com/questions/707937/c-%D0%BF%D0%B5%D1%80%D0%B5%D0%BD%D0%BE%D1%81-%D1%81%D0%BB%D0%BE%D0%B2-%D0%B2-%D1%81%D1%82%D1%80%D0%BE%D0%BA%D0%B5-%D1%81-%D1%80%D0%B0%D0%B7%D0%B1%D0%B8%D0%B2%D0%BA%D0%BE%D0%B9-%D0%BD%D0%B0-%D0%BE%D0%BF%D1%80%D0%B5%D0%B4%D0%B5%D0%BB%D0%B5%D0%BD%D0%BD%D1%83%D1%8E-%D0%B4%D0%BB%D0%B8%D0%BD%D1%83
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

}
