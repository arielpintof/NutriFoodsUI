namespace NutriFoods_UI.Data.Dto;

public class IngestibleDto
{
    public string Name { get; set; } = null!;
    public string Type { get; set; } = null!;
    public ICollection<string> AdministrationTimes { get; set; } = null!;
    public int? Dosage { get; set; }
    public string Adherence { get; set; } = null!;
    public string? Observations { get; set; }
}