using Shared.Utils;

namespace UserTaskManger.ServiceModel.User.ResponseDTOs
{
    public class CreateUserResponseDTO
    {
        public MessageFormat<Shared.DomainModels.User> Result { get; set; }
    }
}
