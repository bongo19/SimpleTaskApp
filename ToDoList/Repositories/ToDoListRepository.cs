using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public void AddTask()
        {
            throw new NotImplementedException();
        }

        public void AddTask(int dayId)
        {
            throw new NotImplementedException();
        }

        public void DeleteTask()
        {
            throw new NotImplementedException();
        }

        public void DeleteTask(Guid id)
        {
            throw new NotImplementedException();
        }

        public void FilterAllTasks()
        {
            throw new NotImplementedException();
        }

        public void FilterTasksForDay()
        {
            throw new NotImplementedException();
        }

        public void FilterTasksForDay(int dayId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Day> GetAllDays()
        {
            return _tasksContext.Days.ToList();
        }

        public void GetAllTasks()
        {
            throw new NotImplementedException();
        }

        public Day GetDay(int id)
        {
            throw new NotImplementedException();
        }

        public void GetTask()
        {
            throw new NotImplementedException();
        }

        public void GetTask(int dayId, Guid id)
        {
            throw new NotImplementedException();
        }

        public void PartiallyUpdateTask()
        {
            throw new NotImplementedException();
        }

        public void PartiallyUpdateTask(int dayId)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateTask()
        {
            throw new NotImplementedException();
        }

        public void UpdateTask(int dayId)
        {
            throw new NotImplementedException();
        }
    }
}
