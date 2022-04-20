using System;
using System.Threading.Tasks;
using EmailGenerator.WebAPI.Controllers;
using EmailGenerator.WebAPI.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace EmailGenerator.WebAPI.Tests;

public class StylesControllerTests
{
    private readonly DbContextOptions<EmailGeneratorContext> _dbContextOptions =
        new DbContextOptionsBuilder<EmailGeneratorContext>()
            .UseInMemoryDatabase(databaseName: nameof(StylesControllerTests))
            .Options;
    
    [Fact]
    public async Task Delete_WithValidId_RemovesDbEntry()
    {
        // Arrange
        var context = new EmailGeneratorContext(true);
        var controller = new StylesController(context);
        var model = new Style
        {
            Id = Guid.NewGuid(),
            DisplayName = "Test"
        };

        context.Styles.Add(model);
        await context.SaveChangesAsync();

        // Act
        var response = await controller.Delete(model.Id);

        // Assert
        context.Styles
            .Should().NotContain(x => x.Id == model.Id);

        response
            .Should().BeOfType<NoContentResult>()
            .And
            .NotBeOfType<NotFoundResult>();
    }
}