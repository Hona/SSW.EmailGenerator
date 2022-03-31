using EmailGenerator.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailGenerator.WebAPI;

public class EmailGeneratorContext : DbContext
{
    public DbSet<Template> Templates { get; set; }
    public DbSet<TemplateRecipient> TemplateRecipients { get; set; }
    public DbSet<TemplateSection> TemplateSections { get; set; }
    public DbSet<Style> Styles { get; set; }

    public string DbPath { get; }

    public EmailGeneratorContext()
    {
        var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        DbPath = Path.Join(path, "emailgenerator.db");
        
        Database.EnsureCreated();
    }
    
    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.SeedIfEmpty();

        var templates = modelBuilder.Entity<Template>();
        templates.HasKey(x => x.Id);
        templates
            .HasMany(x => x.Recipients)
            .WithOne(x => x.Template)
            .HasForeignKey(x => x.TemplateId);

        var templateRecipients = modelBuilder.Entity<TemplateRecipient>();
        templateRecipients.HasKey(x => x.Id);

        var styles = modelBuilder.Entity<Style>();
        styles.HasKey(x => x.Id);
        styles.Ignore(x => x.HeadingColor);
        styles.Ignore(x => x.TextColor);

    }
}