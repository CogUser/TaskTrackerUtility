using System.Threading.Tasks;
using System.Collections.Generic;
using TaskTrackerUtilityApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace TaskTrackerUtilityApp.API.Data
{
    public class TaskAttachmentRepository : ITaskAttachmentRepository
    {
        private readonly DataContext _context;

        public TaskAttachmentRepository(DataContext context)
        {
            _context = context;         
        }
        
         public async Task<IList<TaskAttachment>> GetTaskAttachments()
         {
            return await _context.TaskAttachments.ToListAsync();
         }

         public void AddTaskAttachment(TaskAttachment taskAttachment)
         {
             _context.TaskAttachments.Add(taskAttachment);
         }

         public void DeleteTaskAttachment(TaskAttachment taskAttachment)
         {
             _context.TaskAttachments.Remove(taskAttachment);
         }

         public async Task SaveAsync() 
         {
             await _context.SaveChangesAsync();
         }
    }
}