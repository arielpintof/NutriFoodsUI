using Fluxor;
using NutriFoods_UI.Data.Model;

namespace NutriFoods_UI.Data.Store.Medicines;

public class Reducer
{
    [ReducerMethod]
    public static MedicineState AddMedicine(MedicineState state, AddMedicineAction action)
    {
        var updatedList = state.Medicines?.ToList() ?? new List<Ingestible>();
        updatedList.Add(action.Ingestible);
        return new MedicineState(updatedList);
    }
}