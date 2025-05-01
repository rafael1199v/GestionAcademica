using GestionAcademica.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestionAcademica.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly GestionAcademicaContext _context;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, GestionAcademicaContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<User> Get()
        {
            return _context.Users.ToList();
        }
    }
}
