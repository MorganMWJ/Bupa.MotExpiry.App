using Bupa.MotExpiry.App.Models;
using Bupa.MotExpiry.App.Services;
using Microsoft.AspNetCore.Components;

namespace Bupa.MotExpiry.App.Components.HomePageComponents;

public partial class MotResultsTable
{
    [Inject]
    public ApplicationState State { get; set; }

}
