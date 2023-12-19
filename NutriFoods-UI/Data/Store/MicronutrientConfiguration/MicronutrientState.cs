using Fluxor;
using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.MicronutrientConfiguration;


[FeatureState]
public class MicronutrientState
{
    public bool Initialized { get; } = false;
    public IEnumerable<NutritionalTargetDto> Micronutrients { get; } = [];

    public bool StateIsValid { get; } 

    public MicronutrientState(){}
    
    public MicronutrientState(IEnumerable<NutritionalTargetDto> micronutrients, 
        bool initialized = true, bool stateIsValid = true)
    {
        Micronutrients = micronutrients;
        Initialized = initialized;
        StateIsValid = stateIsValid;
    }

    
}