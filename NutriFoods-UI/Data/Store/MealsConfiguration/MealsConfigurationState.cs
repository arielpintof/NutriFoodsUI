using System.ComponentModel.DataAnnotations;
using Fluxor;
using NutriFoods_UI.Utils.Enums;

namespace NutriFoods_UI.Data.Store.MealsConfiguration;

[FeatureState]
public class MealsConfigurationState
{
    public IEnumerable<MealConfiguration> Meals { get; }
    
    public MealsConfigurationState(){}

    public MealsConfigurationState(IEnumerable<MealConfiguration> meals)
    {
        Meals = meals;
    }
}


public class MealConfiguration
{

    public MealTypeEnum? MealType { get; set; }  

    [Required(ErrorMessage = "El campo MealTime es obligatorio.")]
    public string? MealTime { get; set; } 
    
    [Range(0, 100, ErrorMessage = "El porcentaje debe estar entre 0 y 100.")]
    public double? Percentage { get; set; }
}