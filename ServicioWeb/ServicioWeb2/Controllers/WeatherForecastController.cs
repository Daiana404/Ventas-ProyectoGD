using Microsoft.AspNetCore.Mvc;

namespace ServicioWeb2.Controllers
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

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
      List<WeatherForecast> lll = new List<WeatherForecast>();
      lll.Add(new WeatherForecast() { Id = 1, Nombre = "Franco", Apellido = "Guardiani" });
      lll.Add(new WeatherForecast() { Id = 2, Nombre = "Daiana", Apellido = "Polo" });

      return lll;
    }
  }
}
