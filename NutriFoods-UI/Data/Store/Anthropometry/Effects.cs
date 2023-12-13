using System.Net.Http.Json;
using Fluxor;
using NutriFoods_UI.Data.Dto;
using NutriFoods_UI.Services;

namespace NutriFoods_UI.Data.Store.Anthropometry;

public class Effects(
    IState<AnthropometryState> anthropometryState,
    IPatientService patientService)
{
    [EffectMethod]
    public async Task PostAnthropometry(PostAnthropometryAction action, IDispatcher dispatcher)
    {
        var response = await patientService.AddAnthropometry(
            action.PatientId, action.ConsultationId, anthropometryState.Value.Anthropometry);

        var content = response.Content.ReadFromJsonAsync<ConsultationDto>();
        
        
    }
}