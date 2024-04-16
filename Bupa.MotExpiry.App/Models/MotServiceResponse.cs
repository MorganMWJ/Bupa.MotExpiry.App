using System.Text.Json.Serialization;

namespace Bupa.MotExpiry.App.Models;

public class MotServiceResponse
{
    public string Registration { get; set; }

    public string Make { get; set; }

    public string Model { get; set; }

    [JsonConverter(typeof(DateOnlyConverter))]
    public DateOnly FirstUsedDate { get; set; }

    public string FuelType { get; set; }

    public string PrimaryColour { get; set; }

    public List<MotTest> MotTests { get; set; }
}
