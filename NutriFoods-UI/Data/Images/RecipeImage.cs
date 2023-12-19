using System.Collections.Immutable;
using System.Net.Http.Json;

namespace NutriFoods_UI.Data.Images;

public static class RecipeImage
{
    public static IReadOnlyDictionary<string, string> MapToDict(IEnumerable<ImageRecipe>? recipes)
    {
        
        var uniqueRecipes = recipes?.GroupBy(recipe => recipe.Name)
            .Select(group => group.First())
            .ToList();

        
        var recipeDictionary = uniqueRecipes?.ToDictionary(recipe => recipe.Name, recipe => recipe.Image)
                               ?? new Dictionary<string, string>();

        return recipeDictionary;
    }
}

public class ImageRecipe
{
    public string Name { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
}