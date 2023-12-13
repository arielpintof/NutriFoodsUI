using NutriFoods_UI.Data.Dto;
using NutriFoods_UI.Data.Model;

namespace NutriFoods_UI.Data.Store.Medicines;

public class ChangeMedicineAction(int index, IngestibleDto ingestible)
{
    public int Index { get; } = index;
    public IngestibleDto Ingestible { get; } = ingestible;
}