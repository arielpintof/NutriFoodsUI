using NutriFoods_UI.Data.Dto;
using NutriFoods_UI.Data.Model;

namespace NutriFoods_UI.Data.Store.Vitamins;

public class ChangeVitaminAction
{
    public IngestibleDto Ingestible { get; }
    public int Index { get; }

    public ChangeVitaminAction(IngestibleDto ingestible, int index)
    {
        Ingestible = ingestible;
        Index = index;
    }
}