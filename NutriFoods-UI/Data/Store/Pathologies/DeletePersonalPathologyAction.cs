namespace NutriFoods_UI.Data.Store.Pathologies;

public class DeletePersonalPathologyAction
{
    public int Index { get; }

    public DeletePersonalPathologyAction(int index)
    {
        Index = index;
    }
}