namespace NutriFoods_UI.Data.Store.DailyPlanList;

public class PostDailyPlansAction(Guid patientId, Guid consultationId)
{
    public Guid PatientId { get; } = patientId;
    public Guid ConsultationId { get; } = consultationId;
}