using Bupa.MotExpiry.App.Clients;
using Bupa.MotExpiry.App.Constants;
using Bupa.MotExpiry.App.Enums;
using Bupa.MotExpiry.App.Extensions;
using Bupa.MotExpiry.App.Services;
using Microsoft.AspNetCore.Components;

namespace Bupa.MotExpiry.App.Components.HomePageComponents;

public partial class RegistrationInput
{
    [Inject]
    public ApplicationState State { get; set; }

    [Inject]
    public MotApiClient MotApiClient { get; set; }

    private string _registraion = string.Empty;

    private async Task ProcessInputAsync()
    {
        if (string.IsNullOrWhiteSpace(_registraion))
        {
            State.AlertDisplay.Display(ElementColor.Warning,
                "Please enter a valid registraion");
            return;
        }

        State.InputRegistration = (string)_registraion.Clone();

        State.CarDetails = await MotApiClient.GetCarDetailsAsync(State.InputRegistration);

        if (State.CarDetails == null)
        {
            State.AlertDisplay.Display(ElementColor.Warning,
                string.Format(DisplayStrings.FailedSearch, State.InputRegistration));
        }
        else
        {
            State.AlertDisplay.DisplayAlert = false;
        }

        State.ApplicationStateHasChanged();
    }
}
