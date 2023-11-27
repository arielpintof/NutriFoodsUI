using NutriFoods_UI.Data.Model;

namespace NutriFoods_UI.Data.Store.Medicines;

public class DeleteMedicineAction
{
    public int Index { get; }

    public DeleteMedicineAction(int index)
    {
        Index = index;
    }
}