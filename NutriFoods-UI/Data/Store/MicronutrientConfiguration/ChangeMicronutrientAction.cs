using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.MicronutrientConfiguration;

public class ChangeMicronutrientAction(int index, MicroNutrientDto microNutrientDto)
{
    public int Index { get; } = index;
    public MicroNutrientDto MicroNutrientDto { get; } = microNutrientDto;
}