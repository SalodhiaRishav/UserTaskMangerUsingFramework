namespace Shared.Validators
{
    using FluentValidation;
    using Shared.DomainModels;

    public class TaskCategoryValidator : AbstractValidator<TaskCategory>
    {
        public TaskCategoryValidator()
        {
            RuleFor(taskCategory => taskCategory.CategoryName).Cascade(CascadeMode.StopOnFirstFailure).CheckNull().NotEmpty().Length(1, 50);
        }

    }
}
