namespace NutriFoods_UI.Data.Dto;

public sealed class ContactInfoDto
{
    public string MobilePhone { get; set; } = null!;
    public string? FixedPhone { get; set; }
    public string Email { get; set; } = null!;
}
