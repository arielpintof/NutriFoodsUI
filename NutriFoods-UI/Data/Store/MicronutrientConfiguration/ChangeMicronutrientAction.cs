using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.MicronutrientConfiguration;

public class ChangeMicronutrientAction
{
    public int Index { get; }
    public MicroNutrientDto MicroNutrientDto { get; }

    public ChangeMicronutrientAction(int index, MicroNutrientDto microNutrientDto)
    {
        Index = index;
        MicroNutrientDto = microNutrientDto;
    }
}