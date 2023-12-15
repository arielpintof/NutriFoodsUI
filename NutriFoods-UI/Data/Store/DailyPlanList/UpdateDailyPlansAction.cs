using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.DailyPlanList;

public class UpdateDailyPlansAction(List<DailyPlanDto> dailyPlans)
{
    public List<DailyPlanDto> DailyPlans { get; } = dailyPlans;
}