using Fluxor;
using NutriFoods_UI.Data.Model;
using NutriFoods_UI.Utils.Enums;

namespace NutriFoods_UI.Data.Store.TotalMetabolicRate;

public class Reducer
{
    [ReducerMethod]
    public static TmrState ChangeBmr(TmrState state, ChangeBmrAction action)
    {
        return new TmrState(new TmrConfiguration
        {
            Bmr = action.Bmr,
            BiologicalSex = state.TmrConfiguration.BiologicalSex,
            Age = state.TmrConfiguration.BiologicalSex,
            Weight = state.TmrConfiguration.Weight,
            Height = state.TmrConfiguration.Height,
            Multiplier = state.TmrConfiguration.Multiplier,
            Factor = state.TmrConfiguration.Factor
        });
    }

    [ReducerMethod]
    public static TmrState ChangeMultiplier(TmrState state, ChangeMultiplierAction action)
    {
        return new TmrState(new TmrConfiguration
        {
            Bmr = state.TmrConfiguration.Bmr,
            BiologicalSex = state.TmrConfiguration.BiologicalSex,
            Age = state.TmrConfiguration.BiologicalSex,
            Weight = state.TmrConfiguration.Weight,
            Height = state.TmrConfiguration.Height,
            Multiplier = action.Multiplier,
            Factor = state.TmrConfiguration.Factor
        });
    }
    
    [ReducerMethod]
    public static TmrState ChangeFactor(TmrState state, ChangeAdjusmentFactorAction action)
    {
        return new TmrState(new TmrConfiguration
        {
            Bmr = state.TmrConfiguration.Bmr,
            BiologicalSex = state.TmrConfiguration.BiologicalSex,
            Age = state.TmrConfiguration.BiologicalSex,
            Weight = state.TmrConfiguration.Weight,
            Height = state.TmrConfiguration.Height,
            Multiplier = state.TmrConfiguration.Multiplier,
            Factor = action.Factor
        });
    }

    [ReducerMethod]
    public static TmrState ChangeConfiguration(TmrState state, ChangeTmrAction action)
    {
        return new TmrState(action.Configuration);
    }
}

