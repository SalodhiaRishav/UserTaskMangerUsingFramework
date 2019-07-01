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
        MessageFormat<User> Add(User user);
        MessageFormat<List<User>> GetAll();
        MessageFormat<User> GetById(int id);
        MessageFormat<User> Delete(int id);
        MessageFormat<User> Update(User userDTO);
    }
}
