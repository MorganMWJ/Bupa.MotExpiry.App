using System.Text.Json.Serialization;
using System.Text.Json;

namespace Bupa.MotExpiry.App.Models;

public class DateTimeConverter : JsonConverter<DateTime>
{
    private readonly string _format = "yyyy.MM.dd HH:mm:ss";

    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string value = reader.GetString();
        return DateTime.ParseExact(value, _format, null);
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(_format));
    }
}