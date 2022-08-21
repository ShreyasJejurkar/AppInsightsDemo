using Microsoft.AspNetCore.Mvc;

namespace AppInsightsDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnotherController : ControllerBase
    {
        private readonly ILogger<AnotherController> _logger;

        public AnotherController(ILogger<AnotherController> logger)
        {
            this._logger = logger;
        }

        [HttpGet("{id}")]
        public IActionResult Test(int id)
        {
            _logger.LogDebug("Debug ");
            _logger.LogCritical("Critical", id);
            _logger.LogError("Error", id);
            _logger.LogTrace("Trace", id);
            _logger.LogWarning("Warning", id);
            _logger.LogInformation("Hello World from logs {id}", id);


            // Access current OperationId in request. 
            Console.WriteLine(System.Diagnostics.Activity.Current?.RootId);

            return Content("The number is " + id);
        }
    }

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

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("{id}")]
        public IActionResult GetDetails(int id)
        {
            _logger.LogDebug("Debug ");
            _logger.LogCritical("Critical", id);
            _logger.LogError("Error", id);
            _logger.LogTrace("Trace", id);
            _logger.LogWarning("Warning", id);
            _logger.LogInformation("Hello World from logs {id}", id);

            return Content("The number is " + id);
        }
    }
}