using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace TaskSchedulerClient
{
    public partial class Form1 : Form
    {
        private TaskController _taskController = new TaskController();
        private static string _nameFile = "Logs.txt"; //Файл для общения сервиса и клиента

        string fullPathFolder = "";
        string fullPathFile = "";

        public Form1()
        {
            InitializeComponent();

            fullPathFolder = $"{Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)}\\TaskScheduler\\";
            fullPathFile = $"{fullPathFolder}/{_nameFile}";

            Database.Connect();

            LoadTasks();

        }

        private void OnAddTask_Click(object sender, EventArgs e)
        {
            AddTask();
        }

        private void AddTask()
        {
            try
            {
                Models.Task task = new Models.Task();
                task.Name = tbNameTask.Text;
                task.TimeStart = DateTime.Parse(tbTimeTask.Text);
                task.Path = labelPath.Text;

                if (String.IsNullOrEmpty(task.Path))
                    throw new Exception("Путь не может быть пустым");

                _taskController.AddTasks(task);
                Database.AddTask(_taskController.GetLastTask());
                tbNameTask.Text = "";
                tbTimeTask.Text = "";
                labelPath.Text = "";

                WriteToTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void SaveTask()
        {
            //string json = JsonSerializer.Serialize(_taskController);
            //using (FileStream fstream = new FileStream(fullPathFile, FileMode.OpenOrCreate))
            //{
            //    // преобразуем строку в байты
            //    byte[] buffer = Encoding.Default.GetBytes(json.ToString());
            //    // запись массива байтов в файл
            //    await fstream.WriteAsync(buffer, 0, buffer.Length);
            //    Console.WriteLine("Текст записан в файл");
            //}
        }

        private async void LoadTasks()
        {
            //StringBuilder textFromFile = null;
            //string test;
            //using (FileStream fstream = new FileStream(fullPathFile, FileMode.OpenOrCreate))
            //{
            //    // выделяем массив для считывания данных из файла
            //    byte[] buffer = new byte[fstream.Length];
            //    // считываем данные
            //    await fstream.ReadAsync(buffer, 0, buffer.Length);
            //    // декодируем байты в строку
            //    textFromFile = new StringBuilder(Encoding.Default.GetString(buffer));
            //    Console.WriteLine($"Текст из файла: {textFromFile}");
            //}

            //try
            //{
            //    _taskController = JsonSerializer.Deserialize<TaskController>(textFromFile.ToString());
            //    WriteToTable();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //}

            _taskController.Tasks = Database.GetTasks();
            WriteToTable();
        }

        private void WriteToTable() //Записать в таблицу
        {
            dgTasks.Rows.Clear();
            List<Models.Task> tasks = _taskController.GetTasks();
            for (int i = 0; i < tasks.Count; i++) {
                dgTasks.Rows.Add(tasks[i].Name, tasks[i].TimeStart, tasks[i].Path);
            }
        }

        private void SelectFile_Click(object sender, EventArgs e)
        {
            OpenDialogSelectApp();
        }

        private void OpenDialogSelectApp()
        {
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    labelPath.Text = filePath;
                }
            }
        }
    }
}
