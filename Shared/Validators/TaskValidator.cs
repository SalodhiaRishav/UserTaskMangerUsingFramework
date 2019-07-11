namespace Shared.Validators
{
    using System;
    using FluentValidation;
    using Shared.DomainModels;

    public class TaskValidator : AbstractValidator<Task>
    {
        public TaskValidator()
        {
            RuleFor(task => task.ExpectedTime).GreaterThan(0);
            RuleFor(task => task.TimeSpent).GreaterThan(0);
            RuleFor(task => task.UserStory).CheckNull().CheckEmpty().Length(1, 200);
            RuleFor(task => task.TaskDate).Must(taskDate => taskDate > DateTime.MinValue)
                .WithMessage($"Please enter date greater than {DateTime.MinValue}");
        }
    }
}
