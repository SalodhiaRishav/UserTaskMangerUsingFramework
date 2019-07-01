using ServiceStack;
using UserTaskManger.ServiceModel.User.ResponseDTOs;

namespace UserTaskManger.ServiceModel.User.RequestDTOs
{
    [Route("/user/{Id}","GET")]
    public class GetUserByIdRequestDTO : IReturn<GetUserByIdResponseDTO>
    {
        public int Id { get; set; }
    }
}
