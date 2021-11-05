using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimeWorkTracking
{
    //https://www.akadia.com/services/dotnet_listview_sort_dataset.html
    // Этот класс является реализацией интерфейса IComparer
    public class clListViewItemComparer : IComparer
    {
        private int ColumnToSort;                               //Определяет столбец для сортировки
        private SortOrder OrderOfSort;                          //Определяет порядок сортировки (т.е. «По возрастанию»).
        private readonly CaseInsensitiveComparer ObjectCompare; //Объект сравнения без учета регистра
        public clListViewItemComparer()                           //Конструктор класса, инициализирует различные элементы
        {
            ColumnToSort = 0;                                   //Инициализирует столбец равным 0
            OrderOfSort = SortOrder.None;                       //Инициализируем порядок сортировки как «нет»
            ObjectCompare = new CaseInsensitiveComparer();      //Инициализируем объект CaseInsensitiveComparer
        }

        // Этот метод унаследован от интерфейса IComparer.
        // Он сравнивает два переданных объекта, используя
        // сравнение без учета регистра.
        //
        // x: первый объект для сравнения
        // y: второй объект для сравнения
        //
        // результат сравнения. «0», если равно,
        // отрицательное, если 'x' меньше 'y' и
        // положительно, если 'x' больше 'y'
        public int Compare(object x, object y)
        {
            int compareResult;
            ListViewItem listviewX, listviewY;

            //Приведение объектов для сравнения к объектам ListViewItem
            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;

            //Без учета регистра Compare
            compareResult = ObjectCompare.Compare(
                listviewX.SubItems[ColumnToSort].Text,
                listviewY.SubItems[ColumnToSort].Text
            );

            // Вычислить правильное возвращаемое значение на основе сравнения объектов
            if (OrderOfSort == SortOrder.Ascending)
            {
                //Выбрана сортировка по возрастанию, вернуть нормальный результат операции
                return compareResult;
            }
            else if (OrderOfSort == SortOrder.Descending)
            {
                //Выбрана сортировка по убыванию, вернуть отрицательный результат операции сравнения
                return (-compareResult);
            }
            else
            {
                return 0;       // Верните '0', чтобы указать, что они равны
            }
        }

        // Получает или задает номер столбца, к которому
        // применяется операция сортировки (по умолчанию «0»).
        public int SortColumn
        {
            set
            {
                ColumnToSort = value;
            }
            get
            {
                return ColumnToSort;
            }
        }

        // Получает или задает порядок сортировки для применения
        // (например, «По возрастанию» или «По убыванию»).
        public SortOrder Order
        {
            set
            {
                OrderOfSort = value;
            }
            get
            {
                return OrderOfSort;
            }
        }
    }
}
