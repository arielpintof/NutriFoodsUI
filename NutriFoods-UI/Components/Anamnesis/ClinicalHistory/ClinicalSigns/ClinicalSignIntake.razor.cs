using Fluxor;
using Microsoft.AspNetCore.Components;
using NutriFoods_UI.Components.Anamnesis;
using NutriFoods_UI.Data.Dto;
using NutriFoods_UI.Data.Store.ClinicalSigns;

namespace NutriFoods_UI.Components.ClinicalSigns;

public partial class ClinicalSignIntake : IntakeComponent
{
    [Inject] private IState<ClinicalSignState> ClinicalSignState { get; set; } = null!;
    [Inject] private IDispatcher Dispatcher { get; set; } = null!;

    private ClinicalSignDto ClinicalSignModel => Index < ClinicalSignState.Value.ClinicalSigns.Count()
        ? ClinicalSignState.Value.ClinicalSigns.ElementAt(Index)
        : new ClinicalSignDto();

    protected override void Delete() => Dispatcher.Dispatch(new DeleteClinicalSignAction(Index));

    protected override void Update()
    {
        var action = new ChangeClinicalSignAction(new ClinicalSignDto
        {
            Name = ClinicalSignModel.Name,
            Observations = ClinicalSignModel.Observations
        }, Index);

        Dispatcher.Dispatch(action);
    }
}