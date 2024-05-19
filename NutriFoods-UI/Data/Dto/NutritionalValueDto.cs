namespace NutriFoods_UI.Data.Dto;

public class NutritionalValueDto
{
    public string Nutrient { get; set; } = null!;
    public double Quantity { get; set; }
    public string Unit { get; set; } = null!;
    public double? DailyValue { get; set; }
}

public static class NutritionalValueExtension
{
    //Devuelve la cifra de macronutrientes y unidad de medida correspondiente
    public static List<Tuple<double, string>> GetMacroValues(this List<NutritionalValueDto> nutritionalValue)
    {
        var calories = nutritionalValue.Find(e => e.Nutrient.Equals("Energía, total"));
        var proteins = nutritionalValue.Find(e => e.Nutrient.Equals("Proteína, total"));
        var carbs = nutritionalValue.Find(e => e.Nutrient.Equals("Carbohidratos, total"));
        var fats = nutritionalValue.Find(e => e.Nutrient.Equals("Ácidos grasos, total"));

        return new List<Tuple<double, string>>
        {
            Tuple.Create(calories!.Quantity, calories.Unit.ToLower()),
            Tuple.Create(proteins!.Quantity, proteins.Unit.ToLower()),
            Tuple.Create(carbs!.Quantity, carbs.Unit.ToLower()),
            Tuple.Create(fats!.Quantity, fats.Unit.ToLower())
        };
    }
}