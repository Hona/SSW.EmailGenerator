namespace EmailGenerator.WebAPI.Models;

public class Template
{
    public Guid Id { get; set; }
    public string DisplayName { get; set; }
    public bool IsVisible { get; set; }

    public string Subject { get; set; }
    
    public virtual List<TemplateRecipient> Recipients { get; set; }
}