namespace BAL.BusinessLogics
{
    using System;
    using System.Collections.Generic;
    using DAL.Repositories;
    using FluentValidation.Results;
    using Shared.DomainModels;
    using Shared.Interfaces.BusinessLogicInterfaces;
    using Shared.Utils;
    using Shared.Validators;

    public class TaskCategoryBusinessLogic : BaseBusinessLogic, ITaskCategoryBusinessLogic
    {
        public TaskCategoryRepository TaskCategoryRepository;

        public TaskCategoryBusinessLogic(TaskCategoryRepository taskCategoryRepository)
        {
            this.TaskCategoryRepository = taskCategoryRepository;
        }

        public OperationResult<TaskCategory> AddTaskCategory(TaskCategory taskCategory)
        {
            TaskCategoryValidator taskCategoryValidator = new TaskCategoryValidator();
            ValidationResult validationResult = taskCategoryValidator.Validate(taskCategory);
            if (!validationResult.IsValid)
            {
               return CreateFailureResult<TaskCategory>("Invalid Data", validationResult.Errors, "400");
            }
            try
            {
                this.TaskCategoryRepository.Add(taskCategory);
                return CreateSuccessResult<TaskCategory>("TaskCategory Added Successfully", taskCategory);
            }
            catch (Exception exception)
            {
                return CreateFailureResult<TaskCategory>(exception.Message, null, "500");
            }
        }

        public OperationResult<List<TaskCategory>> GetAllTaskCategories()
        {
            try
            {
                List<TaskCategory> taskCategoryList = this.TaskCategoryRepository.List;
                if (taskCategoryList.Count == 0)
                {
                   return CreateFailureResult<List<TaskCategory>>("Empty List", null, "404");
                }
                else
                {
                    return CreateSuccessResult<List<TaskCategory>>("Fetched Successfully", taskCategoryList);
                }
            }
            catch (Exception exception)
            {
                return CreateFailureResult<List<TaskCategory>>(exception.Message, null, "500");
            }
        }

        public OperationResult<TaskCategory> GetTaskCategoryById(int id)
        {
            try
            {
                TaskCategory taskCategory = this.TaskCategoryRepository.FindById(id);
                if (taskCategory == null)
                {
                    return CreateFailureResult<TaskCategory>("TaskCategory Not Found", null,"404");
                }
                return CreateSuccessResult<TaskCategory>("TaskCategory Has Found", taskCategory);
            }
            catch (Exception exception)
            {
                return CreateFailureResult<TaskCategory>(exception.Message, null,"500");
            }
        }
    }
}
