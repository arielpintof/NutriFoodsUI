using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.CurrentPatient;

public class LoadPatientAction(PatientDto patient)
{
    public PatientDto Patient { get; } = patient;
}