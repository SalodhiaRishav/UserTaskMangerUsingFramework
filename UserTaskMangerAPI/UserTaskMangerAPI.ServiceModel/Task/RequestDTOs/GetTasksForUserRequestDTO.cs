namespace UserTaskMangerAPI.ServiceModel.Task.RequestDTOs
{
    using System.Collections.Generic;
    using ServiceStack.ServiceHost;
    using Shared.Utils;

    [Route("/usertasks/{UserId}", "GET")]
    public class GetTasksForUserRequestDTO : IReturn<OperationResult<List<Shared.DomainModels.Task>>>
    {
        public int UserId { get; set; }
    }
}
