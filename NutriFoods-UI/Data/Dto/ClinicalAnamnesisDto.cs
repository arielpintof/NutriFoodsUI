namespace NutriFoods_UI.Data.Dto;

public class ClinicalAnamnesisDto
{
    public string? CreatedOn { get; set; }
    public string? LastUpdated { get; set; }
    public ICollection<ClinicalSignDto> ClinicalSigns { get; set; } = null!;
    public ICollection<DiseaseDto> Diseases { get; set; } = null!;
    public ICollection<IngestibleDto> Medications { get; set; } = null!;
}