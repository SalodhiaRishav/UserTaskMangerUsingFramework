using ServiceStack;
using ServiceStack.ServiceHost;

using UserTaskManger.ServiceModel.User.ResponseDTOs;

namespace UserTaskManger.ServiceModel.User.RequestDTOs
{
    [Route("/user", "POST")]
    public class CreateUserRequestDTO 
    {
        public Shared.DomainModels.User User{ get; set; }
    }
}
