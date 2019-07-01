using System;
using System.Collections.Generic;
using System.Text;
using Shared;
using Shared.Utils;


namespace UserTaskManger.ServiceModel.Task.ResponseDTOs
{
    public class GetTaskCategoryByIdResponseDTO
    {
       public MessageFormat<Shared.DomainModels.Task> Result { get; set; }
    }
}
