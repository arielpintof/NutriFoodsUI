using NutriFoods_UI.Utils.Enums;

namespace NutriFoods_UI.Data.Model;

public class Disease
{
    public string Name { get; set; } = string.Empty;
    public List<Inheritance>? Inheritances { get; set; } = new();
    public bool IsValid { get; set; }
        
}