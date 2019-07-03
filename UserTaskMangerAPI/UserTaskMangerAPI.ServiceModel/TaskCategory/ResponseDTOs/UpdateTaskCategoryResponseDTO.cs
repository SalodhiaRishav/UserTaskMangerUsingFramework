using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Utils;

namespace UserTaskManger.ServiceModel.TaskCategory.ResponseDTOs
{
    public class UpdateTaskCategoryResponseDTO
    {
        public MessageFormat<Shared.DomainModels.TaskCategory> Result { get; set; }
    }
}
