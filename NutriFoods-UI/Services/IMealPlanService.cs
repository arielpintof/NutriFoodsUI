using NutriFoods_UI.Data.Dto;
using System.ComponentModel.DataAnnotations;

namespace NutriFoods_UI.Services
{
    public interface IMealPlanService
    {
        Task<HttpResponseMessage?> GenerateBasedOnMetrics(string gender, int height,
        double weight, int age, string physicalActivity,
        string isLunchFilling, string breakfastSatiety, string dinnerSatiety);

        Task<HttpResponseMessage?> GenerateBasedOnMbr(double totalMetabolicRate, string isLunchFilling, string breakfastSatiety,
            string dinnerSatiety);
    }
}
