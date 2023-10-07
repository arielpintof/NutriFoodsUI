using NutriFoods_UI.Utils.Enums;


namespace NutriFoods_UI.Services
{
    public interface IUserService
    {
        
        Task<HttpResponseMessage?> Find(string apiKey);

        Task<HttpResponseMessage?> SaveUser(string username, string email, string apiKey);
        
        Task<HttpResponseMessage?> SavePersonalData(string apiKey, string birthdate, Gender gender,
            string? name = "", string? lastName = "", Diet diet = Diet.None, IntendedUse intendedUse = IntendedUse.None,
            UpdateFrequency updateFrequency = UpdateFrequency.None);

        Task<HttpResponseMessage?> SaveMetrics(string apiKey, int height,
            double weight, PhysicalActivity physicalActivity);
    }
}
