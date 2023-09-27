using Fluxor;
using NutriFoods_UI.Data.Enums;

namespace NutriFoods_UI.Data.Store;

public static class Reducer
{
    [ReducerMethod]
    public static MoleculaState ReduceChangeMoleculaAction(MoleculaState state, ChangeMoleculaAction action)
    {
        var newValue = action.NewValue;
        var newCarbTarget = state.CarbTarget;
        var newProteinTarget = state.ProteinTarget;
        var newLipidTarget = state.LipidTarget;

        
        switch (action.Macro.Token)
        {
            case MacroType.Carb:
                newCarbTarget = newValue;
                break;
            case MacroType.Protein:
                newProteinTarget = newValue;
                break;
            case MacroType.Lipid:
                newLipidTarget = newValue;
                break;
            
        }
        
        return new MoleculaState(newCarbTarget, newProteinTarget, newLipidTarget);
    }
}