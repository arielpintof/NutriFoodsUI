
using FluentValidation;
using NutriFoods_UI.Data.Store.DailyMeal;
using NutriFoods_UI.Utils.Enums;
using NutriFoods_UI.Utils.Enumerable;
using static NutriFoods_UI.Utils.Enums.IEnum<NutriFoods_UI.Utils.Enums.Nutrients, NutriFoods_UI.Utils.Enums.NutrientToken>;
using static NutriFoods_UI.Utils.Enums.NutrientExtensions;
using static NutriFoods_UI.Utils.Enums.Nutrients;

namespace NutriFoods_UI.Data.Dto;

public class NutritionalTargetDto
{
    public string Nutrient { get; set; } = null!;
    public double ExpectedQuantity { get; set; }
    public double? ActualQuantity { get; set; }
    public double ExpectedError { get; set; }
    public double? ActualError { get; set; }
    public string Unit { get; set; } = null!;
    public string ThresholdType { get; set; } = null!;
    public bool IsPriority { get; set; }
}

public static class TargetExtensions
{
    public static void IncludeActualValues(this ICollection<NutritionalTargetDto> targets, IList<RecipeDto> solution)
    {
        foreach (var target in targets)
        {
            var thresholdType = IEnum<ThresholdTypes, ThresholdToken>.ToValue(target.ThresholdType);
            var actualQuantity = solution
                .SelectMany(e => e.Nutrients)
                .Where(e => string.Equals(e.Nutrient, target.Nutrient, StringComparison.InvariantCultureIgnoreCase))
                .Sum(e => e.Quantity);
            var actualError = thresholdType == ThresholdTypes.Exact
                ? MathUtils.RelativeError(actualQuantity, target.ExpectedQuantity)
                : 0;
            target.ActualQuantity = actualQuantity;
            target.ActualError = actualError;
        }
    }

    public static IEnumerable<NutritionalTargetDto> MacroDistributionToTargets(
        IDictionary<Nutrients, double> distributionDict, double energy, double errorMargin)
    {
        yield return new NutritionalTargetDto
        {
            Nutrient = Energy.ReadableName,
            ExpectedQuantity = energy,
            ExpectedError = errorMargin,
            Unit = Energy.Unit.ReadableName,
            ThresholdType = ThresholdTypes.Exact.ReadableName,
            IsPriority = true
        };
        foreach (var (nutrient, grams) in distributionDict)
        {
            yield return new NutritionalTargetDto
            {
                Nutrient = nutrient.ReadableName,
                ExpectedQuantity = grams,
                ExpectedError = errorMargin,
                Unit = nutrient.Unit.ReadableName,
                ThresholdType = ThresholdTypes.Exact.ReadableName,
                IsPriority = true
            };
        }
    }

    public static IEnumerable<NutritionalTargetDto> ToTargets(
        PlanConfiguration configuration, double intakePercentage)
    {
        return configuration.Targets.Select(target => new NutritionalTargetDto
        {
            Nutrient = target.Nutrient,
            ExpectedQuantity = target.ExpectedQuantity * intakePercentage,
            ExpectedError = target.ExpectedError,
            Unit = target.Unit,
            ThresholdType = target.ThresholdType,
            IsPriority = target.IsPriority
        });
    }

    

    public static void ValidateMacronutrients<T>(ICollection<NutritionalTargetDto> targets,
        ValidationContext<T> context, double tolerance) where T : class
    {
        if (targets.Count(t => Macronutrients.Contains(ToValue(t.Nutrient))) != Macronutrients.Count)
        {
            context.AddFailure($"""
                                The following macronutrients are missing as targets in the collection:
                                {Macronutrients
                                    .Except(targets.Select(t => ToValue(t.Nutrient)))
                                    .Select(t => t.ReadableName)
                                    .ToJoinedString(", ", ("«", "»"))}
                                """);
            return;
        }

        var expectedEnergy = targets.First(e => ToValue(e.Nutrient) == Energy).ExpectedQuantity;
        var actualEnergy = targets.Where(e =>
                ToValue(e.Nutrient) != Energy && Macronutrients.Contains(ToValue(e.Nutrient)))
            .Select(e => e.ExpectedQuantity * KCalFactors[ToValue(e.Nutrient)])
            .Sum();
        if (Math.Abs(expectedEnergy - actualEnergy) > tolerance)
            context.AddFailure(
                $"The macronutrients' caloric content do not add up to the required caloric intake ({expectedEnergy})");
    }
}