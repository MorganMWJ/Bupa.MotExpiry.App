using Bupa.MotExpiry.App.Models;

namespace Bupa.MotExpiry.App.Extensions;

public static class CarDetailsExtensions
{
    public static bool HasMotExpired(this CarDetails details)
    {
        return details.MotExpiry < DateTime.Now;
    }
}
