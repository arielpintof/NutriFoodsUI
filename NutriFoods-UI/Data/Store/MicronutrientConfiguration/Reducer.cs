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
        
        return new MicronutrientState(updateList);
    }

    [ReducerMethod]
    public static MicronutrientState DeleteMicronutrientFromState(MicronutrientState state,
        DeleteMicronutrientAction action)
    {
        var updateList = state.Micronutrients.ToList();
        //Console.WriteLine($"Indice en el reducer: {action.Index}");
        //Console.WriteLine($"Eliminado nutriente: {updateList.ElementAt(action.Index).Name} con cantidad de: {updateList.ElementAt(action.Index).Quantity}");
        updateList.RemoveAt(action.Index);
        //Console.WriteLine($"Nutriente en posicion {action.Index}: {updateList.ElementAt(action.Index).Name} con cantidad de: {updateList.ElementAt(action.Index).Quantity}");
        return new MicronutrientState(updateList);
    }

    [ReducerMethod]
    public static MicronutrientState ChangeMicronutrientFromState(MicronutrientState state,
        ChangeMicronutrientAction action)
    {
        var updateList = state.Micronutrients.ToList();
        updateList[action.Index] = action.MicroNutrientDto;

        return new MicronutrientState(updateList);
    }

    
    
    
}