using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Repositories
{
    public interface IToDoListRepository
    {
        void GetAllDays();

        void GetDay();

        void GetAllTasks();

        void GetTask();

        void DeleteTask();

        void AddTask();

        void Save();

        void UpdateTask();

        void PartiallyUpdateTask();

        void FilterTasksForDay();

        void FilterAllTasks();
    }
}
