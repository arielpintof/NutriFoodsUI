namespace NutriFoods_UI.Data.Store.TotalMetabolicRate;

public class DaysValidationAction(bool isValid)
{
    public bool IsValid { get; } = isValid;
}