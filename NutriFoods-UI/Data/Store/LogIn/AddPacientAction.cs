using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.LogIn;

public class AddPacientAction(PatientDto patient)
{
    public PatientDto Patient { get; } = patient;
}