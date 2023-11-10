using NutriFoods_UI.Data.Model;

namespace NutriFoods_UI.Data.Store.Pathologies;

public class AddPersonalPathologyAction
{
    public Disease Disease { get; }
    
    public AddPersonalPathologyAction(Disease disease)
    {
        Disease = disease;
    }
}