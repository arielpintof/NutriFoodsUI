namespace NutriFoods_UI.Data.Store.MealsConfiguration;

public class InitializeMealsAction(List<MealConfiguration> meals)
{
    public List<MealConfiguration> Meals { get; } = meals;
}