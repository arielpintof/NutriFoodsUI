using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.RecipeDialog;

public class UpdateDialogAction
{
    public MenuRecipeDto MenuRecipe { get; }

    public UpdateDialogAction(MenuRecipeDto menuRecipe)
    {
        MenuRecipe = menuRecipe;
    }
}