using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace TechProcess
{
    public class Worker : IDisposable
    {
        private int sizeWork;
        private string fileWorker;
        Microsoft.Office.Interop.Excel.Application objectExcel;
        _Workbook bookWorker;
        private _Worksheet[] sheet;
        private Class1[] clWork;
        private bool flag;
        public Worker(string fileName)
        {
            flag = true;
            fileWorker = fileName;
            objectExcel = new Application();
            //bookWorker = OpenBook.Open(objectExcel, fileWorker);
            OpenExcelBook.OpenBook bk = new OpenExcelBook.OpenBook();
            bookWorker = bk.OpenFile(objectExcel, fileWorker);
            sizeWork = bookWorker.Sheets.Count;
            sheet = new _Worksheet[sizeWork];
            clWork = new Class1[sizeWork];
            if (bookWorker.Worksheets.Count >= sizeWork)
            {
                for (int i = 0; i < sizeWork; i++)
                {
                    sheet[i] = (_Worksheet)bookWorker.Worksheets[i + 1];
                    clWork[i] = new Class1(sheet[i]);
                }
                if (clWork[0].getcell(2, 17).ToString() != "Номер строки маршрутки")
                {
                    flag = false;
                    MessageBox.Show("Это не лист заданий", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
        }
        public void Distribution(int numberOp, UnitMarsh unit) //Распределяет исполнителей
        {
            int[] ind = new int[sizeWork];
            string[] worker = new string[sizeWork];
            int delta = 19;
            while (unit.Cls[numberOp].getcell(3, delta) != null) //на 3 строке 19 столбца берем Имена и Фамилии
            {
                worker[delta - 19] = unit.Cls[numberOp].getcell(3, delta).ToString();
                delta++;
            }
            for (int i = 0; i < sizeWork; i++) // перебор по листам
            {
                ind[i] = 5;
                while (clWork[i].getcell(ind[i], 1) != null) //ищем последнюю незаполненную строку
                {
                    ind[i]++;
                }
            }

            for (int i = 0; i < sizeWork; i++)
            {
                int tik = 8;
                int tikWork = 1;
                int ecuals = 0;
                for (int j = 5; j < ind[i]; j++) //
                {
                    if (clWork[i].getcell(j, 2) == null) //Проверка является ли запись установкой
                    {
                        if (clWork[i].getcell(j, 1).ToString() == unit.ClM.getcell(3, 20).ToString())
                        {
                            ecuals = j + 1; //Значение строки установки
                            break;
                        }
                    }
                }
                while (unit.Cls[numberOp].getcell(tik, 1) != null) //Проверка на значения в разных листах маршрутки
                {
                    int step = 0;
                    if (ecuals != 0) //Проверка на совпадение наиминования установок
                    {
                        for (int j = ecuals; j < ind[i]; j++)
                        {
                            if (clWork[i].getcell(j, 17) != null)
                            {
                                if (unit.Cls[numberOp].getcell(tik, 1).ToString() ==
                                    clWork[i].getcell(j, 1).ToString()
                                && unit.Cls[numberOp].getcell(tik, 17).ToString() ==
                                clWork[i].getcell(j, 17).ToString())
                                {
                                    ++step;
                                    break;
                                }
                            }
                            else if (clWork[i].getcell(j, 14) == null) break;
                        }
                    }
                    if (step == 0)
                    {
                        if (unit.Cls[numberOp].getcell(tik, 16) != null)
                        {
                            if (unit.Cls[numberOp].getcell(tik, 16).ToString() == worker[i])
                            {
                                for (int j = 1; j < 13; j++)
                                    sheet[i].Cells[ind[i] + tikWork, j] = unit.Sheet[numberOp].Cells[tik, j];
                                sheet[i].Cells[ind[i] + tikWork, 13] = "=L" + (ind[i] + tikWork).ToString() + "*M$3/K" +
                                                                       (ind[i] + tikWork).ToString() + "\n";
                                sheet[i].Cells[ind[i] + tikWork, 14] = unit.Sheet[numberOp].Cells[tik, 13];
                                sheet[i].Cells[ind[i] + tikWork, 16] = unit.Sheet[numberOp].Cells[tik, 15];
                                sheet[i].Cells[ind[i] + tikWork, 17] = unit.Sheet[numberOp].Cells[tik, 17];
                                sheet[i].Cells[ind[i] + tikWork, 18] = tik;
                                tikWork++;
                            }
                        }
                    }
                    tik++;
                }
                if (tikWork > 1)
                {
                    clWork[i].cellFontSize(16, ind[i], 1);
                    clWork[i].cellFontColor(ind[i], 1, 3);
                    if (unit.ClM.getcell(3, 20) != null) sheet[i].Cells[ind[i], 1] = unit.ClM.getcell(3, 20).ToString();
                    else sheet[i].Cells[ind[i], 1] = unit.ClM.getcell(8, 1).ToString();
                }
                sheet[i].Cells[1, 1] = worker[i];
            }

        }
        public void SynshronizeOp(int sheetOp, UnitMarsh unit)
        {
            for (int i = 0; i < clWork.Length; i++)
            {
                int row = 0;
                int index = 5;
                while (clWork[i].getcell(index, 1) != null)
                {
                    if (clWork[i].getcell(index, 17) != null)
                    {
                        if (clWork[i].getcell(index, 18) != null)
                        {
                            row = Convert.ToInt32(clWork[i].getcell(index, 18));
                            if (clWork[i].getcell(index, 12) != null &&
                                        unit.Cls[sheetOp].getcell(row, 17) != null)
                            {
                                if (unit.Cls[sheetOp].getcell(row, 1).ToString() ==
                                    clWork[i].getcell(index, 1).ToString()
                                    &&
                                    unit.Cls[sheetOp].getcell(row, 17).ToString() ==
                                    clWork[i].getcell(index, 17).ToString())
                                {
                                    if (clWork[i].getcell(index, 12).ToString() !=
                                        unit.Cls[sheetOp].getcell(row, 12).ToString())
                                        sheet[i].Cells[index, 12] = unit.Cls[sheetOp].getcell(row, 12).ToString();
                                }
                            }

                            if (clWork[i].getcell(index, 16) != null)
                            {
                                if (unit.Cls[sheetOp].getcell(row, 1) != null &&
                                    unit.Cls[sheetOp].getcell(row, 17) != null)
                                {
                                    if (unit.Cls[sheetOp].getcell(row, 1).ToString() ==
                                        clWork[i].getcell(index, 1).ToString()
                                        &&
                                        unit.Cls[sheetOp].getcell(row, 17).ToString() ==
                                        clWork[i].getcell(index, 17).ToString())
                                    {
                                        unit.SelectCell(clWork[i], index, 12, 16);
                                        unit.Sheet[sheetOp].Cells[row, 15] = clWork[i].getcell(index, 16).ToString();
                                        unit.SelectCell(unit.Cls[sheetOp], row, 12, 16);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (clWork[i].getcell(index, 17) != null)
                        {
                            if (clWork[i].getcell(index, 18) != null)
                            {
                                row = Convert.ToInt32(clWork[i].getcell(index, 18));
                                if (unit.Cls[sheetOp].getcell(row, 1) != null &&
                                    unit.Cls[sheetOp].getcell(row, 17) != null)
                                    if (unit.Cls[sheetOp].getcell(row, 1).ToString() == clWork[i].getcell(index, 1).ToString()
                                            &&
                                            unit.Cls[sheetOp].getcell(row, 17).ToString() ==
                                            clWork[i].getcell(index, 17).ToString())
                                    {
                                        unit.DeSelectCell(clWork[i], index, 12, 14);
                                        unit.DeSelectCell(unit.Cls[sheetOp], row, 12, 14);
                                        unit.Sheet[sheetOp].Cells[row, 14] = sheet[i].Cells[index, 15];
                                    }
                            }
                        }
                    }
                    index++;
                }
            }
        }
        public Application ObjectExcel
        {
            get { return objectExcel; }
            set { objectExcel = value; }
        }
        public Class1[] ClWork
        {
            get { return clWork; }
        }
        public _Worksheet[] Sheet
        {
            get { return sheet; }
        }
        public bool Flag
        {
            get { return flag; }
        }
        public void Dispose()
        {
            this.objectExcel.Quit();
        }
    }
}
