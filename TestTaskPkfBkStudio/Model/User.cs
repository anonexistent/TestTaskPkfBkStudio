using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskPkfBkStudio.Model
{
    public class User
    {
        public Guid id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public Guid roleId { get; set; }
        public virtual Role role { get; set; }
        public virtual List<TaskList> tasks { get; set; }
    }
}
