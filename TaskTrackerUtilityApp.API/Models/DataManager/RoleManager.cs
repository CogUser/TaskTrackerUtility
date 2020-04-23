using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTrackerUtilityApp.API.Data;
using TaskTrackerUtilityApp.API.Models.Repository;

namespace TaskTrackerUtilityApp.API.Models.DataManager
{
    public class RoleManager: IDataRepository<Role>
    {
        readonly DataContext _dbContext;

        public RoleManager(DataContext context)
        {
            _dbContext = context;
        }

        public IEnumerable<Role> GetAll()
        {
            return _dbContext.Roles.ToList();
        }

        public Role Get(int id)
        {
            return _dbContext.Roles
                  .FirstOrDefault(e => e.RoleId == id);
        }

        public void Add(Role role)
        {
            _dbContext.Roles.Add(role);
            _dbContext.SaveChanges();
        }

        public void Update(Role role, Role entity)
        {
            role.RoleName = entity.RoleName;
            role.IsActive = entity.IsActive;
            _dbContext.SaveChanges();
        }

        public void Delete(Role role)
        {
            _dbContext.Roles.Remove(role);
            _dbContext.SaveChanges();
        }
    }
}
