namespace Shared.Validators
{
    using FluentValidation;
    using Shared.DomainModels;

    public class TaskCategoryValidator : AbstractValidator<TaskCategory>
    {
        public TaskCategoryValidator()
        {
            RuleFor(taskCategory => taskCategory.CategoryName).CheckNull().CheckEmpty().Length(1, 50);
        }

    }
}
