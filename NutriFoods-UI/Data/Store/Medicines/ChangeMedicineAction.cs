using NutriFoods_UI.Data.Model;

namespace NutriFoods_UI.Data.Store.Medicines;

public class ChangeMedicineAction
{
    public int Index { get; }
    public Ingestible Ingestible { get; }

    public ChangeMedicineAction(int index, Ingestible ingestible)
    {
        Index = index;
        Ingestible = ingestible;
    }
}