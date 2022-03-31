using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmailGenerator.WebAPI.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class TemplatesController : Controller
{
    private readonly EmailGeneratorContext _context;

    public TemplatesController(EmailGeneratorContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var output = await _context.Templates.ToListAsync();

        if (!output.Any())
        {
            return NoContent();
        }
        
        return Ok(output);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var output = await _context.Templates
            .Include(x => x.Recipients)
            .FirstOrDefaultAsync(x => x.Id == id);
        

        if (output is null)
        {
            return NotFound();
        }

        return Ok(output);
    }
}