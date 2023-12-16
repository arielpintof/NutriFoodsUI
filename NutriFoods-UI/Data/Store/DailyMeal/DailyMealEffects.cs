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

        var nutrientTarget = _mealState.Value.DailyPlan.Menus.ElementAt(action.Index).Targets;

        var targets = nutrientTarget
            .Select(item => new NutritionalTargetDto()
            {
                Nutrient = item.Nutrient,
                ExpectedQuantity = item.ExpectedQuantity,
                ExpectedError = item.ExpectedError,
                Unit = item.Unit,
                ThresholdType = item.ThresholdType,
                IsPriority = item.IsPriority
            })
            .ToList();
        
        var dailyMenu = new DailyMenuDto()
        {
            IntakePercentage = 1,
            MealType = _mealState.Value.DailyPlan.Menus.ElementAt(action.Index).MealType,
            Hour = _mealState.Value.DailyPlan.Menus.ElementAt(action.Index).Hour,
            Nutrients = [],
            Targets = targets,
            Recipes = []
            
        };

        var response = await _dailyMenuService.GenerateMenu(dailyMenu);
        var content = await response.Content.ReadFromJsonAsync<DailyMenuDto>();

        if (content != null)
        {
            dispatcher.Dispatch(new ChangeDailyMealAction(content, action.Index));
        }

        dispatcher.Dispatch(new StopOnLoadingMenuAction());*/
    }

    /*[EffectMethod(typeof(LoadMealPlanAction))]
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
    }*/
    
    [EffectMethod(typeof(LoadMealPlanAction))]
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
            MealConfigurations = meals,
            Targets = []
        };

        var dailyMealPlanResponse = await dailyMealPlanService.DailyPlanByDistribution(planConfiguration);
        var dailyMealPlan = await dailyMealPlanResponse!.Content.ReadFromJsonAsync<DailyPlanDto>();
        

        if (dailyMealPlan != null)
        {
            var action = new InitializeDailyMealAction(dailyMealPlan);
            dispatcher.Dispatch(action);
        }
        
        dispatcher.Dispatch(new StopOnLoadingMenuAction());
    }

    [EffectMethod(typeof(RenewDailyMealPlanAction))]
    public Task RenewMealPlan(IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new LoadMealPlanAction());

        return Task.CompletedTask;
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
    
    public IList<NutritionalTargetDto> Targets { get; set; } = null!;
}

public class MealConfigurationDto
{
    public string MealType { get; set; } = null!;
    public string Hour { get; set; } = null!;
    public double IntakePercentage { get; set; }
}