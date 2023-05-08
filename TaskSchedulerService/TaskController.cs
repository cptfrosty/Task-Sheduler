using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSchedulerService
{
    [System.Serializable]
    class TaskController
    {
        public List<Models.Task> Tasks { get; set; }

        public TaskController()
        {
            Tasks = new List<Models.Task>();
        }

        public List<Models.Task> GetTasks()
        {
            return Tasks;
        }
    }
}
