using Fluxor;
using NutriFoods_UI.Data.Enums;
using NutriFoods_UI.Utils.Enums;

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

        var token = IEnum<Nutrients, NutrientToken>.ToToken(action.Macro);
        switch (token)
        {
            case NutrientToken.Carbohydrates:
                newCarbTarget = newValue;
                break;
            case NutrientToken.Proteins:
                newProteinTarget = newValue;
                break;
            case NutrientToken.FattyAcids:
                newLipidTarget = newValue;
                break;
            
        }
        
        return new MoleculaState(newCarbTarget, newProteinTarget, newLipidTarget);
    }
}