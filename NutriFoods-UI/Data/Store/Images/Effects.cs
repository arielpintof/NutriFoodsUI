using System.Net.Http.Json;
using Fluxor;
using NutriFoods_UI.Data.Images;

namespace NutriFoods_UI.Data.Store.Images;

public class Effects (HttpClient client)
{

    [EffectMethod(typeof(LoadJsonAction))]
    public async Task LoadJson(IDispatcher dispatcher)
    {
        var json = await client.GetFromJsonAsync<List<ImageRecipe>>("http://localhost:5170/sample-data/images.json");
        var map = RecipeImage.MapToDict(json);
        
        dispatcher.Dispatch(new InitializeDictionaryAction(map));
    }
}