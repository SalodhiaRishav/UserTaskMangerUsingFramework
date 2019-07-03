
using System;
using System.Collections.Generic;
using ServiceStack;
using ServiceStack.ServiceInterface;
using Shared.DomainModels;
using Shared.Interfaces.BusinessLogicInterfaces;
using Shared.Utils;
using UserTaskManger.ServiceModel.Task.RequestDTOs;
using UserTaskManger.ServiceModel.Task.ResponseDTOs;

namespace UserTaskManger.ServiceInterface.Services
{
    public class TaskService : Service
    {
        readonly ITaskBusinessLogic TaskBusinessLogic;
        public TaskService(ITaskBusinessLogic taskBusinessLogic)
        {
            TaskBusinessLogic = taskBusinessLogic;
        }

        public object Post(CreateTaskRequestDTO createTaskRequestDTO)
        {
            try
            {
                MessageFormat<Task> result = this.TaskBusinessLogic.Add(createTaskRequestDTO.Task);
                return new CreateTaskResponseDTO { Result = result };
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public object Delete(DeleteTaskRequestDTO deleteTaskRequestDTO)
        {
            try
            {
                MessageFormat<Task> result = this.TaskBusinessLogic.Delete(deleteTaskRequestDTO.Id);
                return new CreateTaskResponseDTO { Result = result };
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public object Get(GetAllTasksRequestDTO getAllTasksRequestDTO)
        {
            try
            {
                MessageFormat<List<Task>> result = this.TaskBusinessLogic.GetAll();
                return new GetAllTasksResponseDTO { Result = result };
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public object Put(UpdateTaskRequestDTO updateTaskRequestDTO)
        {
            try
            {
                MessageFormat<Task> result = this.TaskBusinessLogic.Update(updateTaskRequestDTO.Task);
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
                MessageFormat<Task> result = this.TaskBusinessLogic.GetById(getTaskByIdRequestDTO.Id);
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
