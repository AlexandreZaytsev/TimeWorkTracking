using System;
using System.Collections.Generic;
using System.Linq;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }

    /*----------------------------------------------------------------------------------------------------------
    *  РАСШИРЕНИЯ
    -----------------------------------------------------------------------------------------------------------*/
    //получить номер выделенной строки в ListView
    public static class Extension
    {
        public static int SelectedIndex(this ListView listView)
        {
            if (listView.SelectedIndices.Count > 0)
                return listView.SelectedIndices[0];
            else
                return -1;
        }
        //Создать ID из даты
        //ГодМесяцДеньЧасыМинутыСекунды+3разряда на потоковые операции (создание до 999 элементов в цикле)
        static string CreateIDFromDate(DateTime curDate)
        {
            return  curDate.ToString("yyyyMMddHHmmss    hh:mm:ss");
                /*
                 * 2019 10 28 10 09 59
                 * 2021 10 24 13 01 18
                CStr(Year(curDate)) +
                          Right("00" & CStr(Month(curDate)), 2) +
                          Right("00" & CStr(Day(curDate)), 2) +
                          Right("00" & CStr(Hour(curDate)), 2) +
                          Right("00" & CStr(Minute(curDate)), 2) +
                          Right("00" & CStr(Second(curDate)), 2)
                      '    "000"
                */
        }
    }
}
