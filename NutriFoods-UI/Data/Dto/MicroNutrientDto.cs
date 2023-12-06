using System.ComponentModel.DataAnnotations;
using NutriFoods_UI.Utils.Enums;

namespace NutriFoods_UI.Data.Dto;

public class MicroNutrientDto
{

    public string? Name { get; set; } = string.Empty;
    [Required]
    [Range(10, 50, ErrorMessage = "La cantidad debe estar entre 10 y 50")]
    public double? Quantity { get; set; } 
    
    public ThresholdTypes? ThresholdType { get; set; }
    
    public UnitEnum Measure { get; set; } = null!;
    
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public bool IsValid { get; set; }
}