using Fluxor;

namespace NutriFoods_UI.Data.Store.LogIn;

public static class Reducer
{
    [ReducerMethod]
    public static CredentialsState LoadDto(CredentialsState state, LoadNutritionistDtoAction action)
    {
        return new CredentialsState(action.NutritionistDto);
    }

    [ReducerMethod]
    public static CredentialsState UpdateDto(CredentialsState state, UpdateNutritionistAction action)
    {
        return new CredentialsState(action.NutritionistDto);
    }
}