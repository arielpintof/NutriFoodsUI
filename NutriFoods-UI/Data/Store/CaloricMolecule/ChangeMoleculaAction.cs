using NutriFoods_UI.Data.Enums;

namespace NutriFoods_UI.Data.Store;

public class ChangeMoleculaAction
{
    public double NewValue { get; }
    public MacroTypeEnum Macro { get; }

    public ChangeMoleculaAction(double newValue, MacroTypeEnum macro)
    {
        NewValue = newValue;
        Macro = macro;
    }
}