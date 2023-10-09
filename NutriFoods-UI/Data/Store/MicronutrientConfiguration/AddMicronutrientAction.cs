using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.MicronutrientConfiguration;

public class AddMicronutrientAction
{
    public MicroNutrientDto MicroNutrient { get; }
    
    public AddMicronutrientAction(MicroNutrientDto microNutrient)
    {
        MicroNutrient = microNutrient;
    }
}