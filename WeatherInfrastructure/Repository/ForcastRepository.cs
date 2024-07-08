using System;
using WeatherApplication.AppConstants;
using WeatherApplication.Interface;
using WeatherApplication.Orchestrator;
using WeatherDomain.Model;
using WeatherInfrastructure.DatabaseModel;

namespace WeatherInfrastructure.Repository
{
	public class ForcastRepository : IForcastRepository
    {
        private readonly DB_WeatherEntities _dbContext;

        public ForcastRepository(DB_WeatherEntities dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Get forecast from SQL DB repository
        /// </summary>
        /// <param name="location">location</param>
        /// <param name="date">date</param>
        /// <returns>Forcast detail</returns>
        public Forecast? GetForecast(string location, DateTime date)
        {
            using (_dbContext)
            {
                if (_dbContext.Forecasts.Any(f => f.Location == location))
                {
                    Tbl_Forecast tblForecast = _dbContext.Forecasts.First(f => f.Location == location && f.ForecastDate == date);
                    Forecast forecast = new Forecast();
                    forecast.Location = tblForecast.Location;
                    forecast.Date = tblForecast.ForecastDate;
                    forecast.Temperature = tblForecast.Temperature;
                    return forecast;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Add forecast in SQL DB repository
        /// </summary>
        /// <param name="forecast">forecast detail</param>
        /// <returns>status</returns>
        public Status AddForecast(Forecast forecast)
        {
            Tbl_Forecast tblForecast = new Tbl_Forecast
            {
                Location = forecast.Location,
                Temperature = forecast.Temperature,
                ForecastDate = forecast.Date
            };
            // Check if data is already present for same location and date
            if(!_dbContext.Forecasts.Any(f => f.ForecastDate == forecast.Date && f.Location == forecast.Location))
            {
                // Save new record in DB and send satatus to client
                _dbContext.Forecasts.Add(tblForecast);
                _dbContext.SaveChanges();
                return new Status(true, Constants.SuccessCode, Constants.SuccessMsg);
            }
            else
            {
                // Return error if data is already present for same location and date
                return new Status(false, Constants.ErrAlreadyExistsCode, Constants.ErrAlreadyExistsMsg);
            }
        }
    }
}

