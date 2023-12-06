using Fluxor;


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