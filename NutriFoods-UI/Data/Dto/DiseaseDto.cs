using System.Text.Json.Serialization;

namespace NutriFoods_UI.Data.Dto;

public sealed class DiseaseDto
{
    public string Name { get; set; } = null!;
    public string InheritanceType { get; set; } = null!;
    [JsonIgnore]
    public bool IsValid { get; set; } 
}
