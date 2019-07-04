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
            TaskValidator taskValidator = new TaskValidator();
            ValidationResult validationResult = taskValidator.Validate(task);
            if (!validationResult.IsValid)
            {
                return CreateFailureMessage<Task>("Invalid Data", validationResult.Errors);
            }
            try
            {
                this.TaskRepository.Add(task);
                return CreateSuccessMessage<Task>("Task Added Successully", task);
            }
            catch (Exception exception)
            {
                return CreateFailureMessage<Task>(exception.Message, null);
            }
        }

        public OperationResult<Task> DeleteTask(int taskId)
        {
            try
            {
                Task task = this.TaskRepository.FindById(taskId);
                if (task == null)
                {
                    return CreateFailureMessage<Task>("No task found with this id", null);
                }
                this.TaskRepository.Delete(task);
                return CreateSuccessMessage<Task>("Task Deleted Successfully", null);
            }
            catch (Exception exception)
            {
                return CreateFailureMessage<Task>(exception.Message, null);
            }
        }

        public OperationResult<List<Shared.DomainModels.Task>> GetAllTasks()
        {
            try
            {
                List<Task> taskList = this.TaskRepository.List;
                if (taskList.Count == 0)
                {
                    return CreateFailureMessage<List<Task>>("Empty tasks", null);
                }
                return CreateSuccessMessage<List<Task>>("Tasks retrieved successfully", taskList);
            }
            catch (Exception exception)
            {
                return CreateFailureMessage<List<Task>>(exception.Message, null);
            }
        }

        public OperationResult<List<Task>> GetTasksForUserId(int userId)
        {
            try
            {
                List<Task> tasks = this.TaskRepository.Find(task => task.UserID == userId);
                if (tasks.Count==0)
                {
                    return CreateFailureMessage<List<Task>>("Not any task found for this user", null);
                }
                return CreateSuccessMessage<List<Task>>("Tasks retrieved successfully", tasks);            
            }
            catch (Exception exception)
            {
                return CreateFailureMessage<List<Task>>(exception.Message, null);
            }
        }

        public OperationResult<Task> UpdateTask(Task task)
        {
            TaskValidator taskValidator = new TaskValidator();
            ValidationResult validationResult = taskValidator.Validate(task);
            if (!validationResult.IsValid)
            {
                return CreateFailureMessage<Task>("Invalid Data", validationResult.Errors);            
            }
            try
            {
                this.TaskRepository.Update(task);
                return CreateSuccessMessage<Task>("Task updated successfully", task);
            }
            catch (Exception exception)
            {
                return CreateFailureMessage<Task>(exception.Message, null);
            }
        }
    }
}
