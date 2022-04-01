using System.Drawing;
using Newtonsoft.Json;

namespace EmailGenerator.WebAPI.Models;

public class Style
{
    public Guid Id { get; set; }
    public string DisplayName { get; set; }
    public string Font { get; set; }
    [JsonIgnore]
    public int HeadingColorRaw { get; set; }
    [JsonConverter(typeof(HexColorConverter))]
    public Color HeadingColor
    {
        get => Color.FromArgb(HeadingColorRaw);
        set => HeadingColorRaw = value.ToArgb();
    }
    [JsonIgnore]
    public int TextColorRaw { get; set; }
    [JsonConverter(typeof(HexColorConverter))]
    public Color TextColor {         
        get => Color.FromArgb(TextColorRaw);
        set => TextColorRaw = value.ToArgb(); 
    }
    public int HeadingSize { get; set; }
    public int TextSize { get; set; }
    public bool IsDefault { get; set; }
}