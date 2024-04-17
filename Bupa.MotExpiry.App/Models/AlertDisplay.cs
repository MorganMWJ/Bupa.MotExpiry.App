using Bupa.MotExpiry.App.Enums;

namespace Bupa.MotExpiry.App.Models;

public class AlertDisplay
{
    public ElementColor AlertColor { get; set; } = ElementColor.Warning;

    public string AlertText { get; set; } = string.Empty;

    public bool DisplayAlert { get; set; } = false;
}
