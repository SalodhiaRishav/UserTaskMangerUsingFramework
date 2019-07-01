using System;
using System.Collections.Generic;
using System.Text;
using Shared;
using Shared.Utils;

namespace UserTaskManger.ServiceModel.TaskCategory.ResponseDTOs
{
    public class GetAllTaskCategoriesResponseDTO
    {
        public MessageFormat<List<Shared.DomainModels.TaskCategory>> Result { get; set; }
    }
}
