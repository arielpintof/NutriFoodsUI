using NutriFoods_UI.Data.Model;

namespace NutriFoods_UI.Data.Store.Medicines;

public class DeleteMedicineAction(int index)
{
    public int Index { get; } = index;
}