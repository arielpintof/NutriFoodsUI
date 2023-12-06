using Fluxor;
using NutriFoods_UI.Data.Model;
using NutriFoods_UI.Utils.Enums;

namespace NutriFoods_UI.Data.Store.TotalMetabolicRate;

[FeatureState]
public class TmrState
{
    public TmrConfiguration TmrConfiguration { get; } = new();
    
    public bool IsValid { get; set; }

    public double GetTmr => IsValid ? TmrConfiguration.Bmr.TotalMetabolicRate(TmrConfiguration.BiologicalSex, 
        TmrConfiguration.Age, TmrConfiguration.Weight, TmrConfiguration.Height, TmrConfiguration.Multiplier) : 0;
    public TmrState(TmrConfiguration tmrConfiguration)
    {
        TmrConfiguration = tmrConfiguration;
    }

    public TmrState()
    {
    }
    
    
}