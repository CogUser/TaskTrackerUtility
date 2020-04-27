using System.Threading.Tasks;
using System.Collections.Generic;
using TaskTrackerUtilityApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace TaskTrackerUtilityApp.API.Data
{
    public class TaskAttachmentRepository : GenericRepository<TaskAttachment>, ITaskAttachmentRepository
    {
       public TaskAttachmentRepository(IUnitOfWork unitOfWork) :base(unitOfWork)
       {

       }
    }
}