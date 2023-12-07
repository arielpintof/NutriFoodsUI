using Fluxor;
using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.Anthropometry;

[FeatureState]
public class AnthropometryState
{
    public AnthropometryDto Anthropometry { get; set; } = new();
    
    public AnthropometryState(){}

    public AnthropometryState(AnthropometryDto anthropometry)
    {
        Anthropometry = anthropometry;
    }
}