using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Repositories
{
    public interface IToDoListRepository
    {
        IEnumerable<Day> GetAllDays();

        Day GetDay(int id);

        void GetAllTasks();

        void GetTask(int dayId, Guid id);

        void DeleteTask(Guid id);

        void AddTask(int dayId);

        void Save();

        void UpdateTask(int dayId);

        void PartiallyUpdateTask(int dayId);

        void FilterTasksForDay(int dayId);

        void FilterAllTasks();
    }
}
