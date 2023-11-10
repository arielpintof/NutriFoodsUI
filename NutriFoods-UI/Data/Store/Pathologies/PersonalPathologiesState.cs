using Fluxor;
using NutriFoods_UI.Data.Dto;
using NutriFoods_UI.Data.Model;

namespace NutriFoods_UI.Data.Store.Pathologies;


[FeatureState]
public class PersonalPathologiesState
{
    public bool Initialized { get; } = false;
    
    public IEnumerable<Disease> Pathologies { get; } 
    public bool StateIsValid { get; }

    public PersonalPathologiesState(){}

    public PersonalPathologiesState(IEnumerable<Disease> pathologies, 
        bool initialized = true, bool stateIsValid = true)
    {
        Initialized = initialized;
        Pathologies = pathologies;
        StateIsValid = stateIsValid;
    }
    
    
}