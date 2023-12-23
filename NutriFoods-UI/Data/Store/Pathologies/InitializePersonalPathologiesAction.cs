using MudBlazor;
using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.Pathologies;

public class InitializePersonalPathologiesAction(List<DiseaseDto> diseases)
{
    public List<DiseaseDto> Diseases { get; } = diseases;
}