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
    IState<MealsConfigurationState> mealsConfigurationState, IState<MoleculaState> moleculaState)
{
    private readonly IState<MoleculaState> _moleculaState = moleculaState;
    private readonly IDailyMenuService _dailyMenuService = dailyMenuService;
    private readonly IDailyMealPlanService _dailyMealPlanService = dailyMealPlanService;
    private readonly IState<DailyMealState> _mealState = dailyMealstate;
    private readonly IState<TmrState> _tmrState = tmrState;
    private readonly IState<MealsConfigurationState> _mealConfigurationState = mealsConfigurationState;
    


    [EffectMethod]
    public async Task RenewDailyMenu(RenewMenuAction action, IDispatcher dispatcher)
    {
        /*dispatcher.Dispatch(new OnLoadingMenuAction(action.Index));

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

        dispatcher.Dispatch(new StopOnLoadingMenuAction());*/
    }

    [EffectMethod(typeof(LoadMealPlanAction))]
    public async Task GetMealPlan(IDispatcher dispatcher)
    {
        var day = Days.Monday.Value;
        var physicalActivityLevel = _tmrState.Value.TmrConfiguration.PhysicalActivityLevel;
        var physicalActivityFactor = _tmrState.Value.TmrConfiguration.Multiplier;
        var adjustmentFactor = _tmrState.Value.TmrConfiguration.Factor;
        var basalMetabolicRate = _tmrState.Value.GetBmr;
        var energy = _tmrState.Value.GetTmr;
        var mealConfigurations = _mealConfigurationState.Value.Meals;
        
        IList<MealConfigurationDto> meals = mealConfigurations
            .Select(mc => new MealConfigurationDto
            {
                MealType = mc.MealType.ReadableName,
                Hour = mc.MealTime.ToString(),
                IntakePercentage = (double)mc.Percentage!
            })
            .ToList();
        
        var planConfiguration = new PlanConfiguration
        {
            Distribution = _moleculaState.Value.Distribution(energy),
            MealConfigurations = meals
        };

        var dailyMealPlanResponse = await _dailyMealPlanService.GenerateDailyMealPlan(
            day, basalMetabolicRate, physicalActivityLevel, physicalActivityFactor, planConfiguration,
            adjustmentFactor);
        
        var dailyMealPlan = await dailyMealPlanResponse!.Content.ReadFromJsonAsync<DailyPlanDto>();
        
        if (dailyMealPlan != null)
        {
            var action = new InitializeDailyMealAction(dailyMealPlan.Menus);
            dispatcher.Dispatch(action);
        }
        
        dispatcher.Dispatch(new StopOnLoadingMenuAction());
    }

    [EffectMethod(typeof(RenewDailyMealPlanAction))]
    public async Task RenewMealPlan(IDispatcher dispatcher)
    {
        var day = Days.Monday.Value;
        var physicalActivityLevel = _tmrState.Value.TmrConfiguration.PhysicalActivityLevel;
        var physicalActivityFactor = _tmrState.Value.TmrConfiguration.Multiplier;
        var adjustmentFactor = _tmrState.Value.TmrConfiguration.Factor;
        var basalMetabolicRate = _tmrState.Value.GetBmr;
        var energy = _tmrState.Value.GetTmr;
        var mealConfigurations = _mealConfigurationState.Value.Meals;
        
        IList<MealConfigurationDto> meals = mealConfigurations
            .Select(mc => new MealConfigurationDto
            {
                MealType = mc.MealType.ReadableName,
                Hour = mc.MealTime.ToString(),
                IntakePercentage = (double)mc.Percentage!
            })
            .ToList();
        
        var planConfiguration = new PlanConfiguration
        {
            Distribution = _moleculaState.Value.Distribution(energy),
            MealConfigurations = meals
        };

        var dailyMealPlanResponse = await _dailyMealPlanService.GenerateDailyMealPlan(
            day, basalMetabolicRate, physicalActivityLevel, physicalActivityFactor, planConfiguration,
            adjustmentFactor);
        
        var dailyMealPlan = await dailyMealPlanResponse!.Content.ReadFromJsonAsync<DailyPlanDto>();
        
        if (dailyMealPlan != null)
        {
            var action = new InitializeDailyMealAction(dailyMealPlan.Menus);
            dispatcher.Dispatch(action);
        }
        
        dispatcher.Dispatch(new StopOnLoadingMenuAction());
    }
}

public class PlanConfiguration
{
    public IDictionary<string, double> Distribution { get; set; } = null!;
    public IList<MealConfigurationDto> MealConfigurations { get; set; } = null!;
}

public class MealConfigurationDto
{
    public string MealType { get; set; } = null!;
    public string Hour { get; set; } = null!;
    public double IntakePercentage { get; set; }
}