using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;
namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ParticipantsController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Participant>>> Get() => await _context.Participants.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Participant>> Get(int id)
        {
            var entity = await _context.Participants.FindAsync(id);
            return entity == null ? NotFound() : Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<Participant>> Post(Participant model)
        {
            _context.Participants.Add(model);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = model.Id }, model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Participant model)
        {
            if (id != model.Id) return BadRequest();
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _context.Participants.FindAsync(id);
            if (entity == null) return NotFound();
            _context.Participants.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
