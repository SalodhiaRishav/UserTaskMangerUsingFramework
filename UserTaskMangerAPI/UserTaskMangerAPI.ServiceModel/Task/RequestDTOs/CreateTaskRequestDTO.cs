using System;
using System.Collections.Generic;
using System.Text;
using ServiceStack;
using UserTaskManger.ServiceModel.Task.ResponseDTOs;


namespace UserTaskManger.ServiceModel.Task.RequestDTOs
{
    [Route("/task", "POST")]
    public class CreateTaskRequestDTO : IReturn<CreateTaskResponseDTO>
    {
       public Shared.DomainModels.Task Task { get; set; }
    }
}
