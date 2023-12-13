using NutriFoods_UI.Data.Dto;
using NutriFoods_UI.Utils.Enums;


namespace NutriFoods_UI.Services
{
    public interface IPatientService
    {
        Task<HttpResponseMessage> FindPatient(Guid patientId);

        Task<HttpResponseMessage> FindConsultations(Guid patientId);

        Task<HttpResponseMessage> FindLatestConsultation(Guid patientId);

        Task<HttpResponseMessage> CreateConsultation(Guid patientId, ConsultationDto consultationDto);

        Task<HttpResponseMessage> AddClinicalAnamnesis(Guid patientId, Guid consultationId, 
            ClinicalAnamnesisDto clinicalAnamnesisDto);

        Task<HttpResponseMessage> AddNutritionalAnamnesis(Guid patientId, Guid consultationId,
            NutritionalAnamnesisDto nutritionalAnamnesisDto);

        Task<HttpResponseMessage> AddAnthropometry(Guid patientId, Guid consultationId,
            AnthropometryDto anthropometryDto);
    }
}
