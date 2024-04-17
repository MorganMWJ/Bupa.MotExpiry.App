using Bupa.MotExpiry.App.Enums;
using Bupa.MotExpiry.App.Models;

namespace Bupa.MotExpiry.App.Extensions;

public static class AlertDisplayExtensions
{
    public static void Display(this AlertDisplay alertDisplay, ElementColor colour, string message)
    {
        alertDisplay.AlertColor = colour;
        alertDisplay.AlertText = message;
        alertDisplay.DisplayAlert = true;
    }
}
