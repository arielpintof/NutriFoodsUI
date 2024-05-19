using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.Pathologies;

public class AddInheritedPathologyAction(DiseaseDto disease)
{
    public DiseaseDto Disease { get; } = disease;
}