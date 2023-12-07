using NutriFoods_UI.Data.Dto;
using NutriFoods_UI.Data.Model;

namespace NutriFoods_UI.Data.Store.Pathologies;

public class ChangePersonalPathologyAction(int index, DiseaseDto disease)
{
    public int Index { get; } = index;
    public DiseaseDto Disease { get; } = disease;
}