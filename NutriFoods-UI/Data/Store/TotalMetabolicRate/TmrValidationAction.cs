namespace NutriFoods_UI.Data.Store.TotalMetabolicRate;

public class TmrValidationAction(bool isValid)
{
    public bool IsValid{ get; } = isValid;
}