using Fluxor;
using NutriFoods_UI.Data.Model;
using NutriFoods_UI.Utils.Enums;

namespace NutriFoods_UI.Data.Store.TotalMetabolicRate;

[FeatureState]
public class TmrState
{
    public TmrConfiguration TmrConfiguration { get; } = new();
    
    public bool IsValid { get;}

    public double GetTmr => TmrConfiguration.Bmr.TotalMetabolicRate(TmrConfiguration.BiologicalSex,
        TmrConfiguration.Age, TmrConfiguration.Weight, TmrConfiguration.Height, TmrConfiguration.Multiplier);

    public double GetBmr => TmrConfiguration.Bmr.BasalMetabolicRate(TmrConfiguration.BiologicalSex,
        TmrConfiguration.Age, TmrConfiguration.Weight, TmrConfiguration.Height);
        
    
    public TmrState(TmrConfiguration tmrConfiguration)
    {
        TmrConfiguration = tmrConfiguration;
    }
    
    public TmrState(TmrConfiguration tmrConfiguration, bool isValid)
    {
        TmrConfiguration = tmrConfiguration;
        IsValid = isValid;
    }

    public TmrState()
    {
    }
    
    
}

[FeatureState]
public class DaysState
{
    public List<string> Days { get; } = [];
    
    public bool IsValid { get;}
    
    public DaysState(List<string> days) => Days = days;

    public DaysState(List<string> days, bool isValid)
    {
        Days = days;
        IsValid = isValid;
    }

    public DaysState()
    {
    }
    
    
}