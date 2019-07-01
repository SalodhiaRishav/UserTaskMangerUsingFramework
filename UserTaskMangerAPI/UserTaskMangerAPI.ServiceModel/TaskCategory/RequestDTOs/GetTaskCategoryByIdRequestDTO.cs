using System;
using System.Collections.Generic;
using System.Text;
using ServiceStack;
using UserTaskManger.ServiceModel.TaskCategory.ResponseDTOs;

namespace UserTaskManger.ServiceModel.TaskCategory.RequestDTOs
{
    [Route("/task/{Id}","GET")]
    public class GetTaskCategoryByIdRequestDTO : IReturn<GetTaskCategoryByIdResponseDTO>
    {
        public int Id { get; set; }
    }
}
