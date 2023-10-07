namespace NutriFoods_UI.Data.Dto;

public class MenuRecipeDto
{
    public RecipeDto Recipe { get; set; } = null!;
    public int Portions { get; set; }
}