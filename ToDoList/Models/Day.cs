using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    public class Day
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(25)]
        public string TaskDay { get; set; }

        public ICollection<ToDoItem> Tasks { get; set; } = new List<ToDoItem>();
    }
}
