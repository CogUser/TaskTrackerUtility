using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTrackerUtilityApp.API.Data;
using TaskTrackerUtilityApp.API.Models.Repository;

namespace TaskTrackerUtilityApp.API.Models.DataManager
{
    public class UserManager: IDataRepository<User>
    {
        readonly DataContext _dbContext;

        public UserManager(DataContext context)
        {
            _dbContext = context;
        }

        public IEnumerable<User> GetAll()
        {
            //return _dbContext.Users.ToList();
            return _dbContext.Users.Include( u => u.Role).ToList();
        }

        public User Get(int id)
        {
            return _dbContext.Users.Include(u => u.Role)
                  .FirstOrDefault(e => e.UserId == id);
        }

        public void Add(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public void Update(User user, User entity)
        {
            user.UserName = entity.UserName;
            user.EmailAddress = entity.EmailAddress;
            user.IsActive = entity.IsActive;
            user.RoleId = entity.RoleId;
            user.Password = entity.Password;
           _dbContext.SaveChanges();
        }

        public void Delete(User user)
        {
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }

    }
}
