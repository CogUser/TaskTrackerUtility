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
        private readonly TaskMaintenanceManager _dataRepository;

        public TaskMaintenancesController(ITaskMaintenanceDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/User
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<TaskMaintenance> tasks = _dataRepository.GetAllTaskMaintenance();
            return Ok(tasks);
        }

        [HttpGet]
        public IActionResult GetTasksByStatusID(string statusID)
        {
            IEnumerable<TaskMaintenance> tasks = _dataRepository.GetTasksByStatusID(statusID);
            return Ok(tasks);
        }

        [HttpGet]
        public IActionResult GetTasksByGetTasksForUser(int userID)
        {
            IEnumerable<TaskMaintenance> tasks = _dataRepository.GetTaskByUserID(userID);
            return Ok(tasks);
        }
        // GET: api/User/5                         
        [HttpGet("{taskID}", Name = "Get")]
        public IActionResult Get(int taskID)
        {
            TaskMaintenance taskMaintenance = _dataRepository.GetTaskMaintenance(taskID);

            if (taskMaintenance == null)
            {
                return NotFound("The task couldn't be found.");
            }

            return Ok(taskMaintenance);
        }

        // POST: api/User
        [HttpPost]
        public IActionResult Post([FromBody] TaskMaintenance taskMaintenance)
        {
            if (taskMaintenance == null)
            {
                return BadRequest("Task is null.");
            }

            _dataRepository.AddTaskMaintenance(taskMaintenance);
            return CreatedAtRoute(
                  "Get",
                  new { Id = taskMaintenance.TaskId },
                  taskMaintenance);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult Put(int taskId, [FromBody] TaskMaintenance taskMaintenance)
        {
            if (taskMaintenance == null)
            {
                return BadRequest("The task couldn't be found.");
            }

            TaskMaintenance updateTask = _dataRepository.GetTaskMaintenance(taskId);
            if (updateTask == null)
            {
                return NotFound("The task couldn't be found.");
            }

            _dataRepository.UpdateTaskMaintenance(updateTask, taskMaintenance);
            return NoContent();
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int taskID)
        {
            TaskMaintenance taskMaintenance = _dataRepository.GetTaskMaintenance(taskID);
            if (taskMaintenance == null)
            {
                return NotFound("The task couldn't be found.");
            }

            _dataRepository.DeleteTaskMaintenance(taskMaintenance);
            return NoContent();
        }
    }
}