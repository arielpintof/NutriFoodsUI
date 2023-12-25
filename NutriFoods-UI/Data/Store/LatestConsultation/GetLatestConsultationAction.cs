namespace NutriFoods_UI.Data.Store.LatestConsultation;

public class GetLatestConsultationAction(Guid patientId)
{
    public Guid PatientId { get; } = patientId;
}