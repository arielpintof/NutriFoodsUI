using Fluxor;
using NutriFoods_UI.Utils.Enums;


namespace NutriFoods_UI.Data.Store;


[FeatureState]
public class MoleculaState
{
    public double CarbTarget { get; }
    public double ProteinTarget { get; }
    public double LipidTarget { get; }
    
    public MoleculaState(){}
    
    public MoleculaState(double carbs, double proteins, double lipids)
    {
        CarbTarget = carbs;
        ProteinTarget = proteins;
        LipidTarget = lipids;
    }
    
    public bool IsValid => CarbTarget + ProteinTarget + LipidTarget == 100;
}


public static class MoleculaStateExtension
{
    public static IDictionary<string, double> GetDistribution(this MoleculaState moleculaState, double totalEnergy)
    {
        
        Console.WriteLine($"Targets: [{moleculaState.CarbTarget}, {moleculaState.LipidTarget}, {moleculaState.ProteinTarget}]");
        var nutrientsDict = NutrientExtensions.GramsDistributionDict(
                totalEnergy, moleculaState.CarbTarget * 0.01, moleculaState.LipidTarget  * 0.01, 
                moleculaState.ProteinTarget  * 0.01);

        var newDict = nutrientsDict
            .ToDictionary(nutrient => nutrient.Key.ReadableName, nutrient => nutrient.Value);

        foreach (var item in newDict)
        {
            Console.WriteLine($"Macro: {item.Key}, gramos: {item.Value}");
        }
        return newDict;
    }
    
}