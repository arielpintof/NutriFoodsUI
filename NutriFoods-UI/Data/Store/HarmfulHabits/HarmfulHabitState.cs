using Fluxor;
using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.HarmfulHabits;


[FeatureState]
public class HarmfulHabitState
{
    public List<HarmfulHabitDto> HarmfulHabits { get; } = new();
    public bool IsValid { get; }

    public HarmfulHabitState() { }

    public HarmfulHabitState(List<HarmfulHabitDto> harmfulHabits, bool isValid = false)
    {
        HarmfulHabits = harmfulHabits;
        IsValid = isValid;
    }
}
