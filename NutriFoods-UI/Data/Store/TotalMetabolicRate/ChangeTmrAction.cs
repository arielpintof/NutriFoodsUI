using NutriFoods_UI.Data.Model;

namespace NutriFoods_UI.Data.Store.TotalMetabolicRate;

public class ChangeTmrAction(TmrConfiguration configuration)
{
    public TmrConfiguration Configuration { get; } = configuration;
}