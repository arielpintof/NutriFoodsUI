using System.Net.Http.Json;
using Fluxor;
using Microsoft.AspNetCore.Components;
using NutriFoods_UI.Data.Dto;
using NutriFoods_UI.Data.Store.DailyMeal;
using NutriFoods_UI.Data.Store.DailyMenu;
using NutriFoods_UI.Data.Store.MealsConfiguration;
using NutriFoods_UI.Data.Store.TotalMetabolicRate;
using NutriFoods_UI.Services;
using NutriFoods_UI.Utils.Enums;

namespace NutriFoods_UI.Data.Store.DailyMeal;

public class DailyMealEffects(IDailyMenuService dailyMenuService, IDailyMealPlanService dailyMealPlanService,
    IState<DailyMealState> dailyMealstate, IState<TmrState> tmrState,
    IState<MealsConfigurationState> mealsConfigurationState)
{
    private readonly IDailyMenuService _dailyMenuService = dailyMenuService;
    private readonly IDailyMealPlanService _dailyMealPlanService = dailyMealPlanService;
    private readonly IState<DailyMealState> _mealState = dailyMealstate;
    private readonly IState<TmrState> _tmrState = tmrState;
    private readonly IState<MealsConfigurationState> _mealConfigurationState = mealsConfigurationState;


    [EffectMethod]
    public async Task RenewDailyMenu(RenewMenuAction action, IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new OnLoadingMenuAction(action.Index));

        var energyTarget = _mealState.Value.DailyMenu.ElementAt(action.Index).EnergyTotal;
        var mealType = MealTypeEnum.FromReadableName(_mealState.Value.DailyMenu.ElementAt(action.Index).MealType)!
            .Token;
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
        var day = Days.Monday.ReadableName;
        //cambiar a int (enum value) desde el componente
        var physicalActivityLevel = _tmrState.Value.TmrConfiguration.PhysicalActivityLevel;
        var physicalActivityFactor = _tmrState.Value.TmrConfiguration.Multiplier;
        var adjustmentFactor = _tmrState.Value.TmrConfiguration.Factor;
        var energy = _tmrState.Value.GetTmr;
        
        var planConfiguration = new PlanConfiguration()
        {
            
        };

    }

    [EffectMethod(typeof(RenewDailyMealPlanAction))]
    public async Task RenewMealPlan(IDispatcher dispatcher)
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

public class PlanConfiguration
{
    public IDictionary<string, double> Distribution { get; set; } = null!;
    public IList<MealConfiguration> MealConfigurations { get; set; } = null!;
}

public class MealConfiguration
{
    public string MealType { get; set; } = null!;
    public string Hour { get; set; } = null!;
    public double IntakePercentage { get; set; }
}