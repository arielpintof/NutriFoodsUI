using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.HarmfulHabits;

public class InitializeHarmfulHabitAction(List<HarmfulHabitDto> harmfulHabits)
{
    public List<HarmfulHabitDto> HarmfulHabits { get; } = harmfulHabits;
}