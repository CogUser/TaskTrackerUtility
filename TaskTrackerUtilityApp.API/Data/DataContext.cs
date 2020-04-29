using Microsoft.EntityFrameworkCore;
using TaskTrackerUtilityApp.API.Models;

namespace TaskTrackerUtilityApp.API.Data
{
    public class DataContext : DbContext
    {
       public DataContext(DbContextOptions<DataContext> options) : base(options){} 

       public DbSet<Value> Values {get; set;}

       public DbSet<TaskAttachment> TaskAttachments {get; set;}
    }
}