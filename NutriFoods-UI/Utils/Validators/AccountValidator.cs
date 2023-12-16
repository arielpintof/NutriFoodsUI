using FluentValidation;
using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Utils.Enums.Validators;

public class AccountValidator : AbstractValidator<NutritionistDto>
{
    public AccountValidator()
    {
        // Email
        RuleFor(e => e.Email)
            .EmailAddress()
            .WithMessage(e => $"Provided argument “{e.Email}” does not correspond to a valid email.");
        // Username
        RuleFor(e => e.Username)
            .Matches(RegexUtils.Username)
            .WithMessage(e => "");
        // Password
        RuleFor(e => e.Password)
            .Matches(RegexUtils.Password)
            .WithMessage(e => "");
    }
    
    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<NutritionistDto>.CreateWithOptions((NutritionistDto)model, x => x.IncludeProperties(propertyName)));
        return result.IsValid ? Array.Empty<string>() : result.Errors.Select(e => e.ErrorMessage);
    };
}