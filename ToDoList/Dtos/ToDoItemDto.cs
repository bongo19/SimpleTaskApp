using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Dtos
{
    public class ToDoItemDto
    {
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public int TaskDay { get; set; }
        public bool IsCompleted { get; set; }
    }
}
