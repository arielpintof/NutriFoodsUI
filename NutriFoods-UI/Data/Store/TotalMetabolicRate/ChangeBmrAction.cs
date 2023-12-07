using NutriFoods_UI.Utils.Enums;

namespace NutriFoods_UI.Data.Store.TotalMetabolicRate;

public class ChangeBmrAction(Bmr bmr)
{
    public Bmr Bmr { get; } = bmr;
}