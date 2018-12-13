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
        public ICollection<ToDoItemDto> Tasks { get; set; } = new List<ToDoItemDto>();
    }
}
