using System;
using WeatherDomain.Model;

namespace WeatherApplication.Interface
{
	public interface IForcastService
	{
        /// <summary>
		/// Get forcast data
		/// </summary>
		/// <param name="location">location</param>
		/// <param name="date">date</param>
		/// <returns></returns>
        public ForecastResponse GetForecast(string location, DateTime date);

        /// <summary>
		/// Add forecast data
		/// </summary>
		/// <param name="forecast">Forecast data</param>
		/// <returns></returns>
        public Status AddForecast(Forecast forecast);
    }
}

