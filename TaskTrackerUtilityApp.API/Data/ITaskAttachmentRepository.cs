using System.Threading.Tasks;
using System.Collections.Generic;
using TaskTrackerUtilityApp.API.Models;

namespace TaskTrackerUtilityApp.API.Data
{
    public interface ITaskAttachmentRepository
    {
         Task<IList<TaskAttachment>> GetTaskAttachments();
         void AddTaskAttachment(TaskAttachment taskAttachment);
         void DeleteTaskAttachment(TaskAttachment taskAttachment);
         Task SaveAsync(); 
    }
}