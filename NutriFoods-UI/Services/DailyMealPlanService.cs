using System.Text;
using Newtonsoft.Json;
using NutriFoods_UI.Data.Store.DailyMeal;


namespace NutriFoods_UI.Services;

public class DailyMealPlanService(HttpClient httpClient, JsonSerializerSettings settings) : IDailyMealPlanService
{

    public async Task<HttpResponseMessage?> DailyPlanByDistribution(PlanConfiguration planConfiguration)
    {
        var jsonBody = JsonConvert.SerializeObject(planConfiguration, settings);
        Console.WriteLine("JSON being sent:\n" + jsonBody);
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        return await httpClient.PostAsync("api/v1/daily-plans", content);
    }
    
}