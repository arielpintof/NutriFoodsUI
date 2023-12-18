using Fluxor;
using NutriFoods_UI.Data.Model;

namespace NutriFoods_UI.Data.Store.TotalMetabolicRate;

public static class Reducer
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

    [ReducerMethod]
    public static DaysState AddDays(DaysState state, AddDaysAction action)
    {
        return new DaysState(action.Days);
    }

    [ReducerMethod]
    public static DaysState ValidateDays(DaysState state, DaysValidationAction action)
    {
        return new DaysState(state.Days, action.IsValid);
    }
}

