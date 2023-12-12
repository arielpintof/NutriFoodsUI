using System.ComponentModel;
using NutriFoods_UI.Utils.Enums;

namespace NutriFoods_UI.Data.Dto;

public class IngestibleDto
{
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public List<TimeSpan?> AdministrationTimes { get; set; } = [];
    public int? Dosage { get; set; }
    public string Adherence { get; set; } = string.Empty;
    public string? Observations { get; set; }
}