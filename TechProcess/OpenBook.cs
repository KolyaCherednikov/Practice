using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;

namespace TechProcess
{
    public static class OpenBook
    {
        public static _Workbook Open(Application app, string file)
        {
            _Workbook book;
            book = (_Workbook)app.Workbooks._Open(file, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            return book;
        }
    }
}
