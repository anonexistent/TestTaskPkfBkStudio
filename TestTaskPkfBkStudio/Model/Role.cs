using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskPkfBkStudio.Model
{
    public class Role
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public virtual List<User> users { get; set; }
    }
}
