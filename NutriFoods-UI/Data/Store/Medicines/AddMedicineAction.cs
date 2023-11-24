using NutriFoods_UI.Data.Model;

namespace NutriFoods_UI.Data.Store.Medicines;

public class AddMedicineAction
{
    public Ingestible Ingestible { get; }

    public AddMedicineAction(Ingestible ingestible)
    {
        Ingestible = ingestible;
    }
}