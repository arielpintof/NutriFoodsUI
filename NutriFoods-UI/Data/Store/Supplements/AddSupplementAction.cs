using NutriFoods_UI.Data.Model;

namespace NutriFoods_UI.Data.Store.Supplements;

public class AddSupplementAction
{
    public Ingestible Ingestible { get; }

    public AddSupplementAction(Ingestible ingestible)
    {
        Ingestible = ingestible;
    }
}