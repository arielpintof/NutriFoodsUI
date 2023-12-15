using Fluxor;

namespace NutriFoods_UI.Data.Store.DailyPlanList;

public static class Reducer
{
    [ReducerMethod]
    public static DailyPlanState Initialize(DailyPlanState state, InitializeDailyPlansAction action)
    {
        return new DailyPlanState([]);
    }

    [ReducerMethod]
    public static DailyPlanState AddDailyPlan(DailyPlanState state, AddDailyPlanAction action)
    {
        var actualList = state.DailyPlans;
        actualList.Add(action.DailyPlanDto);

        return new DailyPlanState(actualList);
    }

    [ReducerMethod]
    public static DailyPlanState RemoveDailyPlan(DailyPlanState state, RemoveDailyPlanAction action)
    {
        var actualList = state.DailyPlans;
        actualList.RemoveAt(action.Index);

        return new DailyPlanState(actualList);
    }
}