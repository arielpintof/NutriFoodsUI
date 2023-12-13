using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.LogIn;

public class LoadNutritionistDtoAction(NutritionistDto nutritionistDto)
{
    public NutritionistDto NutritionistDto { get; } = nutritionistDto;
}