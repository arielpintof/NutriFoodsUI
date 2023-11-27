using NutriFoods_UI.Data.Model;

namespace NutriFoods_UI.Data.Store.Vitamins;

public class AddVitaminAction
{
    public Ingestible Ingestible { get; }

    public AddVitaminAction(Ingestible ingestible)
    {
        Ingestible = ingestible;
    }
}