using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DomainModels;
using Shared.Utils;

namespace Shared.Interfaces.BusinessLogicInterfaces
{
    public interface IUserBusinessLogic
    {
        OperationResult<User> AddUser(User user);
        OperationResult<User> LoginUser(string email, string password);
    }
}
