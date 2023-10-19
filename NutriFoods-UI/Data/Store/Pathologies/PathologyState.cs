using Fluxor;
using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.Pathologies;


[FeatureState]
public class PathologyState
{
    public bool Initialized { get; } = false;
    public IEnumerable<PathologyDto> Micronutrients { get; }
    public bool StateIsValid { get; }

    public PathologyState(){}

    public PathologyState(bool initialized, IEnumerable<PathologyDto> micronutrients, bool stateIsValid)
    {
        Initialized = initialized;
        Micronutrients = micronutrients;
        StateIsValid = stateIsValid;
    }
    
    
}