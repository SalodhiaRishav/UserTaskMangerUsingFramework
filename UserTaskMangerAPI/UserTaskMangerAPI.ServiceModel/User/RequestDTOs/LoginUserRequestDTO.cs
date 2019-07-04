namespace UserTaskMangerAPI.ServiceModel.User.RequestDTOs
{
    using ServiceStack.ServiceHost;
    using Shared.Utils;

    [Route("/user", "POST")]
    public class LoginUserRequestDTO : IReturn<OperationResult<Shared.DomainModels.User>>
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}
