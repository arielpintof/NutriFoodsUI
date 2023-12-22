using System.Net.Http.Json;
using Fluxor;
using Microsoft.AspNetCore.Components;
using NutriFoods_UI.Data.Dto;
using NutriFoods_UI.Services;

namespace NutriFoods_UI.Data.Store.LogIn;

public class Effects(INutritionistService nutritionistService, NavigationManager navigationManager)
{
    
    [EffectMethod]
    public async Task LoadCredentials(LoadCredentialsAction action, IDispatcher dispatcher)
    {
        var response = await nutritionistService.Login(action.Email, action.Password);
        var content = await response!.Content.ReadFromJsonAsync<NutritionistDto>();

        dispatcher.Dispatch(new LoadNutritionistDtoAction(content!));
        
        navigationManager.NavigateTo("/");
    }

    
}