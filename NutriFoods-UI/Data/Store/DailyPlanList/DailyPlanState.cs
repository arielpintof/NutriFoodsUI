using Fluxor;
using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.DailyPlanList;

[FeatureState]
public class DailyPlanState
{
    public List<DailyPlanDto> DailyPlans { get; } = [];
    
    public DailyPlanState(){}
    public DailyPlanState(List<DailyPlanDto> dailyPlans)
    {
        DailyPlans = dailyPlans;
    }
    
}