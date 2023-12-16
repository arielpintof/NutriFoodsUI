using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Services;

public interface IDailyMenuService
{
    Task<HttpResponseMessage> GenerateMenu(DailyMenuDto dailyMenu);
    
    

}