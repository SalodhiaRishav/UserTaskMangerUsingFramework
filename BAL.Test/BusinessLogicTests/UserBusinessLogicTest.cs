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
        [SetUp]
        public void Setup()
        {

        }

        [Test(Description = "Check Login Method.")]
        public void User_should_login()
        {
            //Arrange
            Mock<IUserRepository> mockObject = new Mock<IUserRepository>();
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
            mockObject.Setup(m => m.Find(It.IsAny<Expression<System.Func<User, bool>>>())).Returns(userList);
            IUserRepository userRepository = mockObject.Object;
            IUserBusinessLogic userBusinessLogic = new UserBusinessLogic(userRepository);

            //act
            OperationResult<User> actualResult = userBusinessLogic.LoginUser("rishav@gmail.com", "Lkjh@4321");

            //assert
            Assert.AreEqual("User Found", actualResult.Message);
        }

        [Test(Description = "Check Login Method with invalid credentials.")]
        public void User_should_not_login()
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

        [Test(Description = "Checking Registeration with already existed email.")]
        public void Should_return_email_already_exist()
        {
            //Arrange   
            Mock<IUserRepository> mockObject = new Mock<IUserRepository>();
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
            mockObject.SetupGet(m => m.List).Returns(userList);
            User newUser = new User()
            {
                Email = "rishav@gmail.com",
                Password = "Lkjh@4321",
                FirstName = "Rishav",
                LastName = "Salodhia",
            };
            mockObject.Setup(m => m.Add(It.IsAny<User>()));
            IUserRepository userRepository = mockObject.Object;
            IUserBusinessLogic userBusinessLogic = new UserBusinessLogic(userRepository);

            //act
            OperationResult<User> actualResult = userBusinessLogic.AddUser(newUser);

            //assert
            Assert.AreEqual("Email already exists", actualResult.Message);
        }

        [Test(Description ="checking with empty email")]
        public void Should_return_invalid_data()
        {
            //Arrange   
            Mock<IUserRepository> mockObject = new Mock<IUserRepository>();
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
            mockObject.SetupGet(m => m.List).Returns(userList);
            User newUser = new User()
            {
                Email = "",
                Password = "Lkjh@4321",
                FirstName = "Rishav",
                LastName = "Salodhia",
            };
            mockObject.Setup(m => m.Add(It.IsAny<User>()));
            IUserRepository userRepository = mockObject.Object;
            IUserBusinessLogic userBusinessLogic = new UserBusinessLogic(userRepository);

            //act
            OperationResult<User> actualResult = userBusinessLogic.AddUser(newUser);

            //assert
            Assert.AreEqual("Invalid Data", actualResult.Message);
        }

        [Test(Description = "checking with valid user data")]
        public void User_should_add()
        {
            //Arrange   
            Mock<IUserRepository> mockObject = new Mock<IUserRepository>();
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
            mockObject.SetupGet(m => m.List).Returns(userList);
            User newUser = new User()
            {
                Email = "rishavsalodhia@gmail.com",
                Password = "Lkjh@4321",
                FirstName = "Rishav",
                LastName = "Salodhia",
            };
            mockObject.Setup(m => m.Add(It.IsAny<User>()));
            IUserRepository userRepository = mockObject.Object;
            IUserBusinessLogic userBusinessLogic = new UserBusinessLogic(userRepository);

            //act
            OperationResult<User> actualResult = userBusinessLogic.AddUser(newUser);

            //assert
            Assert.AreEqual("Added successfully", actualResult.Message);
        }
    }
}
