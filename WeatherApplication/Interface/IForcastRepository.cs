using System;
using WeatherDomain.Model;

namespace WeatherApplication.Interface
{
	public interface IForcastRepository
	{
		/// <summary>
		/// Get forecast detail from repository
		/// </summary>
		/// <param name="location">location</param>
		/// <param name="date">data</param>
		/// <returns>Forecast detail</returns>
		public Forecast? GetForecast(string location, DateTime date);

		/// <summary>
		/// Save forecast detail in repository
		/// </summary>
		/// <param name="forecast">forecast detail</param>
		/// <returns>status</returns>
		public Status AddForecast(Forecast forecast);

    }
}

