using System;
using System.Collections.Generic;
using System.Text;
using Shared;
using Shared.Utils;

namespace UserTaskManger.ServiceModel.TaskCategory.ResponseDTOs
{
    public class DeleteTaskCategoryResponseDTO
    {
        public MessageFormat<Shared.DomainModels.TaskCategory> Result { get; set; }
    }
}
