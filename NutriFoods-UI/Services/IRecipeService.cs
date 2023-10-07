using NutriFoods_UI.Data.Dto;
using System.Net.Http;

namespace NutriFoods_UI.Services
{
    public interface IRecipeService
    {
        Task<HttpResponseMessage?> FindAll();

        Task<HttpResponseMessage?> FindByName(string name);

        Task<HttpResponseMessage?> FindById(int id);

        Task<HttpResponseMessage?> GetVegetarianRecipes();

        Task<HttpResponseMessage?> GetOvoVegetarianRecipes();

        Task<HttpResponseMessage?> GetOvoLactoVegetarianRecipes();

        Task<HttpResponseMessage?> GetLactoVegetarianRecipes();

        Task<HttpResponseMessage?> GetPollotarianRecipes();

        Task<HttpResponseMessage?> GetPescetarianRecipes();

        Task<HttpResponseMessage?> GetPolloPescetarianRecipes();

        Task<HttpResponseMessage?> FilterByPreparationTime(int lowerBound, int upperBound);

        Task<HttpResponseMessage?> FilterByPortions(int portions);

        Task<HttpResponseMessage?> FilterByPortions(int lowerBound, int upperBound);

        Task<HttpResponseMessage?> FilterByEnergy(int lowerBound, int upperBound);

        Task<HttpResponseMessage?> FilterByCarbohydrates(int lowerBound, int upperBound);

        Task<HttpResponseMessage?> FilterByLipids(int lowerBound, int upperBound);

        Task<HttpResponseMessage?> FilterByProteins(int lowerBound, int upperBound);

    }
}
