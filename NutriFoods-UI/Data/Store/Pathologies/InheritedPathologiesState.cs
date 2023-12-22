using Fluxor;
using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.Pathologies;

[FeatureState]
public class InheritedPathologiesState 
{
    public bool Initialized { get; } = false;

    public List<DiseaseDto> Pathologies { get; } = [];
    public bool StateIsValid { get; }

    public InheritedPathologiesState (){}

    public InheritedPathologiesState(List<DiseaseDto> pathologies, 
        bool initialized = true, bool stateIsValid = true)
    {
        Initialized = initialized;
        Pathologies = pathologies;
        StateIsValid = stateIsValid;
    }
}