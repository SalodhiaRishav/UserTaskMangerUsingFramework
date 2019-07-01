using System;
using System.Collections.Generic;
using System.Text;
using ServiceStack;
using UserTaskManger.ServiceModel.Task.ResponseDTOs;

namespace UserTaskManger.ServiceModel.Task.RequestDTOs
{
    [Route("/task/{Id}", "DELETE")]
    public class DeleteTaskRequestDTO : IReturn<DeleteTaskCategoryResponseDTO>
    {
        public int Id { get; set; }
    }
}
