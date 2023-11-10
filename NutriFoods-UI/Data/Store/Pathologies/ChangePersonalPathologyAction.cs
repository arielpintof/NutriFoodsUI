using NutriFoods_UI.Data.Model;

namespace NutriFoods_UI.Data.Store.Pathologies;

public class ChangePersonalPathologyAction
{
    public int Index { get; }
    public Disease Disease { get; }

    public ChangePersonalPathologyAction(int index, Disease disease)
    {
        Index = index;
        Disease = disease;
    }
}