using Microsoft.EntityFrameworkCore;
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
            if (context.Days.Any())
            {
                return;
            }


            var days = new List<Day>()
            {
                new Day()
                {
                    TaskDay = "Sunday"
                },
                new Day()
                {
                    TaskDay = "Monday"
                },
                new Day()
                {
                    TaskDay = "Tuesday"
                },
                new Day()
                {
                    TaskDay = "Wednesday"
                },
                new Day()
                {
                    TaskDay = "Thursday"
                },
                new Day()
                {
                    TaskDay = "Friday"
                },
                new Day()
                {
                    TaskDay = "Saturday"
                }
            };

            context.Days.AddRange(days);
            context.SaveChanges();
        }
    }
}
