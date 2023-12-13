using System.Data;
using FluentValidation;
using NutriFoods_UI.Data.Dto;
using NutriFoods_UI.Utils.Enums;

namespace NutriFoods_UI.Utils.Validators.Anamnesis;

public class IngestibleValidator :  AbstractValidator<IngestibleDto>
{
    public IngestibleValidator()
    {
        // Name
        RuleFor(e => e.Name)
            .Must(e => !string.IsNullOrWhiteSpace(e) && e.Length >= 2)
            .WithMessage(e => "Debes ingresar por lo menos un nombre de más de dos caracteres");

        // Type
        RuleFor(e => e.Type)
            .NotEmpty()
            .WithMessage("El tipo no puede estar vacío.");

        // AdministrationTimes
        RuleFor(e => e.AdministrationTimes)
            .NotEmpty()
            .WithMessage("Los tiempos de administración no pueden estar vacíos.");

        // Dosage
        RuleFor(e => e.Dosage)
            .GreaterThanOrEqualTo(0).When(e => e.Dosage.HasValue)
            .WithMessage("La dosis no puede ser negativa.");

        // Adherence
        RuleFor(e => e.Adherence)
            .NotEmpty()
            .Must(e => IEnum<Frequencies, FrequencyToken>.ReadableNameDictionary.ContainsKey(e))
            .WithMessage("La adherencia no puede estar vacía.");

        // Observations
        RuleFor(e => e.Observations)
            .MaximumLength(255)
            .WithMessage("Las observaciones no pueden tener más de 255 caracteres.");
    }
    
    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<IngestibleDto>.CreateWithOptions((IngestibleDto)model,
            x => x.IncludeProperties(propertyName)));
        return result.IsValid ? Array.Empty<string>() : result.Errors.Select(e => e.ErrorMessage);
    };
}