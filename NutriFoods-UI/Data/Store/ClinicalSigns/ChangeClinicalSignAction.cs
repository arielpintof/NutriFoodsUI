using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.ClinicalSigns;

public class ChangeClinicalSignAction(ClinicalSignDto clinicalSign, int index)
{
    public ClinicalSignDto ClinicalSignDto { get; } = clinicalSign;
    public int Index { get; } = index;
}