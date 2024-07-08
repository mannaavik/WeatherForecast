
namespace WeatherApplication.AppConstants
{
	public class Constants
	{
        #region error code
		public const string ErrNotFoundCode = "ERR001";
		public const string ErrTechnicalCode = "ERR002";
		public const string ErrBusinessCode01 = "ERR003";
        public const string ErrBusinessCode02 = "ERR004";
        public const string ErrAlreadyExistsCode = "ERR005";
        public const string SuccessCode = "SUCCESS";

        #endregion


        #region error message
        public const string ErrNotFoundMsg = "No data found.";
		public const string ErrTechnicalMsg = "There is some technical issue. Please contact administrator.";
        public const string SuccessMsg = "The request has been executed successfully.";
        public const string ErrBusinessMsg01 = "Sorry...Please provide current or future date.";
        public const string ErrBusinessMsg02 = "Sorry...Please provide temperature between -60 and 60.";
        public const string ErrAlreadyExistsMsg = "Data is already exists for this date and location.";

        #endregion

        #region master data
        public static Dictionary<string, string> ForecastMaster = new Dictionary<string, string> {
            {"-60;-41", "Freezing"},
            {"-40;-21", "Bracing"},
            {"-20;-11", "Chilly"}, 
            {"-10;-1", "Cool"},
            {"0;9","Mild"}, 
            {"10;19", "Warm"}, 
            {"20;29", "Balmy"}, 
            {"30;39", "Hot"}, 
            {"40;49", "Sweltering"} , 
            {"50; 60", "Scorching"}
        };
        #endregion
    }
}

