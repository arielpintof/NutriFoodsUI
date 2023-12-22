using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.Pathologies;

public class ChangeInheritedPathologyAction(int index, DiseaseDto disease)
{
    public int Index { get; } = index;
    public DiseaseDto Disease { get; } = disease;
}