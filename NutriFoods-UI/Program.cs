using System.Reflection;
using Fluxor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using NutriFoods_UI;
using MudBlazor.Services;
using MudExtensions.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NutriFoods_UI.Data.Dto;
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

builder.Services
    .AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
    
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly()); 

builder.Services
    .AddSingleton<RecipeService>()
    .AddSingleton<PatientService>()
    .AddSingleton<IngredientService>()
    .AddSingleton<MealPlanService>()
    .AddSingleton<NutritionistService>()
    .AddSingleton<DailyMenuService>()
    .AddSingleton<DailyMealPlanService>();


builder.Services.AddSingleton(new JsonSerializerSettings()
{
    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
    ContractResolver = new CamelCasePropertyNamesContractResolver(),
    Formatting = Formatting.Indented
});

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
builder.Services.AddHttpClient<IPatientService, PatientService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7212/");
});
builder.Services.AddHttpClient<INutritionistService, NutritionistService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7212/");
});

    

await builder.Build().RunAsync();



