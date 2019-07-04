namespace UserTaskManger.ServiceModel.User.RequestDTOs
{
    using ServiceStack.ServiceHost;

    [Route("/user/{Id}","GET")]
    public class GetUserByIdRequestDTO 
    {
        public int Id { get; set; }
    }
}
