using Bupa.MotExpiry.App.Clients;
using Bupa.MotExpiry.App.Components.HomePageComponents;
using Bupa.MotExpiry.App.Constants;
using Bupa.MotExpiry.App.Enums;
using Bupa.MotExpiry.App.Extensions;
using Bupa.MotExpiry.App.Services;
using Microsoft.AspNetCore.Components;

namespace Bupa.MotExpiry.App.Components.Pages;

public partial class Home
{
    //[Inject]
    //public ApplicationState State { get; set; }

    //[Inject]
    //public MotApiClient MotApiClient { get; set; }

    //public async Task SearchWithRegistration(string registration)
    //{
    //    State.InputRegistration = registration;

    //    State.CarDetails = await MotApiClient.GetCarDetailsAsync(registration);

    //    if (State.CarDetails == null)
    //    {
    //        State.AlertDisplay.Display(ElementColor.Warning,
    //            string.Format(DisplayStrings.FailedSearch, registration));
    //    }
    //    else
    //    {
    //        State.AlertDisplay.DisplayAlert = false;
    //    }

    //    State.ApplicationStateHasChanged();
    //}
}
