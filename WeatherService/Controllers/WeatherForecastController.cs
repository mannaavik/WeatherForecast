using Microsoft.AspNetCore.Mvc;
using WeatherApplication.Interface;
using WeatherDomain.Model;

namespace WeatherService.Controllers;

[ApiController]
[Route("weather")]
public class WeatherForecastController : ControllerBase
{
    private readonly IForcastService _forecastService;

    public WeatherForecastController(IForcastService forecastService)
    {
        this._forecastService = forecastService;
    }

    /// <summary>
    /// API operartion to get forecast data
    /// </summary>
    /// <param name="location">Location or place</param>
    /// <param name="date">Date</param>
    /// <returns>Forecst detail</returns>
    [HttpGet("getforecast")]
    public ActionResult GetForecast(string location, DateTime date)
    {
        if (!string.IsNullOrEmpty(location))
        {
            return Ok(this._forecastService.GetForecast(location, date));
        }
        else
            return BadRequest();
    }

    /// <summary>
    /// API operation to save forecast data
    /// </summary>
    /// <param name="forecast"></param>
    /// <returns></returns>
    [HttpPost("addforecast")]
    public ActionResult<Status> AddForecast(Forecast forecast)
    {
        if (forecast != null)
        {
            Status s = this._forecastService.AddForecast(forecast);
            return Ok(s);
        }
        else
            return BadRequest();
    }
}

