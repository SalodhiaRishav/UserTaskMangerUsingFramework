using System;
using System.Collections.Generic;
using System.Text;
using ServiceStack;
using ServiceStack.ServiceHost;
using UserTaskManger.ServiceModel.TaskCategory.ResponseDTOs;
namespace UserTaskManger.ServiceModel.TaskCategory.RequestDTOs
{
    
    [Route("/taskcategory", "POST")]
    public class CreateTaskCategoryRequestDTO
    {
       public Shared.DomainModels.TaskCategory TaskCategory { get; set; }
    }
}
