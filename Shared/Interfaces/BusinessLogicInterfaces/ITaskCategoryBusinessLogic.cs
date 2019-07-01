using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DomainModels;
using Shared.Utils;

namespace Shared.Interfaces.BusinessLogicInterfaces
{
    public interface ITaskCategoryBusinessLogic
    {
        MessageFormat<TaskCategory> Add(TaskCategory taskCategory);
        MessageFormat<List<TaskCategory>> GetAll();
        MessageFormat<TaskCategory> GetById(int id);
        MessageFormat<TaskCategory> Delete(int id);
        MessageFormat<TaskCategory> Update(TaskCategory taskCategory);
    }
}
