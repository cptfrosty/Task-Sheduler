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
        private List<Models.Task> _tasks = new List<Models.Task>();
        private string _nameFile = "Logs.txt"; //Файл для общения сервиса и клиента

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            var _timer = new Timer(40 * 1000); //Каждые 40 секунд
            _timer.Elapsed += TimerElapsed;
            _timer.Start();
            LoadData();
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (_tasks.Count == 0) return;

            for(int i = 0; i < _tasks.Count; i++)
            {
                if (_tasks[i].TimeStart.ToString("dd-MM-yyyy HH-mm") == DateTime.Now.ToString("dd-MM-yyyy HH-mm"))
                {
                    _tasks[i].Start();
                }
            }
        }

        private void LoadData()
        {
            if (File.Exists(_nameFile))
            {
                string jsonString = JsonSerializer.Serialize(_tasks);
            }
            else
            {
                File.Create(_nameFile);
            }
        }

        protected override void OnStop()
        {

        }
    }
}
