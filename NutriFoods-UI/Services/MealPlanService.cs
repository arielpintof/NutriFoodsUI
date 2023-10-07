using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Services
{
    public class MealPlanService : IMealPlanService
    {
        private readonly HttpClient _httpClient;
        public MealPlanService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage?> GenerateBasedOnMbr(double totalMetabolicRate, string isLunchFilling, string breakfastSatiety, string dinnerSatiety)
        {
            var response = await _httpClient.GetAsync
                ($"api/v1/meal-plans/mbr-based?totalMetabolicRate={totalMetabolicRate}&isLunchFilling={isLunchFilling}&breakfastSatiety={breakfastSatiety}&dinnerSatiety={dinnerSatiety}");

            return response;
        }

        public async Task<HttpResponseMessage?> GenerateBasedOnMetrics(string gender, int height, double weight, int age, string physicalActivity, string isLunchFilling, string breakfastSatiety, string dinnerSatiety)
        {
            return await _httpClient.GetAsync
                ($"api/v1/meal-plans/metrics-based?gender={gender}&height={height}&weight={weight}&age={age}&physicalActivity={physicalActivity}&isLunchFilling={isLunchFilling}&breakfastSatiety={breakfastSatiety}&dinnerSatiety={dinnerSatiety}");
        }
    }
}
