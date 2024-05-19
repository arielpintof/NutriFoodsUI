using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace NutriFoods_UI.Components.Consultation;

public partial class AddConsultationButton
{
    [Inject] 
    private IDialogService Dialog { get; set; }
    
    [Parameter] 
    public string Class { get; set; } = string.Empty;
    
    [Parameter] 
    public Guid PatientId { get; set; }
    
    private void OpenDialog()
    {
        var options = new DialogOptions{ CloseButton = true, FullWidth = true, MaxWidth = MaxWidth.Small};
        var parameters = new DialogParameters<ConsultationDialog> {{ x => x.PatientId, PatientId }};
        Dialog.Show<ConsultationDialog>("Nueva consulta", parameters, options);
    }
}