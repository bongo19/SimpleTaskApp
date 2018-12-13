using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Models;

namespace ToDoList.Repositories
{
    public class ToDoListRepository : IToDoListRepository
    {
        private TasksContext _tasksContext;

        public ToDoListRepository(TasksContext tasksContext)
        {
            _tasksContext = tasksContext;
        }

        public void AddTask(int dayId, ToDoItem toDoItem)
        {
            toDoItem.DayId = dayId;
            _tasksContext.ToDoItems.Add(toDoItem);
        }

        public void DeleteTask(ToDoItem toDoItem)
        {
            _tasksContext.ToDoItems.Remove(toDoItem);
        }

        public void FilterAllTasks()
        {
            throw new NotImplementedException();
        }

        public void FilterTasksForDay(int dayId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Day> GetAllDays()
        {
            return _tasksContext.Days.Include(t => t.ToDoItems).ToList();
        }

        public List<ToDoItem> GetAllTasks()
        {
            return _tasksContext.ToDoItems.ToList();
        }

        public Day GetDay(int id)
        {
            return _tasksContext.Days.Include(t => t.ToDoItems).Where(d => d.Id == id).FirstOrDefault();
        }

        public ToDoItem GetTask(Guid id)
        {
            return _tasksContext.ToDoItems.FirstOrDefault(x => x.Id == id);
        }

        public bool SaveTask()
        {
            return (_tasksContext.SaveChanges() > 0);
        }
    }
}
