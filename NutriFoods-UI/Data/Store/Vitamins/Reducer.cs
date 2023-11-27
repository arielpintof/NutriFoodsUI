using Fluxor;
using NutriFoods_UI.Data.Model;

namespace NutriFoods_UI.Data.Store.Vitamins;

public class Reducer
{
    [ReducerMethod]
    public static VitaminState AddVitamin(VitaminState state, AddVitaminAction action)
    {
        var updatedList = state.Vitamins?.ToList() ?? new List<Ingestible>();
        updatedList.Add(action.Ingestible);
    
        return new VitaminState(vitamins: updatedList);
    }

    [ReducerMethod]
    public static VitaminState DeleteVitamin(VitaminState state, DeleteVitaminAction action)
    {
        var updatedList = state.Vitamins?.ToList() ?? new List<Ingestible>();
        updatedList.RemoveAt(action.Index);
    
        return new VitaminState(vitamins: updatedList);
    }

}