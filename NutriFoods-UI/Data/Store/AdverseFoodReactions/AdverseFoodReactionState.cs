using Fluxor;
using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.AdverseFoodReactions;


[FeatureState]
public class AdverseFoodReactionState
{
    public List<AdverseFoodReactionDto> AdverseFoodReactions { get; } = new();
    public bool IsValid { get; }

    public AdverseFoodReactionState(List<AdverseFoodReactionDto> adverseFoodReactions, bool isValid = false)
    {
        AdverseFoodReactions = adverseFoodReactions;
        IsValid = isValid;
    }
    
    public AdverseFoodReactionState(){}
}