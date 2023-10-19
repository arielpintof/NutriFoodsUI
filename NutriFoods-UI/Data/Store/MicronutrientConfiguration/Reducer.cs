using Fluxor;
using NutriFoods_UI.Data.Dto;
using NutriFoods_UI.Utils.Enums;

namespace NutriFoods_UI.Data.Store.MicronutrientConfiguration;

public class Reducer
{
    
    [ReducerMethod(typeof(InitializeMicronutrientAction))]
    public static MicronutrientState InitializeMicronutrientState(MicronutrientState state) => 
        new (new List<MicroNutrientDto>(), true);
    
    [ReducerMethod]
    public static MicronutrientState AddMicronutrientToState(MicronutrientState state,
        AddMicronutrientAction action)
    {
        var updateList = state.Micronutrients.ToList();
        updateList.Add(action.MicroNutrient);
        var stateIsValid = updateList.All(nutrient => nutrient.IsValid);
        return new MicronutrientState(updateList, stateIsValid: stateIsValid);
    }

    [ReducerMethod]
    public static MicronutrientState DeleteMicronutrientFromState(MicronutrientState state,
        DeleteMicronutrientAction action)
    {
        var updateList = state.Micronutrients.ToList();
        try
        {
            updateList.RemoveAt(action.Index);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Se produjo una excepción: {ex.Message}");
        }
        
        
        var stateIsValid = updateList.All(nutrient => nutrient.IsValid);
        
        return new MicronutrientState(updateList, stateIsValid: stateIsValid);
    }

    [ReducerMethod]
    public static MicronutrientState ChangeMicronutrientFromState(MicronutrientState state,
        ChangeMicronutrientAction action)
    {
        var updateList = state.Micronutrients.ToList();
        updateList[action.Index] = action.MicroNutrientDto;
        
        var stateIsValid = updateList.All(nutrient => nutrient.IsValid);

        return new MicronutrientState(updateList, true, stateIsValid);
    }

    
    
    
}