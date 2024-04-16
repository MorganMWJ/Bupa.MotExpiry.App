﻿using Bupa.MotExpiry.App.Clients;
using Bupa.MotExpiry.App.Services;
using Microsoft.AspNetCore.Components;

namespace Bupa.MotExpiry.App.Components.Pages;

public partial class Home
{
    [Inject]
    public ApplicationState State { get; set; }

    [Inject]
    public MotApiClient MotApiClient { get; set; }

    //protected override async Task OnInitializedAsync()
    //{
    //    State.RefreshRequested += RefreshThisComponentAsync;
    //}

    //public void Dispose()
    //{
    //    State.RefreshRequested -= RefreshThisComponentAsync;
    //}

    //private async Task RefreshThisComponentAsync()
    //{
    //    await InvokeAsync(StateHasChanged);
    //}

    public async Task SearchWithRegistration(string registration)
    {
        State.InputRegistration = registration;

        try
        {
            State.CarDetails = await MotApiClient.GetCarDetailsAsync(registration);
        }
        catch(Exception ex)
        {

        }

        State.ApplicationStateHasChanged();
    }
}
