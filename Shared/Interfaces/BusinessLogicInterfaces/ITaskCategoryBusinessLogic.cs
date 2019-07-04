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
        OperationResult<TaskCategory> AddTaskCategory(TaskCategory taskCategory);
        OperationResult<List<TaskCategory>> GetAllTaskCategories();
        OperationResult<TaskCategory> GetTaskCategoryById(int id);
    }
}
