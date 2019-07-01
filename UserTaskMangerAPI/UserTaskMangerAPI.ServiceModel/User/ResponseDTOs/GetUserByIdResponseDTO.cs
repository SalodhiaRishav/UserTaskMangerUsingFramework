using Shared.DomainModels;
using Shared.Utils;

namespace UserTaskManger.ServiceModel.User.ResponseDTOs
{
    public class GetUserByIdResponseDTO
    {
        public MessageFormat<Shared.DomainModels.User> Result { get; set; }
    }
}
