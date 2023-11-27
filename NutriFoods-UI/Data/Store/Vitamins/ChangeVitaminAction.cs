using NutriFoods_UI.Data.Model;

namespace NutriFoods_UI.Data.Store.Vitamins;

public class ChangeVitaminAction
{
    public Ingestible Ingestible { get; }
    public int Index { get; }

    public ChangeVitaminAction(Ingestible ingestible, int index)
    {
        Ingestible = ingestible;
        Index = index;
    }
}