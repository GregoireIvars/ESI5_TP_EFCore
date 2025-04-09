using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeakersController : ControllerBase
    {
        private readonly AppDbContext _context;
        public SpeakersController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Speaker>>> Get() => await _context.Speakers.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Speaker>> Get(int id)
        {
            var entity = await _context.Speakers.FindAsync(id);
            return entity == null ? NotFound() : Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<Speaker>> Post(Speaker model)
        {
            _context.Speakers.Add(model);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = model.Id }, model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Speaker model)
        {
            if (id != model.Id) return BadRequest();
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _context.Speakers.FindAsync(id);
            if (entity == null) return NotFound();
            _context.Speakers.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}