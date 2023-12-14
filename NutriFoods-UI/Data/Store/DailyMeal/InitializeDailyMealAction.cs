using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.DailyMeal;

public class InitializeDailyMealAction(IEnumerable<DailyMenuDto> dailyMenu)
{
    public IEnumerable<DailyMenuDto> DailyMenu { get; } = dailyMenu;
}