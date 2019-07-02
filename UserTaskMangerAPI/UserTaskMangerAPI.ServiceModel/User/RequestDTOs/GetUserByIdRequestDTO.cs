using ServiceStack;

using UserTaskManger.ServiceModel.User.ResponseDTOs;
using ServiceStack.ServiceHost;


namespace UserTaskManger.ServiceModel.User.RequestDTOs
{
    [Route("/user/{Id}","GET")]
    public class GetUserByIdRequestDTO 
    {
        public int Id { get; set; }
    }
}
