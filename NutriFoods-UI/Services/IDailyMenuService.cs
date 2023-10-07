
using NutriFoods_UI.Utils.Enums;

namespace NutriFoods_UI.Services;

public interface IDailyMenuService
{
    Task<HttpResponseMessage?> GenerateDailyMenu(double energyTarget, double carbsPercent, double fatsPercent,
        double proteinsPercent, MealType mealType = MealType.None, Satiety satiety = Satiety.None);

    Task<HttpResponseMessage?> GenerateDailyMenu(double energyTarget, MealType mealType = MealType.None,
        Satiety satiety = Satiety.None);

}