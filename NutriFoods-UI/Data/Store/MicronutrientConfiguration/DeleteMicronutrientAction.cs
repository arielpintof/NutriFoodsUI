namespace NutriFoods_UI.Data.Store.MicronutrientConfiguration;

public class DeleteMicronutrientAction
{
    public int Index { get; }
    
    public DeleteMicronutrientAction(int index)
    {
        Index = index;
        Console.WriteLine($"Indice del Action: {Index}");
    }

    
}