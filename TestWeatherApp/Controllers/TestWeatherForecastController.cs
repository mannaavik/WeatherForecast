using System.Net;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WeatherApplication.AppConstants;
using WeatherApplication.Interface;
using WeatherApplication.Orchestrator;
using WeatherDomain.Model;
using WeatherInfrastructure.Repository;
using WeatherService.Controllers;

namespace TestWeatherApp
{
    public class TestWeatherForecastController
    {
        [Fact]
        public void TestGetForecastBadRequest()
        {
            //Arrange
            IForcastRepository forcastRepository = new ForcastRepository();
            IForcastService forecastService = new ForcastService(forcastRepository);
            WeatherForecastController controller = new WeatherForecastController(forecastService);
            string location = string.Empty;
            DateTime date = DateTime.Now;

            //Act
            var result = (BadRequestResult)controller.GetForecast(location, date);

            //Assert   
            Assert.Equal(400, result.StatusCode);
        }

        [Theory]
        [ClassData(typeof(WeatherTestData1))]
        public void TestAddForcastInPast(Forecast forecast)
        {
            //Arrange
            IForcastRepository forcastRepository = new ForcastRepository();
            IForcastService forecastService = new ForcastService(forcastRepository);
            WeatherForecastController controller = new WeatherForecastController(forecastService);
            Status expectedStatus= new Status(false, Constants.ErrBusinessCode01, Constants.ErrBusinessMsg01);

            //Act
            var result = (OkObjectResult)controller.AddForecast(forecast).Result;
            var resultStatus = (Status)result.Value;
            //Assert
            
            Assert.Equal(expectedStatus.ErrorCode, resultStatus.ErrorCode);
        }

        [Theory]
        [ClassData(typeof(WeatherTestData2))]
        public void TestAddForcastWithGreater60(Forecast forecast)
        {
            //Arrange
            IForcastRepository forcastRepository = new ForcastRepository();
            IForcastService forecastService = new ForcastService(forcastRepository);
            WeatherForecastController controller = new WeatherForecastController(forecastService);
            Status expectedStatus= new Status(false, Constants.ErrBusinessCode02, Constants.ErrBusinessMsg02);

            //Act
            var result = (OkObjectResult)controller.AddForecast(forecast).Result;
            var resultStatus = (Status)result.Value;
            //Assert
            
            Assert.Equal(expectedStatus.ErrorCode, resultStatus.ErrorCode);
        }

        [Theory]
        [ClassData(typeof(WeatherTestData3))]
        public void TestAddForcastWithLessMinus60(Forecast forecast)
        {
            //Arrange
            IForcastRepository forcastRepository = new ForcastRepository();
            IForcastService forecastService = new ForcastService(forcastRepository);
            WeatherForecastController controller = new WeatherForecastController(forecastService);
            Status expectedStatus= new Status(false, Constants.ErrBusinessCode02, Constants.ErrBusinessMsg02);

            //Act
            var result = (OkObjectResult)controller.AddForecast(forecast).Result;
            var resultStatus = (Status)result.Value;
            //Assert
            
            Assert.Equal(expectedStatus.ErrorCode, resultStatus.ErrorCode);
        }
    }

    public class WeatherTestData1 : TheoryData<Forecast>
    {
        public WeatherTestData1()
        {
            Forecast forecast = new Forecast();
            forecast.Location = "Belgium";
            forecast.Date = System.DateTime.Today.AddDays(-1);
            forecast.Temperature= 25;
            Add(forecast);
        }
    }

    public class WeatherTestData2 : TheoryData<Forecast>
    {
        public WeatherTestData2()
        {
            Forecast forecast = new Forecast();
            forecast.Location = "Belgium";
            forecast.Date = System.DateTime.Today;
            forecast.Temperature= 61;
            Add(forecast);
        }
    }

    public class WeatherTestData3 : TheoryData<Forecast>
    {
        public WeatherTestData3()
        {
            Forecast forecast = new Forecast();
            forecast.Location = "Belgium";
            forecast.Date = System.DateTime.Today;
            forecast.Temperature= -61;
            Add(forecast);
        }
    }
}


