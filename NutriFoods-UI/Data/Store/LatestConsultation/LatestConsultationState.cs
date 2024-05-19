using Fluxor;
using NutriFoods_UI.Data.Dto;
using NutriFoods_UI.Pages;

namespace NutriFoods_UI.Data.Store.LatestConsultation;


[FeatureState]
public class LatestConsultationState
{
    public ConsultationDto LatestConsultation { get; } = new();
    
    public LatestConsultationState() {}

    public LatestConsultationState(ConsultationDto latestConsultation)
    {
        LatestConsultation = latestConsultation;
    }

    
}