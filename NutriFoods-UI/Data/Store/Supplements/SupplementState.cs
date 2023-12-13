using Fluxor;
using NutriFoods_UI.Data.Dto;
using NutriFoods_UI.Data.Model;

namespace NutriFoods_UI.Data.Store.Supplements;

[FeatureState]
public class SupplementState
{
    public bool Initialized { get; }
    public IEnumerable<IngestibleDto> Supplements { get; } = new List<IngestibleDto>();
    public bool StateIsValid { get; }

    public SupplementState(){}

    public SupplementState(IEnumerable<IngestibleDto> supplements, bool initialized = true , bool stateIsValid = true)
    {
        Initialized = initialized;
        Supplements = supplements;
        StateIsValid = stateIsValid;
    }
}