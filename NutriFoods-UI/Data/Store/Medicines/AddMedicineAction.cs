using NutriFoods_UI.Data.Dto;
using NutriFoods_UI.Data.Model;

namespace NutriFoods_UI.Data.Store.Medicines;

public class AddMedicineAction
{
    public IngestibleDto Ingestible { get; }

    public AddMedicineAction(IngestibleDto ingestible)
    {
        Ingestible = ingestible;
    }
}