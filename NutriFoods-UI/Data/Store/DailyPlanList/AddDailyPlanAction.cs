using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.DailyPlanList;

public class AddDailyPlanAction(DailyPlanDto dailyPlanDto)
{
    public DailyPlanDto DailyPlanDto { get; } = dailyPlanDto;
}