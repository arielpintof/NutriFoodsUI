using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.MicronutrientConfiguration;

public class AddMicronutrientAction
{
    public NutritionalTargetDto MicroNutrient { get; }
    
    public AddMicronutrientAction(NutritionalTargetDto microNutrient)
    {
        MicroNutrient = microNutrient;
    }
}