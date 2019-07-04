namespace UserTaskMangerAPI.ServiceModel.TaskCategory.RequestDTOs
{
    using ServiceStack.ServiceHost;
    using Shared.Utils;

    [Route("/taskcategory", "POST")]
    public class CreateTaskCategoryRequestDTO : IReturn<OperationResult<Shared.DomainModels.TaskCategory>>
    {
       public Shared.DomainModels.TaskCategory TaskCategory { get; set; }
    }
}
