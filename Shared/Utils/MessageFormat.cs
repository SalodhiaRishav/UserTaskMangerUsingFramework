namespace Shared.Utils
{
    using System.Collections.Generic;
    using FluentValidation.Results;

    public class MessageFormat<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
        public IList<ValidationFailure> Errors { get; set; }
    }
}
