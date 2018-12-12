using System;
using System.Collections.Generic;
using ToDoList.Models;

namespace ToDoList.Repositories
{
    public interface IToDoListRepository
    {
        IEnumerable<Day> GetAllDays();

        Day GetDay(int id);

        List<ToDoItem> GetAllTasks();

        ToDoItem GetTask(Guid id);

        void DeleteTask(ToDoItem toDoItem);

        void AddTask(int dayId, ToDoItem toDoItem);

        bool SaveTask();

        void FilterTasksForDay(int dayId);

        void FilterAllTasks();
    }
}
