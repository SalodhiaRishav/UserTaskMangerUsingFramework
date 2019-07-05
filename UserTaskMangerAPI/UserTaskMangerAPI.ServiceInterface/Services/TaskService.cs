namespace UserTaskManger.ServiceInterface.Services
{
    using System;
    using System.Collections.Generic;
    using ServiceStack.ServiceInterface;
    using Shared.DomainModels;
    using Shared.Interfaces.BusinessLogicInterfaces;
    using Shared.Utils;
    using UserTaskMangerAPI.ServiceModel.Task.RequestDTOs;

    public class TaskService : Service
    {
        private readonly ITaskBusinessLogic TaskBusinessLogic;
        public TaskService(ITaskBusinessLogic taskBusinessLogic)
        {
            TaskBusinessLogic = taskBusinessLogic;
        }

        public OperationResult<Task> Post(CreateTaskRequestDTO request)
        {
            return this.TaskBusinessLogic.AddTask(request.Task);
        }

        public OperationResult<Task> Delete(DeleteTaskRequestDTO request)
        {
            return this.TaskBusinessLogic.DeleteTask(request.Id);
        }

        public object Get(GetTasksForUserRequestDTO request)

        {
            return this.TaskBusinessLogic.GetTasksForUser(request.UserId);
        }

        public object Get(GetAllTasksRequestDTO request)
        {
            return this.TaskBusinessLogic.GetAllTasks();
        }

        public OperationResult<Task> Put(UpdateTaskRequestDTO request)
        {
            return this.TaskBusinessLogic.UpdateTask(request.Task);
        }
    }
}
