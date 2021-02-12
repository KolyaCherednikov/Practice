using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using LibTP;

namespace TechProcess
{
    public class RoutedThread
    {
        private string fileMarsh, fileWorker, fileFin;
        private Worker worker;
        private RunWorks wrun;
        private int sheetOp;
        private UnitMarsh un;
        public RoutedThread()
        {

        }
        public void run()
        {
            un = new UnitMarsh(FileMarsh);
            if (un.Flag)
            {
                for (int i = 0; i < un.Size; i++)
                {
                    un.InsertOp(i + 16, i);
                    un.SynshronizeMarsh(i + 16, i);
                }
                un.ObjectExcel.Visible = true;
            }
            else
            {
                un.ObjectExcel.Quit();
                return;
            }
        }
        public UnitMarsh Unit
        {
            get { return un; }
        }
        public Worker Work
        {
            get { return worker; }
        }
        public RunWorks Wrun
        {
            get { return wrun; }
        }
        public int SheetOp
        {
            get { return sheetOp; }
            set { sheetOp = value; }
        }
        public string FileMarsh
        {
            get { return fileMarsh; }
            set { fileMarsh = value; }
        }
        public string FileWorker
        {
            get { return fileWorker; }
            set { fileWorker = value; }
        }
        public string FileFin
        {
            get { return fileFin; }
            set { fileFin = value; }
        }
        public void runW()
        {
            un = new UnitMarsh(FileMarsh);
            if (un.Flag)
            {
                for (int i = 0; i < un.Size; i++)
                {
                    un.SynshronizeMarsh(i + 16, i);
                }
                un.ObjectExcel.Visible = true;
            }
            else
            {
                un.ObjectExcel.Quit();
                return;
            }
        }
        public void runS()
        {
            un = new UnitMarsh(FileMarsh);
            if (un.Flag)
            {
                un.ObjectExcel.Visible = true;
            }
            else
            {
                un.ObjectExcel.Quit();
                return;
            }
        }
        public void myMain()
        {
            worker = new Worker(FileWorker);
            if (worker.Flag)
            {
                worker.Distribution(sheetOp, un);
                worker.ObjectExcel.Visible = true;
            }
            else
            {
                worker.ObjectExcel.Quit();
                return;
            }
        }
        public void myMain1()
        {
            worker = new Worker(FileWorker);
            if (worker.Flag) worker.ObjectExcel.Visible = true;
            else
            {
                worker.ObjectExcel.Quit();
                return;
            }
        }
        public void myMain2()
        {
            worker.Distribution(sheetOp, un);
        }
        public void myMain3()
        {
            for (int i = 0; i < un.Size; i++)
            {
                un.SynshronizeMarsh(i + 16, i);
            }
        }
        public void myMain4()
        {
            worker.SynshronizeOp(sheetOp, un);
            un.SynshronizeMarsh(sheetOp + 16, sheetOp);
        }
        public void myMain5()
        {
            wrun = new RunWorks(FileFin);
            if (wrun.Flag)
            {
                if (worker.ObjectExcel.Visible)
                {
                    wrun.Distribution(worker);
                    wrun.ObjectExcel.Visible = true;
                }
                else
                {
                    MessageBox.Show("Ошибка! Лист задания закрыт.",
                                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    wrun.ObjectExcel.Quit();
                    return;
                }
            }
            else
            {
                wrun.ObjectExcel.Quit();
                return;
            }
        }
    }
}
