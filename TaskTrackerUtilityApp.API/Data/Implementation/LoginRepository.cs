using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTrackerUtilityApp.API.Data.Contracts;
using TaskTrackerUtilityApp.API.Helpers;
using TaskTrackerUtilityApp.API.Models;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using TaskTrackerUtilityApp.API.Models.DataManager;
using TaskTrackerUtilityApp.API.Models.Repository;
using Microsoft.Extensions.Configuration;

namespace TaskTrackerUtilityApp.API.Data.Implementation
{
    public class LoginRepository : ILoginRespository
    {
        private readonly IConfiguration _configuration;
        readonly DataContext _dbContext;
        public LoginRepository(DataContext context, IConfiguration configuration)
        {
            _dbContext = context;
            _configuration = configuration;

        }
        public string Authenticate(string username, string password)
        {
           
            password = Cryptography.Encrypt(password);
            UserManager m = new UserManager(_dbContext);
            IEnumerable<User> _users = m.GetAll();

            var user = _users.SingleOrDefault(x => x.UserName == username && x.Password == password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["AppSettings:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserId.ToString())
                }),
                Expires = DateTime.Now.AddMinutes(900),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            //user.Token = tokenHandler.WriteToken(token);

            return tokenHandler.WriteToken(token);
        }
    }
}
