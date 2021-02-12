namespace TechProcess
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMarsh = new System.Windows.Forms.ToolStripMenuItem();
            this.openWorks = new System.Windows.Forms.ToolStripMenuItem();
            this.openAutohen = new System.Windows.Forms.ToolStripMenuItem();
            this.пильщикиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.рубщикиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.слесариToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сварщикиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.токариToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фрезеровщикиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.гибкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.маляраToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.прочиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightCyan;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(525, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMarsh,
            this.openWorks,
            this.toolStripSeparator1,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // openMarsh
            // 
            this.openMarsh.Name = "openMarsh";
            this.openMarsh.Size = new System.Drawing.Size(152, 22);
            this.openMarsh.Text = "Маршрутка";
            this.openMarsh.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // openWorks
            // 
            this.openWorks.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openAutohen,
            this.пильщикиToolStripMenuItem,
            this.рубщикиToolStripMenuItem,
            this.слесариToolStripMenuItem,
            this.сварщикиToolStripMenuItem,
            this.токариToolStripMenuItem,
            this.фрезеровщикиToolStripMenuItem,
            this.гибкаToolStripMenuItem,
            this.маляраToolStripMenuItem,
            this.прочиеToolStripMenuItem});
            this.openWorks.Name = "openWorks";
            this.openWorks.Size = new System.Drawing.Size(152, 22);
            this.openWorks.Text = "Рабочие";
            // 
            // openAutohen
            // 
            this.openAutohen.Name = "openAutohen";
            this.openAutohen.Size = new System.Drawing.Size(158, 22);
            this.openAutohen.Text = "Автоген";
            this.openAutohen.Click += new System.EventHandler(this.openAutohen_Click);
            // 
            // пильщикиToolStripMenuItem
            // 
            this.пильщикиToolStripMenuItem.Name = "пильщикиToolStripMenuItem";
            this.пильщикиToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.пильщикиToolStripMenuItem.Text = "Пильщики";
            this.пильщикиToolStripMenuItem.Click += new System.EventHandler(this.пильщикиToolStripMenuItem_Click);
            // 
            // рубщикиToolStripMenuItem
            // 
            this.рубщикиToolStripMenuItem.Name = "рубщикиToolStripMenuItem";
            this.рубщикиToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.рубщикиToolStripMenuItem.Text = "Рубщики";
            this.рубщикиToolStripMenuItem.Click += new System.EventHandler(this.рубщикиToolStripMenuItem_Click);
            // 
            // слесариToolStripMenuItem
            // 
            this.слесариToolStripMenuItem.Name = "слесариToolStripMenuItem";
            this.слесариToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.слесариToolStripMenuItem.Text = "Слесари";
            this.слесариToolStripMenuItem.Click += new System.EventHandler(this.слесариToolStripMenuItem_Click);
            // 
            // сварщикиToolStripMenuItem
            // 
            this.сварщикиToolStripMenuItem.Name = "сварщикиToolStripMenuItem";
            this.сварщикиToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.сварщикиToolStripMenuItem.Text = "Сварщики";
            this.сварщикиToolStripMenuItem.Click += new System.EventHandler(this.сварщикиToolStripMenuItem_Click);
            // 
            // токариToolStripMenuItem
            // 
            this.токариToolStripMenuItem.Name = "токариToolStripMenuItem";
            this.токариToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.токариToolStripMenuItem.Text = "Токари";
            this.токариToolStripMenuItem.Click += new System.EventHandler(this.токариToolStripMenuItem_Click);
            // 
            // фрезеровщикиToolStripMenuItem
            // 
            this.фрезеровщикиToolStripMenuItem.Name = "фрезеровщикиToolStripMenuItem";
            this.фрезеровщикиToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.фрезеровщикиToolStripMenuItem.Text = "Фрезеровщики";
            this.фрезеровщикиToolStripMenuItem.Click += new System.EventHandler(this.фрезеровщикиToolStripMenuItem_Click);
            // 
            // гибкаToolStripMenuItem
            // 
            this.гибкаToolStripMenuItem.Name = "гибкаToolStripMenuItem";
            this.гибкаToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.гибкаToolStripMenuItem.Text = "Гибка";
            this.гибкаToolStripMenuItem.Click += new System.EventHandler(this.гибкаToolStripMenuItem_Click);
            // 
            // маляраToolStripMenuItem
            // 
            this.маляраToolStripMenuItem.Name = "маляраToolStripMenuItem";
            this.маляраToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.маляраToolStripMenuItem.Text = "Плазма";
            this.маляраToolStripMenuItem.Click += new System.EventHandler(this.маляраToolStripMenuItem_Click);
            // 
            // прочиеToolStripMenuItem
            // 
            this.прочиеToolStripMenuItem.Name = "прочиеToolStripMenuItem";
            this.прочиеToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.прочиеToolStripMenuItem.Text = "Прочие";
            this.прочиеToolStripMenuItem.Click += new System.EventHandler(this.прочиеToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(35, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.groupBox1.Location = new System.Drawing.Point(12, 135);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 200);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Задание";
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(6, 123);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(105, 20);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.Text = "Стоимость";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.Click += new System.EventHandler(this.radioButton4_Click);
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(6, 55);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(233, 20);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "Распределение по рабочим";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.Click += new System.EventHandler(this.radioButton3_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 89);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(118, 20);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "Выполнение";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.Click += new System.EventHandler(this.radioButton2_Click);
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 21);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(250, 20);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Text = "Распределение по операциям";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Click += new System.EventHandler(this.radioButton1_Click);
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(6, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(206, 35);
            this.button1.TabIndex = 4;
            this.button1.Text = "Синхронизировать";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(6, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 40);
            this.button2.TabIndex = 5;
            this.button2.Text = "Новая\r\nмаршрутка";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.Window;
            this.groupBox2.Location = new System.Drawing.Point(295, 135);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(218, 67);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Добавить";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(113, 22);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(99, 39);
            this.button3.TabIndex = 6;
            this.button3.Text = "Добавить";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.Window;
            this.groupBox3.Location = new System.Drawing.Point(295, 202);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(218, 62);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Выполнение";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Black;
            this.button4.Location = new System.Drawing.Point(7, 21);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(205, 41);
            this.button4.TabIndex = 5;
            this.button4.Text = "Переместить\r\nвыполненные";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button4);
            this.groupBox4.ForeColor = System.Drawing.SystemColors.Window;
            this.groupBox4.Location = new System.Drawing.Point(295, 264);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(218, 71);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Готово";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Blue;
            this.ClientSize = new System.Drawing.Size(525, 347);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Техпроцесс";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMarsh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem openWorks;
        private System.Windows.Forms.ToolStripMenuItem openAutohen;
        private System.Windows.Forms.ToolStripMenuItem пильщикиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem рубщикиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem слесариToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сварщикиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem токариToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem фрезеровщикиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem гибкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem маляраToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem прочиеToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}

