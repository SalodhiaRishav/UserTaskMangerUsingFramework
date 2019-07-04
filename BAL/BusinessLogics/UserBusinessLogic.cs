namespace BAL.BusinessLogics
{
    using System;
    using System.Collections.Generic;
    using FluentValidation.Results;
    using Shared.DomainModels;
    using Shared.Interfaces.BusinessLogicInterfaces;
    using Shared.Interfaces.RepositoryInterfaces;
    using Shared.Utils;
    using Shared.Validators;

    public class UserBusinessLogic : BaseBusinessLogic, IUserBusinessLogic
    {
        private readonly IUserRepository UserRepository;

        public UserBusinessLogic(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public OperationResult<User> AddUser(User newuser)
        {
            UserValidator userValidator = new UserValidator();
            ValidationResult validationResult = userValidator.Validate(newuser);

            if (!validationResult.IsValid)
            {
                return CreateFailureMessage<User>("Invalid Data", validationResult.Errors);
            }

            try
            {
                List<User> userList = UserRepository.List;
                User user = userList.Find(fuser => fuser.Email == newuser.Email);
                if (user != null)
                {
                    return CreateFailureMessage<User>("Email already exists", null);
                }
                else
                {
                    UserRepository.Add(newuser);
                    return CreateSuccessMessage<User>("Added successfully", newuser);
                }
            }
            catch (Exception exception)
            {
                return CreateFailureMessage<User>(exception.Message, null);
            }
        }

        public OperationResult<User> LoginUser(string email, string password)
        {
            try
            {
                List<User> userList = UserRepository.Find(fuser => fuser.Email == email && fuser.Password == password);
                if (userList.Count != 0)
                {
                    return CreateSuccessMessage<User>("User Found", userList[0]);
                }
                else
                {
                    return CreateFailureMessage<User>("User Not Found", null);
                }
            }
            catch(Exception exception)
            {
                return CreateFailureMessage<User>(exception.Message, null);
            }
        }
    }
}
