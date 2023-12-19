using Fluxor;

namespace NutriFoods_UI.Data.Store.Images;

public static class Reducers
{
    [ReducerMethod]
    public static ImagesState InitializeDict(ImagesState state, InitializeDictionaryAction action)
    {
        return new ImagesState(action.Dictionary);
    }
}