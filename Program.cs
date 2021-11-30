using System;
using System.Collections.Generic;
using System.Linq;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;



namespace TimeWorkTracking
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //поработаем с командной строкой на предмет сброса админского пароля
            string[] arguments = Environment.GetCommandLineArgs();
            if (arguments.Length >1)
            {
                switch (arguments[1])
                {
                    case "-r":                          //сбросить админски пароль
                        Properties.Settings.Default.adminPass = "";
                        Properties.Settings.Default.Save();     //сохраним новый пароль в настройках
                        break;
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
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
            
            if (ret==-1)
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
    }
}
