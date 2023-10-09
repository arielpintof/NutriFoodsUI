using Fluxor;
using NutriFoods_UI.Data.Store.DailyMenu;

namespace NutriFoods_UI.Data.Store.DailyMeal;

public class Reducer
{
    [ReducerMethod]
    public static DailyMealState ReduceChangeMoleculaAction(DailyMealState state, ChangeDailyMealAction action)
    {
        var updatedDailyMenu = state.DailyMenu.ToList();
        updatedDailyMenu[action.Position] = action.DailyMenu;
        
        return new DailyMealState(updatedDailyMenu, state.MealLoading, true);
    }

    [ReducerMethod]
    public static DailyMealState ReduceInitializeDailyMealAction(DailyMealState state, InitializeDailyMealAction action)
    {
        var onLoading = Enumerable.Repeat(false, action.DailyMenu.Count()).ToList();
        
        return new DailyMealState(action.DailyMenu, onLoading,true);
    }
    
    [ReducerMethod]
    public static DailyMealState ReduceOnLoadingMenuAction(DailyMealState state, OnLoadingMenuAction action)
    {
        var onLoading = state.MealLoading.Select((_, index) => index == action.Index).ToList();

        return new DailyMealState(state.DailyMenu, onLoading, true);
    }
    
    [ReducerMethod]
    public static DailyMealState ReduceStopOnLoadingMenuAction(DailyMealState state, StopOnLoadingMenuAction action)
    {
        var onLoading = state.MealLoading.Select(_ => false).ToList();

        return new DailyMealState(state.DailyMenu, onLoading, true);
    }
}