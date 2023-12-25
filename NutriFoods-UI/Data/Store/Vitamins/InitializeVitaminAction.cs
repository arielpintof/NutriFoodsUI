using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.Vitamins;

public class InitializeVitaminAction(List<IngestibleDto> vitamins)
{
    public List<IngestibleDto> Vitamins { get; } = vitamins;
}