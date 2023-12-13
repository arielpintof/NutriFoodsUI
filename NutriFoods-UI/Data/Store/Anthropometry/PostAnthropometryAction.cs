using MudBlazor;

namespace NutriFoods_UI.Data.Store.Anthropometry;

public class PostAnthropometryAction(Guid consultationId, Guid patientId)
{
    public Guid ConsultationId { get; } = consultationId;
    public Guid PatientId { get; } = patientId;
}