using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using LibTP;


namespace TechProcess
{
    public partial class Form1 : Form
    {
        private RoutedThread thread;
        private int sheetOp;
        public Form1()
        {
            InitializeComponent();
            thread=new RoutedThread();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (thread != null) thread = null;
            Application.Exit();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnMarsh_Click();
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (thread != null) thread = null; 
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            openMarsh.Enabled = false;
            openWorks.Enabled = false;
            label1.Text = "Выберите файл маршрутки, или смените задание";
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
        }
        private void openAutohen_Click(object sender, EventArgs e)
        {
            sheetOp = 0;
            thread.SheetOp = sheetOp;
            OpenOperation(sheetOp);
        }
        private void пильщикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sheetOp = 1;
            thread.SheetOp = sheetOp;
            OpenOperation(sheetOp);
        }
        private void рубщикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sheetOp = 2;
            thread.SheetOp = sheetOp;
            OpenOperation(sheetOp);
        }
        private void слесариToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sheetOp = 3;
            thread.SheetOp = sheetOp;
            OpenOperation(sheetOp);
        }
        private void сварщикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sheetOp = 4;
            thread.SheetOp = sheetOp;
            OpenOperation(sheetOp);
        }
        private void токариToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sheetOp = 5;
            thread.SheetOp = sheetOp;
            OpenOperation(sheetOp);
        }
        private void фрезеровщикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sheetOp = 6;
            thread.SheetOp = sheetOp;
            OpenOperation(sheetOp);
        }
        private void гибкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sheetOp = 7;
            thread.SheetOp = sheetOp;
            OpenOperation(sheetOp);
        }

        private void маляраToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sheetOp = 8;
            thread.SheetOp = sheetOp;
            OpenOperation(sheetOp);
        }

        private void прочиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sheetOp = 9;
            thread.SheetOp = sheetOp;
            OpenOperation(sheetOp);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
                if (thread.Work != null && thread.Unit != null)
                {
                    if (thread.Work.ObjectExcel.Visible && thread.Unit.ObjectExcel.Visible) thread.Work.SynshronizeOp(sheetOp, thread.Unit);
                    {
                        Thread newThread = new Thread(thread.myMain4);
                        newThread.Start();
                        Thread.Sleep(0);
                    }
                }
                if (thread.Unit != null && thread.Work == null)
                {
                    Thread newThread = new Thread(thread.myMain3);
                    newThread.Start();
                    Thread.Sleep(0);
                }
            
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            openMarsh.Enabled = true;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
           
                if (thread.Unit != null)
                {
                    if (thread.Unit.ObjectExcel.Visible)
                    {
                        label1.Text = "Выберите лист задания";
                        openWorks.Enabled = true;
                    }
                }
                else
                {
                    label1.Text = "Выберите файл маршрутки";
                    openWorks.Enabled = false;
                }
                if (thread.Work != null)
                {
                    if (thread.Work.ObjectExcel.Visible) groupBox2.Visible = true;
                }
            
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            openMarsh.Enabled = true;
            groupBox4.Visible = false;
           
                if (thread.Unit != null)
                {
                    if (thread.Unit.ObjectExcel.Visible)
                    {
                        label1.Text = "Выберите лист задания";
                        openWorks.Enabled = true;
                        groupBox3.Visible = true;
                    }
                }
                else label1.Text = "Выберите файл маршрутки";
                if (thread.Work != null)
                {
                    if (thread.Work.ObjectExcel.Visible)
                    {
                        groupBox2.Visible = true;
                    }
                }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
                if (thread.Unit != null)
                {
                    if (thread.Unit.ObjectExcel.Visible)
                    {
                        thread.Unit.ObjectExcel.Quit();
                        thread = null;
                    }
                    label1.Text = "Выберите другую маршрутку";
                }
                openMarsh.PerformClick();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Thread newThread = new Thread(thread.myMain2);
            newThread.Start();
            Thread.Sleep(0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "(*.xls)|*.xls|(*.xlsx)|*.xlsx";
            this.BringToFront();
            if (opf.ShowDialog() == DialogResult.OK)
            {
                thread.FileFin = opf.FileName;
                label1.Text = "Производится обработка файла\n" + opf.FileName + "\nЭто может занять несколько минут\nНе запускайте Excel";
                
                if (thread.Work.ObjectExcel.Visible)
                {
                    Thread newThread = new Thread(thread.myMain5);
                    newThread.Start();
                    Thread.Sleep(0);
                }
                else
                {
                    MessageBox.Show("Ошибка! Лист задания закрыт.",
                            "TehProcess", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    thread.Wrun.ObjectExcel.Quit();
                    return;
                }
            }
            else
            {
                return;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButton4.Checked) groupBox4.Visible = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            
                if (thread.Unit!= null)
                {
                    if (thread.Unit.ObjectExcel.Visible)
                    {
                        label1.Text = "Выберите лист заданияи";
                        openWorks.Enabled = true;
                    }
                }
                else
                {
                    label1.Text = "Выберите файл маршрутки";
                    openWorks.Enabled = false;
                }
            
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            openMarsh.Enabled = true;
            openWorks.Enabled = false;
            label1.Text = "Выберите файл маршрутки";
        }

        private void radioButton4_Click(object sender, EventArgs e)
        {
            openMarsh.Enabled = false;
            openWorks.Enabled = true;
            
                if (thread.Work != null) groupBox4.Visible = true;
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButton2.Checked) groupBox3.Visible = false;
        }
        private void btnMarsh_Click()
        {
            System.Windows.Forms.OpenFileDialog opf = new System.Windows.Forms.OpenFileDialog();
            opf.Filter = "(*.xls)|*.xls|(*.xlsx)|*.xlsx";
            this.BringToFront();
            if (opf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                thread.FileMarsh = opf.FileName;
                label1.Text = "Производится обработка файла\n" + opf.FileName + "\nЭто может занять несколько минут\nНе запускайте Excel";
                if (radioButton1.Checked)
                {
                   Thread newThread=new Thread(thread.run);
                    newThread.Start();
                    Thread.Sleep(0);
                }
                if (radioButton3.Checked)
                {
                    label1.Text = "Производится обработка файла\n" + opf.FileName + "\nЭто может занять несколько минут\nНе запускайте Excel";
                    Thread newThread = new Thread(thread.runW);
                    newThread.Start();
                    Thread.Sleep(0);
                    label1.Text = "Выберите лист задания";
                    openWorks.Enabled = true;
                }
                if (radioButton2.Checked)
                {
                    label1.Text = "Выберите лист задания";
                    Thread newThread = new Thread(thread.runS);
                    newThread.Start();
                    Thread.Sleep(0);
                    openWorks.Enabled = true;
                    groupBox3.Visible = true;
                }

            }
            else
            {
                return;
            }
        }
        protected void OpenOperation(int sheetOp)
        {
            System.Windows.Forms.OpenFileDialog opf = new System.Windows.Forms.OpenFileDialog();
            opf.Filter = "(*.xls)|*.xls|(*.xlsx)|*.xlsx";
            this.BringToFront();
            if (opf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                thread.FileWorker = opf.FileName;
                if (radioButton3.Checked)
                {
                    label1.Text = "Производится обработка файла\n" + opf.FileName + "\nЭто может занять несколько минут\nНе запускайте Excel";
                    Thread newThread1 = new Thread(thread.myMain);
                    newThread1.Start();
                    Thread.Sleep(0);
                }
                else
                {
                    Thread newThread1 = new Thread(thread.myMain1);
                    newThread1.Start();
                    Thread.Sleep(0);
                }
                if (radioButton1.Checked || radioButton3.Checked) groupBox2.Visible = true;
                if (radioButton4.Checked) groupBox4.Visible = true;
            }
            else
            {
                return;
            }
        }
    }
}
