namespace NutriFoods_UI.Data.Store.MealsConfiguration;

public class MealsConfigurationAction
{
    public MealConfiguration Meal { get; }
    public int Position { get; }

    public MealsConfigurationAction(MealConfiguration meal, int position)
    {
        Meal = meal;
        Position = position;
    }
}