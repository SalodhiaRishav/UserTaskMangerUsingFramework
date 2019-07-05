namespace UserTaskMangerAPI.ServiceModel.User.RequestDTOs
{
    using ServiceStack.ServiceHost;
    using Shared.Utils;

    [Route("/user", "POST")]
    public class LoginUserRequestDTO : IReturn<OperationResult<Shared.DomainModels.User>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
