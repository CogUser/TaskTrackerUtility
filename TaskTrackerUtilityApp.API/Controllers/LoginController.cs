using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using TaskTrackerUtilityApp.API.Data.Contracts;
using TaskTrackerUtilityApp.API.Models;

namespace TaskTrackerUtilityApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILoginRespository _loginRepository;

        public LoginController(ILoginRespository login)
        {
            _loginRepository = login;
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public IActionResult Authenticate([FromBody]AuthenticateModel model)
        {
            var token = _loginRepository.Authenticate(model.Username, model.Password);

            if (token == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(new {
               userToken = token
                });
        }

    }
}