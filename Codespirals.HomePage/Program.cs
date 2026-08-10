using Codespirals.HomePage;
using Codespirals.Solutions.ApiCaller;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IContentService, ContentService>();
builder.Services.AddApiCallerFactory();
builder.Services.AddScoped<IGitHubService, GitHubService>();

await builder.Build().RunAsync();
