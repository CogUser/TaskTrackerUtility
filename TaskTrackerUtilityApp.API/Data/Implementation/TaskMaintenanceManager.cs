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

        public TaskMaintenance GetTaskMaintenance(int taskID)
        {
            return _dbContext.TaskMaintenance
       .FirstOrDefault(e => e.TaskId == taskID);
        }

        public void UpdateTaskMaintenance(TaskMaintenance taskMaintenance, TaskMaintenance newtaskMaintenance)
        {
            _dbContext.SaveChanges();
        }
        public IEnumerable<TaskMaintenance> GetTaskByUserID(int userID)
        {
            return _dbContext.TaskMaintenance.ToList();
        }
        public IEnumerable<TaskMaintenance> GetTasksByStatusID(string statusID)
        {
            return _dbContext.TaskMaintenance.ToList();
        }
    }
}
