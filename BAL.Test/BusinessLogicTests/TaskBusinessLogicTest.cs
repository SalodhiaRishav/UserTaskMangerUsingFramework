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
        private ITaskBusinessLogic TaskBusinessLogic { get; set; }
        private Mock<ITaskRepository> MockObject { get; set; }

        [SetUp]
        public void Initializer()
        {
            MockObject = new Mock<ITaskRepository>();
            ITaskRepository taskRepository = MockObject.Object;
            TaskBusinessLogic = new TaskBusinessLogic(taskRepository);
        }

        [Test]
        public void Can_return_empty_task_list()
        {
            //Arrange
            List<Task> tasks = new List<Task>();
            MockObject.Setup(m => m.List).Returns(tasks);
           
            //act
            OperationResult<List<Task>> actualResult = TaskBusinessLogic.GetAllTasks();

            //assert
            Assert.AreEqual("Empty tasks", actualResult.Message);
        }

        [Test]
        public void Can_return_tasks()
        {
            //Arrange
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
            MockObject.Setup(m => m.List).Returns(tasks);
          
            //act
            OperationResult<List<Task>> actualResult = TaskBusinessLogic.GetAllTasks();

            //assert
            Assert.AreEqual(2, actualResult.Data.Count);
        }

        [Test]
        public void Can_add_new_task()
        {
            //Arrange
            Task newTask = new Task()
            {
                TaskCategoryId = 1,
                TaskDate = DateTime.Now,
                UserId = 1,
                UserStory = "some story",
                ExpectedTime = 4,
                TimeSpent = 6
            };
            MockObject.Setup(m => m.Add(newTask));

            //act
            OperationResult<Task> actualResult = TaskBusinessLogic.AddTask(newTask);

            //assert
            Assert.AreEqual("Task Added Successully", actualResult.Message);
        }

        [Test]
        public void Should_not_add_task_when_data_is_invalid()
        {
            //Arrange
            Task newTask = new Task()
            {
                TaskCategoryId = 1,
                TaskDate = DateTime.Now,
                UserId = 1,
                UserStory = string.Empty,
                ExpectedTime = 4,
                TimeSpent = 6
            };
            MockObject.Setup(m => m.Add(newTask));
          
            //act
            OperationResult<Task> actualResult = TaskBusinessLogic.AddTask(newTask);

            //assert
            Assert.AreEqual("Invalid Data", actualResult.Message);
        }

        [Test]
        public void Can_delete_task()
        {
            //Arrange
            Task task = new Task()
            {
                TaskCategoryId = 1,
                TaskDate = DateTime.Now,
                UserId = 1,
                UserStory = string.Empty,
                ExpectedTime = 4,
                TimeSpent = 6
            };
            MockObject.Setup(m => m.FindById(1)).Returns(task);
            MockObject.Setup(m => m.Delete(task));
          
            //act
            OperationResult<Task> actualResult = TaskBusinessLogic.DeleteTask(1);

            //assert
            Assert.AreEqual("Task Deleted Successfully", actualResult.Message);
        }

        [Test]
        public void Should_not_delete_task_when_task_with_given_id_is_not_exist()
        {
            //Arrange
            Task task = null;
            int taskId = 3;
            MockObject.Setup(m => m.FindById(taskId)).Returns(task);
            MockObject.Setup(m => m.Delete(task));
        
            //act
            OperationResult<Task> actualResult = TaskBusinessLogic.DeleteTask(taskId);

            //assert
            Assert.AreEqual("No task found with this id", actualResult.Message);
        }

        [Test]
        public void Should_not_update_task_when_task_data_is_invalid()
        {
            //Arrange
            Task taskToUpdate = new Task()
            {
                TaskCategoryId = 1,
                TaskDate = DateTime.Now,
                UserId = 1,
                UserStory = "",
                ExpectedTime = 4,
                TimeSpent = 6
            };
            MockObject.Setup(m => m.Update(taskToUpdate));
            
            //act
            OperationResult<Task> actualResult = TaskBusinessLogic.UpdateTask(taskToUpdate);

            //assert
            Assert.AreEqual("Invalid Data", actualResult.Message);
        }

        [Test]
        public void Can_update_task()
        {
            //Arrange
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
            MockObject.Setup(m => m.Update(taskToUpdate));
           
            //act
            OperationResult<Task> actualResult = TaskBusinessLogic.UpdateTask(taskToUpdate);

            //assert
            Assert.AreEqual("Task updated successfully", actualResult.Message);
        }

        [Test]
        public void Can_return_all_tasks_related_to_user()
        {
            //Arrange
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
            MockObject.Setup(m => m.GetUserTasks(userId)).Returns(tasks);
           
            //act
            OperationResult<List<Task>> actualResult = TaskBusinessLogic.GetTasksForUser(userId);

            //assert
            Assert.AreEqual(2, actualResult.Data.Count);
        }

        [Test]
        public void Should_return_empty_task_list_when_no_task_found_for_given_usedId()
        {
            //Arrange
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
            List<Task> resultTasks = new List<Task>();
            int userId = 2;
            MockObject.Setup(m => m.GetUserTasks(userId)).Returns(resultTasks);
           
            //act
            OperationResult<List<Task>> actualResult = TaskBusinessLogic.GetTasksForUser(userId);

            //assert
            Assert.AreEqual("Not any task found for this user", actualResult.Message);
        }

    }
}
