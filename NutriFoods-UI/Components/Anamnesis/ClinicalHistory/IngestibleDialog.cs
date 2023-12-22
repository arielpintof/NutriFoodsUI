using Microsoft.AspNetCore.Components;
using MudBlazor;
using NutriFoods_UI.Components.Anamnesis.ClinicalHistory;
using NutriFoods_UI.Data.Dto;
using NutriFoods_UI.Utils.Enums;
using NutriFoods_UI.Utils.Enums.Validators.Anamnesis;

namespace NutriFoods_UI.Components;

public abstract class IngestibleDialog : ComponentBase
{
    [CascadingParameter]
    public MudDialogInstance MudDialogInstance { get; set; } = null!;

    public IngestibleDto IngestibleModel { get; set; } = new();

    protected MudForm IngestibleForm { get; set; } = new();

    public IngestibleValidator IngestibleValidator { get; set; } = new();

    [Parameter]
    public int Index { get; set; }

    [Parameter]
    public ModeTypeEnum ModeType { get; set; } = null!;
    
    public void AddAdministrationTime()
    {
        IngestibleModel.AdministrationTimes.Add(new TimeSpan());
        StateHasChanged();
    }

    protected static IEnumerable<Frequencies> FrequenciesCollection =>
        IEnum<Frequencies, FrequencyToken>.TokenDictionary.Select(e => e.Value).Skip(1).ToList();

    protected static IEnumerable<Units> UnitsCollection =>
        IEnum<Units, UnitToken>.TokenDictionary.Select(e => e.Value).Skip(1).ToList();
}