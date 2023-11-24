using System.Net.Http.Json;
using Fluxor;
using Microsoft.AspNetCore.Components;
using NutriFoods_UI.Data.Dto;
using NutriFoods_UI.Data.Store.DailyMeal;
using NutriFoods_UI.Data.Store.DailyMenu;
using NutriFoods_UI.Services;
using NutriFoods_UI.Utils.Enums;

namespace NutriFoods_UI.Data.Store.DailyMeal;

public class DailyMealEffects
{
    private readonly IDailyMenuService _dailyMenuService;
    private readonly IDailyMealPlanService _dailyMealPlanService;
    private readonly IState<DailyMealState> _mealState;
    

    public DailyMealEffects(IDailyMenuService dailyMenuService, IDailyMealPlanService dailyMealPlanService, IState<DailyMealState> state)
    {
        _dailyMenuService = dailyMenuService;
        _dailyMealPlanService = dailyMealPlanService;
        _mealState = state;
    }
    
    [EffectMethod]
    public async Task RenewDailyMenu(RenewMenuAction action, IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new OnLoadingMenuAction(action.Index));
        
        var energyTarget = _mealState.Value.DailyMenu.ElementAt(action.Index).EnergyTotal;
        var mealType = MealTypeEnum.FromReadableName(_mealState.Value.DailyMenu.ElementAt(action.Index).MealType)!.Token;
        var satiety = SatietyEnum.FromReadableName(_mealState.Value.DailyMenu.ElementAt(action.Index).Satiety)!.Token;
        var dailyMenuResponse = await _dailyMenuService.GenerateDailyMenu(energyTarget, mealType, satiety);
        var dailyMenuContent = await dailyMenuResponse!.Content.ReadFromJsonAsync<DailyMenuDto?>();

        if (dailyMenuContent != null)
        {
            dispatcher.Dispatch(new ChangeDailyMealAction(dailyMenuContent, action.Index));
        }
        
        dispatcher.Dispatch(new StopOnLoadingMenuAction());
    }

    [EffectMethod(typeof(LoadMealPlanAction))]
    public async Task GetMealPlan(IDispatcher dispatcher)
    {
        var mealPlanResponse = await _dailyMealPlanService.GenerateDailyMealPlan(
            energyTarget: 2000,
            isLunchFilling: true,
            breakfast: Satiety.Normal,
            dinner: Satiety.Normal,
            includeBrunch: false,
            includeLinner: false);

        var dailyMealPlan = await mealPlanResponse!.Content.ReadFromJsonAsync<DailyMealPlanDto>();

        if (dailyMealPlan != null)
        {
            var action = new InitializeDailyMealAction(dailyMealPlan!.DailyMenus);
            dispatcher.Dispatch(action);
        }
    }
    
    [EffectMethod(typeof(RenewDailyMealPlanAction))]
    public async Task RenewMealPlan( IDispatcher dispatcher)
    {

        var mealPlanResponse = await _dailyMealPlanService.GenerateDailyMealPlan(
            energyTarget: 2000,
            isLunchFilling: true,
            breakfast: Satiety.Normal,
            dinner: Satiety.Normal,
            includeBrunch: false,
            includeLinner: false
            );

        var dailyMealPlan = await mealPlanResponse!.Content.ReadFromJsonAsync<DailyMealPlanDto>();

        if (dailyMealPlan != null)
        {
            var action = new InitializeDailyMealAction(dailyMealPlan.DailyMenus);
            dispatcher.Dispatch(action);
        }
        
        dispatcher.Dispatch(new StopOnLoadingMenuAction());
    }
    
    
}