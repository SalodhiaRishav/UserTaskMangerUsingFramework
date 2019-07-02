using System;
using System.Collections.Generic;
using System.Text;
using ServiceStack;

using UserTaskManger.ServiceModel.Task.ResponseDTOs;
using ServiceStack.ServiceHost;



namespace UserTaskManger.ServiceModel.Task.RequestDTOs
{
    [Route("/task", "POST")]
    public class CreateTaskRequestDTO 
    {
       public Shared.DomainModels.Task Task { get; set; }
    }
}
