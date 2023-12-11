using FluentValidation;
using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Utils.Validators.Patients;

public class ContactInfoValidator : AbstractValidator<ContactInfoDto>
{
    public ContactInfoValidator()
    {
        
        RuleFor(e => e.MobilePhone)
            .Matches(RegexUtils.MobilePhone)
            .WithMessage(e => "Formato inválido");

        
        RuleFor(e => e.FixedPhone)
            .Matches(RegexUtils.FixedPhone)
            .When(e => e.FixedPhone != null)
            .WithMessage(e => "Formato invalido");

       
        RuleFor(e => e.Email)
            .EmailAddress()
            .WithMessage(e => $"Formato inválido");
    }
    
    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<ContactInfoDto>.CreateWithOptions((ContactInfoDto)model, x => x.IncludeProperties(propertyName)));
        return result.IsValid ? Array.Empty<string>() : result.Errors.Select(e => e.ErrorMessage);
    };
}