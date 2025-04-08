using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessionController : ControllerBase
    {
        private static readonly string[] Summaries = new[] 
        { 
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" 
        };

        private readonly ILogger<SessionController> _logger;

        public SessionController(ILogger<SessionController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetSession")]
        public IEnumerable<SessionDto> Get()
        {
            _logger.LogInformation("Fetching categories...");
            return Enumerable.Range(1, 5).Select(index => new SessionDto
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            });
        }

        public class SessionDto
        {
            public DateOnly Date { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }
        }
    }
}
