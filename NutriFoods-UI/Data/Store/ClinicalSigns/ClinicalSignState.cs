using Fluxor;
using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.ClinicalSigns;


[FeatureState]
public class ClinicalSignState
{
    public List<ClinicalSignDto> ClinicalSigns { get; } = new();
    
    public bool IsValid { get; }
    
    public ClinicalSignState(){}
    
    public ClinicalSignState(List<ClinicalSignDto> clinicalSigns, bool isValid = false)
    {
        ClinicalSigns = clinicalSigns;
        IsValid = isValid;
    }
}