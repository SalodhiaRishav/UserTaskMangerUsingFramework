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
        OperationResult<Task> AddTask(Task task);
        OperationResult<List<Task>> GetAllTasks();
        OperationResult<List<Task>> GetTasksForUser(int userId);
        OperationResult<Task> DeleteTask(int taskId);
        OperationResult<Task> UpdateTask(Task task);
    }
}
