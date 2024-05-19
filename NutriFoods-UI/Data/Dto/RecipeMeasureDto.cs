using NutriFoods_UI.Data.Dto.Abridged;

namespace NutriFoods_UI.Data.Dto;

public class RecipeMeasureDto
{
    public int IntegerPart { get; set; }
    public int Numerator { get; set; }
    public int Denominator { get; set; }
    public IngredientMeasureAbridged IngredientMeasure { get; set; } = null!;
}

public static class RecipeMeasureExtensions
{
    public static string MeasureToString(this RecipeMeasureDto measure)
    {
        if (measure.IntegerPart == 0)
        {
            return $"{measure.Numerator}/{measure.Denominator}";
        }

        return measure.Numerator > 0
            ? $"{measure.IntegerPart} {measure.Numerator}/{measure.Denominator}"
            : measure.IntegerPart.ToString();
    }
}