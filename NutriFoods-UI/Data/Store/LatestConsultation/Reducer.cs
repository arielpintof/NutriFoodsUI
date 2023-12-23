using Fluxor;

namespace NutriFoods_UI.Data.Store.LatestConsultation;

public static class Reducer
{
    [ReducerMethod]
    public static LatestConsultationState Load(LatestConsultationState state, LoadLatestConsultationAction action)
    {
        return new LatestConsultationState(action.Consultation);
    }
}