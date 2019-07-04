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
                return CreateFailureMessage<TaskCategory>("Invalid Data", validationResult.Errors);
            }
            try
            {
                this.TaskCategoryRepository.Add(taskCategory);
                return CreateSuccessMessage<TaskCategory>("TaskCategory Added Successfully", taskCategory);
            }
            catch (Exception exception)
            {
                return CreateFailureMessage<TaskCategory>(exception.Message, null);
            }
        }

        public OperationResult<List<TaskCategory>> GetAllTaskCategories()
        {
            try
            {
                List<TaskCategory> taskCategoryList = this.TaskCategoryRepository.List;
                if (taskCategoryList.Count == 0)
                {
                    return CreateFailureMessage<List<TaskCategory>>("Empty List", null);
                }  
                else
                {
                    return CreateSuccessMessage<List<TaskCategory>>("Fetched Successfully", taskCategoryList);
                }
            }
            catch (Exception exception)
            {
                return CreateFailureMessage<List<TaskCategory>>(exception.Message, null);
            }
        }

        public OperationResult<TaskCategory> GetTaskCategoryById(int id)
        {
            try
            {
                TaskCategory taskCategory = this.TaskCategoryRepository.FindById(id);
                if (taskCategory == null)
                {
                    return CreateFailureMessage<TaskCategory>("TaskCategory Not Found", null);
                }
                return CreateSuccessMessage<TaskCategory>("TaskCategory Has Found", taskCategory);
            }
            catch (Exception exception)
            {
                return CreateFailureMessage<TaskCategory>(exception.Message, null);
            }
        }
    }
}
