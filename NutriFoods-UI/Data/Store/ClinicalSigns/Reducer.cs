using Fluxor;

namespace NutriFoods_UI.Data.Store.ClinicalSigns;

public class Reducer
{
    [ReducerMethod]
    public static ClinicalSignState AddClinicalSign(ClinicalSignState state, AddClinicalSignAction action)
    {
        var updateList = state.ClinicalSigns;
        updateList.Add(action.ClinicalSignDto);
        
        return new ClinicalSignState(updateList);
    }

    [ReducerMethod]
    public static ClinicalSignState ChangeClinicalSign(ClinicalSignState state, ChangeClinicalSignAction action)
    {
        var updateList = state.ClinicalSigns;
        updateList[action.Index] = action.ClinicalSignDto;

        return new ClinicalSignState(updateList);
    }
    
    [ReducerMethod]
    public static ClinicalSignState DeleteClinicalSign(ClinicalSignState state, DeleteClinicalSignAction action)
    {
        var updateList = state.ClinicalSigns;
        updateList.RemoveAt(action.Index);

        return new ClinicalSignState(updateList);
    }

    [ReducerMethod]
    public static ClinicalSignState Initialize(ClinicalSignState state, InitializeClinicalSignAction action)
    {
        return new ClinicalSignState(action.ClinicalSigns);
    }
}