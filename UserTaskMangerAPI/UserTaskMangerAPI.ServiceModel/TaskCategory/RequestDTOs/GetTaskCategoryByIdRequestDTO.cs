namespace UserTaskMangerAPI.ServiceModel.TaskCategory.RequestDTOs
{
    using ServiceStack.ServiceHost;
    using Shared.Utils;

    [Route("/taskcategory/{Id}","GET")]
    public class GetTaskCategoryByIdRequestDTO : IReturn<OperationResult<Shared.DomainModels.TaskCategory>>
    {
        public int Id { get; set; }
    }
}
