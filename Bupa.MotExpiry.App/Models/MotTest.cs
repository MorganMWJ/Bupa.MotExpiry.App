using System.Text.Json.Serialization;

namespace Bupa.MotExpiry.App.Models;

public class MotTest
{
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime completedDate { get; set; }

    public string TestResult { get; set; }

    [JsonConverter(typeof(DateOnlyConverter))]
    public DateOnly ExpiryDate { get; set; }

    public int OdometerValue { get; set; }

    public string OdometerUnit { get; set; }

    public string MotTestNumber { get; set; }
}