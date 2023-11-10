using Fluxor;
namespace NutriFoods_UI.Data.Store.MealsConfiguration;

public class Reducer
{
    [ReducerMethod]
    public static MealsConfigurationState ReduceMealsConfigurationState(MealsConfigurationState state, MealsConfigurationAction action)
    {
        return new MealsConfigurationState();
    }
}