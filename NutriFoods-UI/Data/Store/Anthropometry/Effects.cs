using System.Net.Http.Json;
using Fluxor;
using NutriFoods_UI.Data.Dto;
using NutriFoods_UI.Data.Store.AdverseFoodReactions;
using NutriFoods_UI.Data.Store.ClinicalSigns;
using NutriFoods_UI.Data.Store.EatingSymptom;
using NutriFoods_UI.Data.Store.FoodConsumptions;
using NutriFoods_UI.Data.Store.HarmfulHabits;
using NutriFoods_UI.Data.Store.Medicines;
using NutriFoods_UI.Data.Store.Pathologies;
using NutriFoods_UI.Data.Store.Supplements;
using NutriFoods_UI.Data.Store.Vitamins;
using NutriFoods_UI.Services;

namespace NutriFoods_UI.Data.Store.Anthropometry;

public class Effects(
    IState<AnthropometryState> anthropometryState,
    //Clinicos
    IState<ClinicalSignState> clinicalSignState,
    IState<PersonalPathologiesState> diseases,
    IState<MedicineState> medicines,
    IState<VitaminState> vitamins,
    IState<SupplementState> supplements,
    //Alimentarios
    IState<FoodConsumptionState> foodConsumption,
    IState<EatingSymptomState> eatingSymptom,
    IState<HarmfulHabitState> harmfulHabit,
    IState<AdverseFoodReactionState> adverse,
    IPatientService patientService)
{
    [EffectMethod]
    public async Task PostAnthropometry(PostAnthropometryAction action, IDispatcher dispatcher)
    {
        var response = await patientService.AddAnthropometry(
            action.PatientId, action.ConsultationId, anthropometryState.Value.Anthropometry);

        var content = response.Content.ReadFromJsonAsync<ConsultationDto>();
        
    }
    
    [EffectMethod]
    public async Task PostClinical(PostClinicalAction action, IDispatcher dispatcher)
    {
        var ingestibles = medicines.Value.Medicines
            .Concat(vitamins.Value.Vitamins)
            .Concat(supplements.Value.Supplements)
            .ToList();
        
        var response = await patientService.AddClinicalAnamnesis(
            action.PatientId, action.ConsultationId, new ClinicalAnamnesisDto
            {
                Medications = ingestibles,
                ClinicalSigns = clinicalSignState.Value.ClinicalSigns,
                Diseases = diseases.Value.Pathologies
            });

        var content = response.Content.ReadFromJsonAsync<ConsultationDto>();
        
    }
    
    public async Task PostAlimentary(PostAlimentaryAction action, IDispatcher dispatcher)
    {
        
        var response = await patientService.AddNutritionalAnamnesis(
            action.PatientId, action.ConsultationId, new NutritionalAnamnesisDto
            {
                HarmfulHabits = harmfulHabit.Value.HarmfulHabits,
                EatingSymptoms = eatingSymptom.Value.EatingSymptoms,
                FoodConsumptions = foodConsumption.Value.FoodConsumptions,
                AdverseFoodReactions = adverse.Value.AdverseFoodReactions
            });

        var content = response.Content.ReadFromJsonAsync<ConsultationDto>();
        
    }
}