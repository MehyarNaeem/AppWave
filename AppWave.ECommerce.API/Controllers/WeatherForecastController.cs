using Microsoft.AspNetCore.Mvc;
using System;

namespace AppWave.ECommerce.API.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
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
    public ActionResult<Dictionary<string, object>> Get()
    {
        _logger.LogInformation("Getting weather forecast");
        
        var forecastDictionary = new Dictionary<string, object>();
        
        for (int i = 1; i <= 5; i++)
        {
            var date = DateOnly.FromDateTime(DateTime.Now.AddDays(i));
            var tempC = Random.Shared.Next(-20, 55);
            var summary = Summaries[Random.Shared.Next(Summaries.Length)];
            
            forecastDictionary[date.ToString("yyyy-MM-dd")] = new
            {
                temperatureC = tempC,
                temperatureF = 32 + (int)(tempC / 0.5556),
                summary = summary
            };
        }

        return Ok(forecastDictionary);
    }
} 