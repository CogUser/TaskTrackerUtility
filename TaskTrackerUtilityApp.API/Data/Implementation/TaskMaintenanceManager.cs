using System.Security.Cryptography.X509Certificates;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks.Sources;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTrackerUtilityApp.API.Models;
using TaskTrackerUtilityApp.API.DTO;

namespace TaskTrackerUtilityApp.API.Data
{
    public class TaskMaintenanceManager: ITaskMaintenanceDataRepository
    {
        readonly DataContext _dbContext;

        public TaskMaintenanceManager(DataContext dbContext)
        {
            _dbContext = dbContext;
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

        public IEnumerable<TaskStatusChartValues> GetTaskCountByStatus()
        {
            var taskCountByStatus = new List<TaskStatusChartValues>();
            taskCountByStatus = _dbContext.TaskMaintenance
                                          .GroupBy( task => task.Status)
                                          .Select(status => new TaskStatusChartValues(){
                                              TaskStatus = status.Key,
                                              TaskCountByStatus = status.Count()
                                          })
                                          .OrderBy(x => x.TaskStatus).ToList();
            return taskCountByStatus;
        }

        public IEnumerable<TaskProgressChartValues> GetTaskCountByProgress()
        {                                                    
            var ranges = new[] { 0, 20, 40, 60 , 80, 100};
            var taskCountByProgress = ranges.Select(r => new TaskProgressChartValues()
            {
                TaskProgress = r,
                TaskCountByProgress = _dbContext.TaskMaintenance.Where(g => Convert.ToInt32(g.Progress) == r ).Count()
            }).OrderBy(x => x.TaskProgress).ToList();
                    
            return taskCountByProgress;
        }
    }
}
