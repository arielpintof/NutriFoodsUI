using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.EatingSymptom;

public class AddEatingSymptomAction(EatingSymptomDto eatingSymptom)
{
    public EatingSymptomDto EatingSymptom { get; } = eatingSymptom;
}