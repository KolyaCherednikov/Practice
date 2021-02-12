using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace TechProcess
{
    public class RunWorks : IDisposable
    {
        private int sizeWork;
        private string fileWorker;
        Microsoft.Office.Interop.Excel.Application objectExcel;
        _Workbook bookWorker;
        private _Worksheet[] sheet;
        private Class1[] clRun;
        private bool flag;
        public RunWorks(string fileName)
        {
            flag = true;
            fileWorker = fileName;
            objectExcel = new Application();
            //bookWorker = OpenBook.Open(objectExcel, fileWorker);
            OpenExcelBook.OpenBook bk = new OpenExcelBook.OpenBook();
            bookWorker = bk.OpenFile(objectExcel, fileWorker);
            sizeWork = bookWorker.Sheets.Count;
            sheet = new _Worksheet[sizeWork];
            clRun = new Class1[sizeWork];
            if (bookWorker.Worksheets.Count >= sizeWork)
            {
                for (int i = 0; i < sizeWork; i++)
                {
                    sheet[i] = (_Worksheet)bookWorker.Worksheets[i + 1];
                    clRun[i] = new Class1(sheet[i]);
                }
            }
            if (clRun[0].getcell(2, 17).ToString() != "Стоимость")
            {
                flag = false;
                MessageBox.Show("Это не лист выполненных заданий", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            int[] ind = new int[sizeWork];
            for (int i = 0; i < sizeWork; i++)
            {
                ind[i] = 5;
                while (clRun[i].getcell(ind[i], 1) != null)
                {
                    ind[i]++;
                }
            }
        }
        public void Distribution(Worker work)
        {
            int[] ind = new int[sizeWork];
            for (int i = 0; i < sizeWork; i++)
            {
                ind[i] = 5;
                while (clRun[i].getcell(ind[i], 1) != null)
                {
                    ind[i]++;
                }
            }
            for (int i = 0; i < sizeWork; i++)
            {
                int tik = 5;
                int tikWork = 1;
                while (work.ClWork[i].getcell(tik, 1) != null)
                {
                    if (work.ClWork[i].getcell(tik, 17) == null)
                    {
                        sheet[i].Cells[ind[i] + tikWork, 1] = work.Sheet[i].Cells[tik, 1];
                        sheet[i].Cells.get_Range(sheet[i].Cells[ind[i] + tikWork, 1], sheet[i].Cells[ind[i] + tikWork, 1]).Font.Size = 16;
                        sheet[i].Cells.get_Range(sheet[i].Cells[ind[i] + tikWork, 1], sheet[i].Cells[ind[i] + tikWork, 1]).Font.ColorIndex = 3;
                        tikWork++;
                    }
                    if (work.ClWork[i].getcell(tik, 16) != null)
                    {
                        int inof = 0;
                        for (int j = 5; j < ind[i]; j++)
                        {
                            if (work.ClWork[i].getcell(tik, 16).ToString() == clRun[i].getcell(j, 16).ToString()
                                && work.ClWork[i].getcell(tik, 1).ToString() == clRun[i].getcell(j, 1).ToString()) inof++;
                        }
                        if (inof == 0)
                        {
                            for (int j = 1; j < 17; j++)
                                sheet[i].Cells[ind[i] + tikWork, j] = work.Sheet[i].Cells[tik, j];
                            sheet[i].Cells[ind[i] + tikWork, 17] = "=M" + (ind[i] + tikWork).ToString() + "*N" +
                                                                   (ind[i] + tikWork).ToString() + "\n";
                        }
                        tikWork++;
                    }
                    tik++;
                }
            }
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
        }
    }
}
