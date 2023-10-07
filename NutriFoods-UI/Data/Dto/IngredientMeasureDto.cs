namespace NutriFoods_UI.Data.Dto;

public class IngredientMeasureDto
{
    public string Name { get; set; } = string.Empty;
    public double Grams { get; set; }
    public bool IsDefault { get; set; }
    public IngredientDto Ingredient { get; set; } = null!;
}