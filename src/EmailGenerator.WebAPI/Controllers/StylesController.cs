using System.Net;
using EmailGenerator.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmailGenerator.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StylesController : Controller
{
    private readonly EmailGeneratorContext _context;

    public StylesController(EmailGeneratorContext context)
    {
        _context = context;
    }

    [ProducesResponseType(typeof(List<Style>), (int)HttpStatusCode.OK)]
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var output = await _context.Styles.ToListAsync();
        return Ok(output);
    }

    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(Style), StatusCodes.Status200OK)]
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var output = await _context.Styles.FirstOrDefaultAsync(x => x.Id == id);

        if (output is null)
        {
            return NotFound();
        }

        return Ok(output);
    }

    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(Style), StatusCodes.Status200OK)]
    [HttpGet("default")]
    public async Task<IActionResult> GetDefault()
    {
        var output = await _context.Styles.FirstOrDefaultAsync(x => x.IsDefault);

        if (output is null)
        {
            return NotFound();
        }
        
        return Ok(output);
    }

    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Style style)
    {
        var output = _context.Styles.Add(style);
        await _context.SaveChangesAsync();

        return Created(new Uri($"/api/Styles/{output.Entity.Id}", UriKind.Relative), output.Entity.Id.ToString());
    }

    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Style style)
    {
        var model = await _context.Styles
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == style.Id);

        if (model is null)
        {
            return NotFound();
        }

        _context.Styles.Update(style);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var model = await _context.Styles.FirstOrDefaultAsync(x => x.Id == id);

        if (model is null)
        {
            return NotFound();
        }
        
        _context.Styles.Remove(model);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}