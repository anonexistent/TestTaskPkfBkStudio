using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskPkfBkStudio.Model
{
    public class Task
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Guid stateId { get; set; }
        public virtual TaskState state { get; set; }
        public virtual List<TaskList> tasks { get; set; }
    }
}
