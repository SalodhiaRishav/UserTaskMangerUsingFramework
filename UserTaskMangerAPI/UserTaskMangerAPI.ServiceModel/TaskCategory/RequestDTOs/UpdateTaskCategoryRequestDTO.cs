using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.ServiceHost;

namespace UserTaskManger.ServiceModel.TaskCategory.RequestDTOs
{
    [Route("/taskcategory", "PUT")]
    public class UpdateTaskCategoryRequestDTO
    {
        public Shared.DomainModels.TaskCategory TaskCategory { get; set; }
    }
}
