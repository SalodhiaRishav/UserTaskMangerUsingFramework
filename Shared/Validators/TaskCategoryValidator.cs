using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Shared.DomainModels;

namespace Shared.Validators
{
    public class TaskCategoryValidator : AbstractValidator<TaskCategory>
    {
        public TaskCategoryValidator()
        {
            RuleFor(taskCategory => taskCategory.CategoryName).NotNull().NotEmpty().Length(1, 50);
        }

    }
}
