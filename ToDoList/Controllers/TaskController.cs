using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using ToDoList.Dtos;
using ToDoList.Models;
using ToDoList.Repositories;
using ToDoList.Wrappers;

namespace ToDoList.Controllers
{
    [Route("api/day")]
    public class TaskController : Controller
    {
        private readonly IToDoListRepository _toDoListRepository;
        private readonly IAutoMapperWrapper _autoMapperWrapper;
        public TaskController(IToDoListRepository toDoListRepository, IAutoMapperWrapper autoMapperWrapper)
        {
            _toDoListRepository = toDoListRepository;
            _autoMapperWrapper = autoMapperWrapper;
        }

        [HttpGet("{dayId}/task/{id}",Name = "GetTaskById")]
        public IActionResult GetTaskById(Guid id)
        {
            var task = _toDoListRepository.GetTask(id);

            var taskMapped = _autoMapperWrapper.Map<ToDoItemDto>(task);
            return Ok(taskMapped);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTaskById(ToDoItem toDoItem)
        {
            _toDoListRepository.DeleteTask(toDoItem);
            
            if(!_toDoListRepository.SaveTask())
            {
                return StatusCode(500, "An error occurred while trying to delete your task.");
            }
            
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(Guid id, [FromBody] ToDoItemForUpdateDto toDoItemForUpdate)
        {
            if(toDoItemForUpdate == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var taskFromEntity = _toDoListRepository.GetTask(id);

            _autoMapperWrapper.Map(toDoItemForUpdate, taskFromEntity);
          
            if (!_toDoListRepository.SaveTask())
            {
                return StatusCode(500, "A problem occured with updating your task");
            }

            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult ParitallyUpdateTask(Guid id, [FromBody] JsonPatchDocument<ToDoItemForUpdateDto> patchDocument)
        {
            if (patchDocument == null)
            {
                return BadRequest();
            }

            var taskFromEntity = _toDoListRepository.GetTask(id);

            if(taskFromEntity == null)
            {
                return BadRequest();
            }

            var taskToPatch = _autoMapperWrapper.Map<ToDoItemForUpdateDto>(patchDocument);

            patchDocument.ApplyTo(taskToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _autoMapperWrapper.Map(taskToPatch, taskFromEntity);

            if (!_toDoListRepository.SaveTask())
            {
                return StatusCode(500, "A problem occured while trying to partially update your task.");
            }

            return NoContent();
        }

        [HttpPost("{dayId}/task")]
        public IActionResult AddTask(int dayId, [FromBody] ToDoItemForCreationDto toDoItemForCreationDto)
        {
            if(toDoItemForCreationDto == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var taskMapped = _autoMapperWrapper.Map<ToDoItem>(toDoItemForCreationDto);

            _toDoListRepository.AddTask(dayId, taskMapped);

            if (!_toDoListRepository.SaveTask())
            {
                return StatusCode(500, "An error occurred while saving your task.");
            }

            var taskToReturn = _autoMapperWrapper.Map<ToDoItemDto>(taskMapped);

            return CreatedAtRoute("GetTaskById", new
            {
                dayId = dayId,
                id = taskToReturn.Id
            }, taskToReturn);
        }

        [HttpGet]
        public IActionResult GetAllTasks()
        {
            return Ok(_toDoListRepository.GetAllTasks());
        }




    }
}