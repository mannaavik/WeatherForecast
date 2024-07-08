using System;
namespace WeatherInfrastructure.DatabaseModel
{
	public class Tbl_Forecast
	{
		public long Id { get; set; }
		public string? Location { get; set; }
		public int Temperature { get; set; }
		public DateTime ForecastDate { get; set; }
    }
}

