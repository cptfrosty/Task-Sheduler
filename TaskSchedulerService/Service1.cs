using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Timers;

namespace TaskSchedulerService
{
    public partial class Service1 : ServiceBase
    {
        private TaskController _taskController = new TaskController();
        static private string _nameFile = "Logs.txt"; //Файл для общения сервиса и клиента

        string fullPathFile = "";
        string fullPathFolder = "";


        internal void TestStartupAndStop(string[] args)
        {
            this.OnStart(args);
            Console.ReadLine();
            this.OnStop();
        }


        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            string currentFolder = args[0];
            fullPathFolder = $"{Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)}\\TaskScheduler\\";
            fullPathFile = $"{fullPathFolder}/{_nameFile}";
            try
            {
                Database.currentPath = currentFolder;
                Database.Connect();
                var _timer = new Timer(30 * 1000); //Каждые 30 секунд
                _timer.Elapsed += TimerElapsed;
                _timer.Start();
                LoadData();
            }catch(Exception ex)
            {
                File.WriteAllText(@"E:\Fast files\Project\Task-Sheduler\Debug\logsService.txt", ex.ToString());
            }
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("fsdf");
            List<Models.Task> tasks = _taskController.GetTasks();
            if (tasks.Count == 0) return;

            for(int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].TimeStart.ToString("dd-MM-yyyy HH:ss") == DateTime.Now.ToString("dd-MM-yyyy HH:ss"))
                {
                    tasks[i].Start();
                }
            }

            LoadData(); //Обновление данных из БД
        }


        public void LoadData()
        {
            //StringBuilder textFromFile = null;
            //DirectoryInfo directory = new DirectoryInfo(fullPathFolder);
            //if (Directory.Exists(fullPathFolder) == false)
            //{
            //    Directory.CreateDirectory(fullPathFolder);
            //}

            //using (FileStream fstream = new FileStream(fullPathFile, FileMode.OpenOrCreate))
            //{
            //    // выделяем массив для считывания данных из файла
            //    byte[] buffer = new byte[fstream.Length];
            //    // считываем данные
            //    fstream.Read(buffer, 0, buffer.Length);
            //    // декодируем байты в строку
            //    textFromFile = new StringBuilder(Encoding.Default.GetString(buffer));
            //    Console.WriteLine($"Текст из файла: {textFromFile}");
            //}

            //try
            //{
            //    if(!String.IsNullOrEmpty(textFromFile.ToString()))
            //        _taskController = JsonSerializer.Deserialize<TaskController>(textFromFile.ToString());
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //}

            _taskController.Tasks = Database.GetTasks();
        }

        protected override void OnStop()
        {

        }
    }
}
