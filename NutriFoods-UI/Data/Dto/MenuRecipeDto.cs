using NutriFoods_UI.Data.Dto.Abridged;

namespace NutriFoods_UI.Data.Dto;

public class MenuRecipeDto
{
    public RecipeAbridged Recipe { get; set; } = null!;
    public int Portions { get; set; }
}