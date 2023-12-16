namespace NutriFoods_UI.Data.Dto;

public sealed class DiseaseDto
{
    public string Name { get; set; } = null!;
    public IEnumerable<string> InheritanceTypes { get; set; } = new HashSet<string>();
}
