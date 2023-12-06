using Fluxor;
using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.FoodConsumptions;

[FeatureState]
public class FoodConsumptionState
{
    public List<FoodConsumptionDto> FoodConsumptions { get; } = new();
    public bool IsValid { get; }
    
    public FoodConsumptionState(){}

    public FoodConsumptionState(List<FoodConsumptionDto> foodConsumptions, bool isValid = false)
    {
        FoodConsumptions = foodConsumptions;
        IsValid = isValid;
    }
    
    
}