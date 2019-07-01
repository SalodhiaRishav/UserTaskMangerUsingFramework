using System.Collections.Generic;
using Shared.Utils;

namespace UserTaskManger.ServiceModel.User.ResponseDTOs
{
    public class GetAllUsersResponseDTO
    {
        public MessageFormat<List<Shared.DomainModels.User>> Result { get; set; }
    }
}
