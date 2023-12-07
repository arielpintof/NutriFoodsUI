using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;
using NutriFoods_UI.Data.Store.DailyMeal;
using NutriFoods_UI.Utils.Enums;

namespace NutriFoods_UI.Services;

public class DailyMealPlanService(HttpClient httpClient) : IDailyMealPlanService
{
    public async Task<HttpResponseMessage?> GenerateDailyMealPlan(int day, double basalMetabolicRate, 
        int activityLevel, double activityFactor, PlanConfiguration planConfiguration, 
        double adjustmentFactor = 1e-1)
    {
        
        var jsonBody = JsonConvert.SerializeObject(planConfiguration);
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        return await httpClient.PostAsync(
            $"/api/v1/daily-plans/by-distribution?day={day}&basalMetabolicRate={basalMetabolicRate}&activityLevel={activityLevel}&activityFactor={activityFactor}&adjustmentFactor={adjustmentFactor}", content);
    }
    
}