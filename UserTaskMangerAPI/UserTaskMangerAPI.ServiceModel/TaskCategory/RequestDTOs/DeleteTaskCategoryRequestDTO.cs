using System;
using System.Collections.Generic;
using System.Text;
using ServiceStack;
using UserTaskManger.ServiceModel.TaskCategory.ResponseDTOs;

namespace UserTaskManger.ServiceModel.TaskCategory.RequestDTOs
{
    [Route("/taskcategory/{Id}", "DELETE")]
    public class DeleteTaskCategoryRequestDTO : IReturn<DeleteTaskCategoryResponseDTO>
    {
        public int Id { get; set; }
    }
}
