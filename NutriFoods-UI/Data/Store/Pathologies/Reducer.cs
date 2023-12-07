using Fluxor;
using NutriFoods_UI.Data.Dto;
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
        
        return new PersonalPathologiesState(updateList, stateIsValid: stateIsValid);
    }
    
    [ReducerMethod]
    public static PersonalPathologiesState Initialize(PersonalPathologiesState state, InitializePersonalPathologiesAction action)
    {
        return new PersonalPathologiesState(new List<DiseaseDto>(), true);
    }
    
    [ReducerMethod]
    public static PersonalPathologiesState DeleteMicronutrientFromState(PersonalPathologiesState state,
        DeletePersonalPathologyAction action)
    {
        var updateList = state.Pathologies;
        try
        {
            updateList.RemoveAt(action.Index);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Se produjo una excepción: {ex.Message}");
        }
        
        var stateIsValid = updateList.All(p => p.IsValid);
        
        return new PersonalPathologiesState(updateList, stateIsValid: stateIsValid);
    }
    
    
}