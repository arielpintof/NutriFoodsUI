using System.Net.Http.Json;
using System.Reflection.Metadata;
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
    IState<PersonalPathologiesState> personalDiseases,
    IState<InheritedPathologiesState> inheritedDiseases,
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
        var ingestibles = medicines.Value.Medicines.ToList();
        ingestibles.AddRange(vitamins.Value.Vitamins);
        ingestibles.AddRange(supplements.Value.Supplements);

        //var toTimeFormat = ingestibles.Select(e => e.TimeFormat()).ToList();

        var pathologies = personalDiseases.Value.Pathologies;
        pathologies.AddRange(inheritedDiseases.Value.Pathologies);
        
        var response = await patientService.AddClinicalAnamnesis(
            action.PatientId, action.ConsultationId, new ClinicalAnamnesisDto
            {
                Ingestibles = ingestibles,
                ClinicalSigns = clinicalSignState.Value.ClinicalSigns,
                Diseases = pathologies
            });

        var content = response.Content.ReadFromJsonAsync<ConsultationDto>();
        
    }
    
    [EffectMethod]
    public async Task PostAlimentary(PostAlimentaryAction action, IDispatcher dispatcher)
    {
        Console.WriteLine("Por hacer la llamada...");
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