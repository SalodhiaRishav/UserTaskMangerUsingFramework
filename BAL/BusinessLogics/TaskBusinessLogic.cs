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

    public class TaskBusinessLogic : BaseBusinessLogic, ITaskBusinessLogic
    {
        public TaskRepository TaskRepository;
        public TaskBusinessLogic(TaskRepository taskRepository)
        {
            TaskRepository = taskRepository;
        }
        public OperationResult<Task> AddTask(Task task)
        {
            OperationResult<Task> result = null;
            TaskValidator taskValidator = new TaskValidator();
            ValidationResult validationResult = taskValidator.Validate(task);
            if (!validationResult.IsValid)
            {
                result = CreateFailureMessage<Task>("Invalid Data", validationResult.Errors, "400");
            }
            try
            {
                this.TaskRepository.Add(task);
                result = CreateSuccessMessage<Task>("Task Added Successully", task);
            }
            catch (Exception exception)
            {
                result = CreateFailureMessage<Task>(exception.Message, null, "500");
            }
            return result;
        }

        public OperationResult<Task> DeleteTask(int taskId)
        {
            OperationResult<Task> result = null;
            try
            {
                Task task = this.TaskRepository.FindById(taskId);
                if (task == null)
                {
                    result = CreateFailureMessage<Task>("No task found with this id", null, "404");
                }
                else
                {
                    this.TaskRepository.Delete(task);
                    result = CreateSuccessMessage<Task>("Task Deleted Successfully", null);
                }
            }
            catch (Exception exception)
            {
                result = CreateFailureMessage<Task>(exception.Message, null, "500");
            }
            return result;
        }

        public OperationResult<List<Shared.DomainModels.Task>> GetAllTasks()
        {
            OperationResult<List<Task>> result = null;
            try
            {
                List<Task> taskList = this.TaskRepository.List;
                if (taskList.Count == 0)
                {
                    result = CreateFailureMessage<List<Task>>("Empty tasks", null, "404");
                }
                else
                {
                    result = CreateSuccessMessage<List<Task>>("Tasks retrieved successfully", taskList);
                }
            }
            catch (Exception exception)
            {
                result = CreateFailureMessage<List<Task>>(exception.Message, null, "500");
            }
            return result;
        }

        public OperationResult<List<Task>> GetTasksForUserId(int userId)
        {
            OperationResult<List<Task>> result = null;
            try
            {
                List<Task> tasks = this.TaskRepository.Find(task => task.UserID == userId);
                if (tasks.Count == 0)
                {
                    result = CreateFailureMessage<List<Task>>("Not any task found for this user", null, "404");
                }
                else
                {
                    result = CreateSuccessMessage<List<Task>>("Tasks retrieved successfully", tasks);
                }
            }
            catch (Exception exception)
            {
                result = CreateFailureMessage<List<Task>>(exception.Message, null, "500");
            }
            return result;
        }

        public OperationResult<Task> UpdateTask(Task task)
        {
            OperationResult<Task> result = null;
            TaskValidator taskValidator = new TaskValidator();
            ValidationResult validationResult = taskValidator.Validate(task);
            if (!validationResult.IsValid)
            {
                result = CreateFailureMessage<Task>("Invalid Data", validationResult.Errors, "400");
            }
            try
            {
                this.TaskRepository.Update(task);
                result = CreateSuccessMessage<Task>("Task updated successfully", task);
            }
            catch (Exception exception)
            {
                result = CreateFailureMessage<Task>(exception.Message, null, "500");
            }
            return result;
        }
    }
}
