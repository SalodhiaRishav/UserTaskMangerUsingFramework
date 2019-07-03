using System;
using System.Collections.Generic;
using System.Text;
using Shared.Utils;

namespace UserTaskManger.ServiceModel.User.RequestDTOs
{
    public class UpdateUserResponseDTO
    {
        public MessageFormat<Shared.DomainModels.User> Result { get; set; }
    }
}
