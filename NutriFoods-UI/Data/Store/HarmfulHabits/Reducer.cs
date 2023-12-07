using Fluxor;

namespace NutriFoods_UI.Data.Store.HarmfulHabits;

public static class HarmfulHabitReducer
{
    [ReducerMethod]
    public static HarmfulHabitState AddHarmfulHabit(HarmfulHabitState state, AddHarmfulHabitAction action)
    {
        var updatedList = state.HarmfulHabits.ToList();
        updatedList.Add(action.HarmfulHabit);

        return new HarmfulHabitState(updatedList);
    }

    [ReducerMethod]
    public static HarmfulHabitState ChangeHarmfulHabit(HarmfulHabitState state, ChangeHarmfulHabitAction action)
    {
        var updatedList = state.HarmfulHabits.ToList();
        updatedList[action.Index] = action.HarmfulHabit;

        return new HarmfulHabitState(updatedList);
    }

    [ReducerMethod]
    public static HarmfulHabitState DeleteHarmfulHabit(HarmfulHabitState state, DeleteHarmfulHabitAction action)
    {
        var updatedList = state.HarmfulHabits.ToList();
        updatedList.RemoveAt(action.Index);

        return new HarmfulHabitState(updatedList);
    }
}
