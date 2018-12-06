using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    public class TasksContext:DbContext
    {
        public TasksContext(DbContextOptions<TasksContext> options)
            :base(options)
        {
            Database.Migrate();
        }

        public DbSet<ToDoItem> ToDoItems { get; set; }
        public DbSet<Day> Days { get; set; }
    }
}
