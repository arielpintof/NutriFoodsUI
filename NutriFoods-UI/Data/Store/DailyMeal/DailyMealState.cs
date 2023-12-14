using Fluxor;
using NutriFoods_UI.Data.Dto;
namespace NutriFoods_UI.Data.Store.DailyMeal;

[FeatureState]
public class DailyMealState
{
    public IEnumerable<DailyMenuDto> DailyMenu { get; } = new List<DailyMenuDto>();
    public bool Initialized { get; }

    public IEnumerable<bool> MealLoading { get; set; } = [];
    
    public DailyMealState(){}

    public DailyMealState(IEnumerable<DailyMenuDto> dailyMenu, bool initialized = true)
    {
        DailyMenu = dailyMenu;
        Initialized = initialized;
    }
    
    public DailyMealState(IEnumerable<DailyMenuDto> dailyMenu, IEnumerable<bool> mealLoading, bool initialized = true)
    {
        DailyMenu = dailyMenu;
        MealLoading = mealLoading;
        Initialized = initialized;
    }
}