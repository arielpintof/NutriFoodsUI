using Fluxor;
using NutriFoods_UI.Components.MealPlan.DailyMeal;
using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.RecipeDialog;

[FeatureState]
public class RecipeDialogState
{
    public MenuRecipeDto MenuRecipe { get; }
    
    public RecipeDialogState(){}

    public RecipeDialogState(MenuRecipeDto menuRecipe)
    {
        MenuRecipe = menuRecipe;
    }
}