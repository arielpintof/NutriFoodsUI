namespace NutriFoods_UI.Data.Store.Images;

public class InitializeDictionaryAction(IReadOnlyDictionary<string, string> dictionary)
{
    public IReadOnlyDictionary<string, string> Dictionary { get; } = dictionary;
}