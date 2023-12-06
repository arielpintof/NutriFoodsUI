using Fluxor;
using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.EatingSymptom;

[FeatureState]
public class EatingSymptomState
{
    public List<EatingSymptomDto> EatingSymptoms { get; } = new();
    public bool IsValid { get; }

    public EatingSymptomState() { }

    public EatingSymptomState(List<EatingSymptomDto> eatingSymptoms, bool isValid = false)
    {
        EatingSymptoms = eatingSymptoms;
        IsValid = isValid;
    }
}