using NutriFoods_UI.Utils;
using NutriFoods_UI.Utils.Enums;
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
            var actualQuantity = solution
                .SelectMany(e => e.Nutrients)
                .Where(e => string.Equals(e.Nutrient, target.Nutrient, StringComparison.InvariantCultureIgnoreCase))
                .Sum(e => e.Quantity);
            var actualError = MathUtils.RelativeError(actualQuantity, target.ExpectedQuantity);
            target.ActualQuantity = actualQuantity;
            target.ActualError = actualError;
        }
    }

    public static IEnumerable<NutritionalTargetDto> DistributionToTargets(
        IDictionary<Nutrients, double> distributionDict, double energy, double errorMargin)
    {
        yield return new NutritionalTargetDto
        {
            Nutrient = Energy.ReadableName,
            ExpectedQuantity = energy,
            ExpectedError = errorMargin,
            Unit = Energy.Unit.ReadableName,
            ThresholdType = ThresholdTypes.WithinRange.ReadableName,
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
                ThresholdType = ThresholdTypes.WithinRange.ReadableName,
                IsPriority = true
            };
        }
    }
}