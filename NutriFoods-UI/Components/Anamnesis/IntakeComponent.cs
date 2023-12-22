using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.VisualBasic.FileIO;

namespace NutriFoods_UI.Components.Anamnesis;

public abstract class IntakeComponent : FluxorComponent
{
    [Parameter]
    public int Index { get; set; }
    
    protected abstract void Delete();

    protected abstract void Update();

    private bool _isValid;
    protected bool IsValidHandler
    {
        get => _isValid;
        set
        {
            if (_isValid == value) return;
            _isValid = value;
            Update();
        }
    }
}
