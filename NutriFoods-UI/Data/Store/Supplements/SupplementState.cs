using NutriFoods_UI.Data.Model;

namespace NutriFoods_UI.Data.Store.Supplements;

public class SupplementState
{
    public bool Initialized { get; } = false;
    public IEnumerable<Ingestible>? Supplements { get; } = new List<Ingestible>();
    public bool StateIsValid { get; }

    public SupplementState(){}

    public SupplementState(bool initialized, IEnumerable<Ingestible> supplements, bool stateIsValid)
    {
        Initialized = initialized;
        Supplements = supplements;
        StateIsValid = stateIsValid;
    }
}