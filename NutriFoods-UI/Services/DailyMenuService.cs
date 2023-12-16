using System.Text;
using Newtonsoft.Json;
using NutriFoods_UI.Data.Dto;


namespace NutriFoods_UI.Services;

public class DailyMenuService(
    HttpClient httpClient,
    JsonSerializerSettings settings) : IDailyMenuService
{
    
    public async Task<HttpResponseMessage> GenerateMenu(DailyMenuDto dailyMenu)
    {
        var jsonBody = JsonConvert.SerializeObject(dailyMenu, settings);
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
        
        return await httpClient.PostAsync("/api/v1/daily-menus", content);
    }

    
}