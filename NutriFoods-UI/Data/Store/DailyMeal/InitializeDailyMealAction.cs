using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.DailyMeal;

public class InitializeDailyMealAction
{
    public IEnumerable<DailyMenuDto> DailyMenu { get; }

    public InitializeDailyMealAction (IEnumerable<DailyMenuDto> dailyMenu)
    {
        DailyMenu = dailyMenu;
    }
}