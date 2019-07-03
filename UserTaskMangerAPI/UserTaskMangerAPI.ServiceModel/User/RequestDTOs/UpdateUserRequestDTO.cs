using System;
using System.Collections.Generic;
using System.Text;
using ServiceStack.ServiceHost;

namespace UserTaskManger.ServiceModel.User.RequestDTOs
{
    [Route("/user", "PUT")]
    public class UpdateUserRequestDTO
    {
        public Shared.DomainModels.User User { get; set; }
    }
}
