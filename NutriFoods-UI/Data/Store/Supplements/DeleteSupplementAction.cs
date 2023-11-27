using NutriFoods_UI.Data.Model;

namespace NutriFoods_UI.Data.Store.Supplements;

public class DeleteSupplementAction
{
    public int Index { get; }

    public DeleteSupplementAction( int index)
    {
        Index = index;
    }
}