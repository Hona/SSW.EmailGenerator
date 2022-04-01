using System.Drawing;
using System.Text.Json;
using Newtonsoft.Json;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace EmailGenerator.WebAPI;

public class HexColorConverter : JsonConverter
{
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        var color = (Color) value;
        writer.WriteValue(
            "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2").ToLower());    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        // Convert from hex to Color
        var hex = (string) reader.Value;
        var color = ColorTranslator.FromHtml(hex);
        return color;
    }

    public override bool CanConvert(Type objectType) => objectType == typeof(Color);
}