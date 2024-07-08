using WeatherApplication.Interface;
using WeatherApplication.Orchestrator;
using WeatherInfrastructure.Repository;
using WeatherService.LoggerService;
using WeatherService.MiddleWare;
using Serilog;
using WeatherInfrastructure.DatabaseModel;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Integrating Serilog for global error handling in file system
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.File("WeatherLog/log.txt", (Serilog.Events.LogEventLevel)RollingInterval.Hour)
    .CreateLogger();

builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DB_WeatherEntities>(Options =>
{
    Options.UseSqlServer(builder.Configuration.GetConnectionString("WeatherDbConnection"));
});

builder.Services.AddScoped<IForcastService, ForcastService>();
builder.Services.AddScoped<IForcastRepository, ForcastRepository>();
builder.Services.AddSingleton<ILoggerService, LoggerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//Adding middleware for global error handling
app.UseMiddlewareClassTemplate();

app.MapControllers();

app.Run();

