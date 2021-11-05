using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TimeWorkTracking
{
    class Calendar 
    {
        private DataTable dtWorkCalendar;                                           //производственный календаоь
        public Calendar(string cs, string sql)                      //конструктор
        {
            dtWorkCalendar = MsSqlDatabase.TableRequest(cs, sql);
        }

        //получить все даты праздников (перенос)
        public List<DateTime> getHoliday()
        {
            List<DateTime> dateList = new List<DateTime>();
            for (int i = 0; i < dtWorkCalendar.Rows.Count; i++)         //Display items in the ListView control
            {
                DataRow drow = dtWorkCalendar.Rows[i];
                if (drow.RowState != DataRowState.Deleted)              //Only row that have not been deleted
                {
                    dateList.Add((DateTime)drow["dWork"]);
                }
            }
            return dateList;
        }

        //проверить день на предмет что это праздникне праздник, выходной или рабочий
        public KeyValuePair<int, DataRow> checkDay(DateTime dayInfo)
        {
            bool check = false;
            for (int i = 0; i < dtWorkCalendar.Rows.Count; i++)                 //Display items in the ListView control
            {
                DataRow drow = dtWorkCalendar.Rows[i];
                if (                                                            //если день совпадает с днем из производственного кадендаря
                    (drow.RowState != DataRowState.Deleted) &&                  //Only row that have not been deleted
                    ((DateTime.Compare((DateTime)drow["dWork"], dayInfo) == 0) ||
                     (DateTime.Compare((DateTime)drow["dSource"], dayInfo) == 0))
                    )
                {
                    check = true;
                    if (DateTime.Compare((DateTime)drow["dWork"], (DateTime)drow["dSource"]) == 0)
                        return new KeyValuePair<int, DataRow>(0, drow);         //это Праздничный день (без переносов)
                    else
                    {                                                           //перенесенная дата
                        if (DateTime.Compare((DateTime)drow["dWork"], dayInfo) == 0)
                            return new KeyValuePair<int, DataRow>(1, drow);     //это Праздничный день (перенесенная дата)
                        else
                        {                                                       //это реальная дата
                            if (drow["dType"].ToString() == "Праздничный")
                                return new KeyValuePair<int, DataRow>(2, drow); //это Выходной день (праздник попадает на выходной)
                            else
                                return new KeyValuePair<int, DataRow>(3, drow); //это Рабочий день (праздник не попадает на выходной)
                        }
                    }
                }
            }
            if (!check)
            {
                if (dayInfo.DayOfWeek == DayOfWeek.Saturday || dayInfo.DayOfWeek == DayOfWeek.Sunday)
                    return new KeyValuePair<int, DataRow>(4, null);             //это просто Выходной день
                else
                    return new KeyValuePair<int, DataRow>(5, null);             //это просто Рабочий день
            }
            return new KeyValuePair<int, DataRow>(-1, null);
        }
    }
}
