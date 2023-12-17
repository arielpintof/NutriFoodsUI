using System.ComponentModel.DataAnnotations;
using Fluxor;
using NutriFoods_UI.Utils.Enums;

namespace NutriFoods_UI.Data.Store.MealsConfiguration;

[FeatureState]
public class MealsConfigurationState
{
    public List<MealConfiguration> Meals { get; } = [];

    public bool IsValid => Meals.Sum(x => x.Percentage) == 100;
    
    public MealsConfigurationState(){}

    public MealsConfigurationState(List<MealConfiguration> meals)
    {
        Meals = meals;
        
    }
}


public class MealConfiguration
{
    public MealTypes MealType { get; set; } = null!;
    
    public int Percentage { get; set; }
    
    public TimeSpan? MealTime { get; set; }
    
}



