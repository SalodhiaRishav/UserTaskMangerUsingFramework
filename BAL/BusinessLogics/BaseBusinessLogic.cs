namespace BAL.BusinessLogics
{
    using System.Collections.Generic;
    using FluentValidation.Results;
    using Shared.Utils;

    public class BaseBusinessLogic
    {
        public static OperationResult<TypeOfEntity> CreateSuccessMessage<TypeOfEntity>(string message, TypeOfEntity data)
        {
            OperationResult<TypeOfEntity> result = new OperationResult<TypeOfEntity>();
            result.Success = true;
            result.Data = data;
            result.Message = message;
            return result;
        }

        public static OperationResult<TypeOfEntity> CreateFailureMessage<TypeOfEntity>(string message,IList<ValidationFailure> validationeErrors)
        {
            OperationResult<TypeOfEntity> result = new OperationResult<TypeOfEntity>();
            List<string> errors = new List<string>();           
            foreach(var error in validationeErrors)
            {
                errors.Add(error.ErrorMessage);
            }
            result.Errors = errors;
            result.Message = message;
            result.Success = false;
            return result;
        }
    }
}
