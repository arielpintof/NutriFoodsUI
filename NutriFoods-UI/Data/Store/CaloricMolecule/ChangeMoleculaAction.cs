using NutriFoods_UI.Utils.Enums;

namespace NutriFoods_UI.Data.Store;

public class ChangeMoleculaAction(int newValue, Nutrients macro)
{
    public int NewValue { get; } = newValue;
    public Nutrients Macro { get; } = macro;
}