using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    public static class TasksContextExtensions
    {
        public static void SeedData(this TasksContext context)
        {
            var days = new List<Day>()
            {
                new Day()
                {
                    Id = 0,
                    TaskDay = "Sunday"
                },
                new Day()
                {
                    Id = 1,
                    TaskDay = "Monday"
                },
                new Day()
                {
                    Id = 2,
                    TaskDay = "Tuesday"
                },
                new Day()
                {
                    Id = 3,
                    TaskDay = "Wednesday"
                },
                new Day()
                {
                    Id = 4,
                    TaskDay = "Thursday"
                },
                new Day()
                {
                    Id = 5,
                    TaskDay = "Friday"
                },
                new Day()
                {
                    Id = 6,
                    TaskDay = "Saturday"
                }
            };

            context.Days.AddRange(days);
            context.SaveChanges();
        }
    }
}
