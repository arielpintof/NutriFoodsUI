using Fluxor;

namespace NutriFoods_UI.Data.Store.Medicines;

[FeatureState]
public class MedicineState
{
    public bool Initialized { get; } = false;
    public IEnumerable<string> Medicines { get; }
    public bool StateIsValid { get; }

    public MedicineState(){}

    public MedicineState(bool initialized, IEnumerable<string> medicines, bool stateIsValid)
    {
        Initialized = initialized;
        Medicines = medicines;
        StateIsValid = stateIsValid;
    }
}