
using ServiceStack;


namespace UserTaskManger.ServiceInterface.Services
{
    public class TaskService : Service
    {
        //readonly ITaskBusinessLogic TaskBusinessLogic;
        //public TaskService(ITaskBusinessLogic taskBusinessLogic)
        //{
        //     TaskBusinessLogic = taskBusinessLogic;
        //}

        //public object Post(CreateTaskRequestDTO createTaskRequestDTO)
        //{
        //    try
        //    {
        //       MessageFormat<TaskDTO> result=this.TaskBusinessLogic.Add(createTaskRequestDTO.TaskDTO);
        //       return new CreateTaskResponseDTO { Result = result };
        //    }
        //    catch(Exception exception)
        //    {
        //        throw exception;
        //    }
        //}

        //public object Delete(DeleteTaskRequestDTO deleteTaskRequestDTO)
        //{
        //    try
        //    {
        //        MessageFormat<TaskDTO> result = this.TaskBusinessLogic.Delete(deleteTaskRequestDTO.Id);
        //        return new CreateTaskResponseDTO { Result = result };
        //    }
        //    catch(Exception exception)
        //    {
        //        throw exception;
        //    }
        //}

        //public object Get(GetAllTasksRequestDTO getAllTasksRequestDTO)
        //{
        //    try
        //    {
        //        MessageFormat<List<TaskDTO>> result = this.TaskBusinessLogic.GetAll();
        //        return new GetAllTaskCategoriesResponseDTO { Result = result };
        //    }
        //    catch(Exception exception)
        //    {
        //        throw exception;
        //    }
        //}

        //public object Get(GetTaskByIdRequestDTO getTaskByIdRequestDTO)
        //{
        //    try
        //    {
        //        MessageFormat<TaskDTO> result = this.TaskBusinessLogic.GetById(getTaskByIdRequestDTO.Id);
        //        return new GetTaskCategoryByIdResponseDTO { Result = result };
        //    }
        //    catch(Exception exception)
        //    {
        //        throw exception;
        //    }
        //}
    }
}
