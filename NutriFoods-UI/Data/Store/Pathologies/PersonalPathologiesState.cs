using Fluxor;
using NutriFoods_UI.Data.Dto;
using NutriFoods_UI.Data.Model;

namespace NutriFoods_UI.Data.Store.Pathologies;


[FeatureState]
public class PersonalPathologiesState
{
    public bool Initialized { get; } = false;

    public List<DiseaseDto> Pathologies { get; } = new();
    public bool StateIsValid { get; }

    public PersonalPathologiesState(){}

    public PersonalPathologiesState(List<DiseaseDto> pathologies, 
        bool initialized = true, bool stateIsValid = true)
    {
        Initialized = initialized;
        Pathologies = pathologies;
        StateIsValid = stateIsValid;
    }
    
    
}