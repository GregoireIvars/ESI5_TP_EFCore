using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;
namespace WebAPI.Controllers
{



    [Route("api/[controller]")]
    [ApiController]
    public class SessionSpeakersController : ControllerBase
    {
        private readonly AppDbContext _context;
        public SessionSpeakersController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SessionSpeaker>>> Get() => await _context.SessionSpeakers.ToListAsync();

        [HttpGet("{sessionId}/{speakerId}")]
        public async Task<ActionResult<SessionSpeaker>> Get(int sessionId, int speakerId)
        {
            var entity = await _context.SessionSpeakers
                .FirstOrDefaultAsync(ss => ss.SessionId == sessionId && ss.SpeakerId == speakerId);

            return entity == null ? NotFound() : Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<SessionSpeaker>> Post(SessionSpeaker model)
        {
            _context.SessionSpeakers.Add(model);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { sessionId = model.SessionId, speakerId = model.SpeakerId }, model);
        }

        [HttpDelete("{sessionId}/{speakerId}")]
        public async Task<IActionResult> Delete(int sessionId, int speakerId)
        {
            var entity = await _context.SessionSpeakers
                .FirstOrDefaultAsync(ss => ss.SessionId == sessionId && ss.SpeakerId == speakerId);

            if (entity == null) return NotFound();

            _context.SessionSpeakers.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}