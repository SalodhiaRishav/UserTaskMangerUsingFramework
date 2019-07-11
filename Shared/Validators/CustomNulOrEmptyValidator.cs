namespace Shared.Validators
{
    using System;
    using FluentValidation;

    public static class CustomNulOrEmptyValidator
    {
        public static IRuleBuilderOptions<T, string> CheckNull<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must((rootObject, item, context) =>
            {
                if (item == null && item != "")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            })
            .WithMessage("'{PropertyName}' should not be null.");         
        }

        //public static IRuleBuilderOptions<T, string> CheckEmpty<T>(this IRuleBuilder<T, string> ruleBuilder)
        //{
        //    return ruleBuilder.Custom((item, context) => {
        //        if (item == "")
        //        {
        //            context.AddFailure("The list must contain 10 items or fewer");
        //        }
        //    });
        //}

        public static IRuleBuilderOptions<T, string> CheckEmpty<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must((rootObject, item, context) =>
            {
               if(item == "" && item!=null)
                {
                    return false;
                }
               else
                {
                    return true;
                }
            })
            .WithMessage("'{PropertyName}' should not be empty.");
        }
    }
}
