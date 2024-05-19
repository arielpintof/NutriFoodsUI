namespace NutriFoods_UI.Data.Store.CurrentPatient;

public class InitializePatientAction(Guid patientId)
{
    public Guid PatientId { get; } = patientId;
}