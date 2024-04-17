using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace Bupa.MotExpiry.App.Tests.End2End;

/// <summary>
/// UI front-end tests using Playwright.
/// 
/// SetUp and TearDown output a trace file to view what was done
/// to the UI during execution of each test.
/// 
/// Open the trace zip in browser at https://trace.playwright.dev/ OR
/// 
/// Run the below command to view the trace in 'PLaywright Trace Viewer'
/// .\playwright.ps1 show-trace <-full-path-to-trace_dir->\trace_Add_new_password_test.zip
///
/// This base class also starts the host before all tests and stops the host after all tests have finished running.
/// We need the actual host web server to be running locally.
/// Cannot run host in memory as blazor server relies on a WebSocket connection, which is not easily imitated.
/// </summary>
public class BlazorTest : PageTest
{
    private IHost? _host;

    protected Uri RootUri { get; private set; } = default!;

    /// <summary>
    /// NUnit calls SetUp in the base class before SetUp in the derived classes.
    /// </summary>
    /// <returns></returns>
    [OneTimeSetUp]
    public async Task SetUpWebApplication()
    {
        _host = Program.CreateWebApplication();

        await _host.StartAsync();

        var addresses = _host.Services.GetRequiredService<IServer>().Features
            .GetRequiredFeature<IServerAddressesFeature>()
            .Addresses;

        var address = addresses.First();

        RootUri = new(address);
    }

    [OneTimeTearDown]
    public async Task TearDownWebApplication()
    {
        if (_host is not null)
        {
            await _host.StopAsync();
            _host.Dispose();
        }
    }

    [SetUp]
    public async Task SetUpTracing()
    {
        await Context.Tracing.StartAsync(new TracingStartOptions
        {
            Screenshots = true,
            Snapshots = true,
            Sources = true
        });
    }

    [TearDown]
    public async Task TearDownTracing()
    {
        var methodExecuted = TestContext.CurrentContext.Test.Name;
        await Context.Tracing.StopAsync(new TracingStopOptions
        {
            Path = $"trace_{methodExecuted}.zip"
        });
    }
}
