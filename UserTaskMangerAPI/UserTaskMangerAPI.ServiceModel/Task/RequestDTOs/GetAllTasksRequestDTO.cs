namespace UserTaskMangerAPI.ServiceModel.Task.RequestDTOs
{
    using System.Collections.Generic;
    using ServiceStack.ServiceHost;
    using Shared.Utils;

    [Route("/task", "GET")]
    public class GetAllTasksRequestDTO : IReturn<OperationResult<List<Shared.DomainModels.Task>>>
    {
      
    }
}
