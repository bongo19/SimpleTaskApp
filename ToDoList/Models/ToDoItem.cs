using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.Models
{
    public class ToDoItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string TaskName { get; set; }

        [MaxLength(500)]
        public string TaskDescription { get; set; }

        public int TaskDay { get; set; }

        public bool IsCompleted { get; set; }
    }
}
