namespace BAL.Test.BusinessLogicTests
{
    using System;
    using System.Collections.Generic;
    using Moq;
    using NUnit.Framework;
    using Shared.DomainModels;
    using Shared.Interfaces.RepositoryInterfaces;
    using Shared.Interfaces.BusinessLogicInterfaces;
    using BAL.BusinessLogics;
    using Shared.Utils;
    using System.Linq.Expressions;

    [TestFixture]
    public class UserBusinessLogicTest
    {
        Mock<IUserRepository> MockObject { get; set; }
        IUserBusinessLogic UserBusinessLogic { get; set; }

        [SetUp]
        public void Initiaizer()
        {
            MockObject = new Mock<IUserRepository>();
            IUserRepository userRepository = MockObject.Object;
            UserBusinessLogic = new UserBusinessLogic(userRepository);
        }

        [Test]
        public void User_can_login()
        {
            //Arrange
            User user = new User()
            {
                Email = "rishav@gmail.com",
                Password = "Lkjh@4321",
                FirstName = "Rishav",
                LastName = "Salodhia",
                ModifiedOn = DateTime.Now,
                CreatedOn = DateTime.Now,
                Id = 1
            };
            List<User> userList = new List<User> { user };
            MockObject.Setup(m => m.Find(It.IsAny<Expression<System.Func<User, bool>>>())).Returns(userList);
            

            //act
            OperationResult<User> actualResult = UserBusinessLogic.LoginUser("rishav@gmail.com", "Lkjh@4321");

            //assert
            Assert.AreEqual("User Found", actualResult.Message);
        }

        [Test]
        public void User_should_not_login_when_invalid_credentials_given()
        {
            //Arrange   
            Mock<IUserRepository> mockObject = new Mock<IUserRepository>();
            List<User> userList = new List<User>();
            mockObject.Setup(m => m.Find(It.IsAny<Expression<System.Func<User, bool>>>())).Returns(userList);
            IUserRepository userRepository = mockObject.Object;
            IUserBusinessLogic userBusinessLogic = new UserBusinessLogic(userRepository);

            //act
            OperationResult<User> actualResult = userBusinessLogic.LoginUser("asdfgh@gmail.com", "Lkjh@4321");

            //assert
            Assert.AreEqual("User Not Found", actualResult.Message);
        }

        [Test]
        public void Can_return_email_already_exist_message()
        {
            //Arrange   
            User user = new User()
            {
                Email = "rishav@gmail.com",
                Password = "Lkjh@4321",
                FirstName = "Rishav",
                LastName = "Salodhia",
                ModifiedOn = DateTime.Now,
                CreatedOn = DateTime.Now,
                Id = 1
            };
            List<User> userList = new List<User> { user };
            MockObject.SetupGet(m => m.List).Returns(userList);
            User newUser = new User()
            {
                Email = "rishav@gmail.com",
                Password = "Lkjh@4321",
                FirstName = "Rishav",
                LastName = "Salodhia",
            };
            MockObject.Setup(m => m.Add(It.IsAny<User>()));

            //act
            OperationResult<User> actualResult = UserBusinessLogic.AddUser(newUser);

            //assert
            Assert.AreEqual("Email already exists", actualResult.Message);
        }

        [Test]
        public void Should_not_save_user_when_data_is_invalid()
        {
            //Arrange   
            User user = new User()
            {
                Email = "rishav@gmail.com",
                Password = "Lkjh@4321",
                FirstName = "Rishav",
                LastName = "Salodhia",
                ModifiedOn = DateTime.Now,
                CreatedOn = DateTime.Now,
                Id = 1
            };
            List<User> userList = new List<User> { user };
            MockObject.SetupGet(m => m.List).Returns(userList);
            User newUser = new User()
            {
                Email = "",
                Password = "Lkjh@4321",
                FirstName = "Rishav",
                LastName = "Salodhia",
            };
            MockObject.Setup(m => m.Add(It.IsAny<User>()));
            
            //act
            OperationResult<User> actualResult = UserBusinessLogic.AddUser(newUser);

            //assert
            Assert.AreEqual("Invalid Data", actualResult.Message);
        }

        [Test]
        public void Can_user_add()
        {
            //Arrange   
            User user = new User()
            {
                Email = "rishav@gmail.com",
                Password = "Lkjh@4321",
                FirstName = "Rishav",
                LastName = "Salodhia",
                ModifiedOn = DateTime.Now,
                CreatedOn = DateTime.Now,
                Id = 1
            };
            List<User> userList = new List<User> { user };
            MockObject.SetupGet(m => m.List).Returns(userList);
            User newUser = new User()
            {
                Email = "rishavsalodhia@gmail.com",
                Password = "Lkjh@4321",
                FirstName = "Rishav",
                LastName = "Salodhia",
            };
            MockObject.Setup(m => m.Add(It.IsAny<User>()));
           
            //act
            OperationResult<User> actualResult = UserBusinessLogic.AddUser(newUser);

            //assert
            Assert.AreEqual("Added successfully", actualResult.Message);
        }
    }
}
