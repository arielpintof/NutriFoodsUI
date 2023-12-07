using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.AdverseFoodReactions;

public class ChangeAdverseFoodReactionAction(AdverseFoodReactionDto adverseFoodReaction, int index)
{
    public AdverseFoodReactionDto AdverseFoodReaction { get; } = adverseFoodReaction;
    public int Index { get; } = index;
}