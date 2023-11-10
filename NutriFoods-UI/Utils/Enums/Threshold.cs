using Ardalis.SmartEnum;

namespace NutriFoods_UI.Utils.Enums;

public class Threshold : SmartEnum<Threshold>, IEnum<Threshold, ThresholdToken>
{
    public static readonly Threshold None =
        new(nameof(None), (int)ThresholdToken.None, string.Empty);

    public static readonly Threshold AtLeast =
        new(nameof(AtLeast), (int)ThresholdToken.AtLeast, "A lo menos");

    public static readonly Threshold Any =
        new(nameof(Any), (int)ThresholdToken.Any, "Cualquiera");

    public static readonly Threshold AtMost =
        new(nameof(AtMost), (int)ThresholdToken.AtMost, "A lo más");

    private Threshold(string name, int value, string readableName) : base(name, value) =>
        ReadableName = readableName;

    public string ReadableName { get; }
}

public enum ThresholdToken
{
    None = 0,
    AtLeast  = 1,
    Any  = 2,
    AtMost  = 3
}