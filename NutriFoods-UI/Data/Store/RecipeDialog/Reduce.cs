using Fluxor;

namespace NutriFoods_UI.Data.Store.RecipeDialog;

public class Reduce
{
    [ReducerMethod]
    public static RecipeDialogState Update(RecipeDialogState state, UpdateDialogAction action)
    {
        return new RecipeDialogState(action.MenuRecipe);
    }
}