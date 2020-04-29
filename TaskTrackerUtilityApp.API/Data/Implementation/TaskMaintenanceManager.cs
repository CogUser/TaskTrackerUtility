using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTrackerUtilityApp.API.Models;

namespace TaskTrackerUtilityApp.API.Data
{
    public class TaskMaintenanceManager: ITaskMaintenanceDataRepository
    {
        readonly DataContext _dbContext;

        public TaskMaintenanceManager(DataContext context)
        {
            _dbContext = context;
        }
        public void AddTaskMaintenance(TaskMaintenance taskMaintenance)
        {
            _dbContext.TaskMaintenance.Add(taskMaintenance);
            _dbContext.SaveChanges();
        }

        public void DeleteTaskMaintenance(TaskMaintenance taskMaintenance)
        {
            _dbContext.TaskMaintenance.Remove(taskMaintenance);
            _dbContext.SaveChanges();
        }

        public IEnumerable<TaskMaintenance> GetAllTaskMaintenance()
        {

            return _dbContext.TaskMaintenance.ToList();
        }

        public TaskMaintenance GetTaskByID(int taskID)
        {
            return _dbContext.TaskMaintenance
       .FirstOrDefault(e => e.TaskId == taskID);
        }

        public void UpdateTaskMaintenance(TaskMaintenance taskMaintenance, TaskMaintenance newtaskMaintenance)
        {
            taskMaintenance = newtaskMaintenance;
            _dbContext.SaveChanges();
        }
        public IEnumerable<TaskMaintenance> GetTasksByUserID(int userID)
        {
            return _dbContext.TaskMaintenance.Where(e => e.UserId == userID).ToList();
        }
        public IEnumerable<TaskMaintenance> GetTasksByStatusID(string status)
        {
            return _dbContext.TaskMaintenance.Where(e => e.Status.ToLower() == status.ToLower()).ToList();
        }
    }
}
