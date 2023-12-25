using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.FoodConsumptions;

public class InitializeFoodConsumptionsAction(List<FoodConsumptionDto> foodConsumptions)
{
    public List<FoodConsumptionDto> FoodConsumptions { get; } = foodConsumptions;
}