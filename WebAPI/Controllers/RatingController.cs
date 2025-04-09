using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;
namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public RatingsController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rating>>> Get() => await _context.Ratings.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Rating>> Get(int id)
        {
            var entity = await _context.Ratings.FindAsync(id);
            return entity == null ? NotFound() : Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<Rating>> Post(Rating model)
        {
            _context.Ratings.Add(model);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = model.Id }, model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Rating model)
        {
            if (id != model.Id) return BadRequest();
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _context.Ratings.FindAsync(id);
            if (entity == null) return NotFound();
            _context.Ratings.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
