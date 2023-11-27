using Fluxor;
using NutriFoods_UI.Data.Model;
using NutriFoods_UI.Data.Store.Medicines;

namespace NutriFoods_UI.Data.Store.Supplements;


public class Reducer
{
    [ReducerMethod]
    public static SupplementState AddSupplement(SupplementState state, AddSupplementAction action)
    {
        var updatedList = state.Supplements?.ToList() ?? new List<Ingestible>();
        updatedList.Add(action.Ingestible);
        
        return new SupplementState(supplements: updatedList);
    }

    [ReducerMethod]
    public static SupplementState DeleteSupplement(SupplementState state, DeleteSupplementAction action)
    {
        var updatedList = state.Supplements?.ToList() ?? new List<Ingestible>();
        updatedList.RemoveAt(action.Index);
        
        return new SupplementState(supplements: updatedList);
    }
}