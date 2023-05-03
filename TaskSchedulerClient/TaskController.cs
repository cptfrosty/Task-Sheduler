using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSchedulerClient
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

        public void AddTasks(Models.Task task)
        {
            if (Tasks == null) Tasks = new List<Models.Task>();

            Tasks.Add(task);
        }
    }
}
