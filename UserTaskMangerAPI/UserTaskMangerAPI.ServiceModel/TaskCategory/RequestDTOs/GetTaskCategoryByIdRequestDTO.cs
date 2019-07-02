using System;
using System.Collections.Generic;
using System.Text;
using ServiceStack;

using UserTaskManger.ServiceModel.TaskCategory.ResponseDTOs;
using ServiceStack.ServiceHost;


namespace UserTaskManger.ServiceModel.TaskCategory.RequestDTOs
{
    [Route("/taskcategory/{Id}","GET")]
    public class GetTaskCategoryByIdRequestDTO
    {
        public int Id { get; set; }
    }
}
