using NutriFoods_UI.Utils.Enums;
using NutriFoods_UI.Data.Store.DailyMeal;
using static System.StringComparison;
using static NutriFoods_UI.Utils.Enums.IEnum<NutriFoods_UI.Utils.Enums.Nutrients, NutriFoods_UI.Utils.Enums.NutrientToken>;

namespace NutriFoods_UI.Data.Dto;

public class DailyPlanDto
{
    public string Day { get; set; } = null!;
    public string PhysicalActivityLevel { get; set; } = null!;
    public double PhysicalActivityFactor { get; set; }
    public double AdjustmentFactor { get; set; }
    public List<NutritionalValueDto> Nutrients { get; set; } = null!;
    public List<NutritionalTargetDto> Targets { get; set; } = null!;
    public List<DailyMenuDto> Menus { get; set; } = null!;
}

public static class DailyPlanExtensions
{
    public static IEnumerable<NutritionalTargetDto> ToTargets(this PlanConfiguration configuration,
        double totalMetabolicRate)
    {
        var energy = Nutrients.Energy;
        yield return new NutritionalTargetDto
        {
            Nutrient = energy.ReadableName,
            ExpectedQuantity = totalMetabolicRate,
            ExpectedError = configuration.AdjustmentFactor,
            Unit = energy.Unit.ReadableName,
            ThresholdType = ThresholdTypes.Exact.ReadableName,
            IsPriority = true
        };
        foreach (var (key, value) in configuration.Distribution)
        {
            var nutrient = ToValue(key);
            yield return new NutritionalTargetDto
            {
                Nutrient = nutrient.ReadableName,
                ExpectedQuantity = totalMetabolicRate * value * NutrientExtensions.GramFactors[nutrient],
                ExpectedError = configuration.AdjustmentFactor,
                Unit = nutrient.Unit.ReadableName,
                ThresholdType = ThresholdTypes.Exact.ReadableName,
                IsPriority = true
            };
        }
    }

    public static void AddMenuTargets(this DailyPlanDto dailyPlan)
    {
        foreach (var menu in dailyPlan.Menus)
        {
            var intakePercentage = menu.IntakePercentage;
            foreach (var target in dailyPlan.Targets)
            {
                menu.Targets.Add(new NutritionalTargetDto
                {
                    Nutrient = target.Nutrient,
                    ExpectedQuantity = intakePercentage * target.ExpectedQuantity,
                    ExpectedError = target.ExpectedError,
                    Unit = target.Unit,
                    ThresholdType = target.ThresholdType,
                    IsPriority = target.IsPriority
                });
            }
        }
    }

    public static void AddNutritionalValues(this DailyPlanDto dailyPlan)
    {
        foreach (var (nutrientName, actualQuantity) in dailyPlan.Menus
                     .SelectMany(e => e.Nutrients)
                     .GroupBy(e => e.Nutrient)
                     .Select(e => (e.Key, e.Sum(x => x.Quantity))))
        {
            var nutrient = ToValue(nutrientName);
            dailyPlan.Nutrients.Add(new NutritionalValueDto
            {
                Nutrient = nutrient.ReadableName,
                Quantity = actualQuantity,
                Unit = nutrient.Unit.ReadableName,
                DailyValue = nutrient.DailyValue.HasValue
                    ? Math.Round(actualQuantity / nutrient.DailyValue.Value, 2)
                    : null
            });
        }
    }

    public static void AddTargetValues(this DailyPlanDto dailyPlan)
    {
        foreach (var (nutrient, actualQuantity) in dailyPlan.Menus
                     .SelectMany(e => e.Targets)
                     .GroupBy(e => e.Nutrient)
                     .Select(e => (e.Key, e.Sum(x => x.ActualQuantity.GetValueOrDefault()))))
        {
            var target = dailyPlan.Targets.First(e => string.Equals(e.Nutrient, nutrient, InvariantCultureIgnoreCase));
            target.ActualQuantity = actualQuantity;
            target.ActualError = MathUtils.RelativeError(target.ExpectedQuantity, actualQuantity);
        }
    }
}