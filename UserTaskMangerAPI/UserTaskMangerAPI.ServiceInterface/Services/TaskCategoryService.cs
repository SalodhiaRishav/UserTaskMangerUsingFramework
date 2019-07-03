
using System;
using System.Collections.Generic;
using ServiceStack;
using ServiceStack.ServiceInterface;
using Shared.DomainModels;
using Shared.Interfaces.BusinessLogicInterfaces;
using Shared.Utils;
using UserTaskManger.ServiceModel.TaskCategory.RequestDTOs;
using UserTaskManger.ServiceModel.TaskCategory.ResponseDTOs;

namespace UserTaskManger.ServiceInterface.Services
{
    public class TaskCategoryService : Service
    {
        readonly ITaskCategoryBusinessLogic TaskCategoryBusinessLogic;
        public TaskCategoryService(ITaskCategoryBusinessLogic taskCategoryBusinessLogic)
        {
            TaskCategoryBusinessLogic = taskCategoryBusinessLogic;
        }

        public object Post(CreateTaskCategoryRequestDTO createTaskRequestDTO)
        {
            try
            {
                MessageFormat<TaskCategory> result = this.TaskCategoryBusinessLogic.Add(createTaskRequestDTO.TaskCategory);
                return new CreateTaskCategoryResponseDTO { Result = result };
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public object Delete(DeleteTaskCategoryRequestDTO deleteTaskCategoryRequestDTO)
        {
            try
            {
                MessageFormat<TaskCategory> result = this.TaskCategoryBusinessLogic.Delete(deleteTaskCategoryRequestDTO.Id);
                return new DeleteTaskCategoryResponseDTO { Result = result };
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public object Get(GetAllTaskCategoriesRequestDTO getAllTasksRequestDTO)
        {
            try
            {
                MessageFormat<List<TaskCategory>> result = this.TaskCategoryBusinessLogic.GetAll();
                return new GetAllTaskCategoriesResponseDTO { Result = result };
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public object Get(GetTaskCategoryByIdRequestDTO getTaskByIdRequestDTO)
        {
            try
            {
                MessageFormat<TaskCategory> result = this.TaskCategoryBusinessLogic.GetById(getTaskByIdRequestDTO.Id);
                return new GetTaskCategoryByIdResponseDTO { Result = result };
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public object Put(UpdateTaskCategoryRequestDTO updateTaskCategoryRequestDTO)
        {
            try
            {
                MessageFormat<TaskCategory> result = this.TaskCategoryBusinessLogic.Update(updateTaskCategoryRequestDTO.TaskCategory);
                return new UpdateTaskCategoryResponseDTO { Result = result };
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
