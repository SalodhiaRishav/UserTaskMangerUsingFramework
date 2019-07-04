
namespace UserTaskManger.ServiceModel.User.ResponseDTOs
{
    using Shared.Utils;

    public class CreateUserResponseDTO
    {
        public MessageFormat<Shared.DomainModels.User> Result { get; set; }
    }
}
