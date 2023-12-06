using Fluxor;
using NutriFoods_UI.Data.Model;

namespace NutriFoods_UI.Data.Store.Medicines;

[FeatureState]
public class MedicineState
{
    public bool Initialized { get; } = false;
    public IEnumerable<Ingestible> Medicines { get; } = new List<Ingestible>();
    public bool StateIsValid { get; }

    public MedicineState(){}

    public MedicineState(IEnumerable<Ingestible> medicines, bool initialized =  true, bool stateIsValid = true)
    {
        Initialized = initialized;
        Medicines = medicines;
        StateIsValid = stateIsValid;
    }
}