namespace BAL.BusinessLogics
{
    using System;
    using System.Collections.Generic;
    using FluentValidation.Results;
    using Shared.DomainModels;
    using Shared.Interfaces.BusinessLogicInterfaces;
    using Shared.Interfaces.RepositoryInterfaces;
    using Shared.Utils;
    using Shared.Validators;

    public class TaskBusinessLogic : BaseBusinessLogic, ITaskBusinessLogic
    {
        private readonly ITaskRepository TaskRepository;
        public TaskBusinessLogic(ITaskRepository taskRepository)
        {
            TaskRepository = taskRepository;
        }

        public OperationResult<Task> AddTask(Task task)
        {
            TaskValidator taskValidator = new TaskValidator();
            ValidationResult validationResult = taskValidator.Validate(task);
            if (!validationResult.IsValid)
            {
                return CreateFailureResult<Task>("Invalid Data", validationResult.Errors, "400");
            }
            try
            {
                this.TaskRepository.Add(task);
                return CreateSuccessResult<Task>("Task Added Successully", task);
            }
            catch (Exception exception)
            {
                Logger.Instance.Error(exception.Message, exception);
                return CreateFailureResult<Task>(exception.Message, null, "500");
            }
        }

        public OperationResult<Task> DeleteTask(int taskId)
        {
            try
            {
                Task task = this.TaskRepository.FindById(taskId);
                if (task == null)
                {
                    return CreateFailureResult<Task>("No task found with this id", null, "404");
                }
                else
                {
                    this.TaskRepository.Delete(task);
                   return CreateSuccessResult<Task>("Task Deleted Successfully", null);
                }
            }
            catch (Exception exception)
            {
                Logger.Instance.Error(exception.Message, exception);
                return CreateFailureResult<Task>(exception.Message, null, "500");
            }
        }

        public OperationResult<List<Shared.DomainModels.Task>> GetAllTasks()
        {
            try
            {
                List<Task> taskList = this.TaskRepository.List;
                if (taskList.Count == 0)
                {
                    return CreateFailureResult<List<Task>>("Empty tasks", null, "404");
                }
                else
                {
                    return CreateSuccessResult<List<Task>>("Tasks retrieved successfully", taskList);
                }
            }
            catch (Exception exception)
            {
                Logger.Instance.Error(exception.Message, exception);
                return CreateFailureResult<List<Task>>(exception.Message, null, "500");
            }
        }

        public OperationResult<List<Task>> GetTasksForUser(int userId)
        {
            try
            {
                List<Task> tasks = this.TaskRepository.Find(task => task.UserID == userId);
                if (tasks.Count == 0)
                {
                    return CreateFailureResult<List<Task>>("Not any task found for this user", null, "404");
                }
                else
                {
                    return CreateSuccessResult<List<Task>>("Tasks retrieved successfully", tasks);
                }
            }
            catch (Exception exception)
            {
                Logger.Instance.Error(exception.Message, exception);
                return CreateFailureResult<List<Task>>(exception.Message, null, "500");
            }
        }

        public OperationResult<Task> UpdateTask(Task task)
        {
            TaskValidator taskValidator = new TaskValidator();
            ValidationResult validationResult = taskValidator.Validate(task);
            if (!validationResult.IsValid)
            {
                return CreateFailureResult<Task>("Invalid Data", validationResult.Errors, "400");
            }
            try
            {
                this.TaskRepository.Update(task);
                return CreateSuccessResult<Task>("Task updated successfully", task);
            }
            catch (Exception exception)
            {
                Logger.Instance.Error(exception.Message, exception);
                return CreateFailureResult<Task>(exception.Message, null, "500");
            }
        }
    }
}
