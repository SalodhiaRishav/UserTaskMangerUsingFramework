using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.ServiceHost;

namespace UserTaskManger.ServiceModel.Task.RequestDTOs
{
    [Route("/task", "PUT")]
    public class UpdateTaskRequestDTO
    {
        public Shared.DomainModels.Task Task { get; set; }
    }
}
