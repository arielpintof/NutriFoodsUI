using System.ComponentModel.DataAnnotations;
using NutriFoods_UI.Data;
using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Services;

public interface INutritionistService
{

    Task<HttpResponseMessage?> SignUp(NutritionistDto dto);

    Task<HttpResponseMessage?> Login([Required] string email, [Required] string password);

    Task<HttpResponseMessage?> AddPatient(Guid nutritionistId, PatientDto patientDto);

}