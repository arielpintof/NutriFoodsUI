using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.MicronutrientConfiguration;

public class ChangeMicronutrientAction(int index, NutritionalTargetDto microNutrientDto)
{
    public int Index { get; } = index;
    public NutritionalTargetDto MicroNutrientDto { get; } = microNutrientDto;
}