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
    public ActionResult<ForecastResponse> GetForecast(string location, DateTime date)
    {
        return Ok(this._forecastService.GetForecast(location, date));
    }

    /// <summary>
    /// API operation to save forecast data
    /// </summary>
    /// <param name="forecast"></param>
    /// <returns></returns>
    [HttpPost("addforecast")]
    public ActionResult<Status> AddForecast(Forecast forecast)
    {
        return Ok(this._forecastService.AddForecast(forecast));
    }
}

