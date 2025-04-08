using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParticipantController : ControllerBase
    {
        private static readonly string[] Summaries = new[] 
        { 
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" 
        };

        private readonly ILogger<ParticipantController> _logger;

        public ParticipantController(ILogger<ParticipantController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetParticipant")]
        public IEnumerable<ParticipantDto> Get()
        {
            _logger.LogInformation("Fetching categories...");
            return Enumerable.Range(1, 5).Select(index => new ParticipantDto
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            });
        }

        public class ParticipantDto
        {
            public DateOnly Date { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }
        }
    }
}
