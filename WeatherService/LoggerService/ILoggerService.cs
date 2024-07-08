namespace WeatherService.LoggerService
{
/// <summary>
    /// Interface for logging
    /// </summary>
	public interface ILoggerService
	{
        /// <summary>
        /// Log errors
        /// </summary>
        /// <param name="message">messages</param>
        void LogError(string message);
    }
}


