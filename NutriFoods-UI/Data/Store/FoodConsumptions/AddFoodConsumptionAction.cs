using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.FoodConsumptions;

public class AddFoodConsumptionAction(FoodConsumptionDto foodConsumption)
{
    public FoodConsumptionDto FoodConsumption { get; } = foodConsumption;
}