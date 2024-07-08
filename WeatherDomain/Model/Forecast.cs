using System;
namespace WeatherDomain.Model
{
	public class Forecast
	{
		public string? Location { get; set; }
		public DateTime Date { get; set; }
		public int Temperature { get; set; }
    }
}

