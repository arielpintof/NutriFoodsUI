using Fluxor;
using NutriFoods_UI.Data.Model;

namespace NutriFoods_UI.Data.Store.Medicines;

public class Reducer
{
    [ReducerMethod]
    public static MedicineState AddMedicine(MedicineState state, AddMedicineAction action)
    {
        var updatedList = state.Medicines.ToList();
        updatedList.Add(action.Ingestible);

        return new MedicineState(updatedList);
        
    }

    [ReducerMethod]
    public static MedicineState ChangeMedicine(MedicineState state, ChangeMedicineAction action)
    {
        var updatedList = state.Medicines.ToList();
        updatedList[action.Index] = action.Ingestible;

        return new MedicineState(updatedList);
    }

    [ReducerMethod]
    public static MedicineState DeleteMedicine(MedicineState state, DeleteMedicineAction action)
    {
        var updatedList = state.Medicines.ToList();
        updatedList.RemoveAt(action.Index);

        return new MedicineState(updatedList);
    }

    [ReducerMethod]
    public static MedicineState InitializeMedicine(MedicineState state, InitializeMedicineAction action)
    {
        return new MedicineState(action.Medicines);
    }
    
}