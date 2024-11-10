using Collector.Client.Components;
using Collector.Client;
using MudBlazor.Services;
using Collector.Client.Utilities.Options;
using Collector.Client.Utilities.Extensions;
using Collector.Client.Services.Login;

var builder = WebApplication.CreateBuilder(args);

//Configuracion de propiedades para las propiedades de configuracion
//Estas propiedades se definen en el launchSetting. Aunque se le puede asignar un valor por defecto.
builder.Services.Configure<AppOptions>(builder.Configuration.GetSection(nameof(AppOptions)));

// Add services to the container.
builder.Services.AddTransient<HttpClientServiceExtensions>();
builder.Services.AddMudServices();
builder.Services.AddWebDependencies();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();











