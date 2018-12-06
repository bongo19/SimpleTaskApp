using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Dtos;
using ToDoList.Models;
using ToDoList.Repositories;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    public class DayController : Controller
    {
        private readonly IToDoListRepository _toDoListRepository;

        public DayController(IToDoListRepository toDoListRepository)
        {
            _toDoListRepository = toDoListRepository;
        }

        [HttpGet]
        public IActionResult GetDays()
        {
            var days = _toDoListRepository.GetAllDays();
            var results = Mapper.Map<IEnumerable<DayDto>>(days);

            return Ok(days);
        }

        [HttpGet("{id}")]
        public IActionResult GetDay(int id)
        {
            var day = _toDoListRepository.GetDay(id);
            var results = Mapper.Map<DayDto>(day);

            return Ok(results);
        }
    }
}