using System.Text.Json;
using System.Text.Json.Serialization;

namespace MyFirstNSwagApplication;

public class LongJsonSerializer : JsonConverter<long>
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert == typeof(long);
    }

    public override long Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string text = reader.GetString()!;

        if (long.TryParse(text, out long value))
        {
            return value;
        }
        else
            return default;
    }

    public override void Write(Utf8JsonWriter writer, long value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}
