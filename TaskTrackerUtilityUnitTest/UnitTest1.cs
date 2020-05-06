using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using TaskTrackerUtilityApp;
using TaskTrackerUtilityApp.API.Controllers;
using TaskTrackerUtilityApp.API.Models.Repository;
using TaskTrackerUtilityApp.API.Data;
using TaskTrackerUtilityApp.API.Models;
using System.Collections;
using System.Collections.Generic;
using Moq;
using Microsoft.IdentityModel.Tokens;
using System;
using Microsoft.AspNetCore.SignalR.Protocol;

namespace TaskTrackerUtilityUnitTest
{
    [TestClass]
    public class TaskTrackerUtilityUnitTest
    {
        #region Task Maintenance
        [TestMethod]
        public void SaveTask()
        {
            var mockDataRepository = new Mock<ITaskMaintenanceDataRepository>();
            TaskMaintenancesController controller = new TaskMaintenancesController(mockDataRepository.Object);
            TaskMaintenance taskMaintenance = CreateTask(1);
            var insertTask = controller.Post(taskMaintenance);
            Assert.AreEqual(200, ((Microsoft.AspNetCore.Mvc.ObjectResult)insertTask).StatusCode);
        }
        [TestMethod]
        public void UpdateTask()
        {
            var mockDataRepository = new Mock<ITaskMaintenanceDataRepository>();
            TaskMaintenancesController controller = new TaskMaintenancesController(mockDataRepository.Object);
            TaskMaintenance taskMaintenance = CreateTask(1);

            TaskMaintenance updateTask = CreateTask(2);

            taskMaintenance.UserId = updateTask.UserId;

            var insertTask = controller.Put(1, updateTask);
            Assert.AreEqual(200, ((Microsoft.AspNetCore.Mvc.ObjectResult)insertTask).StatusCode);
        }
        [TestMethod]
        public void DeleteTask()
        {
            var mockDataRepository = new Mock<ITaskMaintenanceDataRepository>();
            TaskMaintenancesController controller = new TaskMaintenancesController(mockDataRepository.Object);
            TaskMaintenance taskMaintenance = CreateTask(1);
            var deleteTask = controller.Delete(1);
            Assert.AreEqual(200, ((Microsoft.AspNetCore.Mvc.ObjectResult)deleteTask).StatusCode);
        }
        [TestMethod]
        public void GetAllTask()
        {
            var mockDataRepository = new Mock<ITaskMaintenanceDataRepository>();
            TaskMaintenancesController controller = new TaskMaintenancesController(mockDataRepository.Object);
            TaskMaintenance taskMaintenance1 = CreateTask(1);
            TaskMaintenance taskMaintenance2 = CreateTask(2);
            TaskMaintenance taskMaintenance3 = CreateTask(3);


            var insertTask1 = controller.Post(taskMaintenance1);
            var insertTask2 = controller.Post(taskMaintenance2);
            var insertTask3 = controller.Post(taskMaintenance3);

            var output = controller.GetAllTasks();

            Assert.AreEqual(200, ((Microsoft.AspNetCore.Mvc.ObjectResult)output).StatusCode);
        }
        [TestMethod]
        public void GetTasksByTaskID()
        {
            var mockDataRepository = new Mock<ITaskMaintenanceDataRepository>();
            TaskMaintenancesController controller = new TaskMaintenancesController(mockDataRepository.Object);
            TaskMaintenance taskMaintenance1 = CreateTask(1);
            TaskMaintenance taskMaintenance2 = CreateTask(2);
            TaskMaintenance taskMaintenance3 = CreateTask(3);


            var insertTask1 = controller.Post(taskMaintenance1);
            var insertTask2 = controller.Post(taskMaintenance2);
            var insertTask3 = controller.Post(taskMaintenance3);

            var output = controller.GetTaskByID(1);

            Assert.AreEqual(200, ((Microsoft.AspNetCore.Mvc.ObjectResult)output).StatusCode);
        }
        [TestMethod]
        public void GetTasksByUserID()
        {
            var mockDataRepository = new Mock<ITaskMaintenanceDataRepository>();
            TaskMaintenancesController controller = new TaskMaintenancesController(mockDataRepository.Object);
            TaskMaintenance taskMaintenance1 = CreateTask(1);
            TaskMaintenance taskMaintenance2 = CreateTask(2);
            TaskMaintenance taskMaintenance3 = CreateTask(3);


            var insertTask1 = controller.Post(taskMaintenance1);
            var insertTask2 = controller.Post(taskMaintenance2);
            var insertTask3 = controller.Post(taskMaintenance3);

            var output = controller.GetTasksByUserID(1);

            Assert.AreEqual(200, ((Microsoft.AspNetCore.Mvc.ObjectResult)output).StatusCode);
        }
        [TestMethod]
        public void GetTaskByStatus()
        {
            var mockDataRepository = new Mock<ITaskMaintenanceDataRepository>();
            TaskMaintenancesController controller = new TaskMaintenancesController(mockDataRepository.Object);
            TaskMaintenance taskMaintenance1 = CreateTask(1);
            TaskMaintenance taskMaintenance2 = CreateTask(2);
            TaskMaintenance taskMaintenance3 = CreateTask(3);


            var insertTask1 = controller.Post(taskMaintenance1);
            var insertTask2 = controller.Post(taskMaintenance2);
            var insertTask3 = controller.Post(taskMaintenance3);

            var output = controller.GetTasksByStatusID("Open");

            Assert.AreEqual(200, ((Microsoft.AspNetCore.Mvc.ObjectResult)output).StatusCode);
        }

        private TaskMaintenance CreateTask(int taskID)
        {
            TaskMaintenance taskMaintenance = new TaskMaintenance();
            taskMaintenance.TaskId = taskID;
            taskMaintenance.UserId = taskID;
            taskMaintenance.Status = (taskID % 2 == 0 ? "Open" : "close");
            taskMaintenance.ActualEndDate = DateTime.Now;
            taskMaintenance.PlannedStartDate = DateTime.Now;
            taskMaintenance.PlannedEndDate = DateTime.Now;
            taskMaintenance.ActualStartDate = DateTime.Now;
            taskMaintenance.AssignedTo = 2;
            taskMaintenance.Assignee = 2;
            taskMaintenance.ModifiedBy = 3;
            taskMaintenance.ModifiedDateTime = DateTime.Now;
            taskMaintenance.Priority = "High";
            taskMaintenance.Progress = "Progress";
            taskMaintenance.TaskDescription = "TaskDescription";
            taskMaintenance.TaskSummary = "TaskSummary";
            taskMaintenance.Watchers = "Watchers";
            return taskMaintenance;
        }
        #endregion

        #region User
        [TestMethod]
        public void SaveUser()
        {
            var mockDataRepository = new Mock<IDataRepository<User>>();
            UserController controller = new UserController(mockDataRepository.Object);
            User user = CreateUser(1);
            var insertTask = controller.CreateUser(user);
            Assert.AreEqual(200, ((Microsoft.AspNetCore.Mvc.ObjectResult)insertTask).StatusCode);
        }
        [TestMethod]
        public void UpdateUser()
        {
            var mockDataRepository = new Mock<IDataRepository<User>>();
            UserController controller = new UserController(mockDataRepository.Object);
            User user = CreateUser(1);

            User updateUser = CreateUser(1);

            user.UserId = updateUser.UserId;

            var insertTask = controller.UpdateUser(updateUser);
            Assert.AreEqual(200, ((Microsoft.AspNetCore.Mvc.ObjectResult)insertTask).StatusCode);
        }
        [TestMethod]
        public void DeleteUser()
        {
            var mockDataRepository = new Mock<IDataRepository<User>>();
            UserController controller = new UserController(mockDataRepository.Object);
            User user = CreateUser(1);

            var deleteTask = controller.DeleteUser(1);
            Assert.AreEqual(200, ((Microsoft.AspNetCore.Mvc.ObjectResult)deleteTask).StatusCode);
        }
        [TestMethod]
        public void GetAllUsers()
        {
            var mockDataRepository = new Mock<IDataRepository<User>>();
            UserController controller = new UserController(mockDataRepository.Object);
            User user = CreateUser(1);
            User user1 = CreateUser(2);
            User user2 = CreateUser(3);


            var insertTask1 = controller.CreateUser(user);
            var insertTask2 = controller.CreateUser(user1);
            var insertTask3 = controller.CreateUser(user2);

            var output = controller.GetUsers();

            Assert.AreEqual(200, ((Microsoft.AspNetCore.Mvc.ObjectResult)output).StatusCode);
        }
        [TestMethod]
        public void GetUserByUserID()
        {
            var mockDataRepository = new Mock<IDataRepository<User>>();
            UserController controller = new UserController(mockDataRepository.Object);
            User user = CreateUser(1);

            var insertTask1 = controller.CreateUser(user);

            var output = controller.GetUser(1);

            Assert.AreEqual(200, ((Microsoft.AspNetCore.Mvc.ObjectResult)output).StatusCode);
        }

        private User CreateUser(int UserID)
        {
            User user = new User();
            user.UserName = "TestUser"+UserID.ToString();
            user.EmailAddress = "TestUser@Cognizant.com";
            user.IsActive = true;
            user.RoleId = 1;
            user.Password = "anc1";
            return user;
        }
        #endregion

        #region Role
        [TestMethod]
        public void GetAllRoles()
        {
            var mockDataRepository = new Mock<IDataRepository<Role>>();
            RoleController controller = new RoleController(mockDataRepository.Object);
            Role role = CreateRole("Admin");
            Role role1 = CreateRole("User");
            Role role2 = CreateRole("Security");

            var output = controller.GetAllRoles();

            Assert.AreEqual(200, ((Microsoft.AspNetCore.Mvc.ObjectResult)output).StatusCode);
        }

        private Role CreateRole(string roleName)
        {
            Role role = new Role();
            role.RoleName = roleName;
            role.IsActive = true;
            return role;
        }
        #endregion
    }
}
