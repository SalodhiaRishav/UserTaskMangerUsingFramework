namespace UserTaskManger.ServiceModel.Task.RequestDTOs
{
    using ServiceStack.ServiceHost;
    using Shared.Utils;

    [Route("/task", "POST")]
    public class CreateTaskRequestDTO : IReturn<OperationResult<Shared.DomainModels.Task>> 
    {
       public Shared.DomainModels.Task Task { get; set; }
    }
}
