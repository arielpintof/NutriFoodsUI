using Fluxor;
using NutriFoods_UI.Data.Model;

namespace NutriFoods_UI.Data.Store.Medicines;

[FeatureState]
public class MedicineState
{
    public bool Initialized { get; } = false;
    public IEnumerable<Ingestible> Medicines { get; }
    public bool StateIsValid { get; }

    public MedicineState(){}

    public MedicineState(bool initialized, IEnumerable<Ingestible> medicines, bool stateIsValid)
    {
        Initialized = initialized;
        Medicines = medicines;
        StateIsValid = stateIsValid;
    }
}