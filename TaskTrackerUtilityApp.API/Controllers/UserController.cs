using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TaskTrackerUtilityApp.API.Models;
using TaskTrackerUtilityApp.API.Models.Repository;
using TaskTrackerUtilityApp.API.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;

namespace TaskTrackerUtilityApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IDataRepository<User> _dataRepository;

        public UserController(IDataRepository<User> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/User
        [HttpGet]
        public IActionResult GetUsers()
        {
            
            IEnumerable<User> users = _dataRepository.GetAll();
            foreach (User U in users)
            {
                U.Password = Cryptography.Decrypt(U.Password);
            }

            return Ok(users);
        }
       
        // GET: api/User/5
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            User user = _dataRepository.Get(id);

            if (user == null)
            {
                return NotFound("The User record couldn't be found.");
            }

            user.Password = Cryptography.Decrypt(user.Password);
            return Ok(user);
        }

        // POST: api/User
        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User is null.");
            }

            user.Password = Cryptography.Encrypt(user.Password);
            user.Role = null;
            _dataRepository.Add(user);
            //return CreatedAtRoute(
            //      "Get",
            //      new { Id = user.UserId },
            //      user);
            return GetUsers();
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult UpdateUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User is null.");
            }

            User userToUpdate = _dataRepository.Get(user.UserId);
            if (userToUpdate == null)
            {
                return NotFound("The User record couldn't be found.");
            }

            user.Password = Cryptography.Encrypt(user.Password);
            _dataRepository.Update(userToUpdate, user);
            return NoContent();
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            User user = _dataRepository.Get(id);
            if (user == null)
            {
                return NotFound("The User record couldn't be found.");
            }

            _dataRepository.Delete(user);
            return NoContent();
        }

    }
}