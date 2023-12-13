using Fluxor;
using NutriFoods_UI.Data.Dto;
using NutriFoods_UI.Data.Model;

namespace NutriFoods_UI.Data.Store.Medicines;

[FeatureState]
public class MedicineState
{
    public bool Initialized { get; } = false;
    public IEnumerable<IngestibleDto> Medicines { get; } = new List<IngestibleDto>();
    public bool StateIsValid { get; }

    public MedicineState(){}

    public MedicineState(IEnumerable<IngestibleDto> medicines, bool initialized =  true, bool stateIsValid = true)
    {
        Initialized = initialized;
        Medicines = medicines;
        StateIsValid = stateIsValid;
    }
}