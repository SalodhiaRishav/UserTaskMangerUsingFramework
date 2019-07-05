namespace UserTaskMangerAPI.ServiceModel.Task.RequestDTOs
{
    using ServiceStack.ServiceHost;
    using Shared.Utils;

    [Route("/task", "PUT")]
    public class UpdateTaskRequestDTO : IReturn<OperationResult<Shared.DomainModels.Task>>
    {
        public Shared.DomainModels.Task Task { get; set; }
    }
}
