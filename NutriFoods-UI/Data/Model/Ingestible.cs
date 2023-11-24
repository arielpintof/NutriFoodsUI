using NutriFoods_UI.Utils.Enums;

namespace NutriFoods_UI.Data.Model;

public class Ingestible
{
    //public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public IngestibleTypes Type { get; set; } = null!;

    public List<string> AdministrationTimes { get; set; } = null!;

    public int? Dosage { get; set; }

    public Frequencies Adherence { get; set; } = null!;

    public string? Observations { get; set; }

   //public Guid ClinicalAnamnesisId { get; set; }

    //public virtual ClinicalAnamnesis ClinicalAnamnesis { get; set; } = null!;
}

