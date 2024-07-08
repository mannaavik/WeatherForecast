using WeatherApplication.AppConstants;
using WeatherApplication.Interface;
using WeatherDomain.Model;

namespace WeatherApplication.Orchestrator
{
    public class ForcastService : IForcastService
    {
		private readonly IForcastRepository _forcastRepository;

		public ForcastService(IForcastRepository forcastRepository)
		{
			this._forcastRepository = forcastRepository;
        }

		/// <summary>
		/// Get forcast data
		/// </summary>
		/// <param name="location">location</param>
		/// <param name="date">date</param>
		/// <returns></returns>
        public ForecastResponse GetForecast(string location, DateTime date)
		{
			// Get forecast data from repository
			ForecastResponse forecastResponse = new ForecastResponse();
            Forecast? forecast = this._forcastRepository.GetForecast(location, date);
			if (forecast != null)
			{
				// Create response of forecast
				forecastResponse.Forecast = forecast;
                forecastResponse.Status = new Status(true, string.Empty, string.Empty);
				forecastResponse.ForecastType = DetermineForecastType(forecast.Temperature);
            }
			else
			{
				// Send status and not found message if no data is available for the search
				forecastResponse.Status = new Status(false, Constants.ErrNotFoundCode, Constants.ErrNotFoundMsg);
            }
			return forecastResponse;
        }

		/// <summary>
		/// Add forecast data
		/// </summary>
		/// <param name="forecast">Forecast data</param>
		/// <returns></returns>
        public Status AddForecast(Forecast forecast)
		{
			// if user try to save forecast of past days
			if(forecast.Date < System.DateTime.Today)
			{
                return new Status(false, Constants.ErrBusinessCode01, Constants.ErrBusinessMsg01);
            }
			// If user do not enter temperature bewteen 60 and -60
			if(forecast.Temperature < -60 || forecast.Temperature > 60)
			{
                return new Status(false, Constants.ErrBusinessCode02, Constants.ErrBusinessMsg02);
            }
			else
			{
				// Add forecast data in repository
                return this._forcastRepository.AddForecast(forecast);
			}
		}

		/// <summary>
		/// Convert temperature into user readable text
		/// </summary>
		/// <param name="Temperature">Temperatue</param>
		/// <returns>Weather type</returns>
		private string DetermineForecastType(int Temperature)
		{
			KeyValuePair<string, string> item = Constants.ForecastMaster.First(x => 
			Temperature >= Convert.ToInt32(x.Key.Split(';')[0]) &&
			Temperature <= Convert.ToInt32(x.Key.Split(';')[1]));
			return item.Value;
		}
    }
}

