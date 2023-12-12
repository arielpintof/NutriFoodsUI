using NutriFoods_UI.Data.Dto;
using NutriFoods_UI.Data.Model;

namespace NutriFoods_UI.Data.Store.Supplements;

public class ChangeSupplementAction
{
    public IngestibleDto Ingestible { get; }
    public int Index { get; }

    public ChangeSupplementAction(IngestibleDto ingestible, int index)
    {
        Ingestible = ingestible;
        Index = index;
    }
}