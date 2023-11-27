using Fluxor;
using NutriFoods_UI.Data.Model;

namespace NutriFoods_UI.Data.Store.Vitamins;

[FeatureState]
public class VitaminState
{
    public bool Initialized { get; }
    public IEnumerable<Ingestible>? Vitamins { get; } = new List<Ingestible>();
    public bool StateIsValid { get; }

    public VitaminState(){}

    public VitaminState(IEnumerable<Ingestible> vitamins, bool initialized = true , bool stateIsValid = true)
    {
        Initialized = initialized;
        Vitamins = vitamins;
        StateIsValid = stateIsValid;
    }
}