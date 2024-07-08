# WeatherForecast
Repository for Weather Forecast 

Prerequisite to run the application
 1.  Create databse in SQL server by executing the following script.
     CREATE DATABASE DB_Weather
   
 2.  Create table in the database by wxecuting the following script.
     CREATE TABLE Forecast (
      ID bigint identity(1,1),
      Location nvarchar(500) null,
      Temperature int not null,
      ForecastDate datetime not null,
      )
 3.  Change the password in the DB connection string by your own password in the file appsettings.json in Web API project.  
   
   

