using Fluxor;
using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.Anthropometry;

[FeatureState]
public class AnthropometryState
{
    public AnthropometryDto Anthropometry { get; } = new();
    
    //Iniciado si fueron agregados datos en la misma consulta
    public bool IsEdited { get; }
    public bool InitializedFromLastConsultation { get; }
    
    public AnthropometryState() {}

    public AnthropometryState(AnthropometryDto anthropometry, bool initializedFromLastConsultation = false, bool isEdited = false)
    {
        Anthropometry = anthropometry;
        InitializedFromLastConsultation = initializedFromLastConsultation;
        IsEdited = isEdited;
    }
}