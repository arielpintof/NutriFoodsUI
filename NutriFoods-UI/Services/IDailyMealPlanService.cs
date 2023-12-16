
using NutriFoods_UI.Data.Store.DailyMeal;

namespace NutriFoods_UI.Services;

public interface IDailyMealPlanService
{
    Task<HttpResponseMessage?> GenerateDailyMealPlan(int day, double basalMetabolicRate, 
        int activityLevel, double activityFactor, PlanConfiguration planConfiguration, 
        double adjustmentFactor = 1e-1);

    Task<HttpResponseMessage?> DailyPlanByDistribution(PlanConfiguration configuration);
}