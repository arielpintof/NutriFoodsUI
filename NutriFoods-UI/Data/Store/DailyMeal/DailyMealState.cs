using Fluxor;
using NutriFoods_UI.Data.Dto;
namespace NutriFoods_UI.Data.Store.DailyMeal;

[FeatureState]
public class DailyMealState
{
    public DailyPlanDto DailyPlan { get; } = new();
    public bool Initialized { get; }

    public IEnumerable<bool> MealLoading { get; } = [];
    
    public DailyMealState(){}

    public DailyMealState(DailyPlanDto dailyPlan, bool initialized = true)
    {
        DailyPlan = dailyPlan;
        Initialized = initialized;
    }
    
    public DailyMealState(DailyPlanDto dailyPlan, IEnumerable<bool> mealLoading, bool initialized = true)
    {
        DailyPlan = dailyPlan;
        MealLoading = mealLoading;
        Initialized = initialized;
    }
}