namespace Shared.Interfaces.BusinessLogicInterfaces
{
    using System.Collections.Generic;
    using Shared.DomainModels;
    using Shared.Utils;

    public interface ITaskBusinessLogic
    {
        OperationResult<Task> AddTask(Task task);
        OperationResult<List<Task>> GetAllTasks();
        OperationResult<List<Task>> GetTasksForUser(int userId);
        OperationResult<Task> DeleteTask(int taskId);
        OperationResult<Task> UpdateTask(Task task);
    }
}
