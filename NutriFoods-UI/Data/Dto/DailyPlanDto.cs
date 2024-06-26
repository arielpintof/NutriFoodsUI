using NutriFoods_UI.Data.Dto.Insertion;
using NutriFoods_UI.Utils.Enums;
using NutriFoods_UI.Data.Store.DailyMeal;
using static System.StringComparison;
using static NutriFoods_UI.Utils.Enums.IEnum<NutriFoods_UI.Utils.Enums.Nutrients, NutriFoods_UI.Utils.Enums.NutrientToken>;

namespace NutriFoods_UI.Data.Dto;

public class DailyPlanDto
{
    public List<string> Days { get; set; } = null!;
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

    public static Task AddNutritionalValues(this DailyPlanDto dailyPlan)
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
                    ? Math.Round(actualQuantity / nutrient.DailyValue.Value, 3)
                    : null
            });
        }

        dailyPlan.Nutrients.Sort((e1, e2) => ToValue(e1.Nutrient).CompareTo(ToValue(e2.Nutrient)));

        return Task.CompletedTask;
    }

    public static Task AddTargetValues(this DailyPlanDto dailyPlan)
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

        return Task.CompletedTask;
    }

    public static MinimalDailyPlan MapToMinimalDailyPlan(this DailyPlanDto dailyPlan)
    {
        var minimalRecipe = dailyPlan.Menus
            .SelectMany(m => m.Recipes.Select(e => new MinimalMenuRecipe()
            {
                RecipeId = e.Recipe.Id,
                Portions = e.Portions
            })).ToList();

        var minimalDailyMenu = dailyPlan.Menus.Select(m => new MinimalDailyMenu()
        {
            IntakePercentage = m.IntakePercentage,
            MealType = m.MealType,
            Hour = m.Hour,
            Nutrients = m.Nutrients,
            Targets = m.Targets,
            Recipes = minimalRecipe
        }).ToList();
            
        
        return new MinimalDailyPlan
        {
            Days = dailyPlan.Days,
            PhysicalActivityLevel = dailyPlan.PhysicalActivityLevel,
            PhysicalActivityFactor = dailyPlan.PhysicalActivityFactor,
            AdjustmentFactor = dailyPlan.AdjustmentFactor,
            Nutrients = dailyPlan.Nutrients,
            Targets = dailyPlan.Targets,
            Menus = minimalDailyMenu
        };

    }
        
}