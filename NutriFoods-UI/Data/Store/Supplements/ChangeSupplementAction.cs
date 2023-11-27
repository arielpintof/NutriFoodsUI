using NutriFoods_UI.Data.Model;

namespace NutriFoods_UI.Data.Store.Supplements;

public class ChangeSupplementAction
{
    public Ingestible Ingestible { get; }
    public int Index { get; }

    public ChangeSupplementAction(Ingestible ingestible, int index)
    {
        Ingestible = ingestible;
        Index = index;
    }
}