using System.Text;
using System.Text.Json;
using NutriFoods_UI.Data.Dto;
using NutriFoods_UI.Utils.Enums;


namespace NutriFoods_UI.Services
{
    public class UserService : IUserService
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

        public async Task<HttpResponseMessage?> SaveUser(string username, string email, string apiKey)
        {
            var user = new UserDto
            {
                Username = username,
                Email = email,
                ApiKey = apiKey
            };
            var userSerialized = JsonSerializer.Serialize(user);
            var content = new StringContent(userSerialized, Encoding.UTF8, "application/json");
            return await _httpClient.PutAsync
                ($"api/v1/users/save-user?username={user.Username}&email={user.Email}&apiKey={user.ApiKey}", content);
        }

        public async Task<HttpResponseMessage?> SavePersonalData(string apiKey, string birthdate, Gender gender,
            string? name = "", string? lastName = "",
            Diet diet = Diet.None, IntendedUse intendedUse = IntendedUse.None,
            UpdateFrequency updateFrequency = UpdateFrequency.None)
        {
            var userData = new UserDataDto
            {
                Name = name ?? string.Empty,
                LastName = lastName ?? string.Empty,
                Birthdate = birthdate,
                Gender = GenderEnum.FromToken(gender).ReadableName,
                Diet = DietEnum.FromToken(diet).ReadableName,
                IntendedUse = IntendedUseEnum.FromToken(intendedUse).ReadableName,
                UpdateFrequency = UpdateFrequencyEnum.FromToken(updateFrequency).ReadableName
            };
            var userDataSerialized = JsonSerializer.Serialize(userData);
            var content = new StringContent(userDataSerialized, Encoding.UTF8, "application/json");
            return await _httpClient.PutAsync
                ($"api/v1/users/save-data?apiKey={apiKey}&birthdate={birthdate}&gender={gender}&name={name}&lastName={lastName}&diet={diet}&intendedUse={intendedUse}&updateFrequency={updateFrequency}", content);
        }

        public async Task<HttpResponseMessage?> SaveMetrics(string apiKey, int height, double weight, PhysicalActivity physicalActivity)
        {
            var bodyMetricDto = new UserBodyMetricDto
            {
                Height = height,
                Weight = weight,
                BodyMassIndex = Math.Round(1.3 * (weight / Math.Pow(height * 1E-2, 2.5)), 2),
                PhysicalActivity = PhysicalActivityEnum.FromToken(physicalActivity).ReadableName
            };  
            var userMetricsSerialized = JsonSerializer.Serialize(bodyMetricDto);
            var content = new StringContent(userMetricsSerialized, Encoding.UTF8, "application/json");
            return await _httpClient.PostAsync($"api/v1/users/save-metrics?apiKey={apiKey}&height={height}&weight={weight}&physicalActivity={physicalActivity}", content);
        }
    }
}
