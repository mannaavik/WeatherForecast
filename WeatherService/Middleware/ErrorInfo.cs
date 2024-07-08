using System.Text.Json;

namespace WeatherService.MiddleWare
{
    /// <summary>
    /// Error detail to be logged
    /// </summary>
    public class ErrorInfo
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public string? Level { get; set; }
        public string? Detail { get; set; }

        /// <summary>
        /// Overriding tostring method to log error in JSON format
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}