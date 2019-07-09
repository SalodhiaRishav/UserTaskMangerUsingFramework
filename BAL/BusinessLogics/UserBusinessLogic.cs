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
                return CreateFailureResult<User>("Invalid Data", validationResult.Errors, "400");
            }

            try
            {
                List<User> userList = UserRepository.List;
                User user = userList.Find(fuser => fuser.Email == newuser.Email);
                if (user != null)
                {
                    return CreateFailureResult<User>("Email already exists", null, "400");
                }
                else
                {
                    UserRepository.Add(newuser);
                    return CreateSuccessResult<User>("Added successfully", newuser);
                }
            }
            catch (Exception exception)
            {
                Logger.Instance.Error(exception.Message, exception);
                return CreateFailureResult<User>(exception.Message, null, "500");
            }
        }

        public OperationResult<User> LoginUser(string email, string password)
        {
            try
            {
                List<User> userList = UserRepository.Find(fuser => fuser.Email.Equals(email,StringComparison.OrdinalIgnoreCase) && fuser.Password.Equals(password,StringComparison.OrdinalIgnoreCase));
                if (userList.Count != 0)
                {
                    return CreateSuccessResult<User>("User Found", userList[0]);
                }
                else
                {
                    return CreateFailureResult<User>("User Not Found", null, "404");
                }
            }
            catch (Exception exception)
            {
                Logger.Instance.Error(exception.Message, exception);
                return CreateFailureResult<User>(exception.Message, null, "500");
            }
        }
    }
}
