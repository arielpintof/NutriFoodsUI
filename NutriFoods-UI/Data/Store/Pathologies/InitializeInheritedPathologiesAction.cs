using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.Pathologies;

public class InitializeInheritedPathologiesAction(List<DiseaseDto> patologies)
{
    public List<DiseaseDto> Patologies { get; } = patologies;
}