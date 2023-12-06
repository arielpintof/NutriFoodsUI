using Fluxor;

namespace NutriFoods_UI.Data.Store.FoodConsumptions;

public class Reducer
{
    [ReducerMethod]
    public static FoodConsumptionState AddClinicalSign(FoodConsumptionState state, AddFoodConsumptionAction action)
    {
        var updateList = state.FoodConsumptions;
        updateList.Add(action.FoodConsumption);
        
        return new FoodConsumptionState(updateList);
    }

    [ReducerMethod]
    public static FoodConsumptionState ChangeClinicalSign(FoodConsumptionState state, ChangeFoodConsumptionAction action)
    {
        var updateList = state.FoodConsumptions;
        updateList[action.Index] = action.FoodConsumption;

        return new FoodConsumptionState(updateList);
    }
    
    [ReducerMethod]
    public static FoodConsumptionState DeleteClinicalSign(FoodConsumptionState state, DeleteFoodConsumptionAction action)
    {
        var updateList = state.FoodConsumptions;
        updateList.RemoveAt(action.Index);

        return new FoodConsumptionState(updateList);
    }
}