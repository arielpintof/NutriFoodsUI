using Fluxor;
using NutriFoods_UI.Data.Dto;
using NutriFoods_UI.Data.Model;

namespace NutriFoods_UI.Data.Store.Vitamins;

[FeatureState]
public class VitaminState
{
    public bool Initialized { get; }
    public IEnumerable<IngestibleDto> Vitamins { get; } = new List<IngestibleDto>();
    public bool StateIsValid { get; }

    public VitaminState(){}

    public VitaminState(IEnumerable<IngestibleDto> vitamins, bool initialized = true , bool stateIsValid = true)
    {
        Initialized = initialized;
        Vitamins = vitamins;
        StateIsValid = stateIsValid;
    }
}