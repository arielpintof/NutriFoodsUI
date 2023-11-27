using System.Collections.Immutable;
using Ardalis.SmartEnum;
namespace NutriFoods_UI.Components.Anamnesis.ClinicalHistory;

public class ModeTypeEnum : SmartEnum<ModeTypeEnum>
{
    public static readonly ModeTypeEnum Edit =
        new(nameof(Edit), (int) ModeType.Edit, ModeType.Edit, "Editar");
    public static readonly ModeTypeEnum Add =
        new(nameof(Add), (int) ModeType.Add, ModeType.Add, "Añadir");
    
    
    private static readonly IDictionary<ModeType, ModeTypeEnum> TokenDictionary =
        new Dictionary<ModeType, ModeTypeEnum>
        {
            {ModeType.Edit, Edit},
            {ModeType.Add, Add}
        }.ToImmutableDictionary();
    
    private static readonly IDictionary<string, ModeTypeEnum> ReadableNameDictionary = TokenDictionary
        .ToImmutableDictionary(e => e.Value.ReadableName, e => e.Value, StringComparer.InvariantCultureIgnoreCase);
    
    public static IReadOnlyCollection<ModeTypeEnum> Values { get; } =
        TokenDictionary.Values.OrderBy(e => e.Value).ToList();

    public static IReadOnlyCollection<ModeTypeEnum> NonNullValues { get; } =
        TokenDictionary.Values.OrderBy(e => e.Value).Skip(1).ToList();

    public ModeTypeEnum(string name, int value, ModeType token, string readableName) : base(name, value)
    {
        Token = token;
        ReadableName = readableName;
    }
    
    public ModeType Token { get; }
    public string ReadableName { get; }

    public static ModeTypeEnum? FromReadableName(string name) =>
        ReadableNameDictionary.ContainsKey(name) ? ReadableNameDictionary[name] : null;

    public static ModeTypeEnum FromToken(ModeType token) => TokenDictionary[token];
}

public enum ModeType
{
    Edit = 1,
    Add = 2
}