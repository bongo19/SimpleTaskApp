using System;

namespace ToDoList.Dtos
{
    public class ToDoItemDto
    {
        public Guid Id { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public int TaskDay { get; set; }
        public bool IsCompleted { get; set; }
    }
}
