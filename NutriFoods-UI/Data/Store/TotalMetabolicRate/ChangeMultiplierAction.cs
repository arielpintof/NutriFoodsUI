namespace NutriFoods_UI.Data.Store.TotalMetabolicRate;

public class ChangeMultiplierAction(double multiplier)
{
    public double Multiplier { get; } = multiplier;
}