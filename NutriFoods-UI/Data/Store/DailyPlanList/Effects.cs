using System.Net.Http.Json;
using AutoMapper;
using Fluxor;
using Microsoft.AspNetCore.Components;
using NutriFoods_UI.Data.Dto;
using NutriFoods_UI.Data.Dto.Insertion;
using NutriFoods_UI.Services;

namespace NutriFoods_UI.Data.Store.DailyPlanList;

public class Effects(
    IPatientService patientService,
    IState<DailyPlanState> dailyPlanState,
    NavigationManager navigationManager)
{
    [EffectMethod]
    public async Task PostMealPlan(PostDailyPlansAction action, IDispatcher dispatcher)
    {
        var minimalPlans = dailyPlanState.Value.DailyPlans
            .Select(e => e.MapToMinimalDailyPlan()).ToList();
        
        var response = await patientService.AddDailyPlans(action.PatientId, action.ConsultationId, minimalPlans);
        var content = await response.Content.ReadFromJsonAsync<ConsultationDto>();
        
        navigationManager.NavigateTo($"/patients/profile/{action.PatientId}");
        
        
    }
}