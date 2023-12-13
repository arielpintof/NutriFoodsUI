using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using NutriFoods_UI.Data;
using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Services;


public class NutritionistService(HttpClient httpClient, JsonSerializerSettings settings) : INutritionistService
{
    public async Task<HttpResponseMessage?> SignUp(NutritionistDto dto)
    {
        var json = JsonConvert.SerializeObject(dto, settings);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        return await httpClient.PostAsync("sign-up", content);
    }

    public async Task<HttpResponseMessage?> Login(string email, string password)
    {
        return await httpClient.GetAsync($"login?email={email}&password={password}");
    }

    public async Task<HttpResponseMessage?> AddPatient(Guid nutritionistId, PatientDto patientDto)
    {
        var json = JsonConvert.SerializeObject(patientDto, settings);
        
        Console.WriteLine("JSON being sent:\n" + json);
        
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        
        return await httpClient.PostAsync($"nutritionist/{nutritionistId}/patient/", content);
    }
}