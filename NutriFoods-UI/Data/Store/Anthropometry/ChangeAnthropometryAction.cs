using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.Anthropometry;

public class ChangeAnthropometryAction(AnthropometryDto anthropometry)
{
    public AnthropometryDto Anthropometry { get; } = anthropometry;
}