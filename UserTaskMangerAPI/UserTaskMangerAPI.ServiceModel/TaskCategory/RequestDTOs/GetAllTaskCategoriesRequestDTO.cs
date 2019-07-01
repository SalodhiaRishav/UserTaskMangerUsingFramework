using System;
using System.Collections.Generic;
using System.Text;
using ServiceStack;
using UserTaskManger.ServiceModel.Task.ResponseDTOs;

namespace UserTaskManger.ServiceModel.TaskCategory.RequestDTOs
{
    [Route("/taskcategory", "GET")]
    public class GetAllTaskCategoriesRequestDTO : IReturn<GetAllTaskCategoriesResponseDTO>
    {
      
    }
}
