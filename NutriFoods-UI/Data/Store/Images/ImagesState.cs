using Fluxor;

namespace NutriFoods_UI.Data.Store.Images;

[FeatureState]
public class ImagesState
{
    public IReadOnlyDictionary<string, string> ImagesDict { get; } = null!;

    public ImagesState() {}

    public ImagesState(IReadOnlyDictionary<string, string> dictionary)
    {
        ImagesDict = dictionary;
    }
}