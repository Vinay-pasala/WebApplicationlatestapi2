using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("add",Name = "Addition")]
        public IActionResult AddTwoNumbers([FromQuery] int a, [FromQuery] int b)
        {

            try
            {
                int res = a + b;

                return Ok(new { Sum = res });
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("sub", Name = "Subtraction")]
        public IActionResult SubtractTwoNumbers([FromQuery] int a, [FromQuery] int b)
        {

            try
            {
                int res = a - b;

                return Ok(new { Minus = res });
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("mul", Name = "Multiplication")]
        public IActionResult MultiplyTwoNumbers([FromQuery] int a, [FromQuery] int b)
        {

            try
            {
                int res = a * b;

                return Ok(new { Mul = res });
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("Div", Name = "Divide")]
        public IActionResult DivideTwoNumbers([FromQuery] int a, [FromQuery] int b)
        {

            try
            {
                int res = a / b;

                return Ok(new { Div = res });
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
