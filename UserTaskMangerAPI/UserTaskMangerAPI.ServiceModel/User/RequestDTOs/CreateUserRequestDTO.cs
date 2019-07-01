using ServiceStack;
using UserTaskManger.ServiceModel.User.ResponseDTOs;

namespace UserTaskManger.ServiceModel.User.RequestDTOs
{
    [Route("/user", "POST")]
    public class CreateUserRequestDTO : IReturn<CreateUserResponseDTO>
    {
        public Shared.DomainModels.User User{ get; set; }
    }
}
