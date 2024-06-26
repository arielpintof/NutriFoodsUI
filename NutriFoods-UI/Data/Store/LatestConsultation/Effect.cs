﻿using System.Net.Http.Json;
using Fluxor;
using Newtonsoft.Json;
using NutriFoods_UI.Data.Dto;
using NutriFoods_UI.Pages;
using NutriFoods_UI.Services;

namespace NutriFoods_UI.Data.Store.LatestConsultation;

public class Effect(IPatientService patientService)
{

    [EffectMethod]
    public async Task GetLatestConsultation(GetLatestConsultationAction action, IDispatcher dispatcher)
    {
        var response = await patientService.FindLatestConsultation(action.PatientId);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadFromJsonAsync<ConsultationDto>();
            var json = JsonConvert.SerializeObject(content, new JsonSerializerSettings());
            Console.WriteLine($"Latest: {json}");
            dispatcher.Dispatch(new LoadLatestConsultationAction(content!));
        }

        else
        {
            dispatcher.Dispatch(new LoadLatestConsultationAction(new ConsultationDto()));
        }
        
    } 
}