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
        EveryDay = 1,
        EveryWeek = 2
    }

    class Task
    {
        public string Name;
        public DateTime TimeStart;
        public string Path;
        public TypeAction Type;

        public void Start()
        {
            Process process = Process.Start(Path);

            switch (Type)
            {
                case TypeAction.EveryDay:
                    TimeStart.AddDays(1);
                    break;
                case TypeAction.EveryWeek:
                    TimeStart.AddDays(7);
                    break;
            }

            try
            {
                process.WaitForExit();
            }
            finally
            {
                process.Dispose();
            }
        }
    }
}
