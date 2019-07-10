namespace BAL.Test.BusinessLogicTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using BAL.BusinessLogics;
    using Moq;
    using NUnit.Framework;
    using Shared.DomainModels;
    using Shared.Interfaces.BusinessLogicInterfaces;
    using Shared.Interfaces.RepositoryInterfaces;
    using Shared.Utils;

    [TestFixture]
    public class TaskBusinessLogicTest
    {
        [Test]
        public void Can_return_empty_task_list()
        {
            //Arrange
            Mock<ITaskRepository> mockObject = new Mock<ITaskRepository>();
            Mock<ITaskCategoryRepository> taskCategoryRepoMockObject = new Mock<ITaskCategoryRepository>();
            List<Task> tasks = new List<Task>();
            mockObject.Setup(m => m.List).Returns(tasks);
            ITaskRepository taskRepository = mockObject.Object;
            ITaskCategoryRepository taskCategoryRepository = taskCategoryRepoMockObject.Object;
            ITaskBusinessLogic taskBusinessLogic = new TaskBusinessLogic(taskRepository,taskCategoryRepository);

            //act
            OperationResult<List<Task>> actualResult = taskBusinessLogic.GetAllTasks();

            //assert
            Assert.AreEqual("Empty tasks", actualResult.Message);
        }

        [Test]
        public void Can_return_tasks()
        {
            //Arrange
            Mock<ITaskRepository> mockObject = new Mock<ITaskRepository>();
            List<Task> tasks = new List<Task>()
            {
                new Task()
                {
                    Id=1,
                    TaskCategoryId=1,
                    TaskDate=DateTime.Now,
                    CreatedOn=DateTime.Now,
                    ModifiedOn=DateTime.Now,
                    UserId=1,
                    UserStory="some story",
                    ExpectedTime=4,
                    TimeSpent=6
                },
                new Task()
                {
                    Id=2,
                    TaskCategoryId=2,
                    TaskDate=DateTime.Now,
                    CreatedOn=DateTime.Now,
                    ModifiedOn=DateTime.Now,
                    UserId=1,
                    UserStory="some other story",
                    ExpectedTime=8,
                    TimeSpent=6
                }
            };
            mockObject.Setup(m => m.List).Returns(tasks);
            ITaskRepository taskRepository = mockObject.Object;
            Mock<ITaskCategoryRepository> taskCategoryRepoMockObject = new Mock<ITaskCategoryRepository>();
            ITaskCategoryRepository taskCategoryRepository = taskCategoryRepoMockObject.Object;
            ITaskBusinessLogic taskBusinessLogic = new TaskBusinessLogic(taskRepository,taskCategoryRepository);

            //act
            OperationResult<List<Task>> actualResult = taskBusinessLogic.GetAllTasks();

            //assert
            Assert.AreEqual(2, actualResult.Data.Count);
        }

        [Test]
        public void Can_add_new_task()
        {
            //Arrange
            Mock<ITaskRepository> mockObject = new Mock<ITaskRepository>();

            Task newTask = new Task()
            {
                TaskCategoryId = 1,
                TaskDate = DateTime.Now,
                UserId = 1,
                UserStory = "some story",
                ExpectedTime = 4,
                TimeSpent = 6
            };

            mockObject.Setup(m => m.Add(newTask));
            ITaskRepository taskRepository = mockObject.Object;
            Mock<ITaskCategoryRepository> taskCategoryRepoMockObject = new Mock<ITaskCategoryRepository>();
            ITaskCategoryRepository taskCategoryRepository = taskCategoryRepoMockObject.Object;
            ITaskBusinessLogic taskBusinessLogic = new TaskBusinessLogic(taskRepository,taskCategoryRepository);

            //act
            OperationResult<Task> actualResult = taskBusinessLogic.AddTask(newTask);

            //assert
            Assert.AreEqual("Task Added Successully", actualResult.Message);
        }

        [Test]
        public void Should_not_add_task_when_data_is_invalid()
        {
            //Arrange
            Mock<ITaskRepository> mockObject = new Mock<ITaskRepository>();
            Task newTask = new Task()
            {
                TaskCategoryId = 1,
                TaskDate = DateTime.Now,
                UserId = 1,
                UserStory = string.Empty,
                ExpectedTime = 4,
                TimeSpent = 6
            };

            mockObject.Setup(m => m.Add(newTask));
            ITaskRepository taskRepository = mockObject.Object;
            Mock<ITaskCategoryRepository> taskCategoryRepoMockObject = new Mock<ITaskCategoryRepository>();
            ITaskCategoryRepository taskCategoryRepository = taskCategoryRepoMockObject.Object;
            ITaskBusinessLogic taskBusinessLogic = new TaskBusinessLogic(taskRepository,taskCategoryRepository);

            //act
            OperationResult<Task> actualResult = taskBusinessLogic.AddTask(newTask);

            //assert
            Assert.AreEqual("Invalid Data", actualResult.Message);
        }

        [Test]
        public void Can_delete_task()
        {
            //Arrange
            Mock<ITaskRepository> mockObject = new Mock<ITaskRepository>();
            Task task = new Task()
            {
                TaskCategoryId = 1,
                TaskDate = DateTime.Now,
                UserId = 1,
                UserStory = string.Empty,
                ExpectedTime = 4,
                TimeSpent = 6
            };
            mockObject.Setup(m => m.FindById(1)).Returns(task);
            mockObject.Setup(m => m.Delete(task));
            ITaskRepository taskRepository = mockObject.Object;
            Mock<ITaskCategoryRepository> taskCategoryRepoMockObject = new Mock<ITaskCategoryRepository>();
            ITaskCategoryRepository taskCategoryRepository = taskCategoryRepoMockObject.Object;
            ITaskBusinessLogic taskBusinessLogic = new TaskBusinessLogic(taskRepository,taskCategoryRepository);

            //act
            OperationResult<Task> actualResult = taskBusinessLogic.DeleteTask(1);

            //assert
            Assert.AreEqual("Task Deleted Successfully", actualResult.Message);
        }

        [Test]
        public void Should_not_delete_task_when_task_with_given_id_is_not_exist()
        {
            //Arrange
            Mock<ITaskRepository> mockObject = new Mock<ITaskRepository>();
            Task task = null;
            int taskId = 3;
            mockObject.Setup(m => m.FindById(taskId)).Returns(task);
            mockObject.Setup(m => m.Delete(task));
            ITaskRepository taskRepository = mockObject.Object;
            Mock<ITaskCategoryRepository> taskCategoryRepoMockObject = new Mock<ITaskCategoryRepository>();
            ITaskCategoryRepository taskCategoryRepository = taskCategoryRepoMockObject.Object;
            ITaskBusinessLogic taskBusinessLogic = new TaskBusinessLogic(taskRepository,taskCategoryRepository);

            //act
            OperationResult<Task> actualResult = taskBusinessLogic.DeleteTask(taskId);

            //assert
            Assert.AreEqual("No task found with this id", actualResult.Message);
        }

        [Test]
        public void Should_not_update_task_when_task_data_is_invalid()
        {
            //Arrange
            Mock<ITaskRepository> mockObject = new Mock<ITaskRepository>();
            Task taskToUpdate = new Task()
            {
                TaskCategoryId = 1,
                TaskDate = DateTime.Now,
                UserId = 1,
                UserStory = "",
                ExpectedTime = 4,
                TimeSpent = 6
            };
            mockObject.Setup(m => m.Update(taskToUpdate));
            ITaskRepository taskRepository = mockObject.Object;
            Mock<ITaskCategoryRepository> taskCategoryRepoMockObject = new Mock<ITaskCategoryRepository>();
            ITaskCategoryRepository taskCategoryRepository = taskCategoryRepoMockObject.Object;
            ITaskBusinessLogic taskBusinessLogic = new TaskBusinessLogic(taskRepository,taskCategoryRepository);

            //act
            OperationResult<Task> actualResult = taskBusinessLogic.UpdateTask(taskToUpdate);

            //assert
            Assert.AreEqual("Invalid Data", actualResult.Message);
        }

        [Test]
        public void Can_update_task()
        {
            //Arrange
            Mock<ITaskRepository> mockObject = new Mock<ITaskRepository>();
            Task taskToUpdate = new Task()
            {
                TaskCategoryId = 1,
                TaskDate = DateTime.Now,
                UserId = 1,
                UserStory = "new story",
                ExpectedTime = 4,
                TimeSpent = 6,
                CreatedOn = DateTime.Now
            };
            mockObject.Setup(m => m.Update(taskToUpdate));
            ITaskRepository taskRepository = mockObject.Object;
            Mock<ITaskCategoryRepository> taskCategoryRepoMockObject = new Mock<ITaskCategoryRepository>();
            ITaskCategoryRepository taskCategoryRepository = taskCategoryRepoMockObject.Object;
            ITaskBusinessLogic taskBusinessLogic = new TaskBusinessLogic(taskRepository,taskCategoryRepository);

            //act
            OperationResult<Task> actualResult = taskBusinessLogic.UpdateTask(taskToUpdate);

            //assert
            Assert.AreEqual("Task updated successfully", actualResult.Message);
        }

        [Test]
        public void Can_return_all_tasks_related_to_user()
        {
            //Arrange
            Mock<ITaskRepository> mockObject = new Mock<ITaskRepository>();
            List<Task> tasks = new List<Task>()
            {
                new Task()
                {
                    Id=1,
                    TaskCategoryId=1,
                    TaskDate=DateTime.Now,
                    CreatedOn=DateTime.Now,
                    ModifiedOn=DateTime.Now,
                    UserId=1,
                    UserStory="some story",
                    ExpectedTime=4,
                    TimeSpent=6
                },
                new Task()
                {
                    Id=2,
                    TaskCategoryId=2,
                    TaskDate=DateTime.Now,
                    CreatedOn=DateTime.Now,
                    ModifiedOn=DateTime.Now,
                    UserId=1,
                    UserStory="some other story",
                    ExpectedTime=8,
                    TimeSpent=6
                }
            };
            int userId = 1;
            mockObject.Setup(m => m.Find(It.IsAny<Expression<Func<Task, bool>>>())).Returns(tasks);
            Mock<ITaskCategoryRepository> taskCategoryRepoMockObject = new Mock<ITaskCategoryRepository>();
            ITaskRepository taskRepository = mockObject.Object;
            ITaskCategoryRepository taskCategoryRepository = taskCategoryRepoMockObject.Object;
            ITaskBusinessLogic taskBusinessLogic = new TaskBusinessLogic(taskRepository,taskCategoryRepository);

            //act
            OperationResult<List<Task>> actualResult = taskBusinessLogic.GetTasksForUser(userId);

            //assert
            Assert.AreEqual(2, actualResult.Data.Count);
        }

        [Test]
        public void Should_return_empty_task_list_when_no_task_found_for_given_usedId()
        {
            //Arrange
            Mock<ITaskRepository> mockObject = new Mock<ITaskRepository>();
            List<Task> tasks = new List<Task>()
            {
                new Task()
                {
                    Id=1,
                    TaskCategoryId=1,
                    TaskDate=DateTime.Now,
                    CreatedOn=DateTime.Now,
                    ModifiedOn=DateTime.Now,
                    UserId=1,
                    UserStory="some story",
                    ExpectedTime=4,
                    TimeSpent=6
                },
                new Task()
                {
                    Id=2,
                    TaskCategoryId=2,
                    TaskDate=DateTime.Now,
                    CreatedOn=DateTime.Now,
                    ModifiedOn=DateTime.Now,
                    UserId=1,
                    UserStory="some other story",
                    ExpectedTime=8,
                    TimeSpent=6
                }
            };
            Mock<ITaskCategoryRepository> taskCategoryRepoMockObject = new Mock<ITaskCategoryRepository>();
            List<Task> resultTasks = new List<Task>();
            int userId = 2;
            mockObject.Setup(m => m.Find(It.IsAny<Expression<Func<Task, bool>>>())).Returns(resultTasks);
            ITaskRepository taskRepository = mockObject.Object;
            ITaskCategoryRepository taskCategoryRepository = taskCategoryRepoMockObject.Object;
            ITaskBusinessLogic taskBusinessLogic = new TaskBusinessLogic(taskRepository,taskCategoryRepository);

            //act
            OperationResult<List<Task>> actualResult = taskBusinessLogic.GetTasksForUser(userId);

            //assert
            Assert.AreEqual("Not any task found for this user", actualResult.Message);
        }

    }
}
