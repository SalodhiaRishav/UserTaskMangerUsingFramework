using Shared.Utils;

namespace UserTaskManger.ServiceModel.User.ResponseDTOs
{
    public class DeleteUserResponseDTO
    {
        public MessageFormat<Shared.DomainModels.User> Result { get; set; }
    }
}
