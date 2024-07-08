using System;
namespace WeatherDomain.Model
{
	public class ForecastResponse
	{
		public Forecast? Forecast { get; set; }
		public string? ForecastType { get; set; }
		public Status? Status { get; set; }

	}
}

