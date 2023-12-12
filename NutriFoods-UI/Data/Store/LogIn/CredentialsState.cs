using Fluxor;
using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.LogIn;

[FeatureState]
public class CredentialsState
{
    public NutritionistDto NutritionistCredentials { get; } = new();
    
    public CredentialsState(){}

    public CredentialsState(NutritionistDto nutritionistCredentials)
    {
        NutritionistCredentials = nutritionistCredentials;
    }
}