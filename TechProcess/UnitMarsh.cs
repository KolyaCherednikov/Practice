using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace TechProcess
{
    public class UnitMarsh : IDisposable
    {
        private const int size = 26; //Было 10
        private int sizeRows, begine;
        private string fileMarsh;
        List<int> koef = new List<int>(25);
        Microsoft.Office.Interop.Excel.Application objectExcel;
        _Workbook bookMarch;
        private _Worksheet[] sheet;
        private _Worksheet marsh;
        private Class1[] cls;
        private Class1 clM;
        private bool flag;
        public UnitMarsh(string fileName)
        {
            flag = true;
            fileMarsh = fileName;
            objectExcel = new Application();
            // bookMarch = OpenBook.Open(objectExcel, fileMarsh);
            OpenExcelBook.OpenBook bk = new OpenExcelBook.OpenBook();
            bookMarch = bk.OpenFile(objectExcel, fileMarsh);
            marsh = (_Worksheet)bookMarch.Worksheets[1];
            if (marsh.Name != "Маршрутка") //Если ИМЯ в данной строке не является Маршрутка
            {
                flag = false;
                MessageBox.Show("Это не маршрутка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else //Переходим сюда
            {
                sheet = new _Worksheet[size];
                cls = new Class1[size];
                begine = 7; //Cтрока с которой начинаем оброботку данных.
                for (int i = 0; i < size; i++)
                {
                    sheet[i] = (_Worksheet)bookMarch.Worksheets[i + 2];
                    cls[i] = new Class1(sheet[i]);
                    int rw = 8;
                    while (cls[i].getcell(rw, 17) != null) // Проверяет листы на наличие данных. Если хотя бы на одном из листов есть данные, то оброботка данных не происходит.
                    {

                        try
                        {
                            if (begine < Convert.ToInt32(cls[i].getcell(rw, 17)))
                            {
                                begine = Convert.ToInt32(cls[i].getcell(rw, 17)); //Устанавливает номер строки с которой начинать оброботку данных.????
                            }
                            rw++;
                        }
                        catch (Exception)
                        {
                            MessageBox.Show(
                                "Неверный формат: лист " + (i + 2).ToString() + ", строка " + rw.ToString(), "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                            objectExcel.Quit();
                            return;
                        }
                    }
                }
                string str = "";
                clM = new Class1(marsh);
                sizeRows = 7;
                while (str != "*") 
                {
                    sizeRows++;
                    if (sizeRows == 5000) // Проверка на наличие метки конца листа *
                    {
                        MessageBox.Show("Нет конца листа. Проверте данные.", "Ошибка", MessageBoxButton.OK,
                                        MessageBoxImage.Error);
                        objectExcel.Quit();
                        return;
                    }
                    if (clM.getcell(sizeRows, 11) != null)
                    {
                        str = clM.getcell(sizeRows, 11).ToString();
                    }
                }
                for (int k = 0; k < koef.Capacity; k++)
                {
                    koef.Add(Convert.ToInt32(clM.getcell(8, 10)));
                }
            }
        }
        public void InsertOp(int columnOp, int sheetOp) //конвертирует единицы измерения и перебрасывает левую часть таблицы до норм расхода времени (размеры заготовок, материал и веса)
        {
            int index = 8;
            while (cls[sheetOp].getcell(index, 1) != null) //Проверяет первые колонки строк, начиная с 8-ой строки на первом листе, на заполненность
            {
                index++;
            }
            int ind = 0;
            int star = 0;
            marsh.Cells[8, 3] = 1; //Устанавливает количество в ячейке 8,3 в 1
            int col = 1;
            for (int i = begine + 1; i < sizeRows; i++) //Перебор по строкам и колонкам операций сверху вниз и слева направо. Начинаем с 8 до 21
            {
                if (clM.getcell(i, 11) != null) //Проверка на заполненность единиц измерения в 11-ой колонке
                {
                    if (clM.getcell(i, 11).ToString() == "шт" && i != 8) //Норма расходов в штуках
                    {
                        ind++;
                        string s = clM.getcell(i, 10).ToString();
                        koef[ind] = koef[ind - 1] * Convert.ToInt32(s);
                        col = koef[ind];
                        marsh.Cells[i, 3] = 1;
                        star++;
                    }

                    if (clM.getcell(i, 11).ToString()[0] == '*') //Проверяет, являестя ли первый символ в единицах измерения звездочкой
                    {
                        if (star == 0 && begine >= 8) ind += clM.getcell(i, 11).ToString().Length - 1;
                        star++;
                        ind--;
                        if (ind < 0)
                        {
                            MessageBox.Show("Неверно отмечены сборки. Проверте данные.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            objectExcel.Quit();
                            return;
                        }
                        col = koef[ind];
                    }
                }
                if (clM.getcell(i, columnOp) != null && !String.IsNullOrEmpty(clM.getcell(i, columnOp).ToString()))
                {
                    string cll = clM.getcell(i, columnOp).ToString();
                    cll = cll.Replace('.', ',');
                    for (int m = 0; m < cll.Length; m++)
                    {
                        if (!Char.IsDigit(cll[m]) && cll[m] != ',' || cll.IndexOf(',') != cll.LastIndexOf(','))
                        {
                            MessageBox.Show("Неверный формат в ячейке " + i.ToString() + "," + columnOp.ToString(),
                                            "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            objectExcel.Quit();
                            return;
                        }
                    }
                    if (Convert.ToDouble(clM.getcell(i, columnOp)) > 0 && clM.getcell(i, 1) != null) //переносит на листы
                    {
                        sheet[sheetOp].Cells[index, 1] = marsh.Cells[i, 1];
                        sheet[sheetOp].Cells[index, 2] = marsh.Cells[i, 2];
                        for (int j = 3; j < 11; j++)
                        {
                            sheet[sheetOp].Cells[index, j] = marsh.Cells[i, j + 1];
                        }
                        sheet[sheetOp].Cells[index, 11] = col * Convert.ToDouble(clM.getcell(i, 3));
                        if (Convert.ToInt32('A') + columnOp - 1 > 90)
                        {
                            int c = Convert.ToInt32('A') + columnOp - 27;
                            char ch = Convert.ToChar(c);
                            string s = "=Маршрутка!A" + ch.ToString() + i.ToString() + "\n";
                            sheet[sheetOp].Cells[index, 12] = s;
                        }
                        else
                        {
                            int c = Convert.ToInt32('A') + columnOp - 1;
                            char ch = Convert.ToChar(c);
                            string s = "=Маршрутка!" + ch.ToString() + i.ToString() + "\n";
                            sheet[sheetOp].Cells[index, 12] = s;
                        }
                        //sheet[sheetOp].Cells[index, 12] = marsh.Cells[i, columnOp];
                        string str = "=K" + index + "*M$6\n";
                        sheet[sheetOp].Cells[index, 13] = str;
                        sheet[sheetOp].Cells[index, 17] = i;
                        index++;
                    }
                }
            }
            if (ind > 0)
            {
                MessageBox.Show("Неверно отмечены сборки. Проверте данные.",
                   "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                objectExcel.Quit();
                return;
            }
        }
        public void SynshronizeMarsh(int columnOp, int sheetOp) //что-то выделяет цветом и шрифтом
        {
            int index = 8;
            while (cls[sheetOp].getcell(index, 1) != null) //проверяет заполнено ли название на листе операций
            {
                if (cls[sheetOp].getcell(index, 17) != null) //проверяет заполнен ли номер строки маршрутки на листе операций
                {
                    string s = cls[sheetOp].getcell(index, 17).ToString();
                    if (cls[sheetOp].getcell(index, 15) != null) //проверяет заполнено ли фактически выполненное
                    {
                        SelectCell(cls[sheetOp], index, 12, 16);
                        SelectCell(clM, Convert.ToInt32(s), columnOp, 14);
                    }
                    else
                    {
                        DeSelectCell(cls[sheetOp], index, 12, 14);
                        DeSelectCell(clM, Convert.ToInt32(s), columnOp, 10);
                    }
                }
                index++;
            }

        }
        public void SelectCell(Class1 cell, int i, int j, int fontHeigth)
        {
            cell.cellFontSize(fontHeigth, i, j);
            cell.cellFontColor(i, j, 2);
            cell.cellColor(i, j, 25);
        }
        public void DeSelectCell(Class1 cell, int i, int j, int fontHeigth)
        {
            cell.cellFontSize(fontHeigth, i, j);
            cell.cellFontColor(i, j, 1);
            cell.cellColor(i, j, 0);
        }
        public int Size
        {
            get { return size; }
        }
        public int SizeRows
        {
            get { return sizeRows; }
        }
        public Class1[] Cls
        {
            get { return cls; }
        }
        public Class1 ClM
        {
            get { return clM; }
        }
        public _Workbook BookMarsh
        {
            get { return bookMarch; }
        }
        public _Worksheet[] Sheet
        {
            get { return sheet; }
        }
        public _Worksheet Marsh
        {
            get { return marsh; }
        }
        public Application ObjectExcel
        {
            get { return objectExcel; }
            set { objectExcel = value; }
        }
        public bool Flag
        {
            get { return flag; }
        }
        public void Dispose()
        {
            this.objectExcel.Quit();
            clM = null;
            cls = null;
        }
    }
}
