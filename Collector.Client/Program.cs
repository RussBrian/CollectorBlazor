using Collector.Client;
using MudBlazor.Services;
using Collector.Client.Utilities.Options;
using Collector.Client.Utilities.Extensions;
using Collector.Client.Helpers;
using Collector.Client.Services;


var builder = WebApplication.CreateBuilder(args);

//Configuracion de propiedades para las propiedades de configuracion
//Estas propiedades se definen en el launchSetting. Aunque se le puede asignar un valor por defecto.
builder.Services.Configure<AppOptions>(builder.Configuration.GetSection(nameof(AppOptions)));

// Add services to the container.
builder.Services.AddTransient<HttpClientServiceExtensions>();
builder.Services.AddMudServices();
builder.Services.AddScoped<SweetAlert>();
builder.Services.AddWebDependencies();
builder.Services.AddServerSideBlazor()
    .AddCircuitOptions(options => { options.DetailedErrors = true; });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();











