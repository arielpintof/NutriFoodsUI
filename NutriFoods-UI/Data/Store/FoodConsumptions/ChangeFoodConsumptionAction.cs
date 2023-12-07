using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.FoodConsumptions;

public class ChangeFoodConsumptionAction(FoodConsumptionDto foodConsumption, int index)
{
    public FoodConsumptionDto FoodConsumption { get; } = foodConsumption;
    public int Index { get; } = index;
}