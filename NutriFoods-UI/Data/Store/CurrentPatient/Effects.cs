using System.Net.Http.Json;
using Fluxor;
using NutriFoods_UI.Data.Dto;
using NutriFoods_UI.Services;

namespace NutriFoods_UI.Data.Store.CurrentPatient;

public class Effects(
    IPatientService patientService)
{
    
    [EffectMethod]
    public async Task GetPatient(InitializePatientAction action, IDispatcher dispatcher)
    {
        var response = await patientService.FindPatient(action.PatientId);
        var content = await response.Content.ReadFromJsonAsync<PatientDto>();

        if (content != null) dispatcher.Dispatch(new LoadPatientAction(content));
    }
}