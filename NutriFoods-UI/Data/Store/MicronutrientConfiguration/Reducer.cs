using Fluxor;
using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.MicronutrientConfiguration;

public static class Reducer
{
    
    [ReducerMethod(typeof(InitializeMicronutrientAction))]
    public static MicronutrientState InitializeMicronutrientState(MicronutrientState state) => 
        new (new List<NutritionalTargetDto>(), true);
    
    [ReducerMethod]
    public static MicronutrientState AddMicronutrientToState(MicronutrientState state,
        AddMicronutrientAction action)
    {
        var updateList = state.Micronutrients.ToList();
        updateList.Add(action.MicroNutrient);
        
        return new MicronutrientState(updateList, stateIsValid: true);
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
        
        
        return new MicronutrientState(updateList, stateIsValid: true);
    }

    [ReducerMethod]
    public static MicronutrientState ChangeMicronutrientFromState(MicronutrientState state,
        ChangeMicronutrientAction action)
    {
        var updateList = state.Micronutrients.ToList();
        updateList[action.Index] = action.MicroNutrientDto;
        

        return new MicronutrientState(updateList, true, true);
    }

    
    
    
}