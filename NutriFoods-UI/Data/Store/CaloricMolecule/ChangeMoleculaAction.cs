using NutriFoods_UI.Utils.Enums;

namespace NutriFoods_UI.Data.Store;

public class ChangeMoleculaAction(double newValue, Nutrients macro)
{
    public double NewValue { get; } = newValue;
    public Nutrients Macro { get; } = macro;
}