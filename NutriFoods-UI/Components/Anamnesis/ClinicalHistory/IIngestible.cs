
using MudBlazor;

namespace NutriFoods_UI.Components;

public interface IIngestible
{
    public DialogOptions Options { get; }
    public void AddIngestible();

    public void EditIngestible(int index);
    
    public void DeleteIngestible(int index);

    void LoadIngestible();
}

