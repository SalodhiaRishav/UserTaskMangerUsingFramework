using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Repositories;
using Shared.DomainModels;
using Shared.Interfaces.BusinessLogicInterfaces;
using Shared.Utils;


namespace BAL.BusinessLogics
{
    public class TaskBusinessLogic : ITaskBusinessLogic
    {
        public TaskRepository TaskRepository;
        public TaskBusinessLogic(TaskRepository taskRepository)
        {
            TaskRepository = taskRepository;
        }
        public MessageFormat<Shared.DomainModels.Task> Add(Shared.DomainModels.Task task)
        {
            MessageFormat<Task> result = new MessageFormat<Task>();
            task.CreatedOn = DateTime.Now;
            task.ModifiedOn = DateTime.Now;
            try
            {
                this.TaskRepository.Add(task);           
                result.Data = task;
                result.Message = "Added successfully";
                result.Success = true;
                return result;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public MessageFormat<Shared.DomainModels.Task> Delete(int id)
        {
            MessageFormat<Task> result = new MessageFormat<Task>();
            try
            {
                Task task = this.TaskRepository.FindById(id);
                if (task == null)
                {
                    result.Message = "No task found with this id";
                    result.Success = false;
                    return result;
                }
                this.TaskRepository.Delete(task);
                result.Message = "Deleted Successfully";
                result.Success = true;
                return result;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public MessageFormat<List<Shared.DomainModels.Task>> GetAll()
        {
            MessageFormat<List<Task>> result = new MessageFormat<List<Task>>();
            try
            {
                List<Task> taskList = this.TaskRepository.List;
                if (taskList.Count == 0)
                {
                    result.Message = "Empty List";
                    result.Success = false;
                    return result;
                }
                result.Message = "Retrieved Successfully";
                result.Success = true;
                result.Data = taskList;
                return result;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public MessageFormat<Shared.DomainModels.Task> GetById(int id)
        {
            MessageFormat<Task> result = new MessageFormat<Task>();
            try
            {
               Task task = this.TaskRepository.FindById(id);
                if (task == null)
                {
                    result.Message = "No task found with this id";
                    result.Success = false;
                    return result;
                }
                result.Message = "Retrieved Successfully";
                result.Data = task;
                result.Success = true;
                return result;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public MessageFormat<Shared.DomainModels.Task> Update(Shared.DomainModels.Task task)
        {
            MessageFormat<Task> result = new MessageFormat<Task>();
            task.ModifiedOn = DateTime.Now;
            try
            {
                this.TaskRepository.Update(task);
                result.Message = "Updated Successfully";
                result.Data = task;
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
