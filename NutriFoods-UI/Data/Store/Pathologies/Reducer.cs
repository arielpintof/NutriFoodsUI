using Fluxor;
using NutriFoods_UI.Data.Model;

namespace NutriFoods_UI.Data.Store.Pathologies;

public class Reducer
{
    [ReducerMethod]
    public static PersonalPathologiesState AddPathology(PersonalPathologiesState state, AddPersonalPathologyAction action)
    {
        var updateList = state.Pathologies.ToList();
        updateList.Add(action.Disease);
        var stateIsValid = updateList.All(pathology => pathology.IsValid);
        Console.WriteLine("Añadiendo");
        return new PersonalPathologiesState(updateList, stateIsValid: stateIsValid);
    }
    
    [ReducerMethod]
    public static PersonalPathologiesState Initialize(PersonalPathologiesState state, InitializePersonalPathologiesAction action)
    {
        return new PersonalPathologiesState(new List<Disease>(), true);
    }
    
    
}