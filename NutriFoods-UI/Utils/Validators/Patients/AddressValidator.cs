using FluentValidation;
using NutriFoods_UI.Data.Dto;
using NutriFoods_UI.Utils.Enums;

namespace NutriFoods_UI.Utils.Enums.Validators.Patients;

public class AddressValidator : AbstractValidator<AddressDto>
{
    public AddressValidator()
    {
        // Street
        RuleFor(e => e.Street)
            .Must(e => !string.IsNullOrWhiteSpace(e) && e.Length >= 2)
            .WithMessage(e => "El nombre no puede ser menor a 2 caracteres");

        // Number
        RuleFor(e => e.Number).GreaterThan(0);

        // Postal code
        RuleFor(e => e.PostalCode).GreaterThan(0).When(e => e.PostalCode != null);

        // Province
        RuleFor(e => e.Province)
            .Must(e => IEnum<Provinces, ProvinceToken>.ReadableNameDictionary.ContainsKey(e))
            .WithMessage(e => $"El item seleccionado no corresponde a una provincia válida");
    }
    
    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<AddressDto>.CreateWithOptions((AddressDto)model, x => x.IncludeProperties(propertyName)));
        return result.IsValid ? Array.Empty<string>() : result.Errors.Select(e => e.ErrorMessage);
    };
}