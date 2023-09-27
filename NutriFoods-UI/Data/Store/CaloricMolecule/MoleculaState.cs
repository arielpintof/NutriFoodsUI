using Fluxor;


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
}