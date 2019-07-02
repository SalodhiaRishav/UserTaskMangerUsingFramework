using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Shared.DomainModels;

namespace Shared.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.FirstName).NotNull().NotEmpty().Length(1,15);
            RuleFor(user => user.LastName).NotNull().NotEmpty().Length(1, 15);
            RuleFor(user => user.Password).NotNull().NotEmpty().Length(1, 15);
            RuleFor(user => user.Email).EmailAddress();
        }
    }
}
