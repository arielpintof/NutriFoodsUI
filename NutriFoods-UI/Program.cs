using Fluxor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using NutriFoods_UI;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var currentAssembly = typeof(Program).Assembly;
builder.Services.AddFluxor(options => options.ScanAssemblies(currentAssembly));
builder.Services.AddMudServices();
builder.Services.AddBlazorBootstrap(); 
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();



