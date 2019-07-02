using ServiceStack;

using UserTaskManger.ServiceModel.User.ResponseDTOs;
using ServiceStack.ServiceHost;


namespace UserTaskManger.ServiceModel.User.RequestDTOs
{
    [Route("/user","GET")]
    public class GetAllUsersRequestDTO
    {
    }
}
