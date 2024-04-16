using Microsoft.AspNetCore.Components;

namespace Bupa.MotExpiry.App.Components.HomePageComponents;

public partial class Input
{
    [Parameter]
    [EditorRequired]
    public string InputLabel { get; set; }

    [Parameter]
    [EditorRequired]
    public EventCallback<string> InputCallback { get; set; }

    private string _bindInput = string.Empty;

    private async Task ProcessInput()
    {
        await InputCallback.InvokeAsync(_bindInput);
    }
}
