using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;
namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EventParticipantsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public EventParticipantsController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventParticipant>>> Get() => await _context.EventParticipants.ToListAsync();

        [HttpGet("{eventId}/{participantId}")]
        public async Task<ActionResult<EventParticipant>> Get(int eventId, int participantId)
        {
            var entity = await _context.EventParticipants
                .FirstOrDefaultAsync(ep => ep.EventId == eventId && ep.ParticipantId == participantId);

            return entity == null ? NotFound() : Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<EventParticipant>> Post(EventParticipant model)
        {
            _context.EventParticipants.Add(model);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { eventId = model.EventId, participantId = model.ParticipantId }, model);
        }

        [HttpDelete("{eventId}/{participantId}")]
        public async Task<IActionResult> Delete(int eventId, int participantId)
        {
            var entity = await _context.EventParticipants
                .FirstOrDefaultAsync(ep => ep.EventId == eventId && ep.ParticipantId == participantId);

            if (entity == null) return NotFound();

            _context.EventParticipants.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
