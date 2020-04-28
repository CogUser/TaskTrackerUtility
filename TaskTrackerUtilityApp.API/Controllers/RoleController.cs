using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskTrackerUtilityApp.API.Models;
using TaskTrackerUtilityApp.API.Models.Repository;

namespace TaskTrackerUtilityApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IDataRepository<Role> _dataRepository;

        public RoleController(IDataRepository<Role> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/Roles
        [HttpGet]
        public IActionResult GetAllRoles()
        {
            IEnumerable<Role> roles = _dataRepository.GetAll();
            return Ok(roles);
        }
    }
}