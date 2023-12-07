using System.Text;
using System.Text.Json;
using NutriFoods_UI.Utils.Enums;


namespace NutriFoods_UI.Services
{
    public class UserService 
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage?> Find(string apiKey)
        {
            return await _httpClient.GetAsync($"api/v1/users/api-key?apiKey={apiKey}");
        }
        
    }
}
