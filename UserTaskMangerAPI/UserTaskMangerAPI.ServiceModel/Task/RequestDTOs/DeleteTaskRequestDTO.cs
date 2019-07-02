using System;
using System.Collections.Generic;
using System.Text;
using ServiceStack;

using UserTaskManger.ServiceModel.Task.ResponseDTOs;
using ServiceStack.ServiceHost;


namespace UserTaskManger.ServiceModel.Task.RequestDTOs
{
    [Route("/task/{Id}", "DELETE")]
    public class DeleteTaskRequestDTO 
    {
        public int Id { get; set; }
    }
}
