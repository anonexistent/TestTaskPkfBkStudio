using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskPkfBkStudio.Model
{
    public class TaskList
    {
        [Key]
        public Guid id { get; set; }
        public Guid userId { get; set; }
        public Guid taskId { get; set; }
        public virtual User user { get; set; }
        public virtual Task task { get; set; }
    }
}
