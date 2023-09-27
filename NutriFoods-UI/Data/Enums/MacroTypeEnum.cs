using System.Collections.Immutable;
using Ardalis.SmartEnum;

namespace NutriFoods_UI.Data.Enums;

public class MacroTypeEnum : SmartEnum<MacroTypeEnum>
{
    public static readonly MacroTypeEnum Protein =
        new(nameof(Protein), (int) MacroType.Protein, MacroType.Protein, "Proteínas");
    public static readonly MacroTypeEnum Carb =
        new(nameof(Carb), (int) MacroType.Carb, MacroType.Carb, "Carbohidratos");
    public static readonly MacroTypeEnum Lipid =
        new(nameof(Lipid), (int) MacroType.Lipid, MacroType.Lipid, "Lipidos");
    public static readonly MacroTypeEnum Energy =
        new(nameof(Energy), (int) MacroType.Energy, MacroType.Energy, "Energía");
    
    private static readonly IDictionary<MacroType, MacroTypeEnum> TokenDictionary =
        new Dictionary<MacroType, MacroTypeEnum>
        {
            {MacroType.Protein, Protein},
            {MacroType.Carb, Carb},
            {MacroType.Lipid, Lipid},
            {MacroType.Energy, Energy}
        }.ToImmutableDictionary();
    
    private static readonly IDictionary<string, MacroTypeEnum> ReadableNameDictionary = TokenDictionary
        .ToImmutableDictionary(e => e.Value.ReadableName, e => e.Value, StringComparer.InvariantCultureIgnoreCase);
    
    public static IReadOnlyCollection<MacroTypeEnum> Values { get; } =
        TokenDictionary.Values.OrderBy(e => e.Value).ToList();

    public static IReadOnlyCollection<MacroTypeEnum> NonNullValues { get; } =
        TokenDictionary.Values.OrderBy(e => e.Value).Skip(1).ToList();

    public MacroTypeEnum(string name, int value, MacroType token, string readableName) : base(name, value)
    {
        Token = token;
        ReadableName = readableName;
    }
    
    public MacroType Token { get; }
    public string ReadableName { get; }

    public static MacroTypeEnum? FromReadableName(string name) =>
        ReadableNameDictionary.ContainsKey(name) ? ReadableNameDictionary[name] : null;

    public static MacroTypeEnum FromToken(MacroType token) => TokenDictionary[token];
}

public enum MacroType
{
    Protein = 1,
    Carb = 2,
    Lipid = 3,
    Energy = 4
}
