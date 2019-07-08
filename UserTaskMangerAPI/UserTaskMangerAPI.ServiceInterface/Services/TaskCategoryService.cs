namespace UserTaskMangerAPI.ServiceInterface.Services
{
    using System.Collections.Generic;
    using ServiceStack.ServiceInterface;
    using Shared.DomainModels;
    using Shared.Interfaces.BusinessLogicInterfaces;
    using Shared.Utils;
    using UserTaskMangerAPI.ServiceModel.TaskCategory.RequestDTOs;

    public class TaskCategoryService : Service
    {
        private readonly ITaskCategoryBusinessLogic TaskCategoryBusinessLogic;
        public TaskCategoryService(ITaskCategoryBusinessLogic taskCategoryBusinessLogic)
        {
            TaskCategoryBusinessLogic = taskCategoryBusinessLogic;
        }

        public OperationResult<TaskCategory> Post(CreateTaskCategoryRequestDTO request)
        {
            return this.TaskCategoryBusinessLogic.AddTaskCategory(request.TaskCategory);
        }

        public OperationResult<List<TaskCategory>> Get(GetAllTaskCategoriesRequestDTO request)
        {
            return this.TaskCategoryBusinessLogic.GetAllTaskCategories();
        }

        public OperationResult<TaskCategory> Get(GetTaskCategoryByIdRequestDTO request)

        {
            return this.TaskCategoryBusinessLogic.GetTaskCategoryById(request.Id);
        }
    }
}
