using Microsoft.EntityFrameworkCore;
using TaskTrackerUtilityApp.API.Models;

namespace TaskTrackerUtilityApp.API.Data
{
    public class DataContext : DbContext
    {
       public DataContext(DbContextOptions<DataContext> options) : base(options){} 

       public DbSet<Value> Values {get; set;}

       public DbSet<TaskAttachment> TaskAttachments {get; set;}

       public DbSet<TaskMaintenance> TaskMaintenance { get; set; }
       
       public DbSet<User> Users { get; set; }

       public DbSet<Role> Roles { get; set; }
    }
}