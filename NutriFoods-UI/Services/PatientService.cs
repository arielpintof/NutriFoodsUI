﻿using System.Text;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using NutriFoods_UI.Data.Dto;


namespace NutriFoods_UI.Services;


public class PatientService(HttpClient httpClient, JsonSerializerSettings settings) : IPatientService
{
    public async Task<HttpResponseMessage?> FindPatient(Guid patientId)
    {
        return await httpClient.GetAsync($"{patientId}");
    }

    public async Task<HttpResponseMessage?> FindConsultations(Guid patientId)
    {
        return await httpClient.GetAsync($"{patientId}/consultations");
    }

    public async Task<HttpResponseMessage?> FindLatestConsultation(Guid patientId)
    {
        return await httpClient.GetAsync($"{patientId}/consultations/latest");
    }

    public async Task<HttpResponseMessage?> CreateConsultation(Guid patientId, ConsultationDto consultationDto)
    {
        var json = JsonConvert.SerializeObject(consultationDto, settings);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        return await httpClient.PostAsync($"{patientId}/consultations/", content);
    }

    public async Task<HttpResponseMessage?> AddClinicalAnamnesis(Guid patientId, Guid consultationId,
        ClinicalAnamnesisDto clinicalAnamnesisDto)
    {
        var json = JsonConvert.SerializeObject(clinicalAnamnesisDto, settings);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        return await httpClient.PostAsync
            ($"{patientId}/consultations/{consultationId}/clinical-anamnesis/", content);
    }

    public async Task<HttpResponseMessage?> AddNutritionalAnamnesis(Guid patientId, Guid consultationId,
        NutritionalAnamnesisDto nutritionalAnamnesisDto)
    {
        var json = JsonConvert.SerializeObject(nutritionalAnamnesisDto, settings);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        return await httpClient.PostAsync(
            $"{patientId}/consultations/{consultationId}/nutritional-anamnesis/", content);
    }

    public async Task<HttpResponseMessage?> AddAnthropometry(Guid patientId, Guid consultationId,
        AnthropometryDto anthropometryDto)
    {
        var json = JsonConvert.SerializeObject(anthropometryDto, settings);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        
        return await httpClient.PostAsync(
            $"{patientId}/consultations/{consultationId}/anthropometry/", content);
    }
}

