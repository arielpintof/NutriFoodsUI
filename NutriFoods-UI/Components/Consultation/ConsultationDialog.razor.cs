using System.Net.Http.Json;
using Fluxor;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using NutriFoods_UI.Data.Dto;
using NutriFoods_UI.Data.Store.DailyPlanList;
using NutriFoods_UI.Data.Store.LatestConsultation;
using NutriFoods_UI.Services;
using NutriFoods_UI.Utils.Enums;

namespace NutriFoods_UI.Components.Consultation;

public partial class ConsultationDialog
{
    [Inject] private IDispatcher Dispatcher { get; set; } = null!;
    [Inject] private IPatientService PatientService { get; set; } = null!;
    [Inject] private NavigationManager Nav { get; set; } = null!;
    
    [CascadingParameter] MudDialogInstance MudDialogInstance { get; set; } = null!;
    [Parameter] public Guid PatientId { get; set; }

    [Parameter] public Guid NutritionistId { get; set; }

    private string Type { get; set; } = string.Empty;

    private string Purpose { get; set; } = string.Empty;

    private MudForm Form { get; set; } = new();

    private ConsultationDto Consultation { get; set; } = new();

    private async Task IsValid()
    {
        await Form.Validate();

        if (Form.IsValid)
        {
            await Task.Delay(1000);
            Dispatcher.Dispatch(new GetLatestConsultationAction(PatientId));

            await Task.Delay(1000);
            await CreateConsultation();
        }
    }


    private static IEnumerable<ConsultationTypes> ConsultationTypesCollection => IEnum<ConsultationTypes, ConsultationTypeToken>
        .TokenDictionary.Select(e => e.Value)
        .Skip(1).ToList();

    private static IEnumerable<ConsultationPurposes> ConsultationPurposesCollection => IEnum<ConsultationPurposes, ConsultationPurposeToken>
        .TokenDictionary.Select(e => e.Value)
        .Skip(1).ToList();

    private async Task CreateConsultation()
    {
        var response = await PatientService.CreateConsultation(PatientId, new ConsultationDto
        {
            Type = Type,
            Purpose = Purpose,
            DailyPlans = []
        });

        var content = await response.Content.ReadFromJsonAsync<ConsultationDto>();

        if (content != null)
        {
            Consultation = content;
            Dispatcher.Dispatch(new InitializeDailyPlansAction());
            await Task.Delay(1000);

            NavToNewConsultation();
        }
    }

    private void NavToNewConsultation()
    {
        Nav.NavigateTo($"/patient/{PatientId}/consultation/{Consultation.Id}");
    }
}