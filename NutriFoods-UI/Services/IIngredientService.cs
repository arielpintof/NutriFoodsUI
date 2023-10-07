using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Services
{
    public interface IIngredientService
    {
        Task<HttpResponseMessage?> GetAll();
        Task<HttpResponseMessage?> FindByName(string name);
        Task<HttpResponseMessage?> FindById(int id);
        Task<HttpResponseMessage?> FindByPrimaryGroup(string name);
        Task<HttpResponseMessage?> FindByPrimaryGroup(int id);
        Task<HttpResponseMessage?> FindBySecondaryGroup(string name);
        Task<HttpResponseMessage?> FindBySecondaryGroup(int id);
        Task<HttpResponseMessage?> FindByTertiaryGroup(string name);
        Task<HttpResponseMessage?> FindByTertiaryGroup(int id);

    }
}
