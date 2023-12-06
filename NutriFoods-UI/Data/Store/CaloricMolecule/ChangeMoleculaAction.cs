using NutriFoods_UI.Data.Enums;

namespace NutriFoods_UI.Data.Store;

public class ChangeMoleculaAction(int newValue, MacroTypeEnum macro)
{
    public int NewValue { get; } = newValue;
    public MacroTypeEnum Macro { get; } = macro;
}