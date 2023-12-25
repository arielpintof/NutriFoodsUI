using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.EatingSymptom;

public class InitializeEatingSymptomAction(List<EatingSymptomDto> eatingSymptoms)
{
    public List<EatingSymptomDto> EatingSymptoms { get; } = eatingSymptoms;
}