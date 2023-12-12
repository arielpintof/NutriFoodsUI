using NutriFoods_UI.Data.Dto;
using NutriFoods_UI.Data.Model;

namespace NutriFoods_UI.Data.Store.Supplements;

public class AddSupplementAction
{
    public IngestibleDto Ingestible { get; }

    public AddSupplementAction(IngestibleDto ingestible)
    {
        Ingestible = ingestible;
    }
}