using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskTrackerUtilityApp.API.Data;
using TaskTrackerUtilityApp.API.Models;

namespace TaskTrackerUtilityApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskMaintenancesController : ControllerBase
    {
        private readonly ITaskMaintenanceDataRepository _dataRepository;

        public TaskMaintenancesController(ITaskMaintenanceDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet("/api/GetAllTasks")]
        public IActionResult GetAllTasks()
        {
            IEnumerable<TaskMaintenance> tasks = _dataRepository.GetAllTaskMaintenance();
            return Ok(tasks);
        }

        [HttpGet("/api/GetTasksByStatus/{status}")]
        public IActionResult GetTasksByStatusID(string status)
        {
            IEnumerable<TaskMaintenance> tasks = _dataRepository.GetTasksByStatusID(status);
            return Ok(tasks);
        }

        [HttpGet("/api/GetTasksByUserID/{userID}")]
        public IActionResult GetTasksByUserID(int userID)
        {
            IEnumerable<TaskMaintenance> tasks = _dataRepository.GetTasksByUserID(userID);
            return Ok(tasks);
        }
                               
        [HttpGet("/api/GetTaskByID/{taskID}")]
        public IActionResult GetTaskByID(int taskID)
        {
            TaskMaintenance taskMaintenance = _dataRepository.GetTaskByID(taskID);

            if (taskMaintenance == null)
            {
                return NotFound("The task couldn't be found.");
            }

            return Ok(taskMaintenance);
        }

        
        [HttpPost]
        public IActionResult Post([FromBody] TaskMaintenance taskMaintenance)
        {
            if (taskMaintenance == null)
            {
                return BadRequest("Task is null.");
            }

            _dataRepository.AddTaskMaintenance(taskMaintenance);
            return GetAllTasks();

        }

        
        [HttpPut("{taskID}")]
        public IActionResult Put(int taskID, [FromBody] TaskMaintenance taskMaintenance)
        {
            if (taskMaintenance == null)
            {
                return BadRequest("The task couldn't be found.");
            }

            TaskMaintenance updateTask = _dataRepository.GetTaskByID(taskMaintenance.TaskId);
            if (updateTask == null)
            {
                return NotFound("The task couldn't be found.");
            }

            _dataRepository.UpdateTaskMaintenance(taskMaintenance,updateTask);
            return NoContent();
        }

        
        [HttpDelete("{taskID}")]
        public IActionResult Delete(int taskID)
        {
            TaskMaintenance taskMaintenance = _dataRepository.GetTaskByID(taskID);
            if (taskMaintenance == null)
            {
                return NotFound("The task couldn't be found.");
            }

            _dataRepository.DeleteTaskMaintenance(taskMaintenance);
            return NoContent();
        }
    }
}