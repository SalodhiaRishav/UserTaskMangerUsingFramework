using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace Shared.Utils
{
    public class MessageFormat<T>
    {
        public Boolean Success { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
        public IList<ValidationFailure> Errors { get; set; }
    }
}
