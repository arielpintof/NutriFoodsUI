namespace NutriFoods_UI.Data.Dto.Abridged;

public sealed class IngredientMeasureAbridged
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Grams { get; set; }
    public bool IsDefault { get; set; }
    public IngredientAbridged Ingredient { get; set; } = null!;
}