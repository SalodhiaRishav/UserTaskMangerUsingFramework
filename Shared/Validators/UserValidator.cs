namespace Shared.Validators
{
    using FluentValidation;
    using Shared.DomainModels;

    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.FirstName).CheckNull().CheckEmpty().Length(1, 20);
            RuleFor(user => user.LastName).CheckNull().CheckEmpty().Length(1, 20);
            RuleFor(user => user.Password).CheckNull().CheckEmpty().Length(1, 20);
            RuleFor(user => user.Email).EmailAddress();
        }
    }
}
