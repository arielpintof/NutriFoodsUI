

namespace NutriFoods_UI.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly HttpClient _httpClient;
        public IngredientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage?> GetAll()
        {
            var response = await _httpClient.GetAsync("api/v1/ingredients");
            response.EnsureSuccessStatusCode();
            return response;
        }

        public async Task<HttpResponseMessage?> FindByName(string name)
        {
                return await _httpClient.GetAsync($"api/v1/ingredients/name/{name}");
        }

        public async Task<HttpResponseMessage?> FindById(int id)
        {
            return await _httpClient.GetAsync($"api/v1/ingredients/id/{id}");
        }

        public async Task<HttpResponseMessage?> FindByPrimaryGroup(string name)
        {
            return await _httpClient.GetAsync($"api/v1/ingredients/primaryGroup/{name}");
        }

        public async Task<HttpResponseMessage?> FindByPrimaryGroup(int id)
        {
            return await _httpClient.GetAsync($"api/v1/ingredients/primaryGroup/{id}");
        }

        public async Task<HttpResponseMessage?> FindBySecondaryGroup(string name)
        {
            return await _httpClient.GetAsync($"api/v1/ingredients/secondaryGroup/{name}");
        }

        public async Task<HttpResponseMessage?> FindBySecondaryGroup(int id)
        {
            return await _httpClient.GetAsync($"api/v1/ingredients/secondaryGroup/{id}");
        }

        public async Task<HttpResponseMessage?> FindByTertiaryGroup(string name)
        {
            return await _httpClient.GetAsync($"api/v1/ingredients/tertiaryGroup/{name}");
        }

        public async Task<HttpResponseMessage?> FindByTertiaryGroup(int id)
        {
            return await _httpClient.GetAsync($"api/v1/ingredients/tertiaryGroup/{id}");
        }
    }
}
