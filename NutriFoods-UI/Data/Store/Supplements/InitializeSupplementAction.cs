using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.Supplements;

public class InitializeSupplementAction(List<IngestibleDto> supplements)
{
    public List<IngestibleDto> Supplements { get; } = supplements;
}