namespace UserTaskManger.ServiceInterface.Services
{
    using System;
    using System.Collections.Generic;
    using ServiceStack.ServiceInterface;
    using Shared.DomainModels;
    using Shared.Interfaces.BusinessLogicInterfaces;
    using Shared.Utils;
    using UserTaskManger.ServiceModel.Task.RequestDTOs;

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

        public object Get(GetAllTasksRequestDTO getAllTasksRequestDTO)
        {
            try
            {
                OperationResult<List<Task>> result = this.TaskBusinessLogic.GetAll();
                return new GetAllTasksResponseDTO { Result = result };
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public OperationResult<Task> Put(UpdateTaskRequestDTO updateTaskRequestDTO)
        {
            try
            {
                OperationResult<Task> result = this.TaskBusinessLogic.Update(updateTaskRequestDTO.Task);
                return new UpdateTaskResponseDTO { Result = result };
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public object Get(GetTaskByIdRequestDTO getTaskByIdRequestDTO)
        {
            try
            {
                OperationResult<Task> result = this.TaskBusinessLogic.GetById(getTaskByIdRequestDTO.Id);
                return new GetTaskByIdResponseDTO { Result = result };
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public object Execute(Task request)
        {
            throw new NotImplementedException();
        }
    }
}
