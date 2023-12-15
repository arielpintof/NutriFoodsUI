using Fluxor;
using NutriFoods_UI.Data.Store.DailyMenu;

namespace NutriFoods_UI.Data.Store.DailyMeal;

public class Reducer
{
    [ReducerMethod]
    public static DailyMealState ChangeDailyMenu(DailyMealState state, ChangeDailyMealAction action)
    {
        var updatedDailyPlan = state.DailyPlan;
        updatedDailyPlan.Menus[action.Position] = action.DailyMenu;
        
        return new DailyMealState(updatedDailyPlan, state.MealLoading, true);
    }

    [ReducerMethod]
    public static DailyMealState InitializeDailyMenusAction(DailyMealState state, InitializeDailyMealAction action)
    {
        var onLoading = Enumerable.Repeat(false, action.DailyPlan.Menus.Count).ToList();
        
        return new DailyMealState(action.DailyPlan, onLoading,true);
    }
    
    [ReducerMethod]
    public static DailyMealState ReduceOnLoadingMenuAction(DailyMealState state, OnLoadingMenuAction action)
    {
        var onLoading = state.MealLoading.Select((_, index) => index == action.Index).ToList();

        return new DailyMealState(state.DailyPlan, onLoading, true);
    }
    
    [ReducerMethod]
    public static DailyMealState ReduceStopOnLoadingMenuAction(DailyMealState state, StopOnLoadingMenuAction action)
    {
        var onLoading = state.MealLoading.Select(_ => false).ToList();

        return new DailyMealState(state.DailyPlan, onLoading, true);
    }
}