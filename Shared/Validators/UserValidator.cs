namespace Shared.Validators
{
    using FluentValidation;
    using Shared.DomainModels;

    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.FirstName).Cascade(CascadeMode.StopOnFirstFailure).CheckNull().NotEmpty().Length(1, 20);
            RuleFor(user => user.LastName).Cascade(CascadeMode.StopOnFirstFailure).CheckNull().NotEmpty().Length(1, 20);
            RuleFor(user => user.Password).Cascade(CascadeMode.StopOnFirstFailure).CheckNull().NotEmpty().Length(1, 20);
            RuleFor(user => user.Email).EmailAddress();
        }
    }
}
