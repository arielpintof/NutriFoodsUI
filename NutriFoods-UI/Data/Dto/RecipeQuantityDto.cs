using NutriFoods_UI.Data.Dto.Abridged;

namespace NutriFoods_UI.Data.Dto;

public class RecipeQuantityDto
{
    public IngredientAbridged Ingredient { get; set; } = null!;
    public double Grams { get; set; }
}