using System.Net.Http.Json;
using Fluxor;
using NutriFoods_UI.Data.Dto;
using NutriFoods_UI.Pages;
using NutriFoods_UI.Services;

namespace NutriFoods_UI.Data.Store.LatestConsultation;

public class Effect(
    IState<LatestConsultationState> state, 
    IPatientService patientService)
{

    [EffectMethod]
    public async Task GetLatestConsultation(GetLatestConsultationAction action, IDispatcher dispatcher)
    {
        var response = await patientService.FindLatestConsultation(action.PatiendId);
        var content = await response.Content.ReadFromJsonAsync<ConsultationDto>();
        
        dispatcher.Dispatch(content is not null ? new LoadLatestConsultationAction(content)
            : new LoadLatestConsultationAction(new ConsultationDto()));
    } 
}