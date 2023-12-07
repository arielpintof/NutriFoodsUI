using Fluxor;
using NutriFoods_UI.Utils.Enums;


namespace NutriFoods_UI.Data.Store;


[FeatureState]
public class MoleculaState
{
    public int CarbTarget { get; }
    public int ProteinTarget { get; }
    public int LipidTarget { get; }
    
    public MoleculaState(){}
    
    public MoleculaState(int carbs, int proteins, int lipids)
    {
        CarbTarget = carbs;
        ProteinTarget = proteins;
        LipidTarget = lipids;
    }
    
    public bool IsValid => CarbTarget + ProteinTarget + LipidTarget == 100;
}


public static class MoleculaStateExtension
{
    public static Dictionary<string, double> Distribution(this MoleculaState moleculaState, double totalEnergy)
    {
        
        var carbPercentage = moleculaState.CarbTarget * 0.01;
        var proteinPercentage = moleculaState.ProteinTarget * 0.01;
        var lipidPercentage = moleculaState.LipidTarget * 0.01;
        
        var carbValue = carbPercentage * totalEnergy;
        var proteinValue = proteinPercentage * totalEnergy;
        var lipidValue = lipidPercentage * totalEnergy;
        
        var nutrientDictionary = new Dictionary<string, double>
        {
            { IEnum<Nutrients, NutrientToken>.ToReadableName(NutrientToken.Carbohydrates), carbValue },
            { IEnum<Nutrients, NutrientToken>.ToReadableName(NutrientToken.Proteins), proteinValue },
            { IEnum<Nutrients, NutrientToken>.ToReadableName(NutrientToken.FattyAcids), lipidValue }
        };

        return nutrientDictionary;
    }
    
}