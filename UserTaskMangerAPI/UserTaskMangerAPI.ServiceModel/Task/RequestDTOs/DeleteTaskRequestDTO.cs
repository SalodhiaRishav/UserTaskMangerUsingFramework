namespace UserTaskMangerAPI.ServiceModel.Task.RequestDTOs
{
    using ServiceStack.ServiceHost;
    using Shared.Utils;

    [Route("/task/{Id}", "DELETE")]
    public class DeleteTaskRequestDTO : IReturn<OperationResult<Shared.DomainModels.Task>>
    {
        public int Id { get; set; }
    }
}
