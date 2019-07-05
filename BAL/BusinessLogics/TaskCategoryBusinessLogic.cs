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
            OperationResult<TaskCategory> result = null;
            if (!validationResult.IsValid)
            {
                result = CreateFailureMessage<TaskCategory>("Invalid Data", validationResult.Errors, "400");
            }
            try
            {
                this.TaskCategoryRepository.Add(taskCategory);
                result = CreateSuccessMessage<TaskCategory>("TaskCategory Added Successfully", taskCategory);
            }
            catch (Exception exception)
            {
                result = CreateFailureMessage<TaskCategory>(exception.Message, null, "500");
            }
            return result;
        }

        public OperationResult<List<TaskCategory>> GetAllTaskCategories()
        {
            OperationResult<List<TaskCategory>> result = null;
            try
            {
                List<TaskCategory> taskCategoryList = this.TaskCategoryRepository.List;
                if (taskCategoryList.Count == 0)
                {
                    result = CreateFailureMessage<List<TaskCategory>>("Empty List", null, "404");
                }
                else
                {
                    result = CreateSuccessMessage<List<TaskCategory>>("Fetched Successfully", taskCategoryList);
                }
            }
            catch (Exception exception)
            {
                result = CreateFailureMessage<List<TaskCategory>>(exception.Message, null, "500");
            }
            return result;
        }

        public OperationResult<TaskCategory> GetTaskCategoryById(int id)
        {
            OperationResult<TaskCategory> result = null;
            try
            {
                TaskCategory taskCategory = this.TaskCategoryRepository.FindById(id);
                if (taskCategory == null)
                {
                    result = CreateFailureMessage<TaskCategory>("TaskCategory Not Found", null,"404");
                }
                return CreateSuccessMessage<TaskCategory>("TaskCategory Has Found", taskCategory);
            }
            catch (Exception exception)
            {
                result = CreateFailureMessage<TaskCategory>(exception.Message, null,"500");
            }
            return result;
        }
    }
}
