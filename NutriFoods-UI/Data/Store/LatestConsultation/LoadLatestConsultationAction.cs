using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.LatestConsultation;

public class LoadLatestConsultationAction(ConsultationDto consultation)
{
    public ConsultationDto Consultation { get; } = consultation;
}