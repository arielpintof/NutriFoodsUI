namespace NutriFoods_UI.Data.Dto;

public sealed class ClinicalAnamnesisDto
{
    public DateTime? CreatedOn { get; set; }
    public DateTime? LastUpdated { get; set; }
    public List<ClinicalSignDto> ClinicalSigns { get; set; } = null!;
    public List<DiseaseDto> Diseases { get; set; } = null!;
    public List<IngestibleDto> Ingestibles { get; set; } = null!;
}
