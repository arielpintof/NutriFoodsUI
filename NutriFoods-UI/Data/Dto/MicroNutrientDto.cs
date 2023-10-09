using NutriFoods_UI.Utils.Enums;

namespace NutriFoods_UI.Data.Dto;

public class MicroNutrientDto
{
    public string? Name { get; set; }
    public double? Quantity { get; set; } 
    public UnitEnum Measure { get; set; } = null!;
}