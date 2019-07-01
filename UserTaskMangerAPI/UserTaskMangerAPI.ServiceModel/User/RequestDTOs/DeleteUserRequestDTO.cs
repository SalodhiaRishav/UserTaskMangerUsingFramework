using System;
using System.Collections.Generic;
using System.Text;
using ServiceStack;
using UserTaskManger.ServiceModel.User.ResponseDTOs;

namespace UserTaskManger.ServiceModel.User.RequestDTOs
{
    [Route("/user/{Id}","DELETE")]
    public class DeleteUserRequestDTO : IReturn<DeleteUserResponseDTO>
    {
        public int Id { get; set; }
    }
}
