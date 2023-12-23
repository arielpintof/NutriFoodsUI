using Fluxor;
using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.Pathologies;

public class Reducer
{
    [ReducerMethod]
    public static PersonalPathologiesState AddPathology(PersonalPathologiesState state, AddPersonalPathologyAction action)
    {
        var updateList = state.Pathologies.ToList();
        updateList.Add(action.Disease);
        //var stateIsValid = updateList.All(pathology => pathology.IsValid);
        
        return new PersonalPathologiesState(updateList, state.Initialized, state.StateIsValid);
    }
    
    [ReducerMethod]
    public static PersonalPathologiesState Initialize(PersonalPathologiesState state, InitializePersonalPathologiesAction action)
    {
        return new PersonalPathologiesState(action.Diseases, true, state.StateIsValid);
    }
    
    [ReducerMethod]
    public static PersonalPathologiesState DeletePathology(PersonalPathologiesState state,
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
        
        
        return new PersonalPathologiesState(updateList, state.Initialized, state.StateIsValid);
    }
    
    [ReducerMethod]
    public static PersonalPathologiesState ChangePathology(PersonalPathologiesState state, ChangePersonalPathologyAction action)
    {
        var pathologies = state.Pathologies;
        pathologies[action.Index] = action.Disease;
        
        return new PersonalPathologiesState(pathologies, stateIsValid: true);
    }
    
    [ReducerMethod]
    public static InheritedPathologiesState AddInhPathology(InheritedPathologiesState state, AddInheritedPathologyAction action)
    {
        var updateList = state.Pathologies.ToList();
        updateList.Add(action.Disease);
        //var stateIsValid = updateList.All(pathology => pathology.IsValid);
        
        return new InheritedPathologiesState(updateList, stateIsValid: true);
    }
    
    
    [ReducerMethod]
    public static InheritedPathologiesState DeleteMicronutrientFromState(InheritedPathologiesState state,
        DeleteInheritedPathologyAction action)
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
        
        
        return new InheritedPathologiesState(updateList, stateIsValid: true);
    }
    
    [ReducerMethod]
    public static InheritedPathologiesState ChangeInhPathology(InheritedPathologiesState state, ChangeInheritedPathologyAction action)
    {
        var pathologies = state.Pathologies;
        pathologies[action.Index] = action.Disease;
        
        return new InheritedPathologiesState(pathologies, stateIsValid: true);
    }
    
    public static InheritedPathologiesState Initialize(InheritedPathologiesState state, InitializeInheritedPathologiesAction action)
    {
        return new InheritedPathologiesState(new List<DiseaseDto>(), true);
    }
    
    
}