namespace Shared.Validators
{
    using FluentValidation;

    public static class CustomNulOrEmptyValidator
    {
        public static IRuleBuilderOptions<T, string> CheckNull<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must((rootObject, item, context) =>
            {
                return item != null;
            })
            .WithMessage("'{PropertyName}' should not be null.");         
        }
    }
}
