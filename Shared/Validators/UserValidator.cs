namespace Shared.Validators
{
    using FluentValidation;
    using Shared.DomainModels;

    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.FirstName).NotNull().NotEmpty().Length(1, 20);
            RuleFor(user => user.LastName).NotNull().NotEmpty().Length(1, 20);
            RuleFor(user => user.Password).NotNull().NotEmpty().Length(1, 20);
            RuleFor(user => user.Email).EmailAddress();
        }
    }
}
