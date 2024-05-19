using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.AdverseFoodReactions;

public class InitializeFoodReactionsAction(List<AdverseFoodReactionDto> adverseFoodReactions)
{
    public List<AdverseFoodReactionDto> AdverseFoodReactions { get; } = adverseFoodReactions;
}