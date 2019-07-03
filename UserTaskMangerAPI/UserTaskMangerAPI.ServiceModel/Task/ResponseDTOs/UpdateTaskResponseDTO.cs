using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Utils;

namespace UserTaskManger.ServiceModel.Task.ResponseDTOs
{
    public class UpdateTaskResponseDTO
    {
        public MessageFormat<Shared.DomainModels.Task> Result { get; set; }
    }
}
