using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSchedulerService.Models
{
    public enum TypeAction
    {
        EveryDay = 0,
        EveryWeek = 1
    }

    [System.Serializable]
    class Task
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime TimeStart { get; set; }
        public string Path { get; set; }
        public TypeAction Type { get; set; }

        public void Start()
        {
            Process process = Process.Start(Path);

            AddDays();

            Database.UpdateTaskTime(Id, TimeStart.ToString());
        }

        public void CheckDays()
        {
            while (TimeStart <= DateTime.Now)
            {
                AddDays();
            }

            Database.UpdateTaskTime(Id, TimeStart.ToString());
        }

        public void AddDays()
        {
            switch (Type)
            {
                case TypeAction.EveryDay:
                    TimeStart = TimeStart.AddDays(1);
                    break;
                case TypeAction.EveryWeek:
                    TimeStart = TimeStart.AddDays(7);
                    break;
            }
        }
    }
}
