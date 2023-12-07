using Fluxor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using NutriFoods_UI;
using MudBlazor.Services;
using MudExtensions.Services;
using NutriFoods_UI.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var currentAssembly = typeof(Program).Assembly;
builder.Services.AddFluxor(options => options.ScanAssemblies(currentAssembly));
builder.Services.AddMudServices();
builder.Services.AddMudExtensions();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7212/") });
builder.Services.AddSingleton<IngredientService>();
builder.Services.AddSingleton<MealPlanService>();
builder.Services.AddSingleton<RecipeService>();
builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<DailyMenuService>();
builder.Services.AddSingleton<DailyMealPlanService>();
builder.Services.AddHttpClient<IIngredientService, IngredientService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7212/");
});
builder.Services.AddHttpClient<IMealPlanService, MealPlanService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7212/");
});
builder.Services.AddHttpClient<IRecipeService, RecipeService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7212/");
});
builder.Services.AddHttpClient<IDailyMenuService, DailyMenuService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7212/");
});
builder.Services.AddHttpClient<IDailyMealPlanService, DailyMealPlanService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7212/");
});

await builder.Build().RunAsync();



