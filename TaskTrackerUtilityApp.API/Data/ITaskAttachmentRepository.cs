using System.Threading.Tasks;
using TaskTrackerUtilityApp.API.Models;

namespace TaskTrackerUtilityApp.API.Data
{
    public interface ITaskAttachmentRepository
    {
         Task<TaskAttachment> GetTaskAttachments(int TaskId);
         void AddTaskAttachment(TaskAttachment taskAttachment);
         void DeleteTaskAttachment(TaskAttachment taskAttachment);
    }
}