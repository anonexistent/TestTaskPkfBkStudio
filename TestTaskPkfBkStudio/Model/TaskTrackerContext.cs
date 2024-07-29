using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskPkfBkStudio.Model
{
    internal class TaskTrackerContext : DbContext
    {
        public DbSet<Role> roles { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Task> tasks { get; set; }
        public DbSet<TaskState> taskStates { get; set; }
        public DbSet<TaskList> taskList { get; set; }

        public TaskTrackerContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=TaskTrackerDatabase.db");
        }
    }
}
