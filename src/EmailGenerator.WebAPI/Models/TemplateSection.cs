namespace EmailGenerator.WebAPI.Models;

public class TemplateSection
{
    public Guid TemplateId { get; set; }
    public Guid Id { get; set; }
    public int HeadingLevel { get; set; }
    public string Heading { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }
}