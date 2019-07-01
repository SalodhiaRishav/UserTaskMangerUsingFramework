using System;
using System.Collections.Generic;
using System.Text;
using ServiceStack;
using UserTaskManger.ServiceModel.TaskCategory.ResponseDTOs;
namespace UserTaskManger.ServiceModel.TaskCategory.RequestDTOs
{
    
    [Route("/taskcategory", "POST")]
    public class CreateTaskCategoryRequestDTO : IReturn<CreateTaskCategoryRequestDTO>
    {
       public Shared.DomainModels.TaskCategory TaskCategory { get; set; }
    }
}
