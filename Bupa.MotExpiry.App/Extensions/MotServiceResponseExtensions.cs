using Bupa.MotExpiry.App.Models;

namespace Bupa.MotExpiry.App.Extensions;

public static class MotServiceResponseExtensions
{
    public static CarDetails ToCarDetails(this MotServiceResponse msr)
    {
        var recentMot = msr.MotTests.FirstOrDefault();

        return new CarDetails
        {
            Registration = msr.Registration,
            Make = msr.Make,
            Model = msr.Model,
            Colour = msr.PrimaryColour,
            MotExpiry = recentMot.ExpiryDate.ToDateTime(TimeOnly.MaxValue),
            MileageAtLastMot = recentMot.OdometerValue
        };
    }
}
