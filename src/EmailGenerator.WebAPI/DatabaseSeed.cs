using System.Drawing;
using EmailGenerator.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailGenerator.WebAPI;

public static class DatabaseSeed
{
    public static void SeedIfEmpty(this ModelBuilder builder)
    {
        var emptyTemplateId = Guid.Parse("0275A527-E041-4E38-98D9-B34904EA6982");
        builder.Entity<Template>().HasData(new Template
        {
            Id = emptyTemplateId,
            Subject = "DELETE ME - New Email",
            DisplayName = "Empty Template",
            IsVisible = true
        });

        builder.Entity<TemplateRecipient>().HasData(new TemplateRecipient
        {
            TemplateId = emptyTemplateId,
            Id = Guid.NewGuid(),
            DisplayName = "Adam",
            EmailAddress = "AdamCogan@ssw.com.au",
            Type = RecipientType.To
        });

        builder.Entity<Style>().HasData(new Style
        {
            Id = Guid.NewGuid(),
            DisplayName = "SSW",
            Font = "Open Sans",
            HeadingColor = Color.FromArgb(204, 65, 65),
            HeadingSize = 14,
            IsDefault = true,
            TextColor = Color.Black,
            TextSize = 12
        });
    }
}