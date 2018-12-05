using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Dtos
{
    public class DayDto
    {
        public string TaskDay { get; set; }
        public ICollection<ToDoItem> Tasks { get; set; } = new List<ToDoItem>();
    }
}
