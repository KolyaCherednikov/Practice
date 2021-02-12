using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;

namespace TechProcess
{
    public class Class1
    {
        private _Worksheet sheet;
        public Class1(_Worksheet sh)
        {
            this.sheet = sh;
        }
        public object getcell(int i, int j)
        {
            object first = sheet.get_Range(sheet.Cells[i, j], sheet.Cells[i, j]).get_Value(Type.Missing);
            return first;
        }
        public void cellFontSize(int size, int i, int j)
        {
            sheet.get_Range(sheet.Cells[i, j], sheet.Cells[i, j]).Font.Size = size;
        }
        public void cellFontColor(int i, int j, int ci)
        {
            sheet.get_Range(sheet.Cells[i, j], sheet.Cells[i, j]).Font.ColorIndex = ci;
        }
        public void cellFontStyle(int i, int j, int ci)
        {
            sheet.get_Range(sheet.Cells[i, j], sheet.Cells[i, j]).Font.Bold = ci;
        }
        public void cellBorderColor(int i, int j, int ci)
        {
            sheet.get_Range(sheet.Cells[i, j], sheet.Cells[i, j]).Borders.ColorIndex = ci;
        }
        public void cellBorderLine(int i, int j, XlLineStyle line, XlBorderWeight weight)
        {
            sheet.get_Range(sheet.Cells[i, j], sheet.Cells[i, j]).Borders.LineStyle = line;
            sheet.get_Range(sheet.Cells[i, j], sheet.Cells[i, j]).Borders.Weight = weight;
        }
        public void cellColor(int i, int j, int ci)
        {
            sheet.get_Range(sheet.Cells[i, j], sheet.Cells[i, j]).Interior.ColorIndex = ci;
        }
    }
}
