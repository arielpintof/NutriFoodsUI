using System.ComponentModel.DataAnnotations;
using NutriFoods_UI.Data.Store.DailyMeal;
using NutriFoods_UI.Utils.Enums;

namespace NutriFoods_UI.Services;

public interface IDailyMealPlanService
{
    Task<HttpResponseMessage?> GenerateDailyMealPlan(int day, double basalMetabolicRate, 
        int activityLevel, double activityFactor, PlanConfiguration planConfiguration, 
        double adjustmentFactor = 1e-1);
}