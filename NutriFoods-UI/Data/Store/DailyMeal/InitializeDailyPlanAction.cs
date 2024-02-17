using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.DailyMeal;

public class InitializeDailyPlanAction(DailyPlanDto dailyPlan)
{
    public DailyPlanDto DailyPlan { get; } = dailyPlan;
}