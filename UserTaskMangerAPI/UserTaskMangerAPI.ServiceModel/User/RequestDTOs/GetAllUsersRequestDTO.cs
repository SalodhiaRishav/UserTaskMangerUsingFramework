using ServiceStack;
using UserTaskManger.ServiceModel.User.ResponseDTOs;

namespace UserTaskManger.ServiceModel.User.RequestDTOs
{
    [Route("/user","GET")]
    public class GetAllUsersRequestDTO : IReturn<GetAllUsersResponseDTO>
    {
    }
}
