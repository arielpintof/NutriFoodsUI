﻿using System.Net.Http.Json;
using Fluxor;
using NutriFoods_UI.Data.Dto;
using NutriFoods_UI.Data.Store.DailyMenu;
using NutriFoods_UI.Data.Store.MealsConfiguration;
using NutriFoods_UI.Data.Store.MicronutrientConfiguration;
using NutriFoods_UI.Data.Store.TotalMetabolicRate;
using NutriFoods_UI.Services;

namespace NutriFoods_UI.Data.Store.DailyMeal;

public class DailyMealEffects(
    IDailyMenuService dailyMenuService,
    IDailyMealPlanService dailyMealPlanService,
    IState<DailyMealState> dailyMealState,
    IState<TmrState> tmrState,
    IState<MealsConfigurationState> mealsConfigurationState,
    IState<MoleculaState> moleculaState,
    IState<DaysState> daysState,
    IState<MicronutrientState> micronutrientState)
{
    [EffectMethod]
    public async Task RenewDailyMenu(RenewMenuAction action, IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new OnLoadingMenuAction(action.Index));

        var dailyMenu = new DailyMenuDto()
        {
            IntakePercentage = 1,
            MealType = dailyMealState.Value.DailyPlan.Menus.ElementAt(action.Index).MealType,
            Hour = dailyMealState.Value.DailyPlan.Menus.ElementAt(action.Index).Hour,
            Nutrients = [],
            Targets = dailyMealState.Value.DailyPlan.Menus.ElementAt(action.Index).Targets.ResetActualValues(),
            Recipes = []
        };

        var response = await dailyMenuService.GenerateMenu(dailyMenu);
        var content = await response.Content.ReadFromJsonAsync<DailyMenuDto>();

        if (content != null)
        {
            dispatcher.Dispatch(new ChangeDailyMealAction(content, action.Index));
            
        }
        
        dispatcher.Dispatch(new RecalculateNutrientsAction());
        dispatcher.Dispatch(new StopOnLoadingMenuAction());
    }


    [EffectMethod(typeof(GetDailyPlanAction))]
    public async Task GetMealPlan(IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new OnLoadingPlanAction());

        var physicalActivityLevel = tmrState.Value.TmrConfiguration.PhysicalActivityLevel;
        var physicalActivityFactor = tmrState.Value.TmrConfiguration.Multiplier;
        var adjustmentFactor = tmrState.Value.TmrConfiguration.Factor;
        var basalMetabolicRate = tmrState.Value.GetBmr;
        var mealConfigurations = mealsConfigurationState.Value.Meals;
        var days = daysState.Value.Days;

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
            Days = days,
            BasalMetabolicRate = basalMetabolicRate,
            AdjustmentFactor = adjustmentFactor,
            ActivityLevel = physicalActivityLevel,
            ActivityFactor = physicalActivityFactor,
            Distribution = new Dictionary<string, double>
            {
                { "Carbohidratos, total", moleculaState.Value.CarbTarget * 0.01 },
                { "Proteína, total", moleculaState.Value.ProteinTarget * 0.01 },
                { "Ácidos grasos, total", moleculaState.Value.LipidTarget * 0.01 }
            },
            MealConfigurations = meals,
            Targets = micronutrientState.Value.Micronutrients.ToList()
        };

        var dailyMealPlanResponse = await dailyMealPlanService.DailyPlanByDistribution(planConfiguration);
        var dailyMealPlan = await dailyMealPlanResponse!.Content.ReadFromJsonAsync<DailyPlanDto>();


        if (dailyMealPlan != null)
        {
            var action = new InitializeDailyPlanAction(dailyMealPlan);
            dispatcher.Dispatch(action);
        }

        dispatcher.Dispatch(new StopOnLoadingMenuAction());
    }

    [EffectMethod(typeof(RenewDailyPlanAction))]
    public Task RenewMealPlan(IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new GetDailyPlanAction());

        return Task.CompletedTask;
    }

    [EffectMethod(typeof(RecalculateNutrientsAction))]
    public async Task Recalculate(IDispatcher dispatcher)
    {
        var dailyPlan = dailyMealState.Value.DailyPlan;
        await dailyPlan.AddTargetValues();
        
        dispatcher.Dispatch(new InitializeDailyPlanAction(dailyPlan));
        
    }
}

public class PlanConfiguration
{
    public List<string> Days { get; set; } = null!;
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