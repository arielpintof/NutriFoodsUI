namespace NutriFoods_UI.Data.Dto.Abridged;

public class AddressDto
{
    public string Street { get; set; } = null!;
    public int Number { get; set; }
    public int? PostalCode { get; set; }
    public string Province { get; set; } = null!;
}