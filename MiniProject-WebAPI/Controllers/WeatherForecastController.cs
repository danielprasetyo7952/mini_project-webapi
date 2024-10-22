using Microsoft.AspNetCore.Mvc;

namespace MiniProject_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetAllWeatherForecast")]
        public IActionResult GetAll()
        {
            List<WeatherForecast>? forecasts = new List<WeatherForecast>();

            foreach (var summary in Summaries)
            {
                Random random = new Random();
                int randomNumber = random.Next(1, 365);

                forecasts.Add(new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(randomNumber)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = summary
                });
            }

            return Ok(forecasts);
        }

        [HttpGet("{id}", Name = "GetWeatherForecastById")]
        public IActionResult GetById([FromRoute] int id)
        {
            var summary = Summaries[id];

            if (summary == null)
            {
                return NotFound();
            }

            Random random = new Random();
            int randomNumber = random.Next(1, 365);

            WeatherForecast forecast = new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(randomNumber)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = summary
            };

            return Ok(forecast);
        }
    }
}
