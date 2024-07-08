using System;
namespace WeatherDomain.Model
{
	public class Status
	{
		public bool IsSuccess { get; set; }
		public string? ErrorCode { get; set; }
		public string? Message { get; set; }

		public Status (bool isSuccess, string errorCode, string message)
		{
			this.IsSuccess = isSuccess;
			this.ErrorCode = errorCode;
			this.Message = message;
		}
    }
}

