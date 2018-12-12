using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Dtos
{
    public class ToDoItemForUpdateDto
    {
        [Required(ErrorMessage = "You need to provide a name for the task.")]
        public string TaskName { get; set; }

        [Required(ErrorMessage = "You need to provide a description for the task.")]
        [MaxLength(500, ErrorMessage = "Your description cannot be more than 500 characters.")]
        public string TaskDescription { get; set; }

        public bool IsCompleted { get; set; }
    }
}
