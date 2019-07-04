namespace UserTaskMangerAPI.ServiceModel.TaskCategory.RequestDTOs
{
    using System.Collections.Generic;
    using ServiceStack.ServiceHost;
    using Shared.Utils;

    [Route("/taskcategory", "GET")]
    public class GetAllTaskCategoriesRequestDTO : IReturn<OperationResult<List<Shared.DomainModels.TaskCategory>>>
    {     
    }
}
