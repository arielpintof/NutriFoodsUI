using Fluxor;
using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.CurrentPatient;

public static class Reducer
{
    [ReducerMethod]
    public static PatientState Initialize(PatientState state, LoadPatientAction action)
    {
        return new PatientState(action.Patient, true);
    }
}