using Fluxor;
namespace NutriFoods_UI.Data.Store.AdverseFoodReactions;

public class Reducer
{
    [ReducerMethod]
    public static AdverseFoodReactionState AddAdverseFoodReaction(AdverseFoodReactionState state, 
        AddAdverseFoodReactionAction action)
    {
        var updateList = state.AdverseFoodReactions;
        updateList.Add(action.AdverseFoodReaction);
        
        return new AdverseFoodReactionState(updateList);
    }

    [ReducerMethod]
    public static AdverseFoodReactionState ChangeAdverseFoodReaction(AdverseFoodReactionState state, 
        ChangeAdverseFoodReactionAction action)
    {
        var updateList = state.AdverseFoodReactions;
        updateList[action.Index] = action.AdverseFoodReaction;

        return new AdverseFoodReactionState(updateList);
    }
    
    [ReducerMethod]
    public static AdverseFoodReactionState DeleteAdverseFoodReaction(AdverseFoodReactionState state, 
        DeleteAdverseFoodReactionAction action)
    {
        var updateList = state.AdverseFoodReactions;
        updateList.RemoveAt(action.Index);

        return new AdverseFoodReactionState(updateList);
    }
}