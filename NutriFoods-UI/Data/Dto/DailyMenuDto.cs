using NutriFoods_UI.Data.Store.DailyMeal;
using NutriFoods_UI.Utils.Enums;
using NutriFoods_UI.Utils.Enums;
using static NutriFoods_UI.Utils.Enums.IEnum<NutriFoods_UI.Utils.Enums.Nutrients,NutriFoods_UI.Utils.Enums.NutrientToken>;

namespace NutriFoods_UI.Data.Dto;

public sealed class DailyMenuDto
{
    public double IntakePercentage { get; set; }
    public string MealType { get; set; } = null!;
    public string Hour { get; set; } = null!;
    public List<NutritionalValueDto> Nutrients { get; set; } = null!;
    public List<NutritionalTargetDto> Targets { get; set; } = null!;
    public List<MenuRecipeDto> Recipes { get; set; } = null!;
}

public static class DailyMenuExtensions
{
    public static IEnumerable<DailyMenuDto> ToMenus(PlanConfiguration configuration, double totalMetabolicRate)
    {
        var planDistribution = configuration.Distribution.ToDictionary(e => ToValue(e.Key), e => e.Value);
        foreach (var mealConfiguration in configuration.MealConfigurations)
        {
            var energy = mealConfiguration.IntakePercentage * totalMetabolicRate;
            var macroDistribution = planDistribution
                .ToDictionary(e => e.Key, e => e.Value * energy * NutrientExtensions.GramFactors[e.Key]);
            var macroTargets =
                TargetExtensions
                    .MacroDistributionToTargets(macroDistribution, energy, configuration.AdjustmentFactor);
            var microTargets =
                TargetExtensions
                    .ToTargets(configuration, mealConfiguration.IntakePercentage);
            yield return new DailyMenuDto
            {
                Hour = mealConfiguration.Hour,
                MealType = mealConfiguration.MealType,
                IntakePercentage = mealConfiguration.IntakePercentage,
                Targets = [..macroTargets, ..microTargets]
            };
        }
    }
}