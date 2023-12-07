using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.HarmfulHabits;

public class ChangeHarmfulHabitAction(HarmfulHabitDto harmfulHabit, int index)
{
    public HarmfulHabitDto HarmfulHabit { get; } = harmfulHabit;
    public int Index { get; } = index;
}