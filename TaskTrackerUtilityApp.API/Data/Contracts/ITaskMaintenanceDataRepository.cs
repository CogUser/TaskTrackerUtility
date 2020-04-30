using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTrackerUtilityApp.API.Models;
using TaskTrackerUtilityApp.API.DTO;

namespace TaskTrackerUtilityApp.API.Data
{
    public interface ITaskMaintenanceDataRepository
    {
        IEnumerable<TaskMaintenance> GetAllTaskMaintenance();
        TaskMaintenance GetTaskByID(int taskID);
        void AddTaskMaintenance(TaskMaintenance taskMaintenance);
        void UpdateTaskMaintenance(TaskMaintenance taskMaintenance, TaskMaintenance newTaskMaintenance);
        void DeleteTaskMaintenance(TaskMaintenance taskMaintenance);
        IEnumerable<TaskMaintenance> GetTasksByStatusID(string status);
        IEnumerable<TaskMaintenance> GetTasksByUserID(int userID);
        IEnumerable<TaskStatusChartValues> GetTaskCountByStatus();
        IEnumerable<TaskProgressChartValues> GetTaskCountByProgress();
    }

}
