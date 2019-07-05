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
            OperationResult<User> result = null;
            if (!validationResult.IsValid)
            {
                result = CreateFailureMessage<User>("Invalid Data", validationResult.Errors,"400");
            }

            try
            {
                List<User> userList = UserRepository.List;
                User user = userList.Find(fuser => fuser.Email == newuser.Email);
                if (user != null)
                {
                    result = CreateFailureMessage<User>("Email already exists", null,"400");
                }
                else
                {
                    UserRepository.Add(newuser);
                    result = CreateSuccessMessage<User>("Added successfully", newuser);
                }
            }
            catch (Exception exception)
            {
                result = CreateFailureMessage<User>(exception.Message, null,"500");
            }
            return result;
        }

        public OperationResult<User> LoginUser(string email, string password)
        {
            OperationResult<User> result = null;
            try
            {
                List<User> userList = UserRepository.Find(fuser => fuser.Email == email && fuser.Password == password);
                if (userList.Count != 0)
                {
                   result = CreateSuccessMessage<User>("User Found", userList[0]);
                }
                else
                {
                    result = CreateFailureMessage<User>("User Not Found", null,"404");
                }
            }
            catch(Exception exception)
            {
                result = CreateFailureMessage<User>(exception.Message, null,"500");
            }
            return result;
        }
    }
}
