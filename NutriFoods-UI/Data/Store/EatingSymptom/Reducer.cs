using Fluxor;

namespace NutriFoods_UI.Data.Store.EatingSymptom;

public class Reducer
{
    [ReducerMethod]
    public static EatingSymptomState AddClinicalSign(EatingSymptomState state, AddEatingSymptomAction action)
    {
        var updateList = state.EatingSymptoms;
        updateList.Add(action.EatingSymptom);

        return new EatingSymptomState(updateList);
    }

    [ReducerMethod]
    public static EatingSymptomState ChangeClinicalSign(EatingSymptomState state, ChangeEatingSymptomAction action)
    {
        var updateList = state.EatingSymptoms;
        updateList[action.Index] = action.EatingSymptom;

        return new EatingSymptomState(updateList);
    }

    [ReducerMethod]
    public static EatingSymptomState DeleteClinicalSign(EatingSymptomState state, DeleteEatingSymptomAction action)
    {
        var updateList = state.EatingSymptoms;
        updateList.RemoveAt(action.Index);

        return new EatingSymptomState(updateList);
    }
}