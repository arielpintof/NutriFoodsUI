using NutriFoods_UI.Data.Dto;
using NutriFoods_UI.Data.Model;

namespace NutriFoods_UI.Data.Store.Vitamins;

public class AddVitaminAction(IngestibleDto ingestible)
{
    public IngestibleDto Ingestible { get; } = ingestible;
}