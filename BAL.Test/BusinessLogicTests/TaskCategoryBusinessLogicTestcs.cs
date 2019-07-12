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
        Mock<ITaskCategoryRepository> MockObject { get; set; }
        ITaskCategoryBusinessLogic TaskCategoryBusinessLogic { get; set; }

       [SetUp]
        public void Initializer()
        {
            MockObject = new Mock<ITaskCategoryRepository>();
            ITaskCategoryRepository taskCategoryRepository = MockObject.Object;
            TaskCategoryBusinessLogic = new TaskCategoryBusinessLogic(taskCategoryRepository);
        }

        [Test]
        public void Can_return_empty_taskcategory_list()
        {
            //Arrange
           
            List<TaskCategory> taskCategories = new List<TaskCategory>();
            MockObject.Setup(m => m.List).Returns(taskCategories);

            //act
            OperationResult<List<TaskCategory>> actualResult = TaskCategoryBusinessLogic.GetAllTaskCategories();

            //assert
            Assert.AreEqual("Empty List", actualResult.Message);
        }

        [Test]
        public void Can_return_taskcategories()
        {
            //Arrange
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
            MockObject.Setup(m => m.List).Returns(taskCategories);
          
            //act
            OperationResult<List<TaskCategory>> actualResult = TaskCategoryBusinessLogic.GetAllTaskCategories();

            //assert          
            Assert.AreEqual(2, actualResult.Data.Count);
        }

        [Test]
        public void Should_not_return_taskcategory_when_taskCategoryId_2_not_exist()
        {
            //Arrange
            TaskCategory taskCategory = null;
            MockObject.Setup(m => m.FindById(2)).Returns(taskCategory);

            //act
            OperationResult<TaskCategory> actualResult = TaskCategoryBusinessLogic.GetTaskCategoryById(2);

            //assert          
            Assert.AreEqual("TaskCategory Not Found", actualResult.Message);
        }

        [Test]
        public void Can_return_taskcategory_with_id_1()
        {
            //Arrange
            TaskCategory taskCategory = new TaskCategory()
            {
                Id = 1,
                CategoryName = "Dot Net",
                ModifiedOn = DateTime.Now,
                CreatedOn = DateTime.Now
            };
            MockObject.Setup(m => m.FindById(1)).Returns(taskCategory);
           
            //act
            OperationResult<TaskCategory> actualResult = TaskCategoryBusinessLogic.GetTaskCategoryById(1);

            //assert          
            Assert.AreEqual("TaskCategory Has Found", actualResult.Message);
        }

        [Test]
        public void Can_add_new_taskcategory()
        {
            //Arrange
            TaskCategory taskCategory = new TaskCategory()
            {
                CategoryName = "Vue.JS",
            };
            MockObject.Setup(m => m.Add(It.IsAny<TaskCategory>()));

            //act
            OperationResult<TaskCategory> actualResult = TaskCategoryBusinessLogic.AddTaskCategory(taskCategory);

            //assert          
            Assert.AreEqual("TaskCategory Added Successfully", actualResult.Message);
        }

        [Test]
        public void Should_not_save_taskcategory_when_data_is_invalid()
        {
            //Arrange
            TaskCategory taskCategory = new TaskCategory()
            {
                CategoryName = "",
            };
            MockObject.Setup(m => m.Add(It.IsAny<TaskCategory>()));

            //act
            OperationResult<TaskCategory> actualResult = TaskCategoryBusinessLogic.AddTaskCategory(taskCategory);

            //assert          
            Assert.AreEqual("Invalid Data", actualResult.Message);
        }
    }
}
