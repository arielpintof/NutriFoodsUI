namespace NutriFoods_UI.Data.Store.MealsConfiguration;

public class ChangeMealsConfigurationAction(MealConfiguration meal, int position)
{
    public MealConfiguration Meal { get; } = meal;
    public int Position { get; } = position;
}