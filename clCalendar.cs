﻿using System;
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
        private DataTable dtWorkCalendar;                                           //производственный календаоь
        public clCalendar(string cs, string sql)                      //конструктор
        {
            dtWorkCalendar = clMsSqlDatabase.TableRequest(cs, sql);
        }

        //получить все даты праздников (перенос)
        public List<DateTime> getListWorkHoliday()
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

        //проdерить дату на праздник (перенос)
        public bool chechWorkHoliday(DateTime chDate)
        {
            bool ret = false;
            for (int i = 0; i < dtWorkCalendar.Rows.Count; i++)         //Display items in the ListView control
            {
                DataRow drow = dtWorkCalendar.Rows[i];
                if (drow.RowState != DataRowState.Deleted)              //Only row that have not been deleted
                {
                    if (DateTime.Compare(chDate.Date, (DateTime)drow["dWork"]) == 0 || drow["dType"].ToString()== "Праздничный") 
                    {
                        ret= true;
                    }
                }
            }
            return ret;
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

        //прочитать харектеристики дня по производственному календарю 
        public string getDateInfo(DateTime dayInfo)
        {
            string WORK_AREA = "";
            string imgSrc = "";
            KeyValuePair<int, DataRow> infoDate = checkDay(dayInfo);
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
                        "<br>" +
                        //                     "<div style='font-size: 9pt; text-align: center'>" + "(" + drow["dLength"].ToString().ToLower() + ")" + "</div>" +
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