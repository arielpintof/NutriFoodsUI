using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.AdverseFoodReactions;

public class AddAdverseFoodReactionAction(AdverseFoodReactionDto adverseFoodReaction)
{
    public AdverseFoodReactionDto AdverseFoodReaction { get; } = adverseFoodReaction;
   
}