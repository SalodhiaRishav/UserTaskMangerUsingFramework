namespace BAL.Test.BusinessLogicTests
{
    using System;
    using System.Collections.Generic;
    using BAL.BusinessLogics;
    using Moq;
    using NUnit.Framework;
    using Shared.DomainModels;
    using Shared.Interfaces.BusinessLogicInterfaces;
    using Shared.Interfaces.RepositoryInterfaces;
    using Shared.Utils;

    [TestFixture]
    public class TaskCategoryBusinessLogicTestcs
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test(Description = "Should return empty taskcategory list.")]
        public void Should_return_empty_taskcategory_list()
        {
            //Arrange
            Mock<ITaskCategoryRepository> mockObject = new Mock<ITaskCategoryRepository>();
            List<TaskCategory> taskCategories = new List<TaskCategory>();
            mockObject.Setup(m => m.List).Returns(taskCategories);
            ITaskCategoryRepository taskCategoryRepository = mockObject.Object;
            ITaskCategoryBusinessLogic taskCategoryBusinessLogic = new TaskCategoryBusinessLogic(taskCategoryRepository);

            //act
            OperationResult<List<TaskCategory>> actualResult = taskCategoryBusinessLogic.GetAllTaskCategories();

            //assert
            Assert.AreEqual("Empty List", actualResult.Message);
        }

        [Test(Description = "Should return taskcategories.")]
        public void Should_return_taskcategories()
        {
            //Arrange
            TaskCategory taskCategory = new TaskCategory()
            {
                Id = 1,
                CategoryName = "Dot Net",
                ModifiedOn = DateTime.Now,
                CreatedOn = DateTime.Now,
            };

            Mock<ITaskCategoryRepository> mockObject = new Mock<ITaskCategoryRepository>();
            List<TaskCategory> taskCategories = new List<TaskCategory>() { taskCategory };
            mockObject.Setup(m => m.List).Returns(taskCategories);
            ITaskCategoryRepository taskCategoryRepository = mockObject.Object;
            ITaskCategoryBusinessLogic taskCategoryBusinessLogic = new TaskCategoryBusinessLogic(taskCategoryRepository);

            //act
            OperationResult<List<TaskCategory>> actualResult = taskCategoryBusinessLogic.GetAllTaskCategories();

            //assert          
            Assert.AreEqual("Dot Net", actualResult.Data[0].CategoryName);
        }

        [Test(Description = "Task Category with id 2 should not found")]
        public void Should_not_return_taskcategory_with_id_2()
        {
            //Arrange
            Mock<ITaskCategoryRepository> mockObject = new Mock<ITaskCategoryRepository>();
            TaskCategory taskCategory = null;
            mockObject.Setup(m => m.FindById(2)).Returns(taskCategory);
            ITaskCategoryRepository taskCategoryRepository = mockObject.Object;
            ITaskCategoryBusinessLogic taskCategoryBusinessLogic = new TaskCategoryBusinessLogic(taskCategoryRepository);

            //act
            OperationResult<TaskCategory> actualResult = taskCategoryBusinessLogic.GetTaskCategoryById(2);

            //assert          
            Assert.AreEqual("TaskCategory Not Found", actualResult.Message);
        }

        [Test(Description = "Task Category with id 1 should return")]
        public void Should_return_taskcategory_with_id_1()
        {
            //Arrange
            Mock<ITaskCategoryRepository> mockObject = new Mock<ITaskCategoryRepository>();
            TaskCategory taskCategory = new TaskCategory()
            {
                Id = 1,
                CategoryName = "Dot Net",
                ModifiedOn = DateTime.Now,
                CreatedOn = DateTime.Now
            };
            mockObject.Setup(m => m.FindById(1)).Returns(taskCategory);
            ITaskCategoryRepository taskCategoryRepository = mockObject.Object;
            ITaskCategoryBusinessLogic taskCategoryBusinessLogic = new TaskCategoryBusinessLogic(taskCategoryRepository);

            //act
            OperationResult<TaskCategory> actualResult = taskCategoryBusinessLogic.GetTaskCategoryById(1);

            //assert          
            Assert.AreEqual("TaskCategory Has Found", actualResult.Message);
        }

        [Test(Description = "New Task Category should be added successfully")]
        public void Should_add_new_taskcategory()
        {
            //Arrange
            Mock<ITaskCategoryRepository> mockObject = new Mock<ITaskCategoryRepository>();
            TaskCategory taskCategory = new TaskCategory()
            {
                CategoryName = "Vue.JS",
            };
            mockObject.Setup(m => m.Add(It.IsAny<TaskCategory>()));
            ITaskCategoryRepository taskCategoryRepository = mockObject.Object;
            ITaskCategoryBusinessLogic taskCategoryBusinessLogic = new TaskCategoryBusinessLogic(taskCategoryRepository);

            //act
            OperationResult<TaskCategory> actualResult = taskCategoryBusinessLogic.AddTaskCategory(taskCategory);

            //assert          
            Assert.AreEqual("TaskCategory Added Successfully", actualResult.Message);
        }

        [Test(Description = "Adding invalid taskcategory")]
        public void Should_return_invalid_data_message()
        {
            //Arrange
            Mock<ITaskCategoryRepository> mockObject = new Mock<ITaskCategoryRepository>();
            TaskCategory taskCategory = new TaskCategory()
            {
                CategoryName = "",
            };
            mockObject.Setup(m => m.Add(It.IsAny<TaskCategory>()));
            ITaskCategoryRepository taskCategoryRepository = mockObject.Object;
            ITaskCategoryBusinessLogic taskCategoryBusinessLogic = new TaskCategoryBusinessLogic(taskCategoryRepository);

            //act
            OperationResult<TaskCategory> actualResult = taskCategoryBusinessLogic.AddTaskCategory(taskCategory);

            //assert          
            Assert.AreEqual("Invalid Data", actualResult.Message);
        }
    }
}
