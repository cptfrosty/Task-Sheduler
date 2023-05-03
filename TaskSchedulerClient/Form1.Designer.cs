namespace TaskSchedulerClient
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgTasks = new System.Windows.Forms.DataGridView();
            this.NameTask = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SelectFile = new System.Windows.Forms.Button();
            this.tbNameTask = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbTimeTask = new System.Windows.Forms.TextBox();
            this.labelPath = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgTasks)).BeginInit();
            this.SuspendLayout();
            // 
            // dgTasks
            // 
            this.dgTasks.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTasks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameTask,
            this.TimeStart,
            this.Path});
            this.dgTasks.Location = new System.Drawing.Point(12, 97);
            this.dgTasks.Name = "dgTasks";
            this.dgTasks.Size = new System.Drawing.Size(745, 251);
            this.dgTasks.TabIndex = 0;
            // 
            // NameTask
            // 
            this.NameTask.HeaderText = "Название задачи";
            this.NameTask.Name = "NameTask";
            this.NameTask.Width = 255;
            // 
            // TimeStart
            // 
            this.TimeStart.HeaderText = "Время запуска";
            this.TimeStart.Name = "TimeStart";
            this.TimeStart.Width = 120;
            // 
            // Path
            // 
            this.Path.HeaderText = "Путь до файла";
            this.Path.Name = "Path";
            this.Path.Width = 255;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "ПЛАНИРОВЩИК ЗАДАЧ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Задачи";
            // 
            // SelectFile
            // 
            this.SelectFile.Location = new System.Drawing.Point(12, 433);
            this.SelectFile.Name = "SelectFile";
            this.SelectFile.Size = new System.Drawing.Size(131, 23);
            this.SelectFile.TabIndex = 4;
            this.SelectFile.Text = "Выбрать файл";
            this.SelectFile.UseVisualStyleBackColor = true;
            this.SelectFile.Click += new System.EventHandler(this.SelectFile_Click);
            // 
            // tbNameTask
            // 
            this.tbNameTask.Location = new System.Drawing.Point(149, 365);
            this.tbNameTask.Name = "tbNameTask";
            this.tbNameTask.Size = new System.Drawing.Size(241, 20);
            this.tbNameTask.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 368);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Название задачи";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 404);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Время запуска (HH:MM)";
            // 
            // tbTimeTask
            // 
            this.tbTimeTask.Location = new System.Drawing.Point(149, 401);
            this.tbTimeTask.Name = "tbTimeTask";
            this.tbTimeTask.Size = new System.Drawing.Size(241, 20);
            this.tbTimeTask.TabIndex = 8;
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.Location = new System.Drawing.Point(149, 438);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(0, 13);
            this.labelPath.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(549, 365);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(208, 56);
            this.button1.TabIndex = 10;
            this.button1.Text = "Добавить задачу";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnAddTask_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 468);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelPath);
            this.Controls.Add(this.tbTimeTask);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbNameTask);
            this.Controls.Add(this.SelectFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgTasks);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgTasks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgTasks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SelectFile;
        private System.Windows.Forms.TextBox tbNameTask;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbTimeTask;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameTask;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn Path;
    }
}

