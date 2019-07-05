namespace Shared.Interfaces.BusinessLogicInterfaces
{
    using System.Collections.Generic;
    using Shared.DomainModels;
    using Shared.Utils;

    public interface ITaskCategoryBusinessLogic
    {
        OperationResult<TaskCategory> AddTaskCategory(TaskCategory taskCategory);
        OperationResult<List<TaskCategory>> GetAllTaskCategories();
        OperationResult<TaskCategory> GetTaskCategoryById(int id);
    }
}
