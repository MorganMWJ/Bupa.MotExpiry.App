using Bupa.MotExpiry.App.Constants;
using Microsoft.Playwright;

namespace Bupa.MotExpiry.App.Tests.End2End;

public class HomePageTests : BlazorTest
{

    [SetUp]
    public async Task SetUp()
    {
        // navigate to URI
        await Page.GotoAsync(RootUri.AbsoluteUri);

        // Delay to ensure it loads page
        await Task.Delay(1000);
    }

    [Test]
    public async Task Searching_for_valid_registration_displays_results()
    {
        var reg = "M200PEW";
        await Page.GetByPlaceholder(DisplayStrings.RegistraionInputLabel).FillAsync(reg);

        await Page.GetByRole(AriaRole.Button).ClickAsync();

        await Expect(Page.Locator(".table")).ToBeVisibleAsync();

        await Expect(Page.Locator($"#{DisplayStrings.ResultTableHeader}")).ToContainTextAsync("Result Details: MOT is In-Date");
        await Expect(Page.Locator($"#{DisplayStrings.ResultTableDataReg}")).ToContainTextAsync(reg);
        await Expect(Page.Locator($"#{DisplayStrings.ResultTableDataMake}")).ToContainTextAsync("KIA");
        await Expect(Page.Locator($"#{DisplayStrings.ResultTableDataModel}")).ToContainTextAsync("SPORTAGE");
        await Expect(Page.Locator($"#{DisplayStrings.ResultTableDataColour}")).ToContainTextAsync("Black");
        await Expect(Page.Locator($"#{DisplayStrings.ResultTableDataMotExpiry}")).ToContainTextAsync("28/06/2024 23:59:59");
        await Expect(Page.Locator($"#{DisplayStrings.ResultTableDataMileage}")).ToContainTextAsync("38712");
    }

    [Test]
    public async Task Searching_for_invalid_registration_displays_user_notification()
    {
        var reg = "aaa";
        var expectedAlertMessage = string.Format(DisplayStrings.FailedSearch, reg);

        await Page.GetByPlaceholder(DisplayStrings.RegistraionInputLabel).FillAsync(reg);

        await Page.GetByRole(AriaRole.Button).ClickAsync();

        await Expect(Page.Locator(".table")).ToBeHiddenAsync();

        await Expect(Page.Locator(".alert")).ToBeVisibleAsync();
        await Expect(Page.Locator(".alert")).ToContainTextAsync(expectedAlertMessage);
    }
}
