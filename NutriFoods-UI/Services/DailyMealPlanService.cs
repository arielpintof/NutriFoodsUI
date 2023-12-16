using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;
using NutriFoods_UI.Data.Store.DailyMeal;
using NutriFoods_UI.Utils.Enums;

namespace NutriFoods_UI.Services;

public class DailyMealPlanService(HttpClient httpClient, JsonSerializerSettings settings) : IDailyMealPlanService
{
    public async Task<HttpResponseMessage?> GenerateDailyMealPlan(int day, double basalMetabolicRate, 
        int activityLevel, double activityFactor, PlanConfiguration planConfiguration, 
        double adjustmentFactor = 1e-1)
    {
        
        var jsonBody = JsonConvert.SerializeObject(planConfiguration, settings);
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        return await httpClient.PostAsync(
            $"/api/v1/daily-plans/distribution?day={day}&basalMetabolicRate={basalMetabolicRate}&activityLevel={activityLevel}&activityFactor={activityFactor}&adjustmentFactor={adjustmentFactor}", content);
    }

    public async Task<HttpResponseMessage?> DailyPlanByDistribution(PlanConfiguration planConfiguration)
    {
        var jsonBody = JsonConvert.SerializeObject(planConfiguration, settings);
        Console.WriteLine("JSON being sent:\n" + jsonBody);
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        return await httpClient.PostAsync("api/v1/daily-plans/distribution", content);
    }
    
}