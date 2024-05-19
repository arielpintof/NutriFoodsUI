using System.Collections.Immutable;

namespace NutriFoods_UI.Data.Images;

public interface IRecipeImage
{
    public IReadOnlyDictionary<string, string>? ImgRecipeDict { get; }

    
    
}
        