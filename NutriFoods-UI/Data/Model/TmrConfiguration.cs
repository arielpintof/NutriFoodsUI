using NutriFoods_UI.Utils.Enums;

namespace NutriFoods_UI.Data.Model;

public class TmrConfiguration
{
    public Bmr Bmr = Bmr.HarrisBenedict;
    public BiologicalSexes  BiologicalSex { get; set;} = null!;
    public int Age { get; set; } 
    public double Weight { get; set;} 
    public int Height { get; set;}
    public double Multiplier { get; set; } = 1.3;

    public int PhysicalActivityLevel { get; set; }
    public double Factor { get; set; } = 0.1;
}