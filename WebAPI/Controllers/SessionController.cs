using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public SessionsController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Session>>> Get() => await _context.Sessions.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Session>> Get(int id)
        {
            var entity = await _context.Sessions.FindAsync(id);
            return entity == null ? NotFound() : Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<Session>> Post(Session model)
        {
            _context.Sessions.Add(model);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = model.Id }, model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Session model)
        {
            if (id != model.Id) return BadRequest();
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _context.Sessions.FindAsync(id);
            if (entity == null) return NotFound();
            _context.Sessions.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
