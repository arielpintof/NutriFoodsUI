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

public class DailyMealEffects(
    IDailyMenuService dailyMenuService,
    IDailyMealPlanService dailyMealPlanService,
    IState<DailyMealState> dailyMealstate,
    IState<TmrState> tmrState,
    IState<MealsConfigurationState> mealsConfigurationState,
    IState<MoleculaState> moleculaState)
{
    private readonly IDailyMenuService _dailyMenuService = dailyMenuService;
    private readonly IState<DailyMealState> _mealState = dailyMealstate;


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
        
        var client = new HttpClient();
        var dailyMealPlan = await client.GetFromJsonAsync<DailyPlanDto>("http://localhost:5170/sample-data/dailymeal.json");

        if (dailyMealPlan != null)
        {
            var action = new InitializeDailyMealAction(dailyMealPlan);
            dispatcher.Dispatch(action);
        }
        
        dispatcher.Dispatch(new StopOnLoadingMenuAction());
    }
    
    /*[EffectMethod(typeof(LoadMealPlanAction))]
    public async Task GetMealPlan(IDispatcher dispatcher)
    {
        var physicalActivityLevel = tmrState.Value.TmrConfiguration.PhysicalActivityLevel;
        var physicalActivityFactor = tmrState.Value.TmrConfiguration.Multiplier;
        var adjustmentFactor = tmrState.Value.TmrConfiguration.Factor;
        var basalMetabolicRate = tmrState.Value.GetBmr;
        //var energy = tmrState.Value.GetTmr;
        var mealConfigurations = mealsConfigurationState.Value.Meals;

        var meals = mealConfigurations
            .Select(mc => new MealConfigurationDto
            {
                MealType = mc.MealType.ReadableName,
                Hour = "08:00",
                IntakePercentage = mc.Percentage * 0.01
            })
            .ToList();
        
        var planConfiguration = new PlanConfiguration
        {
            Day = Days.Monday.ReadableName,
            BasalMetabolicRate = basalMetabolicRate,
            AdjustmentFactor = adjustmentFactor,
            ActivityLevel = physicalActivityLevel,
            ActivityFactor = physicalActivityFactor,
            Distribution = new Dictionary<string, double>()
            {
                { "Carbohidratos, total", moleculaState.Value.CarbTarget * 0.01  },
                { "Proteína, total", moleculaState.Value.ProteinTarget * 0.01 },
                { "Ácidos grasos, total", moleculaState.Value.LipidTarget  * 0.01}
            },
            MealConfigurations = meals
        };

        var dailyMealPlanResponse = await dailyMealPlanService.DailyPlanByDistribution(planConfiguration);
        var dailyMealPlan = await dailyMealPlanResponse!.Content.ReadFromJsonAsync<DailyPlanDto>();
        

        if (dailyMealPlan != null)
        {
            var action = new InitializeDailyMealAction(dailyMealPlan);
            dispatcher.Dispatch(action);
        }
        
        dispatcher.Dispatch(new StopOnLoadingMenuAction());
    }*/

    [EffectMethod(typeof(RenewDailyMealPlanAction))]
    public async Task RenewMealPlan(IDispatcher dispatcher)
    {
        /*var day = Days.Monday.Value;
        var physicalActivityLevel = tmrState.Value.TmrConfiguration.PhysicalActivityLevel;
        var physicalActivityFactor = tmrState.Value.TmrConfiguration.Multiplier;
        var adjustmentFactor = tmrState.Value.TmrConfiguration.Factor;
        var basalMetabolicRate = tmrState.Value.GetBmr;
        var energy = tmrState.Value.GetTmr;
        var mealConfigurations = mealsConfigurationState.Value.Meals;

        IList<MealConfigurationDto> meals = mealConfigurations
            .Select(mc => new MealConfigurationDto
            {
                MealType = mc.MealType.ReadableName,
                Hour = mc.MealTime.ToString()!,
                IntakePercentage = mc.Percentage
            })
            .ToList();

        var planConfiguration = new PlanConfiguration
        {
            Distribution = moleculaState.Value.GetDistribution(energy),
            MealConfigurations = meals
        };

        var dailyMealPlanResponse = await dailyMealPlanService.GenerateDailyMealPlan(
            day, basalMetabolicRate, physicalActivityLevel, physicalActivityFactor, planConfiguration,
            adjustmentFactor);

        var dailyMealPlan = await dailyMealPlanResponse!.Content.ReadFromJsonAsync<DailyPlanDto>();

        if (dailyMealPlan != null)
        {
            var action = new InitializeDailyMealAction(dailyMealPlan.Menus);
            dispatcher.Dispatch(action);
        }

        dispatcher.Dispatch(new StopOnLoadingMenuAction());*/
    }
}

public class PlanConfiguration
{
    public string Day { get; set; } = null!;
    public double BasalMetabolicRate { get; set; }
    public double AdjustmentFactor { get; set; }
    public string ActivityLevel { get; set; } = null!;
    public double ActivityFactor { get; set; }
    public IDictionary<string, double> Distribution { get; set; } = null!;
    public IList<MealConfigurationDto> MealConfigurations { get; set; } = null!;
}

public class MealConfigurationDto
{
    public string MealType { get; set; } = null!;
    public string Hour { get; set; } = null!;
    public double IntakePercentage { get; set; }
}