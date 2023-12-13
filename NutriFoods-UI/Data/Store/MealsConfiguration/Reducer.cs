using Fluxor;
namespace NutriFoods_UI.Data.Store.MealsConfiguration;

public class Reducer
{
    [ReducerMethod]
    public static MealsConfigurationState ChangeMealConfigurationState(MealsConfigurationState state, MealsConfigurationAction action)
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
}