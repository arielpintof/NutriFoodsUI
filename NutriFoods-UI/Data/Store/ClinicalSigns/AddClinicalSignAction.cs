using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.ClinicalSigns;

public class AddClinicalSignAction(ClinicalSignDto clinicalSign)
{
    public ClinicalSignDto ClinicalSignDto { get; } = clinicalSign;
}