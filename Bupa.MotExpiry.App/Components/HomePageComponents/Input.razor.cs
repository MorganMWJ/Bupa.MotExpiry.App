using Microsoft.AspNetCore.Components;

namespace Bupa.MotExpiry.App.Components.HomePageComponents;

public partial class Input
{
    [Parameter]
    [EditorRequired]
    public string InputLabel { get; set; }

    [Parameter]
    [EditorRequired]
    public string BindInput { get; set; }
}
