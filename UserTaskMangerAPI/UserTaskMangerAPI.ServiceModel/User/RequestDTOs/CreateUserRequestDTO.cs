namespace UserTaskMangerAPI.ServiceModel.User.RequestDTOs
{
    using ServiceStack.ServiceHost;
    using Shared.Utils;

    [Route("/user", "POST")]
    public class CreateUserRequestDTO : IReturn<OperationResult<Shared.DomainModels.User>>
    {
        public Shared.DomainModels.User User { get; set; }
    }
}
