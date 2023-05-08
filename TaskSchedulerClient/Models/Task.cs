using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSchedulerClient.Models
{
    public enum TypeAction
    {
        EveryDay = 0,
        EveryWeek = 1
    }

    class Task
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime TimeStart { get; set; }
        public string Path { get; set; }
        public TypeAction Type { get; set; }
    }
}
