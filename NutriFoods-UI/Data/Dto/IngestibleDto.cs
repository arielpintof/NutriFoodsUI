namespace NutriFoods_UI.Data.Dto;

public sealed class IngestibleDto
{
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public List<TimeSpan?> AdministrationTimes { get; set; } = null!;
    public int? Dosage { get; set; }
    public string? Unit { get; set; }
    public string Adherence { get; set; } = null!;
    public string? Observations { get; set; }
}