using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly HttpClient _httpClient;
        public RecipeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage?> FilterByCarbohydrates(int lowerBound, int upperBound)
        {
            return await _httpClient.GetAsync
                ($"api/v1/recipes/carbohydrates?lower={lowerBound}&upper={upperBound}");
        }

        public async Task<HttpResponseMessage?> FilterByEnergy(int lowerBound, int upperBound)
        {
            return await _httpClient.GetAsync
                ($"api/v1/recipes/energy?lower={lowerBound}&upper={upperBound}");
        }

        public async Task<HttpResponseMessage?> FilterByLipids(int lowerBound, int upperBound)
        {
            return await _httpClient.GetAsync
                ($"api/v1/recipes/lipids?lower={lowerBound}&upper={upperBound}");
        }

        public async Task<HttpResponseMessage?> FilterByPortions(int portions)
        {
            return await _httpClient.GetAsync
                ($"api/v1/recipes/portions/{portions}");
        }

        public async Task<HttpResponseMessage?> FilterByPortions(int lowerBound, int upperBound)
        {
            return await _httpClient.GetAsync
                ($"api/v1/recipes/portions?lower={lowerBound}&upper={upperBound}");
        }

        public async Task<HttpResponseMessage?> FilterByPreparationTime(int lowerBound, int upperBound)
        {
            return await _httpClient.GetAsync
                ($"api/v1/recipes/preparationTime?lower={lowerBound}&upper={upperBound}");
        }

        public async Task<HttpResponseMessage?> FilterByProteins(int lowerBound, int upperBound)
        {
            return await _httpClient.GetAsync
                ($"api/v1/recipes/proteins?lower={lowerBound}&upper={upperBound}");
        }

        public async Task<HttpResponseMessage?> FindAll()
        {
            return await _httpClient.GetAsync
                ($"api/v1/recipes");
        }

        public async Task<HttpResponseMessage?> FindById(int id)
        {
            return await _httpClient.GetAsync
                ($"api/v1/recipes/id/{id}");
        }

        public async Task<HttpResponseMessage?> FindByName(string name)
        {
            return await _httpClient.GetAsync
                ($"api/v1/recipes/name/{name}");
        }

        public async Task<HttpResponseMessage?> GetLactoVegetarianRecipes()
        {
            return await _httpClient.GetAsync
                ($"api/v1/recipes/lacto-vegetarian");
        }

        public async Task<HttpResponseMessage?> GetOvoLactoVegetarianRecipes()
        {
            return await _httpClient.GetAsync
                ($"api/v1/recipes/ovo-lacto-vegetarian");
        }

        public async Task<HttpResponseMessage?> GetOvoVegetarianRecipes()
        {
            return await _httpClient.GetAsync
                ($"api/v1/recipes/ovo-vegetarian");
        }

        public async Task<HttpResponseMessage?> GetPescetarianRecipes()
        {
            return await _httpClient.GetAsync
                ($"api/v1/recipes/pescetarian");
        }

        public async Task<HttpResponseMessage?> GetPolloPescetarianRecipes()
        {
            return await _httpClient.GetAsync
                ($"api/v1/recipes/pollo-pescetarian");
        }

        public async Task<HttpResponseMessage?> GetPollotarianRecipes()
        {
            return await _httpClient.GetAsync
                ($"api/v1/recipes/pollotarian");
        }

        public async Task<HttpResponseMessage?> GetVegetarianRecipes()
        {
            return await _httpClient.GetAsync
                ($"api/v1/recipes/vegetarian"); ;
        }
    }
}
