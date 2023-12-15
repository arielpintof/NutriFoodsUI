namespace NutriFoods_UI.Utils.Strings;

public static class Strings
{
    
    public static string FirstWord(string name) => new(name.TakeWhile(c => !char.IsWhiteSpace(c)).ToArray());
    
}