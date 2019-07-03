using System.Collections.Generic;
using ServiceStack;
using UserTaskManger.ServiceModel.User.RequestDTOs;
using UserTaskManger.ServiceModel.User.ResponseDTOs;
using System;
using Shared.Interfaces.BusinessLogicInterfaces;
using Shared.Utils;
using Shared.DomainModels;
using ServiceStack.ServiceInterface;

namespace UserTaskManger.ServiceInterface.Services
{
    public class UserService : Service
    {
        readonly IUserBusinessLogic UserBusinessLogic;
        public UserService(IUserBusinessLogic userBusinessLogic)
        {
            UserBusinessLogic = userBusinessLogic;
        }

        public object Get(GetUserByIdRequestDTO getUserByIdRequestDTO)
        {
            try
            {
                MessageFormat<User> result = this.UserBusinessLogic.GetById(getUserByIdRequestDTO.Id);
                return new GetUserByIdResponseDTO { Result = result };
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public object Get(GetAllUsersRequestDTO request)
        {
            try
            {
                MessageFormat<List<User>> result = this.UserBusinessLogic.GetAll();
                return new GetAllUsersResponseDTO { Result = result };
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public object Delete(DeleteUserRequestDTO deleteUserRequestDTO)
        {
            try
            {
                MessageFormat<User> result = this.UserBusinessLogic.Delete(deleteUserRequestDTO.Id);
                return new DeleteUserResponseDTO { Result = result };
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public object Post(CreateUserRequestDTO createUserRequestDTO)
        {
            try
            {
                MessageFormat<User> result = this.UserBusinessLogic.Add(createUserRequestDTO.User);
                return new CreateUserResponseDTO { Result = result };
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }

        public object Put(UpdateUserRequestDTO updateUserRequestDTO)
        {
            try
            {
                MessageFormat<User> result = this.UserBusinessLogic.Update(updateUserRequestDTO.User);
                return new UpdateUserResponseDTO { Result = result };
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
