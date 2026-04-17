using lapushki_blazor;
using lapushki_blazor.ApiRequests.Models;
using lapushki_blazor.ApiRequests.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<AppointmentRequests>();
builder.Services.AddScoped<PetRequests>();
builder.Services.AddScoped<UserRequests>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5276") });
builder.Services.AddSingleton<UserService>();

await builder.Build().RunAsync();
