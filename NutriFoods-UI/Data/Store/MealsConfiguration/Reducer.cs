using Fluxor;
namespace NutriFoods_UI.Data.Store.MealsConfiguration;

public static class Reducer
{
    [ReducerMethod]
    public static MealsConfigurationState ChangeMealConfigurationState(MealsConfigurationState state, ChangeMealsConfigurationAction action)
    {
        var updatedList = state.Meals;
        updatedList[action.Position] = action.Meal;
        
        return new MealsConfigurationState(updatedList);
    }
    
    [ReducerMethod]
    public static MealsConfigurationState InitializeMealConfiguration(MealsConfigurationState state, InitializeMealsAction action)
    {
        return new MealsConfigurationState(action.Meals);
    }

    [ReducerMethod]
    public static MealsConfigurationState AddMeal(MealsConfigurationState state, AddMealAction action)
    {
        var meals = state.Meals;
        meals.Add(action.MealConfiguration);

        return new MealsConfigurationState(meals);
    }

    [ReducerMethod]
    public static MealsConfigurationState RemoveMeal(MealsConfigurationState state, RemoveMealAction action)
    {
        var meals = state.Meals;
        meals.RemoveAt(action.Position);

        return new MealsConfigurationState(meals);
    }
    
}