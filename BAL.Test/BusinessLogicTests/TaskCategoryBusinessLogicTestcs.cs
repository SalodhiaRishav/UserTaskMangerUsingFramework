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
        [Test]
        public void Can_return_empty_taskcategory_list()
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

        [Test]
        public void Can_return_taskcategories()
        {
            //Arrange
            Mock<ITaskCategoryRepository> mockObject = new Mock<ITaskCategoryRepository>();
            List<TaskCategory> taskCategories = new List<TaskCategory>()
            {
                new TaskCategory
                {
                    Id = 1,
                    CategoryName = "Dot Net",
                    ModifiedOn = DateTime.Now,
                    CreatedOn = DateTime.Now,
                },
                new TaskCategory
                {
                    Id = 2,
                    CategoryName = "Vue.js",
                    ModifiedOn = DateTime.Now,
                    CreatedOn = DateTime.Now,
                },

            };
            mockObject.Setup(m => m.List).Returns(taskCategories);
            ITaskCategoryRepository taskCategoryRepository = mockObject.Object;
            ITaskCategoryBusinessLogic taskCategoryBusinessLogic = new TaskCategoryBusinessLogic(taskCategoryRepository);

            //act
            OperationResult<List<TaskCategory>> actualResult = taskCategoryBusinessLogic.GetAllTaskCategories();

            //assert          
            Assert.AreEqual(2, actualResult.Data.Count);
        }

        [Test]
        public void Should_not_return_taskcategory_when_taskCategoryId_2_not_exist()
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

        [Test]
        public void Can_return_taskcategory_with_id_1()
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

        [Test]
        public void Can_add_new_taskcategory()
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

        [Test]
        public void Should_not_save_taskcategory_when_data_is_invalid()
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
