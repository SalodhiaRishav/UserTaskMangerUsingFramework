using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using Shared.DomainModels;

namespace Shared.Validators
{
    public class TaskValidator : AbstractValidator<Task>
    {
        public TaskValidator()
        {
            RuleFor(task => task.ExpectedTime).NotNull().NotEmpty().GreaterThanOrEqualTo(0);
            RuleFor(task => task.TimeSpent).NotNull().NotEmpty().GreaterThanOrEqualTo(0);
            RuleFor(task => task.UserStory).NotNull().NotEmpty().Length(1, 200);
            RuleFor(task => task.TaskDate).NotNull().NotEmpty();


        }
    }
}
