using Fluxor;

namespace NutriFoods_UI.Data.Store.Anthropometry;

public static class Reducer
{
    [ReducerMethod]
    public static AnthropometryState ChangeAnthropometry(AnthropometryState state, ChangeAnthropometryAction action)
    {
        return new AnthropometryState(action.Anthropometry, state.InitializedFromLastConsultation, state.IsEdited);
    }
    
    public static AnthropometryState InitializeFromConsultation(AnthropometryState state, InitializedAnthropometryAction action)
    {
        return new AnthropometryState(action.Anthropometry, true, state.IsEdited);
    }
}