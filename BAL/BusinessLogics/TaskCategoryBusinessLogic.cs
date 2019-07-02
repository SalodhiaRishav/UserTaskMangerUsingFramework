using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories;
using FluentValidation.Results;
using Shared.DomainModels;
using Shared.Interfaces.BusinessLogicInterfaces;
using Shared.Utils;
using Shared.Validators;

namespace BAL.BusinessLogics
{
    public class TaskCategoryBusinessLogic : ITaskCategoryBusinessLogic
    {
        public TaskCategoryRepository TaskCategoryRepository;
        public TaskCategoryBusinessLogic(TaskCategoryRepository taskCategoryRepository)
        {
            this.TaskCategoryRepository = taskCategoryRepository;
        }
        public MessageFormat<TaskCategory> Add(TaskCategory taskCategory)
        {
            MessageFormat<TaskCategory> result = new MessageFormat<TaskCategory>();
            TaskCategoryValidator taskCategoryValidator = new TaskCategoryValidator();
            ValidationResult validationResult = taskCategoryValidator.Validate(taskCategory);
            if (!validationResult.IsValid)
            {
                result.Success = false;
                result.Errors = validationResult.Errors;
                result.Message = "Invalid Data";
                return result;
            }
            taskCategory.CreatedOn = DateTime.Now;
            taskCategory.ModifiedOn = DateTime.Now;
            try
            {
                this.TaskCategoryRepository.Add(taskCategory);              
                result.Data = taskCategory;
                result.Message = "Added successfully";
                result.Success = true;
                return result;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public MessageFormat<TaskCategory> Delete(int id)
        {
            MessageFormat<TaskCategory> result = new MessageFormat<TaskCategory>();
            try
            {
                TaskCategory taskCategory = this.TaskCategoryRepository.FindById(id);
                if (taskCategory == null)
                {
                    result.Message = "No taskcategory found with this id";
                    result.Success = false;
                    return result;
                }
                this.TaskCategoryRepository.Delete(taskCategory);              
                result.Message = "Deleted Successfully";
                result.Success = true;
                return result;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public MessageFormat<List<TaskCategory>> GetAll()
        {
            MessageFormat<List<TaskCategory>> result = new MessageFormat<List<TaskCategory>>();
            try
            {
                List<TaskCategory> taskCategoryList = this.TaskCategoryRepository.List;
                if (taskCategoryList.Count == 0)
                {
                    result.Message = "Empty List";
                    result.Success = false;
                    return result;
                }               
                result.Message = "Retrieved Successfully";
                result.Success = true;
                result.Data = taskCategoryList;
                return result;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public MessageFormat<TaskCategory> GetById(int id)
        {
            MessageFormat<TaskCategory> result = new MessageFormat<TaskCategory>();
            try
            {
                TaskCategory taskCategory = this.TaskCategoryRepository.FindById(id);
                if (taskCategory == null)
                {
                    result.Message = "No task found with this id";
                    result.Success = false;
                    return result;
                }
                result.Message = "Retrieved Successfully";
                result.Data = taskCategory;
                result.Success = true;
                return result;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public MessageFormat<TaskCategory> Update(TaskCategory taskCategory)
        {
            MessageFormat<TaskCategory> result = new MessageFormat<TaskCategory>();
            TaskCategoryValidator taskCategoryValidator = new TaskCategoryValidator();
            ValidationResult validationResult = taskCategoryValidator.Validate(taskCategory);
            if (!validationResult.IsValid)
            {
                result.Success = false;
                result.Errors = validationResult.Errors;
                result.Message = "Invalid Data";
                return result;
            }
            taskCategory.ModifiedOn = DateTime.Now;
            try
            {
                this.TaskCategoryRepository.Update(taskCategory);
                result.Message = "Updated Successfully";
                result.Data = taskCategory;
                result.Success = true;
                return result;

            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
