using System.Collections.Immutable;
using Ardalis.SmartEnum;

namespace NutriFoods_UI.Utils.Enums;

public class UnitEnum : SmartEnum<UnitEnum>
{
    public static readonly UnitEnum None =
        new(nameof(None), (int) Unit.None, Unit.None, string.Empty);

    public static readonly UnitEnum Grams =
        new(nameof(Grams), (int) Unit.Grams, Unit.Grams, "g");

    public static readonly UnitEnum Milligrams =
        new(nameof(Milligrams), (int) Unit.Milligrams, Unit.Milligrams, "mg");

    public static readonly UnitEnum Micrograms =
        new(nameof(Micrograms), (int) Unit.Micrograms, Unit.Micrograms, "µg");

    public static readonly UnitEnum KiloCalories =
        new(nameof(KiloCalories), (int) Unit.KiloCalories, Unit.KiloCalories, "KCal");

    private static readonly IDictionary<Unit, UnitEnum> TokenDictionary =
        new Dictionary<Unit, UnitEnum>
        {
            {Unit.None, None},
            {Unit.Grams, Grams},
            {Unit.Milligrams, Milligrams},
            {Unit.Micrograms, Micrograms},
            {Unit.KiloCalories, KiloCalories}
        }.ToImmutableDictionary();

    private static readonly IDictionary<string, UnitEnum> ReadableNameDictionary = TokenDictionary
        .ToImmutableDictionary(e => e.Value.ReadableName, e => e.Value, StringComparer.InvariantCultureIgnoreCase);

    public static IReadOnlyCollection<UnitEnum> Values { get; } =
        TokenDictionary.Values.OrderBy(e => e.Value).ToList();

    public static IReadOnlyCollection<UnitEnum> NonNullValues { get; } =
        TokenDictionary.Values.OrderBy(e => e.Value).Skip(1).ToList();
    
    public UnitEnum(string name, int value, Unit token, string readableName) : base(name, value)
    {
        Token = token;
        ReadableName = readableName;
    }

    public Unit Token { get; }
    public string ReadableName { get; }

    public static UnitEnum? FromReadableName(string name) =>
        ReadableNameDictionary.ContainsKey(name) ? ReadableNameDictionary[name] : null;

    public static UnitEnum FromToken(Unit token) => TokenDictionary[token];
}

public enum Unit
{
    None = 0,
    Grams = 1,
    Milligrams = 2,
    Micrograms = 3,
    KiloCalories = 4
}