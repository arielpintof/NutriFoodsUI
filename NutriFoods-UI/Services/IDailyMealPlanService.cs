using NutriFoods_UI.Data.Dto;
using NutriFoods_UI.Utils.Enums;

namespace NutriFoods_UI.Services;

public interface IDailyMealPlanService
{
    Task<HttpResponseMessage?> GenerateDailyMealPlan(double energyTarget,
        bool isLunchFilling, Satiety breakfast, Satiety dinner,
        bool? includeBrunch = false, bool? includeLinner = false, DayOfTheWeek? dayOfWeek = DayOfTheWeek.None);
}