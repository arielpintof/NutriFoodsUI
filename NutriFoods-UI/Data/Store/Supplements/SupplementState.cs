namespace NutriFoods_UI.Data.Store.Supplements;

public class SupplementState
{
    public bool Initialized { get; } = false;
    public IEnumerable<string>? Supplements { get; } = new List<string>();
    public bool StateIsValid { get; }

    public SupplementState(){}

    public SupplementState(bool initialized, IEnumerable<string> supplements, bool stateIsValid)
    {
        Initialized = initialized;
        Supplements = supplements;
        StateIsValid = stateIsValid;
    }
}