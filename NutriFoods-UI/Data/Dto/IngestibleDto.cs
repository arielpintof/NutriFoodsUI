namespace NutriFoods_UI.Data.Dto;

public sealed class IngestibleDto
{
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public List<TimeSpan?> AdministrationTimes { get; set; } = [];
    public int? Dosage { get; set; }
    public string? Unit { get; set; }
    public string Adherence { get; set; } = null!;
    public string? Observations { get; set; } = string.Empty;
}

public static class IngestibleExtensions{

    public static Ingestible TimeFormat(this IngestibleDto ingestible)
    {
        var times = ingestible.AdministrationTimes.Select(time => time!.Value.ToString(@".hh\:mm")).ToList();
        return new Ingestible()
        {
            Name = ingestible.Name,
            Type = ingestible.Type,
            AdministrationTimes = times,
            Dosage = ingestible.Dosage,
            Unit = ingestible.Unit,
            Adherence = ingestible.Adherence,
            Observations = ingestible.Observations
        };
    }
}

public class Ingestible
{
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public List<string> AdministrationTimes { get; set; } = [];
    public int? Dosage { get; set; }
    public string? Unit { get; set; }
    public string Adherence { get; set; } = null!;
    public string? Observations { get; set; } = string.Empty;
}

