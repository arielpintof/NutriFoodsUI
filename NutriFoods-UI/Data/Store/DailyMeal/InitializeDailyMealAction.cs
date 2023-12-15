using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.DailyMeal;

public class InitializeDailyMealAction(DailyPlanDto dailyPlan)
{
    public DailyPlanDto DailyPlan { get; } = dailyPlan;
}