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
            taskMaintenance.TaskId = taskMaintenance.TaskId;
            taskMaintenance.UserId = newtaskMaintenance.UserId;
            taskMaintenance.Status = newtaskMaintenance.Status;
            taskMaintenance.ActualEndDate = newtaskMaintenance.ActualEndDate;
            taskMaintenance.PlannedStartDate = newtaskMaintenance.PlannedStartDate;
            taskMaintenance.PlannedEndDate = newtaskMaintenance.PlannedEndDate;
            taskMaintenance.ActualStartDate = newtaskMaintenance.ActualStartDate;
            taskMaintenance.AssignedTo = newtaskMaintenance.AssignedTo;
            taskMaintenance.Assignee = newtaskMaintenance.Assignee;
            taskMaintenance.ModifiedBy = newtaskMaintenance.ModifiedBy;
            taskMaintenance.ModifiedDateTime = newtaskMaintenance.ModifiedDateTime;
            taskMaintenance.Priority = newtaskMaintenance.Priority;
            taskMaintenance.Progress = newtaskMaintenance.Progress;
            taskMaintenance.TaskDescription = newtaskMaintenance.TaskDescription;
            taskMaintenance.TaskSummary = newtaskMaintenance.TaskSummary;
            taskMaintenance.Watchers = newtaskMaintenance.Watchers;
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
