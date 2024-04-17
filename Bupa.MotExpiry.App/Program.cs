using Bupa.MotExpiry.App.Clients;
using Bupa.MotExpiry.App.Services;
using System.Text.Json;

namespace Bupa.MotExpiry.App;

public class Program
{
    public static void Main(string[] args)
    {
        var app = CreateWebApplication();
        app.Run();
    }

    public static WebApplication CreateWebApplication()
    {
        var builder = WebApplication.CreateBuilder();

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        builder.Logging.AddConsole();

        builder.Services.AddSingleton<ApplicationState>();

        var apiKey = builder.Configuration["ApiKey"];
        builder.Services.AddHttpClient<MotApiClient>(cli =>
        {
            cli.BaseAddress = new Uri("https://beta.check-mot.service.gov.uk");
            cli.DefaultRequestHeaders.Add("x-api-key", apiKey);
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseAntiforgery();

        app.MapRazorComponents<Components.App>()
            .AddInteractiveServerRenderMode();

        return app;
    }
}
