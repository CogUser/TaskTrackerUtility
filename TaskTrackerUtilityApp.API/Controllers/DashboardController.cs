using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TaskTrackerUtilityApp.API.DTO;
using TaskTrackerUtilityApp.API.Data;

namespace TaskTrackerUtilityApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController: ControllerBase
    {
        private readonly ITaskMaintenanceDataRepository _dataRepository;

        public DashboardController(ITaskMaintenanceDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

         // GET api/chartValues
        [Route("/api/Dashboard/TaskByStatus")]
        [HttpGet]
        public IActionResult GetTaskCountByStatus()
        {
            var values = _dataRepository.GetTaskCountByStatus();
            return Ok(values);
        }

        // GET api/chartValues
        [Route("/api/Dashboard/TaskByProgress")]
        [HttpGet]
        public IActionResult GetTaskCountByProgress()
        {
            var values = _dataRepository.GetTaskCountByProgress();
            return Ok(values);
        }
    }
}