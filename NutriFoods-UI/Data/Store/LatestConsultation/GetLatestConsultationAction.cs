namespace NutriFoods_UI.Data.Store.LatestConsultation;

public class GetLatestConsultationAction(Guid patiendId)
{
    public Guid PatiendId { get; } = patiendId;
}