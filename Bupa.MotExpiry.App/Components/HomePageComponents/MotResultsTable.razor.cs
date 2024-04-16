using Bupa.MotExpiry.App.Models;
using Bupa.MotExpiry.App.Services;
using Microsoft.AspNetCore.Components;

namespace Bupa.MotExpiry.App.Components.HomePageComponents;

public partial class MotResultsTable
{
    [Inject]
    public ApplicationState State { get; set; }

    protected override async Task OnInitializedAsync()
    {
        State.RefreshRequested += RefreshThisComponentAsync;
    }

    public void Dispose()
    {
        State.RefreshRequested -= RefreshThisComponentAsync;
    }

    private async Task RefreshThisComponentAsync()
    {
        await InvokeAsync(StateHasChanged);
    }
}
