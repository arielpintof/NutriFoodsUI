
using NutriFoods_UI.Data.Store.DailyMeal;

namespace NutriFoods_UI.Services;

public interface IDailyMealPlanService
{
    Task<HttpResponseMessage?> DailyPlanByDistribution(PlanConfiguration configuration);
}