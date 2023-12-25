using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.ClinicalSigns;

public class InitializeClinicalSignAction(List<ClinicalSignDto> clinicalSigns)
{
    public List<ClinicalSignDto> ClinicalSigns { get; } = clinicalSigns;
}