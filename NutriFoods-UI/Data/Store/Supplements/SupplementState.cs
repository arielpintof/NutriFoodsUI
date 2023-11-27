using Fluxor;
using NutriFoods_UI.Data.Model;

namespace NutriFoods_UI.Data.Store.Supplements;

[FeatureState]
public class SupplementState
{
    public bool Initialized { get; }
    public IEnumerable<Ingestible>? Supplements { get; } = new List<Ingestible>();
    public bool StateIsValid { get; }

    public SupplementState(){}

    public SupplementState(IEnumerable<Ingestible> supplements, bool initialized = true , bool stateIsValid = true)
    {
        Initialized = initialized;
        Supplements = supplements;
        StateIsValid = stateIsValid;
    }
}