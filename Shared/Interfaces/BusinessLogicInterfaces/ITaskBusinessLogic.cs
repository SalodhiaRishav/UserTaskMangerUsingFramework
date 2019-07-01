using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shared.DomainModels;
using Shared.Utils;

namespace Shared.Interfaces.BusinessLogicInterfaces
{
   public interface ITaskBusinessLogic
    {
        MessageFormat<Task> Add(Task task);
        MessageFormat<List<Task>> GetAll();
        MessageFormat<Task> GetById(int id);
        MessageFormat<Task> Delete(int id);
        MessageFormat<Task> Update(Task task);
    }
}
