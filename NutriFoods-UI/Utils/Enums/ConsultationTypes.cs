using Ardalis.SmartEnum;

namespace NutriFoods_UI.Utils.Enums;

public class ConsultationTypes : SmartEnum<ConsultationTypes>, IEnum<ConsultationTypes, ConsultationTypeToken>
{
    public static readonly ConsultationTypes None =
        new(nameof(None), (int)ConsultationTypeToken.None, string.Empty);

    public static readonly ConsultationTypes Evaluation =
        new(nameof(Evaluation), (int)ConsultationTypeToken.Evaluation, "Evaluación nutricional");

    public static readonly ConsultationTypes Control =
        new(nameof(Control), (int)ConsultationTypeToken.Control, "Seguimiento nutricional");

    private ConsultationTypes(string name, int value, string readableName) : base(name, value) => ReadableName = readableName;

    public string ReadableName { get; }
}

public enum ConsultationTypeToken
{
    None,
    Evaluation,
    Control
}