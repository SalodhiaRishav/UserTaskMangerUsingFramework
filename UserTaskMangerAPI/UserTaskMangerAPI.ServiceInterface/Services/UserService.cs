namespace UserTaskMangerAPI.ServiceInterface.Services
{
    using ServiceStack.ServiceInterface;
    using Shared.DomainModels;
    using Shared.Interfaces.BusinessLogicInterfaces;
    using Shared.Utils;
    using UserTaskMangerAPI.ServiceModel.User.RequestDTOs;

    public class UserService : Service
    {
        private readonly IUserBusinessLogic UserBusinessLogic;
        public UserService(IUserBusinessLogic userBusinessLogic)
        {
            UserBusinessLogic = userBusinessLogic;
        }

        public OperationResult<User> Post(CreateUserRequestDTO request)
        {           
            return this.UserBusinessLogic.AddUser(request.User);
        }

        public OperationResult<User> Post(LoginUserRequestDTO request)
        {
            return this.UserBusinessLogic.LoginUser(request.Email, request.Password);
        }
    }
}
