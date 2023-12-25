using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.Medicines;

public class InitializeMedicineAction(List<IngestibleDto> medicines)
{
    public List<IngestibleDto> Medicines { get; } = medicines;
}