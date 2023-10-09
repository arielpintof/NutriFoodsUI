using NutriFoods_UI.Components.MealPlan.DailyMeal;
using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.DailyMenu;

public class ChangeDailyMealAction
{
    public DailyMenuDto DailyMenu { get; }
    public int Position { get; }

    public ChangeDailyMealAction(DailyMenuDto dailyMenu, int position)
    {
        DailyMenu = dailyMenu;
        Position = position;
    }
}