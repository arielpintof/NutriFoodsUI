using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.HarmfulHabits;

public class AddHarmfulHabitAction(HarmfulHabitDto harmfulHabit)
{
    public HarmfulHabitDto HarmfulHabit { get; } = harmfulHabit;
}