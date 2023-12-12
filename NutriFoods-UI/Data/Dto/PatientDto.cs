using System.Text.Json.Serialization;
using NutriFoods_UI.Data.Dto;
using NutriFoods_UI.Data.Dto.Abridged;
using NutriFoods_UI.Data.Model;

namespace NutriFoods_UI.Data;

public sealed class PatientDto
{
    public Guid Id { get; set; }
    
    public DateTime JoinedOn { get; set; }
    public PersonalInfoDto? PersonalInfo { get; set; }
    public ContactInfoDto? ContactInfo { get; set; }
    public AddressDto? Address { get; set; }
    public ICollection<Consultation> Consultations { get; set; } = null!;
}