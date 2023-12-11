using System.Globalization;
using FluentValidation;
using NutriFoods_UI.Data;
using NutriFoods_UI.Utils.Date;
using NutriFoods_UI.Utils.Enums;
using static System.Globalization.CultureInfo;

namespace NutriFoods_UI.Utils.Validators.Patients;

public class PersonalInfoValidator : AbstractValidator<PersonalInfoDto>
{
    //private const int MinAge = 18;
    //private const int MaxAge = 60;
    
    public PersonalInfoValidator()
    {
        // Name
        RuleFor(e => e.Names)
            .Must(e => !string.IsNullOrWhiteSpace(e) && e.Length >= 2)
            .WithMessage(e => "Debes ingresar por lo menos un nombre de más de dos caracteres");

        // Last name
        RuleFor(e => e.LastNames)
            .Must(e => !string.IsNullOrWhiteSpace(e) && e.Length >= 2)
            .WithMessage(e => "Debes ingresar por lo menos un apellido de más de dos caracteres");

        // Birthdate
        RuleFor(e => e.Birthdate).Custom((str, context) =>
        {
            if (!DateOnly.TryParseExact(str, DateOnlyUtils.AllowedFormats, InvariantCulture, DateTimeStyles.None,
                    out var date))
            {
                context.AddFailure("La fecha no es válida");
                return;
            }

            var age = date.Difference(Interval.Years, false);
            switch (age)
            {
                case < 0:
                    context.AddFailure(
                        $"User's date of birth can't be greater than current date (User's birth date: {str} - Current date: {DateTime.Now.ToDateOnly()})");
                    break;
                case < 18 or > 60:
                    context.AddFailure("La edad no esta dentro de los rangos permitidos (18-60 años)");
                    break;
            }
        });

        // Biological sex
        RuleFor(e => e.BiologicalSex)
            .Must(e => IEnum<BiologicalSexes, BiologicalSexToken>.ReadableNameDictionary.ContainsKey(e))
            .WithMessage(e => "El sexo no corresponde a un elemento de la lista");
    }
    
    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<PersonalInfoDto>.CreateWithOptions((PersonalInfoDto)model, x => x.IncludeProperties(propertyName)));
        return result.IsValid ? Array.Empty<string>() : result.Errors.Select(e => e.ErrorMessage);
    };
    
}