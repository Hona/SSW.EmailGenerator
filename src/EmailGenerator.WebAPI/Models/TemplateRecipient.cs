using System.Text.Json.Serialization;

namespace EmailGenerator.WebAPI.Models;

public class TemplateRecipient
{
    public Guid Id { get; set; }
    public Guid TemplateId { get; set; }

    public string DisplayName { get; set; }
    public string EmailAddress { get; set; }
    public RecipientType Type { get; set; }
    
    [JsonIgnore]
    public virtual Template Template { get; set; }
}