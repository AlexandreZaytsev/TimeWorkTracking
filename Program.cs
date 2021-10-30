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
        public static int FindListByColValue(this ListView lstView, int numCol, string find)
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


    }
}
