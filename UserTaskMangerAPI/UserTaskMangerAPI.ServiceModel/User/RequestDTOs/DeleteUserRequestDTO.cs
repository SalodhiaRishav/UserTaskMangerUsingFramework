using System;
using System.Collections.Generic;
using System.Text;
using ServiceStack;
using UserTaskManger.ServiceModel.User.ResponseDTOs;
using ServiceStack.ServiceHost;


namespace UserTaskManger.ServiceModel.User.RequestDTOs
{
    [Route("/user/{Id}","DELETE")]
    public class DeleteUserRequestDTO 
    {
        public int Id { get; set; }
    }
}
