using Microsoft.AspNetCore.Components;

namespace NutriFoods_UI.Data.Model;

public class CollapseItemModel
{
    public string Title { get; init; } = string.Empty;
    public RenderFragment? ChildContent { get; set; }
}