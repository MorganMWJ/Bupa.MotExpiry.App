using Bupa.MotExpiry.App.Models;

namespace Bupa.MotExpiry.App.Services;

/// <summary>
/// Injected as a singleton object for holding entire application state.
/// </summary>
public class ApplicationState
{
    public string InputRegistration { get; set; } = string.Empty;

    public CarDetails? CarDetails { get; set; }

    /// <summary>
    /// This multicast delegate is used to register handlers
    /// to be called when the State property has changed.
    /// Register action/method handler in OnInitializedAsync()?
    /// </summary>
    public event Func<Task>? RefreshRequested;

    /// <summary>
    /// Components should call this method after changing State property.
    /// It will invoke all the registered handlers of the RefreshRequested
    /// event (multicast delegate)
    /// </summary>
    public void ApplicationStateHasChanged()
    {
        RefreshRequested?.Invoke();
    }
}
