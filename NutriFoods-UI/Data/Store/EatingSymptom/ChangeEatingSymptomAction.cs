using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.EatingSymptom;

public class ChangeEatingSymptomAction(EatingSymptomDto eatingSymptom, int index)
{
    public EatingSymptomDto EatingSymptom { get; } = eatingSymptom;
    public int Index { get; } = index;
}