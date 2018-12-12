using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ToDoList.Dtos;
using ToDoList.Models;
using ToDoList.Repositories;

namespace ToDoList
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var connectionString = Configuration["connectionStrings:toDoListDBConnectionString"];
            services.AddDbContext<TasksContext>(o => o.UseSqlServer(connectionString));

            services.AddScoped<IToDoListRepository, ToDoListRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, TasksContext tasksContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            tasksContext.SeedData();

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Day, DayDto>();
                cfg.CreateMap<ToDoItem, ToDoItemDto>()
                .ForMember(dest => dest.TaskDay, opt => opt.MapFrom(src => src.DayId));

                cfg.CreateMap<ToDoItemForCreationDto, ToDoItem>();
                cfg.CreateMap<ToDoItemForUpdateDto, ToDoItem>();
                cfg.CreateMap<ToDoItem, ToDoItemForUpdateDto>();

            });

            app.UseHttpsRedirection();
            app.UseMvc();


        }
    }
}
