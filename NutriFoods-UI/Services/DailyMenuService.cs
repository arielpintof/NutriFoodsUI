using NutriFoods_UI.Data.Dto;
using NutriFoods_UI.Utils.Enums;


namespace NutriFoods_UI.Services;

public class DailyMenuService : IDailyMenuService
{
    private readonly HttpClient _httpClient;

    public DailyMenuService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<HttpResponseMessage?> GenerateDailyMenu(double energyTarget, double carbsPercent, double fatsPercent, double proteinsPercent,
        MealType mealType = MealType.None, Satiety satiety = Satiety.None)
    {
        var energy = energyTarget.ToString().Replace(",", ".");
        return await _httpClient.GetAsync($"api/v1/daily-meals/custom-percentages?energyTarget={energy}&carbsPercent={carbsPercent}&fatsPercent={fatsPercent}&proteinsPercent={proteinsPercent}&mealType={mealType}&satiety={satiety}");
    }

    public async Task<HttpResponseMessage?> GenerateDailyMenu(double energyTarget, MealType mealType = MealType.None, 
        Satiety satiety = Satiety.None)
    {
        var energy = energyTarget.ToString().Replace(",", ".");
        return await _httpClient.GetAsync($"api/v1/daily-meals/default-percentages?energyTarget={energy}&mealType={mealType}&satiety={satiety}");
    }
}