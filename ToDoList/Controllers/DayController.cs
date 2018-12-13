using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Dtos;
using ToDoList.Models;
using ToDoList.Repositories;
using ToDoList.Wrappers;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    public class DayController : Controller
    {
        private readonly IToDoListRepository _toDoListRepository;
        private readonly IAutoMapperWrapper _autoMapperWrapper;
        public DayController(IToDoListRepository toDoListRepository,IAutoMapperWrapper autoMapperWrapper)
        {
            _toDoListRepository = toDoListRepository;
            _autoMapperWrapper = autoMapperWrapper;
        }

        [HttpGet]
        public IActionResult GetDays()
        {
            var days = _toDoListRepository.GetAllDays();
            var results = _autoMapperWrapper.Map<IEnumerable<DayDto>>(days);

            return Ok(days);
        }

        [HttpGet("{id}")]
        public IActionResult GetDay(int id)
        {
            var day = _toDoListRepository.GetDay(id);
            var results = _autoMapperWrapper.Map<DayDto>(day);

            return Ok(results);
        }
    }
}