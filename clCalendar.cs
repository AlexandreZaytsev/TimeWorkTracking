using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace TimeWorkTracking
{
    class clCalendar 
    {
        private DataTable dtWorkCalendar;                    //производственный календаоь
        public clCalendar()                                           //конструктор  
        {
            dtWorkCalendar = null;
        }                                      

        public void uploadCalendar(string cs, string sql)               //конструктор
        {
            dtWorkCalendar = clMsSqlDatabase.TableRequest(cs, sql);
        }

        //получить все даты праздников (перенос)
        public List<DateTime> getListWorkHoliday()
        {
            List<DateTime> dateList = new List<DateTime>();
            if (dtWorkCalendar != null)
            {
                for (int i = 0; i < dtWorkCalendar.Rows.Count; i++)         //Display items in the ListView control
                {
                    DataRow drow = dtWorkCalendar.Rows[i];
                    if (drow.RowState != DataRowState.Deleted)              //Only row that have not been deleted
                    {
                        dateList.Add((DateTime)drow["dWork"]);
                    }
                }
            }
            return dateList;
        }

        //проверить дату на длину (по производственному календарю)
        public int getLengthWorkHoliday(DateTime chDate)
        {
            int ret = 0;
            if (dtWorkCalendar != null)
            {
                for (int i = 0; i < dtWorkCalendar.Rows.Count; i++)         //Display items in the ListView control
                {
                    DataRow drow = dtWorkCalendar.Rows[i];
                    if (drow.RowState != DataRowState.Deleted)              //Only row that have not been deleted
                    {
                        if (
                            (DateTime.Compare(chDate.Date, (DateTime)drow["dWork"]) == 0) ||
                            (DateTime.Compare(chDate.Date, (DateTime)drow["dSource"]) == 0)
                            )
                        {
                            switch (drow["dLength"].ToString())
                            {
                                case "Короткий":                            //меньше на час
                                    ret = -60;
                                    break;
                                case "Длинный":                             //больше на час
                                    ret = 60;
                                    break;
                                default:
                                    ret = 0;
                                    break;
                            }
                        }
                    }
                }
            }
            return ret;
        }

        //проdерить дату на праздник (перенос)
        public bool chechWorkHoliday(DateTime chDate)
        {
            bool ret = false;
            if (dtWorkCalendar != null)
            {
                for (int i = 0; i < dtWorkCalendar.Rows.Count; i++)         //Display items in the ListView control
                {
                    DataRow drow = dtWorkCalendar.Rows[i];
                    if (drow.RowState != DataRowState.Deleted)              //Only row that have not been deleted
                    {
                        if (DateTime.Compare(chDate.Date, (DateTime)drow["dWork"]) == 0 && drow["dType"].ToString() == "Праздничный")
                        {
                            ret = true;
                        }
                    }
                }
            }
            return ret;
        }

        //проdерить дату на рабочий день
        public bool chechWorkDay(DateTime chDate)
        {
            KeyValuePair<int, DataRow> infoDate = checkDay(chDate.Date);
            switch (infoDate.Key)
            {
                case 3:                                             //это рабочий день из перенесенного праздника
                case 5:                                             //это просто рабочий день
                    return true;
                default:
                    return false;
            }
        }

        //проверить день на предмет что это праздникне праздник, выходной или рабочий
        public KeyValuePair<int, DataRow> checkDay(DateTime dayInfo)
        {
            bool check = false;
            if (dtWorkCalendar != null) 
            {
                for (int i = 0; i < dtWorkCalendar.Rows.Count; i++)                 //Display items in the ListView control
                {
                    DataRow drow = dtWorkCalendar.Rows[i];
                    if (                                                            //если день совпадает с днем из производственного кадендаря
                        (drow.RowState != DataRowState.Deleted) &&                  //Only row that have not been deleted
                        ((DateTime.Compare((DateTime)drow["dWork"], dayInfo.Date) == 0) ||
                         (DateTime.Compare((DateTime)drow["dSource"], dayInfo.Date) == 0))
                        )
                    {
                        check = true;
                        if (DateTime.Compare((DateTime)drow["dWork"], (DateTime)drow["dSource"]) == 0)
                            return new KeyValuePair<int, DataRow>(0, drow);         //это Праздничный день (без переносов)
                        else
                        {                                                           //перенесенная дата
                            if (DateTime.Compare((DateTime)drow["dWork"], dayInfo.Date) == 0)
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
            }
            if (!check)
            {
                if (dayInfo.Date.DayOfWeek == DayOfWeek.Saturday || dayInfo.Date.DayOfWeek == DayOfWeek.Sunday)
                    return new KeyValuePair<int, DataRow>(4, null);             //это просто Выходной день
                else
                    return new KeyValuePair<int, DataRow>(5, null);             //это просто Рабочий день
            }
            return new KeyValuePair<int, DataRow>(-1, null);
        }

        //прочитать описание дня по производственному календарю 
        public string getDateDescription(DateTime dayInfo)
        {
            string ret;// = "";
            KeyValuePair<int, DataRow> infoDate = checkDay(dayInfo.Date);
            switch (infoDate.Key)
            {
                case 0:                         //это Праздничный день (без переносов)                 
                    ret = infoDate.Value["dName"].ToString();
                    break;
                case 1:                         //это Праздничный день (перенесенная дата)
                    ret =  "Нерабочий день" +
                        "\r\n" + "Перенесено с даты " + ((DateTime)infoDate.Value["dSource"]).ToString("dd.MM.yyyy г.");// + 
//                        "\r\n" + infoDate.Value["dName"].ToString();
                    break;
                case 2:                         //это Выходной день (праздник попадает на выходной)
                    ret = "Выходной день" +
                        "\r\n" + "Перенесено на дату " + ((DateTime)infoDate.Value["dWork"]).ToString("dd.MM.yyyy г.");// + "\r\n" +
//                        infoDate.Value["dName"].ToString();
                    break;
                case 3:                         //это Рабочий день (праздник не попадает на выходной)
                    ret = "Рабочий день" +
                        "\r\n" + "(" + infoDate.Value["dLength"].ToString().ToLower() + ")" +
                        "\r\n" + "Перенесено на дату " + ((DateTime)infoDate.Value["dWork"]).ToString("dd.MM.yyyy г.");// + "\r\n" +
//                        infoDate.Value["dName"].ToString();
                    break;
                case 4:                         //это просто Выходной день
                    return "Выходной день";
//                    break;
                case 5:                         //это просто Рабочий день
                    ret = "Рабочий день";
                    break;
                default:
                    ret = "";    
                    break;
            }
            return ret;
        }

        //прочитать харектеристики дня по производственному календарю
        //вернуть страницу HTML
        public string getDateInfoHTML(DateTime dayInfo)
        {
            string WORK_AREA = "";
            string imgSrc = "";
            KeyValuePair<int, DataRow> infoDate = checkDay(dayInfo.Date);
            switch (infoDate.Key)
            {
                case 0:                         //это Праздничный день (без переносов)                 
                    imgSrc = "'data:image/png;base64, " + Properties.Resources.holiday_48.extImageToBase64Converter(ImageFormat.Png) + "'";
                    WORK_AREA =
                        "<div>" + infoDate.Value["dName"].ToString() + "</div>";// +
                                                                                //                            "<div style='font-size: 9pt; text-align: center'>" + "\r\n(" + drow["dLength"].ToString().ToLower() + ")" + "</div>";
                    break;
                case 1:                         //это Праздничный день (перенесенная дата)
                    imgSrc = "'data:image/png;base64, " + Properties.Resources.cDay_48.extImageToBase64Converter(ImageFormat.Png) + "'";
                    WORK_AREA =
                        "<div>" + "Нерабочий день" + "</div>" +
                        "<br>" +
                        "<div style='font-size: 9pt;'>" + "Перенесено с даты<br>" + ((DateTime)infoDate.Value["dSource"]).ToString("dd.MM.yyyy г.") + "<br>" + infoDate.Value["dName"].ToString() + "</div>";
                    break;
                case 2:                         //это Выходной день (праздник попадает на выходной)
                    imgSrc = "'data:image/png;base64, " + Properties.Resources.cDay_48.extImageToBase64Converter(ImageFormat.Png) + "'";
                    WORK_AREA =
                        "<div>" + "Выходной день" + "</div>" +
                        "<br>" +
                        //                                    "<div style='font-size: 9pt; text-align: center'>" + "(" + drow["dLength"].ToString().ToLower() + ")" + "</div>"+
                        "<div style='font-size: 9pt;'>" + "Перенесено на дату" + "<br>" +
                        ((DateTime)infoDate.Value["dWork"]).ToString("dd.MM.yyyy г.") + "<br>" +
                        infoDate.Value["dName"].ToString() +
                        "</div>";
                    break;
                case 3:                         //это Рабочий день (праздник не попадает на выходной)
                    imgSrc = "'data:image/png;base64, " + Properties.Resources.cDay_48.extImageToBase64Converter(ImageFormat.Png) + "'";
                    WORK_AREA =
                        "<div>" + "Рабочий день" + "</div>" +
                        "<div style='font-size: 8pt; text-align: center'>" + "(" + infoDate.Value["dLength"].ToString().ToLower() + ")" + "</div>" +
                        "<br>" +
                        "<div style='font-size: 9pt;'>" + "Перенесено на дату" + "<br>" +
                        ((DateTime)infoDate.Value["dWork"]).ToString("dd.MM.yyyy г.") + "<br>" +
                        infoDate.Value["dName"].ToString() +
                        "</div>";
                    break;
                case 4:                         //это просто Выходной день
                    imgSrc = "'data:image/png;base64, " + Properties.Resources.cDay_48.extImageToBase64Converter(ImageFormat.Png) + "'";
                    WORK_AREA =
                        "<div>" + "Выходной день" + "</div>";
                    break;
                case 5:                         //это просто Рабочий день
                    imgSrc = "'data:image/png;base64, " + Properties.Resources.wDay_48.extImageToBase64Converter(ImageFormat.Png) + "'";
                    WORK_AREA =
                        "<div>" + "Рабочий день" + "</div>";
                    break;
                default:
                    break;
            }
            WORK_AREA =
                "<div style='font-size: 14pt; text-align: center;'>" + dayInfo.ToString("dd-MM-yyyy") + "&nbsp;" +
                "<img src = " + imgSrc + " height = '24' width = '24' style='vertical-align: middle;'/>" +
                "</div>" +
                "<div style='font-size: 12pt; text-align: center;'><hr>" + WORK_AREA + "</div>";

            string html = "<body " +
                            "style = '" +
                            "background - color: " + SystemColors.Control.extHexConverter() + "; " +
                            "font-family: Geneva, Arial, Helvetica, sans-serif; " +
                            "'" +
                            ">" + WORK_AREA + "</body>";
            return html;
        }
    }
}
