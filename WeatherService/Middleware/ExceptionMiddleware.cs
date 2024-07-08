using System.Net;
using System.Text.Json;
using WeatherService.LoggerService;

namespace WeatherService.MiddleWare
{
    /// <summary>
    /// Global exception handling
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerService _logger;

        public ExceptionMiddleware(RequestDelegate next, ILoggerService logger)
        {
            _next = next;
            _logger = logger;
        }

        /// <summary>
        /// Asynchronous invokation of middleware
        /// </summary>
        /// <param name="httpContext">Http context</param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                ErrorInfo errorInfo = new ErrorInfo
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Message = ex.Message,
                    Level = "Exception",
                    Detail = ex.StackTrace
                };
                var errJson = JsonSerializer.Serialize(errorInfo);
                this._logger.LogError(errJson);
                
            }
        }
    }

    /// <summary>
    /// Extension method used to add the middleware to the HTTP request pipeline.
    /// </summary>
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddlewareClassTemplate(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}

    
