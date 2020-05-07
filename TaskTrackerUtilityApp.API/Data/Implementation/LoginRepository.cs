﻿using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using TaskTrackerUtilityApp.API.Data.Contracts;
using TaskTrackerUtilityApp.API.Helpers;
using TaskTrackerUtilityApp.API.Models;
using TaskTrackerUtilityApp.API.Models.DataManager;

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
                Expires = DateTime.Now.AddMinutes(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            //user.Token = tokenHandler.WriteToken(token);

            return tokenHandler.WriteToken(token);
        }
    }
}
