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
    }
}
