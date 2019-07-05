namespace Shared.Interfaces.BusinessLogicInterfaces
{
    using Shared.DomainModels;
    using Shared.Utils;

    public interface IUserBusinessLogic
    {
        OperationResult<User> AddUser(User user);
        OperationResult<User> LoginUser(string email, string password);
    }
}
